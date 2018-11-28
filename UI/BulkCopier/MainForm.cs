﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using System.Drawing.Printing;

namespace BulkCopier
{
    public partial class MainForm : Form
    {
        private readonly ICopyFilesService _copyFileService;
        private readonly IPrintService _printService;
        private List<ProductImage> _foundImages = new List<ProductImage>();
        private IEnumerator<ProductImage> _foundImagesEnumerator;
        private ObservableCollection<ProductImage> _copiedImages = new ObservableCollection<ProductImage>();
        private readonly IProcessImagesService _processImagesService;

        public MainForm(ICopyFilesService copyFileService, IPrintService printService, IProcessImagesService processImagesService)
        {
            _copyFileService = copyFileService ?? throw new ArgumentNullException(nameof(copyFileService));
            _printService = printService ?? throw new ArgumentNullException(nameof(printService));
            _processImagesService = processImagesService ?? throw new ArgumentNullException(nameof(processImagesService));
            InitializeComponent();
        }

        private async void CopiedImages_Change(object sender, NotifyCollectionChangedEventArgs args)
        {
            try
            {
                await RecalculateCopiedImagesCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task RecalculateCopiedImagesCollection()
        {
            try
            {
                BarcodeCountLabel.Text = _copiedImages.Count.ToString();
                ProductCountLabel.Text = _copiedImages.Sum(x => x.Count).ToString();
                if (_copiedImages.Any())
                {
                    await _copyFileService.SaveProcessedImagesList(_copiedImages);
                }
            }
            catch (IOException io)
            {
                throw new IOException("Не удалось сохранить список файлов\n" + io.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Временный список файлов в памяти приложения поврежден\n" + ex.Message);
            }
        }

        private void InputBarcodeBox_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Clipboard.GetText()))
            {
                MessageBox.Show("Буфер обмена пуст. Скопируйте значение еще раз");
                return;
            }
            InputBarcodeBox.Text = Clipboard.GetText();
        }

