using System;
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

namespace BulkCopier
{
    public partial class MainForm : Form
    {
        private readonly ICopyFilesService _service;
        private List<ProductImage> _foundImages = new List<ProductImage>();
        private IEnumerator<ProductImage> _foundImagesEnumerator;
        private ObservableCollection<ProductImage> _processedImages = new ObservableCollection<ProductImage>();

        public MainForm(ICopyFilesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _processedImages.CollectionChanged += ProcessedImages_Change;
            InitializeComponent();
        }

        private void ProcessedImages_Change(object sender, NotifyCollectionChangedEventArgs args)
        {
            RecalculateProcessedImagesCollection();
        }

        private void RecalculateProcessedImagesCollection()
        {
            BarcodeCountLabel.Text = _processedImages.Count.ToString();
            ProductCountLabel.Text = _processedImages.Sum(x => x.Count).ToString();
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
                _foundImages = (await _service.FindFiles(InputBarcodeBox.Text))?.ToList() 
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
                _service.SetSourceDirectory(null);
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
                    _service.SetSourceDirectory(sourcePath);
                    SourceBox.Text = sourcePath;
                    FoundFilesCount.Text = (await _service.FindAllFiles()).ToString();
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
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    DestinationBox.Text = folderBrowserDialog1.SelectedPath;
                    await _service.SetDestinationDirectory(DestinationBox.Text);
                    DestinationBox.BackColor = Color.LimeGreen;
                    InputBarcodeBox.Visible = _service.IsSourceDirectorySet();
                    DestinationBox.ReadOnly = true;
                }
                else
                {
                    DestinationBox.ReadOnly = false;
                    DestinationBox.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DestinationBox.ReadOnly = false;
                DestinationBox.BackColor = SystemColors.Control;
            }
        }

