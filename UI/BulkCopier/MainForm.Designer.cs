namespace BulkCopier
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InputBarcodeBox = new System.Windows.Forms.TextBox();
            this.ProductImagesList = new System.Windows.Forms.ListView();
            this.Barcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestinationBox = new System.Windows.Forms.TextBox();
            this.DestinationBtn = new System.Windows.Forms.Button();
            this.SourceBox = new System.Windows.Forms.TextBox();
            this.SourceBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.FoundFilesCount = new System.Windows.Forms.Label();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.LeftTable = new System.Windows.Forms.TableLayoutPanel();
            this.RightTable = new System.Windows.Forms.TableLayoutPanel();
            this.NextBtnPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NextPicBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BarcodeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarcodeCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProductCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ResetOrder = new System.Windows.Forms.ToolStripSplitButton();
            this.Print = new System.Windows.Forms.ToolStripSplitButton();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchModePanel = new System.Windows.Forms.TableLayoutPanel();
            this.StartsWithRadio = new System.Windows.Forms.RadioButton();
            this.ContainsRadio = new System.Windows.Forms.RadioButton();
            this.MainTable.SuspendLayout();
            this.LeftTable.SuspendLayout();
            this.RightTable.SuspendLayout();
            this.NextBtnPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SearchModePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputBarcodeBox
            // 
            this.InputBarcodeBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InputBarcodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBarcodeBox.Location = new System.Drawing.Point(3, 3);
            this.InputBarcodeBox.MinimumSize = new System.Drawing.Size(25, 30);
            this.InputBarcodeBox.Name = "InputBarcodeBox";
            this.InputBarcodeBox.Size = new System.Drawing.Size(331, 30);
            this.InputBarcodeBox.TabIndex = 0;
            this.InputBarcodeBox.Visible = false;
            this.InputBarcodeBox.WordWrap = false;
            this.InputBarcodeBox.TextChanged += new System.EventHandler(this.InputBarcodeBox_TextChanged);
            this.InputBarcodeBox.DoubleClick += new System.EventHandler(this.InputBarcodeBox_DoubleClick);
            this.InputBarcodeBox.Leave += new System.EventHandler(this.InputBarcodeBox_Leave);
            // 
            // ProductImagesList
            // 
            this.ProductImagesList.AutoArrange = false;
            this.ProductImagesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Barcode,
            this.Count});
            this.ProductImagesList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductImagesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductImagesList.FullRowSelect = true;
            this.ProductImagesList.GridLines = true;
            this.ProductImagesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProductImagesList.Location = new System.Drawing.Point(3, 3);
            this.ProductImagesList.MinimumSize = new System.Drawing.Size(145, 75);
            this.ProductImagesList.MultiSelect = false;
            this.ProductImagesList.Name = "ProductImagesList";
            this.ProductImagesList.ShowGroups = false;
            this.ProductImagesList.ShowItemToolTips = true;
            this.ProductImagesList.Size = new System.Drawing.Size(229, 457);
            this.ProductImagesList.TabIndex = 3;
            this.ProductImagesList.UseCompatibleStateImageBehavior = false;
            this.ProductImagesList.View = System.Windows.Forms.View.Details;
            this.ProductImagesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ProductImagesList_ItemSelectionChanged);
            this.ProductImagesList.Enter += new System.EventHandler(this.ProductImagesList_Enter);
            this.ProductImagesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductImagesList_KeyDown);
            this.ProductImagesList.Leave += new System.EventHandler(this.ProductImagesList_Leave);
            this.ProductImagesList.Resize += new System.EventHandler(this.ProductImagesList_Resize);
            // 
            // Barcode
            // 
            this.Barcode.Text = "Артикул";
            this.Barcode.Width = 129;
            // 
            // Count
            // 
            this.Count.Text = "Количество";
            this.Count.Width = 95;
            // 
            // DestinationBox
            // 
            this.DestinationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationBox.Location = new System.Drawing.Point(65, 3);
            this.DestinationBox.Name = "DestinationBox";
            this.DestinationBox.Size = new System.Drawing.Size(263, 20);
            this.DestinationBox.TabIndex = 4;
            this.DestinationBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DestinationBox_KeyDown);
            // 
            // DestinationBtn
            // 
            this.DestinationBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DestinationBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DestinationBtn.Location = new System.Drawing.Point(3, 3);
            this.DestinationBtn.Name = "DestinationBtn";
            this.DestinationBtn.Size = new System.Drawing.Size(56, 21);
            this.DestinationBtn.TabIndex = 5;
            this.DestinationBtn.Text = "Куда";
            this.DestinationBtn.UseVisualStyleBackColor = true;
            this.DestinationBtn.Click += new System.EventHandler(this.DestinationBtn_Click);
            // 
            // SourceBox
            // 
            this.SourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceBox.Location = new System.Drawing.Point(65, 3);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.ReadOnly = true;
            this.SourceBox.Size = new System.Drawing.Size(263, 20);
            this.SourceBox.TabIndex = 4;
            // 
            // SourceBtn
            // 
            this.SourceBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SourceBtn.Location = new System.Drawing.Point(3, 3);
            this.SourceBtn.Name = "SourceBtn";
            this.SourceBtn.Size = new System.Drawing.Size(56, 21);
            this.SourceBtn.TabIndex = 5;
            this.SourceBtn.Text = "Откуда";
            this.SourceBtn.UseVisualStyleBackColor = true;
            this.SourceBtn.Click += new System.EventHandler(this.SourceBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Найдено файлов:";
            // 
            // FoundFilesCount
            // 
            this.FoundFilesCount.AutoSize = true;
            this.FoundFilesCount.Location = new System.Drawing.Point(113, 0);
            this.FoundFilesCount.Name = "FoundFilesCount";
            this.FoundFilesCount.Size = new System.Drawing.Size(13, 13);
            this.FoundFilesCount.TabIndex = 9;
            this.FoundFilesCount.Text = "0";
            // 
            // MainTable
            // 
            this.MainTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTable.ColumnCount = 2;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.31668F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.68332F));
            this.MainTable.Controls.Add(this.LeftTable, 0, 0);
            this.MainTable.Controls.Add(this.RightTable, 1, 0);
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 1;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.Size = new System.Drawing.Size(584, 469);
            this.MainTable.TabIndex = 11;
            // 
            // LeftTable
            // 
            this.LeftTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftTable.ColumnCount = 1;
            this.LeftTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftTable.Controls.Add(this.ProductImagesList, 0, 0);
            this.LeftTable.Location = new System.Drawing.Point(3, 3);
            this.LeftTable.Name = "LeftTable";
            this.LeftTable.RowCount = 1;
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 430F));
            this.LeftTable.Size = new System.Drawing.Size(235, 463);
            this.LeftTable.TabIndex = 0;
            // 
            // RightTable
            // 
            this.RightTable.ColumnCount = 1;
            this.RightTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTable.Controls.Add(this.SearchModePanel, 0, 1);
            this.RightTable.Controls.Add(this.InputBarcodeBox, 0, 0);
            this.RightTable.Controls.Add(this.NextBtnPanel, 0, 2);
            this.RightTable.Controls.Add(this.PictureBox, 0, 3);
            this.RightTable.Controls.Add(this.tableLayoutPanel6, 0, 4);
            this.RightTable.Controls.Add(this.tableLayoutPanel7, 0, 5);
            this.RightTable.Controls.Add(this.tableLayoutPanel8, 0, 6);
            this.RightTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTable.Location = new System.Drawing.Point(244, 3);
            this.RightTable.Name = "RightTable";
            this.RightTable.RowCount = 7;
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.RightTable.Size = new System.Drawing.Size(337, 463);
            this.RightTable.TabIndex = 1;
            // 
            // NextBtnPanel
            // 
            this.NextBtnPanel.AutoSize = true;
            this.NextBtnPanel.ColumnCount = 2;
            this.NextBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NextBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.NextBtnPanel.Controls.Add(this.NextPicBtn, 1, 0);
            this.NextBtnPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.NextBtnPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NextBtnPanel.Location = new System.Drawing.Point(3, 68);
            this.NextBtnPanel.MinimumSize = new System.Drawing.Size(0, 55);
            this.NextBtnPanel.Name = "NextBtnPanel";
            this.NextBtnPanel.RowCount = 1;
            this.NextBtnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NextBtnPanel.Size = new System.Drawing.Size(331, 61);
            this.NextBtnPanel.TabIndex = 1;
            this.NextBtnPanel.Visible = false;
            // 
            // NextPicBtn
            // 
            this.NextPicBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NextPicBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NextPicBtn.BackgroundImage = global::BulkCopier.Properties.Resources.Next;
            this.NextPicBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NextPicBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.NextPicBtn.FlatAppearance.BorderSize = 0;
            this.NextPicBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.NextPicBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.NextPicBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPicBtn.Location = new System.Drawing.Point(199, 3);
            this.NextPicBtn.Name = "NextPicBtn";
            this.NextPicBtn.Size = new System.Drawing.Size(129, 55);
            this.NextPicBtn.TabIndex = 2;
            this.NextPicBtn.UseVisualStyleBackColor = false;
            this.NextPicBtn.Click += new System.EventHandler(this.NextPicBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BarcodeLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 55);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // BarcodeLabel
            // 
            this.BarcodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BarcodeLabel.AutoSize = true;
            this.BarcodeLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BarcodeLabel.Location = new System.Drawing.Point(65, 18);
            this.BarcodeLabel.Name = "BarcodeLabel";
            this.BarcodeLabel.Size = new System.Drawing.Size(60, 18);
            this.BarcodeLabel.TabIndex = 8;
            this.BarcodeLabel.Text = "Артикул";
            this.BarcodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Артикул:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBox
            // 
            this.PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(3, 136);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(331, 238);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            this.PictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.FoundFilesCount, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 381);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(331, 13);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.SourceBtn, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.SourceBox, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 400);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(331, 27);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.DestinationBtn, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.DestinationBox, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 433);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(331, 27);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.BarcodeCountLabel,
            this.toolStripStatusLabel3,
            this.ProductCountLabel,
            this.ResetOrder,
            this.Print});
            this.StatusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.StatusBar.Location = new System.Drawing.Point(0, 472);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(590, 22);
            this.StatusBar.TabIndex = 12;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Артикулов:";
            // 
            // BarcodeCountLabel
            // 
            this.BarcodeCountLabel.Name = "BarcodeCountLabel";
            this.BarcodeCountLabel.Size = new System.Drawing.Size(13, 17);
            this.BarcodeCountLabel.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel3.Text = "Товаров:";
            // 
            // ProductCountLabel
            // 
            this.ProductCountLabel.Name = "ProductCountLabel";
            this.ProductCountLabel.Size = new System.Drawing.Size(13, 17);
            this.ProductCountLabel.Text = "0";
            // 
            // ResetOrder
            // 
            this.ResetOrder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ResetOrder.Image = global::BulkCopier.Properties.Resources.New;
            this.ResetOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetOrder.Name = "ResetOrder";
            this.ResetOrder.Size = new System.Drawing.Size(108, 20);
            this.ResetOrder.Text = "Новый заказ";
            this.ResetOrder.ToolTipText = "Начать формировать новый заказ";
            this.ResetOrder.Click += new System.EventHandler(this.ResetOrder_Click_1);
            // 
            // Print
            // 
            this.Print.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Print.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem});
            this.Print.Image = global::BulkCopier.Properties.Resources.Print;
            this.Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(78, 20);
            this.Print.Text = "Печать";
            this.Print.ButtonClick += new System.EventHandler(this.Print_ButtonClick);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Image = global::BulkCopier.Properties.Resources.Settings;
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(133, 22);
            this.SettingsMenuItem.Text = "Настройка";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // SearchModePanel
            // 
            this.SearchModePanel.ColumnCount = 2;
            this.SearchModePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchModePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchModePanel.Controls.Add(this.StartsWithRadio, 0, 0);
            this.SearchModePanel.Controls.Add(this.ContainsRadio, 1, 0);
            this.SearchModePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchModePanel.Location = new System.Drawing.Point(3, 38);
            this.SearchModePanel.Name = "SearchModePanel";
            this.SearchModePanel.RowCount = 1;
            this.SearchModePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchModePanel.Size = new System.Drawing.Size(331, 24);
            this.SearchModePanel.TabIndex = 6;
            this.SearchModePanel.Visible = false;
            // 
            // StartsWithRadio
            // 
            this.StartsWithRadio.AutoSize = true;
            this.StartsWithRadio.Checked = true;
            this.StartsWithRadio.Location = new System.Drawing.Point(3, 3);
            this.StartsWithRadio.Name = "StartsWithRadio";
            this.StartsWithRadio.Size = new System.Drawing.Size(103, 17);
            this.StartsWithRadio.TabIndex = 0;
            this.StartsWithRadio.TabStop = true;
            this.StartsWithRadio.Text = "Начинается с...";
            this.StartsWithRadio.UseVisualStyleBackColor = true;
            this.StartsWithRadio.CheckedChanged += new System.EventHandler(this.StartsWithRadio_CheckedChanged);
            // 
            // ContainsRadio
            // 
            this.ContainsRadio.AutoSize = true;
            this.ContainsRadio.Location = new System.Drawing.Point(168, 3);
            this.ContainsRadio.Name = "ContainsRadio";
            this.ContainsRadio.Size = new System.Drawing.Size(84, 17);
            this.ContainsRadio.TabIndex = 1;
            this.ContainsRadio.Text = "Содержит...";
            this.ContainsRadio.UseVisualStyleBackColor = true;
            this.ContainsRadio.CheckedChanged += new System.EventHandler(this.ContainsRadio_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 494);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BulkCopier";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MainTable.ResumeLayout(false);
            this.LeftTable.ResumeLayout(false);
            this.RightTable.ResumeLayout(false);
            this.RightTable.PerformLayout();
            this.NextBtnPanel.ResumeLayout(false);
            this.NextBtnPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.SearchModePanel.ResumeLayout(false);
            this.SearchModePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBox;
        public System.Windows.Forms.TextBox InputBarcodeBox;
        private System.Windows.Forms.Button NextPicBtn;
        public System.Windows.Forms.ListView ProductImagesList;
        private System.Windows.Forms.ColumnHeader Barcode;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.TextBox DestinationBox;
        private System.Windows.Forms.Button DestinationBtn;
        private System.Windows.Forms.TextBox SourceBox;
        private System.Windows.Forms.Button SourceBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FoundFilesCount;
        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.TableLayoutPanel LeftTable;
        private System.Windows.Forms.TableLayoutPanel RightTable;
        private System.Windows.Forms.TableLayoutPanel NextBtnPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel BarcodeCountLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel ProductCountLabel;
        private System.Windows.Forms.ToolStripSplitButton ResetOrder;
        private System.Windows.Forms.ToolStripSplitButton Print;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label BarcodeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel SearchModePanel;
        private System.Windows.Forms.RadioButton StartsWithRadio;
        private System.Windows.Forms.RadioButton ContainsRadio;
    }
}

