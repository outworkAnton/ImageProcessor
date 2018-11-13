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
            this.label3 = new System.Windows.Forms.Label();
            this.ProductCountLabel = new System.Windows.Forms.Label();
            this.BarcodeLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.FoundFilesCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(368, 109);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(501, 519);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            // 
            // InputBarcodeBox
            // 
            this.InputBarcodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBarcodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBarcodeBox.Location = new System.Drawing.Point(368, 12);
            this.InputBarcodeBox.MinimumSize = new System.Drawing.Size(4, 30);
            this.InputBarcodeBox.Name = "InputBarcodeBox";
            this.InputBarcodeBox.Size = new System.Drawing.Size(502, 26);
            this.InputBarcodeBox.TabIndex = 0;
            this.InputBarcodeBox.WordWrap = false;
            this.InputBarcodeBox.TextChanged += new System.EventHandler(this.InputBarcodeBox_TextChanged);
            this.InputBarcodeBox.DoubleClick += new System.EventHandler(this.InputBarcodeBox_DoubleClick);
            this.InputBarcodeBox.Leave += new System.EventHandler(this.InputBarcodeBox_Leave);
            // 
            // NextPicBtn
            // 
            this.NextPicBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NextPicBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPicBtn.Location = new System.Drawing.Point(738, 48);
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
            this.ProductImagesList.FullRowSelect = true;
            this.ProductImagesList.GridLines = true;
            this.ProductImagesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProductImagesList.LabelEdit = true;
            this.ProductImagesList.Location = new System.Drawing.Point(12, 12);
            this.ProductImagesList.MultiSelect = false;
            this.ProductImagesList.Name = "ProductImagesList";
            this.ProductImagesList.ShowItemToolTips = true;
            this.ProductImagesList.Size = new System.Drawing.Size(350, 662);
            this.ProductImagesList.TabIndex = 3;
            this.ProductImagesList.UseCompatibleStateImageBehavior = false;
            this.ProductImagesList.View = System.Windows.Forms.View.Details;
            this.ProductImagesList.DoubleClick += new System.EventHandler(this.ProductImagesList_DoubleClick);
            this.ProductImagesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductImagesList_KeyDown);
            this.ProductImagesList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProductImagesList_KeyPress);
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
            this.DestinationBox.Location = new System.Drawing.Point(456, 680);
            this.DestinationBox.Name = "DestinationBox";
            this.DestinationBox.Size = new System.Drawing.Size(413, 20);
            this.DestinationBox.TabIndex = 4;
            this.DestinationBox.Leave += new System.EventHandler(this.DestinationBox_Leave);
            // 
            // DestinationBtn
            // 
            this.DestinationBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DestinationBtn.Location = new System.Drawing.Point(367, 678);
            this.DestinationBtn.Name = "DestinationBtn";
            this.DestinationBtn.Size = new System.Drawing.Size(75, 23);
            this.DestinationBtn.TabIndex = 5;
            this.DestinationBtn.Text = "Куда";
            this.DestinationBtn.UseVisualStyleBackColor = true;
            this.DestinationBtn.Click += new System.EventHandler(this.DestinationBtn_Click);
            // 
            // SourceBox
            // 
            this.SourceBox.Location = new System.Drawing.Point(456, 654);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.ReadOnly = true;
            this.SourceBox.Size = new System.Drawing.Size(413, 20);
            this.SourceBox.TabIndex = 4;
            // 
            // SourceBtn
            // 
            this.SourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SourceBtn.Location = new System.Drawing.Point(367, 652);
            this.SourceBtn.Name = "SourceBtn";
            this.SourceBtn.Size = new System.Drawing.Size(75, 23);
            this.SourceBtn.TabIndex = 5;
            this.SourceBtn.Text = "Откуда";
            this.SourceBtn.UseVisualStyleBackColor = true;
            this.SourceBtn.Click += new System.EventHandler(this.SourceBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 685);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Артикулов:";
            // 
            // BarcodeCountLabel
            // 
            this.BarcodeCountLabel.AutoSize = true;
            this.BarcodeCountLabel.Location = new System.Drawing.Point(81, 685);
            this.BarcodeCountLabel.Name = "BarcodeCountLabel";
            this.BarcodeCountLabel.Size = new System.Drawing.Size(13, 13);
            this.BarcodeCountLabel.TabIndex = 6;
            this.BarcodeCountLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 685);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Товаров:";
            // 
            // ProductCountLabel
            // 
            this.ProductCountLabel.AutoSize = true;
            this.ProductCountLabel.Location = new System.Drawing.Point(331, 685);
            this.ProductCountLabel.Name = "ProductCountLabel";
            this.ProductCountLabel.Size = new System.Drawing.Size(13, 13);
            this.ProductCountLabel.TabIndex = 6;
            this.ProductCountLabel.Text = "0";
            // 
            // BarcodeLabel
            // 
            this.BarcodeLabel.AutoSize = true;
            this.BarcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeLabel.Location = new System.Drawing.Point(404, 70);
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
            this.label2.Location = new System.Drawing.Point(453, 631);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Найдено файлов:";
            // 
            // FoundFilesCount
            // 
            this.FoundFilesCount.AutoSize = true;
            this.FoundFilesCount.Location = new System.Drawing.Point(554, 631);
            this.FoundFilesCount.Name = "FoundFilesCount";
            this.FoundFilesCount.Size = new System.Drawing.Size(13, 13);
            this.FoundFilesCount.TabIndex = 9;
            this.FoundFilesCount.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 710);
            this.Controls.Add(this.FoundFilesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarcodeLabel);
            this.Controls.Add(this.ProductCountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BarcodeCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceBtn);
            this.Controls.Add(this.DestinationBtn);
            this.Controls.Add(this.SourceBox);
            this.Controls.Add(this.DestinationBox);
            this.Controls.Add(this.ProductImagesList);
            this.Controls.Add(this.NextPicBtn);
            this.Controls.Add(this.InputBarcodeBox);
            this.Controls.Add(this.PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BulkCopier";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BarcodeCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ProductCountLabel;
        private System.Windows.Forms.Label BarcodeLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FoundFilesCount;
    }
}