        private async void SourceBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    FoundFilesCount.Text = 0.ToString();
                    SourceBox.BackColor = SystemColors.Control;
                    var sourcePath = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.SourcePath = sourcePath;
                    Properties.Settings.Default.Save();
                    SourceBox.Text = sourcePath;
                    _service.SetSourceDirectory(sourcePath);
                    FoundFilesCount.Text = (await _service.FindAllFiles()).ToString();
                    SourceBox.BackColor = Color.LimeGreen;
                    InputBarcodeBox.Visible = _service.IsDestinationDirectorySet();
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
            if (NextPicBtn.Focused || string.IsNullOrWhiteSpace(InputBarcodeBox.Text))
            {
                return;
            }
            await ProcessProductImage();
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
                newFilePath = await _service.CopyFile(_foundImagesEnumerator.Current.Id);
                _processedImages.Insert(0, new ProductImage(_foundImagesEnumerator.Current.Id, newFilePath));
                ProductImagesList.Items.Insert(0, new ListViewItem(new[] { _foundImagesEnumerator.Current.Id, "" }));
            }
            catch (ArgumentException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (FileNotFoundException fnf)
            {
                MessageBox.Show("Не удалось скопировать файл в целевую папку\n" + fnf.Message);
                _processedImages.Remove(_processedImages.FirstOrDefault(img => img.Id == _foundImagesEnumerator.Current.Id));
                ProductImagesList.Items.Find(_foundImagesEnumerator.Current.Id, false).FirstOrDefault().Remove();
            }
            catch (IOException io)
            {
                MessageBox.Show("Ошибка при обработке файла изображения\n" + io.Message);
            }
            catch (Exception ex)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(_foundImagesEnumerator.Current.Id))
                    {
                        if (!_processedImages.Any(img => img.Id == _foundImagesEnumerator.Current.Id) && !string.IsNullOrWhiteSpace(newFilePath))
                        {
                            _processedImages.Insert(0, new ProductImage(_foundImagesEnumerator.Current.Id, newFilePath));
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
                    MessageBox.Show("Неизвестная ошибка в работе приложения\n" + ex.Message);
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

                    if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                    {
                        pressedKey = ((char)e.KeyValue).ToString();
                    }
                    else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                    {
                        pressedKey = ((char)(e.KeyValue - 48)).ToString();
                    }
                    else if (e.KeyCode == Keys.Back)
                    {
                        var currentValue = selectedItemValue.Text;
                        if (currentValue.Length > 0)
                        {
                            selectedItemValue.Text = pressedKey;
                            pressedKey = currentValue.Remove(currentValue.Length - 1, 1);
                        }
                    } else if (e.KeyCode == Keys.Delete)
                    {
                        await _service.DeleteFile(selectedItemKey.Text);
                        _processedImages.Remove(_processedImages.FirstOrDefault(img => img.Id == selectedItemKey.Text));
                        ProductImagesList.Items.Remove(ProductImagesList.Items[ProductImagesList.SelectedIndices[0]]);
                        RecalculateProcessedImagesCollection();
                        return;
                    }
                    else
                    {
                        return;
                    }

                    selectedItemValue.Text += pressedKey;

                    var count = 1;
                    if (int.TryParse(selectedItemValue.Text, out var cnt) && !new[] { 0, 1 }.Contains(cnt))
                    {
                        count = cnt;
                    }

                    _processedImages.First(img => img.Id == selectedItemKey.Text).Count = count;
                    RecalculateProcessedImagesCollection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductImagesList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    var imagePath = _processedImages.First(img => img.Id == e.Item.SubItems[0].Text).Path;
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
                _processedImages.Remove(_processedImages.FirstOrDefault(img => img.Id == e.Item.Text));
                ProductImagesList.Items.Remove(ProductImagesList.Items[ProductImagesList.SelectedIndices[0]]);
                RecalculateProcessedImagesCollection();
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
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetOrder_Click(object sender, EventArgs e)
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
                _processedImages.Clear();
                _service.SetDestinationDirectory(null);
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
            if (!_processedImages.Any(img => img.Id == _foundImagesEnumerator?.Current?.Id))
            {
                await ProcessProductImage();
            }
        }

        private void ProductImagesList_Enter(object sender, EventArgs e)
        {
            try
            {
                if (ProductImagesList.SelectedIndices.Count > 0)
                {
                    var selectedItemKey = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[0];
                    var imagePath = _processedImages.First(img => img.Id == selectedItemKey.Text).Path;
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
                if (!_processedImages.Any(img => img.Id == _foundImagesEnumerator?.Current?.Id))
                {
                    await ProcessProductImage();
                    PictureBox.ImageLocation = _processedImages.First(img => img.Id == _foundImagesEnumerator?.Current?.Id).Path;
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
            if (e.KeyCode == Keys.F2 && folderBrowserDialog1.ShowDialog() == DialogResult.OK 
                && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                GetFileNamesForTest(folderBrowserDialog1.SelectedPath);
            }
        }

        private async void DestinationBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(DestinationBox.Text))
                    {
                        await _service.SetDestinationDirectory(DestinationBox.Text);
                        DestinationBox.BackColor = Color.LimeGreen;
                        InputBarcodeBox.Visible = _service.IsSourceDirectorySet();
                        DestinationBox.ReadOnly = true;
                    }
                    else
                    {
                        DestinationBox.ReadOnly = false;
                        DestinationBox.BackColor = SystemColors.Control;
                    }
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
                listView.Columns[i].Width = iListViewWidth * aiWeights[i] / iTotWeight;
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Properties.Settings.Default.FormWidth = Width;
            Properties.Settings.Default.FormHeight = Height;
            Properties.Settings.Default.FormTopPos = Location.X;
            Properties.Settings.Default.FormLeftPos = Location.Y;
            Properties.Settings.Default.Save();
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox.Cursor = PictureBox.Image != null ? Cursors.Hand : DefaultCursor;
        }
    }
}
