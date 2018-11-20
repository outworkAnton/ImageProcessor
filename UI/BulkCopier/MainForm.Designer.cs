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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.InputBarcodeBox = new System.Windows.Forms.TextBox();
            this.NextPicBtn = new System.Windows.Forms.Button();
            this.ProductImagesList = new System.Windows.Forms.ListView();
            this.Barcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestinationBox = new System.Windows.Forms.TextBox();
            this.DestinationBtn = new System.Windows.Forms.Button();
            this.SourceBox = new System.Windows.Forms.TextBox();
            this.SourceBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BarcodeCountLabel = new System.Windows.Forms.Label();
            this.ProductCountLabel = new System.Windows.Forms.Label();
            this.BarcodeLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.FoundFilesCount = new System.Windows.Forms.Label();
            this.ResetOrder = new System.Windows.Forms.Button();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.LeftTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RightTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.MainTable.SuspendLayout();
            this.LeftTable.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.RightTable.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(3, 106);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(331, 260);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            this.PictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
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
            // NextPicBtn
            // 
            this.NextPicBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NextPicBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NextPicBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPicBtn.Location = new System.Drawing.Point(196, 3);
            this.NextPicBtn.Name = "NextPicBtn";
            this.NextPicBtn.Size = new System.Drawing.Size(132, 55);
            this.NextPicBtn.TabIndex = 2;
            this.NextPicBtn.Text = ">>>";
            this.NextPicBtn.UseVisualStyleBackColor = true;
            this.NextPicBtn.Visible = false;
            this.NextPicBtn.Click += new System.EventHandler(this.NextPicBtn_Click);
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
            this.ProductImagesList.Size = new System.Drawing.Size(229, 416);
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
            this.Barcode.Width = 250;
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
            this.DestinationBox.Size = new System.Drawing.Size(173, 20);
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.MinimumSize = new System.Drawing.Size(60, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 11);
            this.label1.TabIndex = 6;
            this.label1.Text = "Артикулов:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BarcodeCountLabel
            // 
            this.BarcodeCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BarcodeCountLabel.AutoSize = true;
            this.BarcodeCountLabel.Location = new System.Drawing.Point(73, 7);
            this.BarcodeCountLabel.Name = "BarcodeCountLabel";
            this.BarcodeCountLabel.Size = new System.Drawing.Size(13, 13);
            this.BarcodeCountLabel.TabIndex = 6;
            this.BarcodeCountLabel.Text = "0";
            // 
            // ProductCountLabel
            // 
            this.ProductCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCountLabel.AutoSize = true;
            this.ProductCountLabel.Location = new System.Drawing.Point(182, 7);
            this.ProductCountLabel.Name = "ProductCountLabel";
            this.ProductCountLabel.Size = new System.Drawing.Size(13, 13);
            this.ProductCountLabel.TabIndex = 6;
            this.ProductCountLabel.Text = "0";
            // 
            // BarcodeLabel
            // 
            this.BarcodeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BarcodeLabel.AutoSize = true;
            this.BarcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeLabel.Location = new System.Drawing.Point(43, 20);
            this.BarcodeLabel.Name = "BarcodeLabel";
            this.BarcodeLabel.Size = new System.Drawing.Size(79, 20);
            this.BarcodeLabel.TabIndex = 7;
            this.BarcodeLabel.Text = "Артикул";
            this.BarcodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BarcodeLabel.Visible = false;
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
            // ResetOrder
            // 
            this.ResetOrder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ResetOrder.Location = new System.Drawing.Point(244, 3);
            this.ResetOrder.Name = "ResetOrder";
            this.ResetOrder.Size = new System.Drawing.Size(84, 21);
            this.ResetOrder.TabIndex = 10;
            this.ResetOrder.Text = "Новый заказ";
            this.ResetOrder.UseVisualStyleBackColor = true;
            this.ResetOrder.Click += new System.EventHandler(this.ResetOrder_Click);
            // 
            // MainTable
            // 
            this.MainTable.ColumnCount = 2;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.31668F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.68332F));
            this.MainTable.Controls.Add(this.LeftTable, 0, 0);
            this.MainTable.Controls.Add(this.RightTable, 1, 0);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 1;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.Size = new System.Drawing.Size(584, 461);
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
            this.LeftTable.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.LeftTable.Location = new System.Drawing.Point(3, 3);
            this.LeftTable.Name = "LeftTable";
            this.LeftTable.RowCount = 2;
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.LeftTable.Size = new System.Drawing.Size(235, 455);
            this.LeftTable.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ProductCountLabel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.BarcodeCountLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 425);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(229, 27);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // RightTable
            // 
            this.RightTable.ColumnCount = 1;
            this.RightTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTable.Controls.Add(this.InputBarcodeBox, 0, 0);
            this.RightTable.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.RightTable.Controls.Add(this.PictureBox, 0, 2);
            this.RightTable.Controls.Add(this.tableLayoutPanel6, 0, 3);
            this.RightTable.Controls.Add(this.tableLayoutPanel7, 0, 4);
            this.RightTable.Controls.Add(this.tableLayoutPanel8, 0, 5);
            this.RightTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTable.Location = new System.Drawing.Point(244, 3);
            this.RightTable.Name = "RightTable";
            this.RightTable.RowCount = 6;
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.RightTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.RightTable.Size = new System.Drawing.Size(337, 455);
            this.RightTable.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.BarcodeLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.NextPicBtn, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel5.MinimumSize = new System.Drawing.Size(0, 55);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(331, 61);
            this.tableLayoutPanel5.TabIndex = 1;
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
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 373);
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
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 392);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(331, 27);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel8.Controls.Add(this.DestinationBtn, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.ResetOrder, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.DestinationBox, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 425);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(331, 27);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Товаров:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.MainTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BulkCopier";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.MainTable.ResumeLayout(false);
            this.LeftTable.ResumeLayout(false);
            this.LeftTable.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.RightTable.ResumeLayout(false);
            this.RightTable.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BarcodeCountLabel;
        private System.Windows.Forms.Label ProductCountLabel;
        private System.Windows.Forms.Label BarcodeLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FoundFilesCount;
        private System.Windows.Forms.Button ResetOrder;
        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.TableLayoutPanel LeftTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel RightTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label3;
    }
}

