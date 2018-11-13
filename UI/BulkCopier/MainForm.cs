using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;

namespace BulkCopier
{
    public partial class MainForm : Form
    {
        private readonly ICopyFilesService _service;
        private IReadOnlyCollection<ProductImage> _foundImages;
        private ProductImage _currentImage;

        public MainForm(ICopyFilesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
        }

        private void InputBarcodeBox_DoubleClick(object sender, EventArgs e)
        {
            InputBarcodeBox.Text = Clipboard.GetText();
        }

        private async void InputBarcodeBox_TextChanged(object sender, EventArgs e)
        {
            InputBarcodeBox.BackColor = SystemColors.Control;
            _foundImages = await _service.FindFiles(InputBarcodeBox.Text).ConfigureAwait(false);
            _currentImage = _foundImages.First();
            if (_currentImage != null)
            {
                PictureBox.LoadAsync(_currentImage.Path);

                if (_foundImages.Count > 1)
                {
                    PrevPicBtn.Visible = true;
                    NextPicBtn.Visible = true;
                }
                else
                {
                    PrevPicBtn.Visible = false;
                    NextPicBtn.Visible = false;
                }
            }
            else
            {
                InputBarcodeBox.BackColor = Color.Red;
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
                await _service.SetDestinationDirectory(DestinationBox.Text).ConfigureAwait(false);
            }
        }

        private async void DestinationBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                DestinationBox.Text = folderBrowserDialog1.SelectedPath;
                await _service.SetDestinationDirectory(DestinationBox.Text).ConfigureAwait(false);
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
            }
        }
    }
}