        private async void InputBarcodeBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputBarcodeBox.Text))
            {
                InputBarcodeBox.BackColor = SystemColors.Control;
                if (PictureBox.Image != null)
                {
                    PictureBox.Image.Dispose();
                    PictureBox.Image = null;
                    PictureBox.ImageLocation = null;
                }
                BarcodeLabel.Visible = false;
                NextPicBtn.Visible = false;
                return;
            }
            _foundImages.Clear();
            _foundImagesEnumerator = null;
            try
            {
                _foundImages = (await _copyFileService.FindFiles(InputBarcodeBox.Text))?.ToList() 
                    ?? throw new IOException("Источник изображений не найден");

                if (_foundImages.Any())
                {
                    InputBarcodeBox.BackColor = Color.LimeGreen;
                    _foundImagesEnumerator = _foundImages.GetEnumerator();
                    _foundImagesEnumerator.MoveNext();
                    PictureBox.ImageLocation = _foundImagesEnumerator.Current.Path;
                    PictureBox.LoadAsync();
                    BarcodeLabel.Visible = true;
                    BarcodeLabel.Text = _foundImagesEnumerator.Current.Id;

                    if (_foundImages.Count > 1)
                    {
                        NextPicBtn.Visible = true;
                    }
                    else
                    {
                        NextPicBtn.Visible = false;
                    }
                }
                else
                {
                    InputBarcodeBox.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                _copyFileService.SetSourceDirectory(null);
                Properties.Settings.Default.SourcePath = string.Empty;
                Properties.Settings.Default.Save();
                SourceBox.Clear();
                SourceBox.BackColor = SystemColors.Control;
                InputBarcodeBox.Clear();
                if (MessageBox.Show(ex.Message + "\nВыбрать заново где находятся файлы?", "Ошибка при поиске файлов изображений", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SourceBtn.PerformClick();
                }
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Height = Properties.Settings.Default.FormHeight;
                Width = Properties.Settings.Default.FormWidth;
                Location = new Point(Properties.Settings.Default.FormTopPos, Properties.Settings.Default.FormLeftPos);
                AdjustColumnWidths(ProductImagesList);

                var sourcePath = Properties.Settings.Default.SourcePath;
                if (!string.IsNullOrWhiteSpace(sourcePath) && Directory.Exists(sourcePath))
                {
                    _copyFileService.SetSourceDirectory(sourcePath);
                    SourceBox.Text = sourcePath;
                    FoundFilesCount.Text = (await _copyFileService.FindAllFiles()).ToString();
                    SourceBox.BackColor = Color.LimeGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка при доступе к папке с исходными изображениями\n" + ex.Message + "После завершения работы запустите приложение заново");
                Properties.Settings.Default.SourcePath = string.Empty;
                Properties.Settings.Default.Save();
                Application.Exit();
            }
        }

        private async void DestinationBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    DestinationBox.Text = folderBrowserDialog1.SelectedPath;
                    await _copyFileService.SetDestinationDirectory(DestinationBox.Text);
                    DestinationBox.BackColor = Color.LimeGreen;
                    InputBarcodeBox.Visible = _copyFileService.IsSourceDirectorySet();
                    DestinationBox.ReadOnly = true;
                    ProductImagesList.Items.Clear();
                    _copiedImages = await _copyFileService.LoadFromDestinationDirectory();
                    _copiedImages.CollectionChanged += CopiedImages_Change;
                    if (_copiedImages.Any())
                    {
                        ProductImagesList.Items.AddRange(ConvertCopiedToList(_copiedImages));
                        FixProductListCount();
                        await RecalculateCopiedImagesCollection();
                    }
                }
            }
            catch (FileLoadException fl)
            {
                MessageBox.Show("Загрузка списка изображений из сохраненного файла со списком не удалась\n" + fl.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DestinationBox.ReadOnly = false;
                DestinationBox.Clear();
                DestinationBox.BackColor = SystemColors.Control;
            }
        }

        private ListViewItem[] ConvertCopiedToList(ObservableCollection<ProductImage> processedImages)
        {
            try
            {
                var list = new List<ListViewItem>();
                foreach (var item in processedImages)
                {
                    list.Add(new ListViewItem(new[] { item.Id, item.Count.ToString() }));
                }
                return list.ToArray();
            }
            catch (Exception ex)
            {
                throw new FileLoadException(ex.Message);
            }
        }

        private async void SourceBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    FoundFilesCount.Text = 0.ToString();
                    SourceBox.BackColor = SystemColors.Control;
                    var sourcePath = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.SourcePath = sourcePath;
                    Properties.Settings.Default.Save();
                    SourceBox.Text = sourcePath;
                    _copyFileService.SetSourceDirectory(sourcePath);
                    FoundFilesCount.Text = (await _copyFileService.FindAllFiles()).ToString();
                    SourceBox.BackColor = Color.LimeGreen;
                    InputBarcodeBox.Visible = _copyFileService.IsDestinationDirectorySet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                FoundFilesCount.Text = 0.ToString();
                SourceBox.BackColor = SystemColors.Control;
                Properties.Settings.Default.SourcePath = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        private void NextPicBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_foundImagesEnumerator.MoveNext())
                {
                    _foundImagesEnumerator.Reset();
                    _foundImagesEnumerator.MoveNext();
                }

                PictureBox.ImageLocation = _foundImagesEnumerator.Current.Path;
                PictureBox.LoadAsync();
                BarcodeLabel.Text = _foundImagesEnumerator.Current.Id;
                InputBarcodeBox.Focus();
            }
            catch
            {
                PictureBox.Image = null;
                PictureBox.ImageLocation = _foundImagesEnumerator.Current.Path;
                PictureBox.LoadAsync();
                BarcodeLabel.Text = _foundImagesEnumerator.Current.Id;
                InputBarcodeBox.Focus();
            }
        }

        private async void InputBarcodeBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NextPicBtn.Focused || string.IsNullOrWhiteSpace(InputBarcodeBox.Text))
                {
                    return;
                }
                await ProcessProductImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ProcessProductImage()
        {
            var newFilePath = string.Empty;
            try
            {
                if (_foundImagesEnumerator == null || string.IsNullOrWhiteSpace(InputBarcodeBox.Text))
                {
                    return;
                }
                newFilePath = await _copyFileService.CopyFile(_foundImagesEnumerator.Current.Id);
                _copiedImages.Insert(0, new ProductImage(_foundImagesEnumerator.Current.Id, newFilePath));
                ProductImagesList.Items.Insert(0, new ListViewItem(new[] { _foundImagesEnumerator.Current.Id, "" }));
            }
            catch (ArgumentException a)
            {
                throw new ArgumentException(a.Message);
            }
            catch (FileNotFoundException fnf)
            {
                _copiedImages.Remove(_copiedImages.FirstOrDefault(img => img.Id == _foundImagesEnumerator.Current.Id));
                ProductImagesList.Items.Find(_foundImagesEnumerator.Current.Id, false).FirstOrDefault().Remove();
                throw new FileNotFoundException("Не удалось скопировать файл в целевую папку\n" + fnf.Message);
            }
            catch (IOException io)
            {
                throw new IOException("Ошибка при обработке файла изображения\n" + io.Message);
            }
            catch (Exception ex)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(_foundImagesEnumerator.Current.Id))
                    {
                        if (!_copiedImages.Any(img => img.Id == _foundImagesEnumerator.Current.Id) && !string.IsNullOrWhiteSpace(newFilePath))
                        {
                            _copiedImages.Insert(0, new ProductImage(_foundImagesEnumerator.Current.Id, newFilePath));
                        }
                        if (!ProductImagesList.Items.Find(_foundImagesEnumerator.Current.Id, false).Any())
                        {
                            ProductImagesList.Items.Insert(0, new ListViewItem(new[] { _foundImagesEnumerator.Current.Id, "" }));
                        }
                    }
                    else
                    {
                        throw new ApplicationException();
                    }
                }
                catch
                {
                    throw new Exception("Неизвестная ошибка в работе приложения\n" + ex.Message);
                }
                
            }
            finally
            {
                InputBarcodeBox.Clear();
            }
        }

        private async void ProductImagesList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (ProductImagesList.SelectedIndices.Count > 0)
                {
                    var selectedItemKey = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[0];
                    var selectedItemValue = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[1];
                    var pressedKey = string.Empty;

                    switch (e.KeyCode)
                    {
                        case var key when (key >= Keys.D0 && key <= Keys.D9):
                            pressedKey = ((char)e.KeyValue).ToString();
                            break;

                        case var key when (key >= Keys.NumPad0 && key <= Keys.NumPad9):
                            pressedKey = ((char)(e.KeyValue - 48)).ToString();
                            break;

                        case Keys.Back:
                            var currentValue = selectedItemValue.Text;
                            if (currentValue.Length > 0)
                            {
                                selectedItemValue.Text = pressedKey;
                                pressedKey = currentValue.Remove(currentValue.Length - 1, 1);
                            }
                            break;

                        case Keys.Delete:
                            await _copyFileService.DeleteFile(selectedItemKey.Text);
                            _copiedImages.Remove(_copiedImages.FirstOrDefault(img => img.Id == selectedItemKey.Text));
                            ProductImagesList.Items.Remove(ProductImagesList.Items[ProductImagesList.SelectedIndices[0]]);
                            await RecalculateCopiedImagesCollection();
                            return;

                        default:
                            return;
                    }

                    selectedItemValue.Text += pressedKey;

                    var count = 1;
                    if (int.TryParse(selectedItemValue.Text, out var cnt) && !new[] { 0, 1 }.Contains(cnt))
                    {
                        count = cnt;
                    }

                    _copiedImages.First(img => img.Id == selectedItemKey.Text).Count = count;
                    await RecalculateCopiedImagesCollection();
                }
            }
            catch (IOException io)
            {
                MessageBox.Show("Не удалось удалить файл изображения\n" + io.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ProductImagesList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    var imagePath = _copiedImages.First(img => img.Id == e.Item.SubItems[0].Text).Path;
                    if (!File.Exists(imagePath))
                    {
                        throw new FileNotFoundException("Файл изображения не найден");
                    }
                    PictureBox.ImageLocation = imagePath;
                    PictureBox.LoadAsync();
                }
                else
                {
                    if (PictureBox.Image != null)
                    {
                        PictureBox.Image.Dispose();
                        PictureBox.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изображения\n" + ex.Message);
                PictureBox.Image = null;
                PictureBox.ImageLocation = null;
                _copiedImages.Remove(_copiedImages.FirstOrDefault(img => img.Id == e.Item.Text));
                ProductImagesList.Items.Remove(ProductImagesList.Items[ProductImagesList.SelectedIndices[0]]);
                await RecalculateCopiedImagesCollection();
                ProductImagesList.SelectedItems.Clear();
            }
        }

        private void FixProductListCount()
        {
            try
            {
                foreach (ListViewItem item in ProductImagesList.Items)
                {
                    if (new[] { "1", "0" }.Contains(item.SubItems[1].Text))
                    {
                        item.SubItems[1].Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ResetToNewOrder()
        {
            try
            {
                _foundImages.Clear();
                _foundImagesEnumerator = null;
                DestinationBox.ReadOnly = false;
                DestinationBox.Clear();
                DestinationBox.BackColor = SystemColors.Control;
                InputBarcodeBox.Visible = false;
                if (PictureBox.Image != null)
                {
                    PictureBox.Image.Dispose();
                    PictureBox.Image = null;
                }
                BarcodeLabel.Visible = false;
                NextPicBtn.Visible = false;
                ProductImagesList.Items.Clear();
                BarcodeCountLabel.Text = "0";
                ProductCountLabel.Text = "0";
                _copiedImages.Clear();
                _copyFileService.SetDestinationDirectory(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (InputBarcodeBox.Visible)
            {
                InputBarcodeBox.Focus();
            }
        }

        private void ProductImagesList_Leave(object sender, EventArgs e)
        {
            try
            {
                if (PictureBox.Focused)
                {
                    return;
                }

                ProductImagesList.SelectedItems.Clear();
                if (PictureBox.Image != null)
                {
                    PictureBox.Image.Dispose();
                    PictureBox.Image = null;
                }

                FixProductListCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MainForm_Deactivate(object sender, EventArgs e)
        {
            try
            {
                if (_foundImagesEnumerator != null)
                {
                    await ProcessProductImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductImagesList_Enter(object sender, EventArgs e)
        {
            try
            {
                if (ProductImagesList.SelectedIndices.Count > 0)
                {
                    var selectedItemKey = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[0];
                    var imagePath = _copiedImages.First(img => img.Id == selectedItemKey.Text).Path;
                    PictureBox.LoadAsync(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (PictureBox.Image == null)
                {
                    return;
                }
                if (ProductImagesList.SelectedIndices.Count > 0)
                {
                    var selectedItemValue = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[1];
                    if (!string.IsNullOrWhiteSpace(selectedItemValue.Text))
                    {
                        Clipboard.SetText(selectedItemValue.Text);
                    }
                }
                if (_foundImagesEnumerator != null)
                {
                    await ProcessProductImage();
                    PictureBox.ImageLocation = _copiedImages.First(img => img.Id == _foundImagesEnumerator?.Current?.Id).Path;
                }
                var filePath = PictureBox.ImageLocation;
                ProcessStartInfo Info = new ProcessStartInfo()
                {
                    FileName = "mspaint.exe",
                    WindowStyle = ProcessWindowStyle.Maximized,
                    Arguments = filePath
                };
                Process.Start(Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                PictureBox.ImageLocation = null;
                PictureBox.Image = null;
            }
        }

        private static void GetFileNamesForTest(string path)
        {
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FileList.txt");

            using (StreamWriter stream = new StreamWriter(filename))
            {
                foreach (string file in Directory.GetFiles(path, "*.jpg"))
                {
                    stream.WriteLine(Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2 when folderBrowserDialog1.ShowDialog() == DialogResult.OK:
                    GetFileNamesForTest(folderBrowserDialog1.SelectedPath);
                    break;
                case Keys.F1:
                    MessageBox.Show(Application.ProductVersion, "Версия приложения");
                    break;
            }
        }

        private async void DestinationBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!string.IsNullOrWhiteSpace(DestinationBox.Text) && !DestinationBox.ReadOnly)
                        {
                            await _copyFileService.SetDestinationDirectory(DestinationBox.Text);
                            DestinationBox.BackColor = Color.LimeGreen;
                            InputBarcodeBox.Visible = _copyFileService.IsSourceDirectorySet();
                            DestinationBox.ReadOnly = true;
                        }
                        break;

                    case Keys.Delete:
                        DestinationBox.Clear();
                        DestinationBox.ReadOnly = false;
                        DestinationBox.BackColor = SystemColors.Control;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductImagesList_Resize(object sender, EventArgs e)
        {
            AdjustColumnWidths(ProductImagesList);
        }

        private void AdjustColumnWidths(ListView listView)
        {
            int iListViewWidth = listView.ClientSize.Width;
            var aiWeights = new int[] { 60, 40 };
            int iTotWeight = 0;

            foreach (int n in aiWeights)
            {
                iTotWeight += n;
            }

            for (int i = 0; i < aiWeights.Length; i++)
            {
                listView.Columns[i].Width = (iListViewWidth * aiWeights[i] / iTotWeight) - 1;
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Properties.Settings.Default.FormWidth = Width;
            Properties.Settings.Default.FormHeight = Height;
            Properties.Settings.Default.Save();
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox.Cursor = PictureBox.Image != null ? Cursors.Hand : DefaultCursor;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormTopPos = Location.X;
            Properties.Settings.Default.FormLeftPos = Location.Y;
            Properties.Settings.Default.Save();
        }

        private void ResetOrder_Click_1(object sender, EventArgs e)
        {
            ResetToNewOrder();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var page = _printService.GetPage();
            e.Graphics.DrawImage(page, e.PageSettings.PrintableArea);
            e.HasMorePages = _printService.HasNextPage();
        }

        private async void Print_ButtonClick(object sender, EventArgs e)
        {
            await ProcessImages();
            if (_copiedImages.Any())
            {
                printPreviewDialog1.Document = printDocument1;
                ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
                printPreviewDialog1.ShowDialog();
            }
        }

        private async Task ProcessImages()
        {
            var imagesToProcess = _copiedImages.Where(img => (img.Count > 1) && !img.Processed);
            if (imagesToProcess.Any())
            {
                _processImagesService.Process(imagesToProcess.ToArray());
                foreach (var productImage in imagesToProcess)
                {
                    productImage.Processed = true;
                }
                await RecalculateCopiedImagesCollection();
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            printDocument1.DocumentName = new DirectoryInfo(_copyFileService.GetDestinationDirectoryPath()).Name;
            printDocument1.DefaultPageSettings = new PageSettings()
            {
                Color = true,
                Landscape = false,
                Margins = new Margins(1, 1, 1, 1)
            };
            _printService.SetPrintSettings(printDocument1, 
                _copiedImages.ToArray(), 
                Properties.Settings.Default.PrintColumns, 
                Properties.Settings.Default.PrintRows);
        }

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            _printService.ResetPrintSettings();
        }
    }
}
