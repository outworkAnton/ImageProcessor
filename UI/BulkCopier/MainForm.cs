using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
                }
                BarcodeLabel.Text = "Артикул";
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
                    PictureBox.LoadAsync(_foundImagesEnumerator.Current.Path);
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
            var sourcePath = Properties.Settings.Default.SourcePath;
            if (!string.IsNullOrWhiteSpace(sourcePath) && Directory.Exists(sourcePath))
            {
                _service.SetSourceDirectory(sourcePath);
                SourceBox.Text = sourcePath;
                FoundFilesCount.Text = (await _service.FindAllFiles()).ToString();
                SourceBox.BackColor = Color.LimeGreen;
            }
        }

        private async void DestinationBox_Leave(object sender, EventArgs e)
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

        private async void DestinationBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;
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

        private async void SourceBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
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

        private void NextPicBtn_Click(object sender, EventArgs e)
        {
            if (!_foundImagesEnumerator.MoveNext())
            {
                _foundImagesEnumerator.Reset();
                _foundImagesEnumerator.MoveNext();
            }

            if (PictureBox.Image != null)
            {
                PictureBox.Image.Dispose();
                PictureBox.Image = null;
            }

            PictureBox.LoadAsync(_foundImagesEnumerator.Current.Path);
            BarcodeLabel.Text = _foundImagesEnumerator.Current.Id;
            InputBarcodeBox.Focus();
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
            try
            {
                if (_foundImagesEnumerator == null || string.IsNullOrWhiteSpace(InputBarcodeBox.Text))
                {
                    return;
                }
                var newFilePath = await _service.CopyFile(_foundImagesEnumerator.Current.Id);
                _processedImages.Insert(0, new ProductImage(_foundImagesEnumerator.Current.Id, newFilePath, 1, true));
                ProductImagesList.Items.Insert(0, new ListViewItem(new[] { _foundImagesEnumerator.Current.Id, "" }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InputBarcodeBox.Clear();
        }

        private void ProductImagesList_KeyDown(object sender, KeyEventArgs e)
        {
            var selectedItemValue = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[1];
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                selectedItemValue.Text += ((char)e.KeyValue).ToString();
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                selectedItemValue.Text += ((char)(e.KeyValue - 48)).ToString();
            }
            else if (e.KeyCode == Keys.Back)
            {
                var currentValue = selectedItemValue.Text;
                if (currentValue.Length > 0 && !new[] { "0", "1" }.Contains(currentValue))
                {
                    selectedItemValue.Text = currentValue.Remove(currentValue.Length - 1, 1);
                }
                else
                {
                    selectedItemValue.Text = string.Empty;
                }
            }
            else 
            {
                return;
            }

            var count = 1;
            if (int.TryParse(selectedItemValue.Text, out var cnt))
            {
                if (!new[] { 0, 1 }.Contains(cnt))
                {
                    count = cnt;
                }
            }
            var selectedItemKey = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[0];
            _processedImages.Where(img => img.Id == selectedItemKey.Text).First().Count = count;
            RecalculateProcessedImagesCollection();
        }

        private void ProductImagesList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var imagePath =_processedImages.Where(img => img.Id == e.Item.SubItems[0].Text).First().Path;
            PictureBox.LoadAsync(imagePath);
        }

        private void ResetOrder_Click(object sender, EventArgs e)
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

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (InputBarcodeBox.Visible)
            {
                InputBarcodeBox.Focus();
            } 
        }

        private void ProductImagesList_Leave(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                PictureBox.Image.Dispose();
                PictureBox.Image = null;
            }
        }

        private async void MainForm_Deactivate(object sender, EventArgs e)
        {
            await ProcessProductImage();
        }

        private void ProductImagesList_Enter(object sender, EventArgs e)
        {
            if (ProductImagesList.SelectedIndices.Count > 0)
            {
                var selectedItemKey = ProductImagesList.Items[ProductImagesList.SelectedIndices[0]].SubItems[0];
                var imagePath = _processedImages.Where(img => img.Id == selectedItemKey.Text).First().Path;
                PictureBox.LoadAsync(imagePath); 
            }
        }
    }
}
