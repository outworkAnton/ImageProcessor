namespace BulkCopier
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RowCounter = new System.Windows.Forms.NumericUpDown();
            this.ColumnCounter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DrawGridLinesChk = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrinterSetupBtn = new System.Windows.Forms.Button();
            this.PageSetupBtn = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.PrinterLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PaperSizeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnCounter)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RowCounter);
            this.groupBox1.Controls.Add(this.ColumnCounter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DrawGridLinesChk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки документа";
            // 
            // RowCounter
            // 
            this.RowCounter.Location = new System.Drawing.Point(9, 123);
            this.RowCounter.Name = "RowCounter";
            this.RowCounter.Size = new System.Drawing.Size(138, 20);
            this.RowCounter.TabIndex = 6;
            // 
            // ColumnCounter
            // 
            this.ColumnCounter.Location = new System.Drawing.Point(9, 58);
            this.ColumnCounter.Name = "ColumnCounter";
            this.ColumnCounter.Size = new System.Drawing.Size(138, 20);
            this.ColumnCounter.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество изображений по вертикали:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество изображений по горизонтали:";
            // 
            // DrawGridLinesChk
            // 
            this.DrawGridLinesChk.AutoSize = true;
            this.DrawGridLinesChk.Location = new System.Drawing.Point(9, 161);
            this.DrawGridLinesChk.Name = "DrawGridLinesChk";
            this.DrawGridLinesChk.Size = new System.Drawing.Size(95, 17);
            this.DrawGridLinesChk.TabIndex = 2;
            this.DrawGridLinesChk.Text = "Печать линий";
            this.DrawGridLinesChk.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PaperSizeLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.PrinterLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.PrinterSetupBtn);
            this.groupBox2.Controls.Add(this.PageSetupBtn);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 195);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки принтера";
            // 
            // PrinterSetupBtn
            // 
            this.PrinterSetupBtn.Location = new System.Drawing.Point(15, 58);
            this.PrinterSetupBtn.Name = "PrinterSetupBtn";
            this.PrinterSetupBtn.Size = new System.Drawing.Size(181, 23);
            this.PrinterSetupBtn.TabIndex = 1;
            this.PrinterSetupBtn.Text = "Настройка принтера";
            this.PrinterSetupBtn.UseVisualStyleBackColor = true;
            this.PrinterSetupBtn.Click += new System.EventHandler(this.PrinterSetupBtn_Click);
            // 
            // PageSetupBtn
            // 
            this.PageSetupBtn.Location = new System.Drawing.Point(15, 26);
            this.PageSetupBtn.Name = "PageSetupBtn";
            this.PageSetupBtn.Size = new System.Drawing.Size(181, 23);
            this.PageSetupBtn.TabIndex = 0;
            this.PageSetupBtn.Text = "Настройка страницы";
            this.PageSetupBtn.UseVisualStyleBackColor = true;
            this.PageSetupBtn.Click += new System.EventHandler(this.PageSetupBtn_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Принтер:";
            // 
            // PrinterLabel
            // 
            this.PrinterLabel.AutoSize = true;
            this.PrinterLabel.Location = new System.Drawing.Point(71, 90);
            this.PrinterLabel.Name = "PrinterLabel";
            this.PrinterLabel.Size = new System.Drawing.Size(0, 13);
            this.PrinterLabel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Формат бумаги:";
            // 
            // PaperSizeLabel
            // 
            this.PaperSizeLabel.AutoSize = true;
            this.PaperSizeLabel.Location = new System.Drawing.Point(109, 125);
            this.PaperSizeLabel.Name = "PaperSizeLabel";
            this.PaperSizeLabel.Size = new System.Drawing.Size(0, 13);
            this.PaperSizeLabel.TabIndex = 5;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 219);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка печати";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnCounter)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox DrawGridLinesChk;
        private System.Windows.Forms.Button PageSetupBtn;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrinterSetupBtn;
        private System.Windows.Forms.NumericUpDown RowCounter;
        private System.Windows.Forms.NumericUpDown ColumnCounter;
        private System.Windows.Forms.Label PaperSizeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PrinterLabel;
        private System.Windows.Forms.Label label3;
    }
}