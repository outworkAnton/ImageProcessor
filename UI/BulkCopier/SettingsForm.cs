using BusinessLogic.Contract.Models;
using Newtonsoft.Json;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BulkCopier
{
    public partial class SettingsForm : Form
    {
        private PrintDocument _document;
        private BulkCopierSettings _settings;

        public SettingsForm(PrintDocument document, BulkCopierSettings settings)
        {
            InitializeComponent();
            _document = document;
            _settings = settings;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ColumnCounter.Value = _settings.PageColumns;
            RowCounter.Value = _settings.PageRows;
            DrawGridLinesChk.Checked = _settings.DrawGridLines;
            printDialog1.Document = _document;
            pageSetupDialog1.Document = _document;
            PrinterLabel.Text = _settings.PrinterName;
            PaperSizeLabel.Text = _settings.PageSize.PaperName;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.PageColumns = (int)ColumnCounter.Value;
            _settings.PageRows = (int)RowCounter.Value;
            _settings.DrawGridLines = DrawGridLinesChk.Checked;
            _settings.PageMargins = _document.DefaultPageSettings.Margins;
            _settings.PageLandscape = _document.DefaultPageSettings.Landscape;
            _settings.PageSize = _document.DefaultPageSettings.PaperSize;
            _settings.PrinterName = _document.DefaultPageSettings.PrinterSettings.PrinterName;
            Properties.Settings.Default.BulkCopierSettings = JsonConvert.SerializeObject(_settings, Formatting.None);
            Properties.Settings.Default.Save();
        }

        private void PageSetupBtn_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
            PaperSizeLabel.Text = _document.DefaultPageSettings.PaperSize.PaperName;
        }

        private void PrinterSetupBtn_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            PrinterLabel.Text = _document.DefaultPageSettings.PrinterSettings.PrinterName;
        }
    }
}
