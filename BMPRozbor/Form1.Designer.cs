namespace BMPRozbor
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.txtBx_info = new System.Windows.Forms.TextBox();
            this.picBx_hlavni = new System.Windows.Forms.PictureBox();
            this.nuUpDo_imageScale = new System.Windows.Forms.NumericUpDown();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.btn_Invert = new System.Windows.Forms.Button();
            this.btn_90Left = new System.Windows.Forms.Button();
            this.btn_90Right = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "BMP Soubor (*.bmp)|*.bmp|All files (*.*)|*.*\"";
            this.openFileDialog1.Title = "Výběr souboru";
            // 
            // btn_openFile
            // 
            this.btn_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFile.Location = new System.Drawing.Point(1057, 12);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(105, 23);
            this.btn_openFile.TabIndex = 0;
            this.btn_openFile.Text = "Otevři soubor";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // txtBx_info
            // 
            this.txtBx_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBx_info.Location = new System.Drawing.Point(1057, 147);
            this.txtBx_info.Multiline = true;
            this.txtBx_info.Name = "txtBx_info";
            this.txtBx_info.ReadOnly = true;
            this.txtBx_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBx_info.Size = new System.Drawing.Size(193, 422);
            this.txtBx_info.TabIndex = 1;
            // 
            // picBx_hlavni
            // 
            this.picBx_hlavni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBx_hlavni.Location = new System.Drawing.Point(39, 30);
            this.picBx_hlavni.Name = "picBx_hlavni";
            this.picBx_hlavni.Size = new System.Drawing.Size(1012, 417);
            this.picBx_hlavni.TabIndex = 2;
            this.picBx_hlavni.TabStop = false;
            this.picBx_hlavni.Paint += new System.Windows.Forms.PaintEventHandler(this.picBx_hlavni_Paint);
            // 
            // nuUpDo_imageScale
            // 
            this.nuUpDo_imageScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuUpDo_imageScale.Location = new System.Drawing.Point(1057, 41);
            this.nuUpDo_imageScale.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nuUpDo_imageScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuUpDo_imageScale.Name = "nuUpDo_imageScale";
            this.nuUpDo_imageScale.Size = new System.Drawing.Size(105, 20);
            this.nuUpDo_imageScale.TabIndex = 3;
            this.nuUpDo_imageScale.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.Location = new System.Drawing.Point(1168, 38);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(82, 23);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Soubor.bmp";
            this.saveFileDialog1.Filter = "BMP Soubor (*.bmp)|*.bmp|All files (*.*)|*.*\"";
            this.saveFileDialog1.Title = "Uložení souboru";
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveFile.Location = new System.Drawing.Point(1168, 12);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(82, 23);
            this.btn_SaveFile.TabIndex = 5;
            this.btn_SaveFile.Text = "Ulož soubor";
            this.btn_SaveFile.UseVisualStyleBackColor = true;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // btn_Invert
            // 
            this.btn_Invert.Location = new System.Drawing.Point(1057, 90);
            this.btn_Invert.Name = "btn_Invert";
            this.btn_Invert.Size = new System.Drawing.Size(105, 26);
            this.btn_Invert.TabIndex = 6;
            this.btn_Invert.Text = "Invertovat obrázek";
            this.btn_Invert.UseVisualStyleBackColor = true;
            this.btn_Invert.Click += new System.EventHandler(this.btn_Invert_Click);
            // 
            // btn_90Left
            // 
            this.btn_90Left.Location = new System.Drawing.Point(1073, 67);
            this.btn_90Left.Name = "btn_90Left";
            this.btn_90Left.Size = new System.Drawing.Size(75, 23);
            this.btn_90Left.TabIndex = 7;
            this.btn_90Left.Text = "90° doleva";
            this.btn_90Left.UseVisualStyleBackColor = true;
            this.btn_90Left.Click += new System.EventHandler(this.btn_90Left_Click);
            // 
            // btn_90Right
            // 
            this.btn_90Right.Location = new System.Drawing.Point(1168, 67);
            this.btn_90Right.Name = "btn_90Right";
            this.btn_90Right.Size = new System.Drawing.Size(75, 23);
            this.btn_90Right.TabIndex = 8;
            this.btn_90Right.Text = "90° doprava";
            this.btn_90Right.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 550);
            this.Controls.Add(this.btn_90Right);
            this.Controls.Add(this.btn_90Left);
            this.Controls.Add(this.btn_Invert);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.nuUpDo_imageScale);
            this.Controls.Add(this.picBx_hlavni);
            this.Controls.Add(this.txtBx_info);
            this.Controls.Add(this.btn_openFile);
            this.Name = "Form1";
            this.Text = "BMPMP";
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.TextBox txtBx_info;
        private System.Windows.Forms.PictureBox picBx_hlavni;
        private System.Windows.Forms.NumericUpDown nuUpDo_imageScale;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.Button btn_Invert;
        private System.Windows.Forms.Button btn_90Left;
        private System.Windows.Forms.Button btn_90Right;
    }
}

