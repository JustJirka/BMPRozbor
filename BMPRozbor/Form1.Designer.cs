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
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_openFile
            // 
            this.btn_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFile.Location = new System.Drawing.Point(1165, 12);
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
            this.txtBx_info.Location = new System.Drawing.Point(1077, 66);
            this.txtBx_info.Multiline = true;
            this.txtBx_info.Name = "txtBx_info";
            this.txtBx_info.ReadOnly = true;
            this.txtBx_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBx_info.Size = new System.Drawing.Size(193, 356);
            this.txtBx_info.TabIndex = 1;
            // 
            // picBx_hlavni
            // 
            this.picBx_hlavni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBx_hlavni.Location = new System.Drawing.Point(39, 30);
            this.picBx_hlavni.Name = "picBx_hlavni";
            this.picBx_hlavni.Size = new System.Drawing.Size(1032, 539);
            this.picBx_hlavni.TabIndex = 2;
            this.picBx_hlavni.TabStop = false;
            this.picBx_hlavni.Paint += new System.Windows.Forms.PaintEventHandler(this.picBx_hlavni_Paint);
            // 
            // nuUpDo_imageScale
            // 
            this.nuUpDo_imageScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuUpDo_imageScale.Location = new System.Drawing.Point(1077, 41);
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
            this.nuUpDo_imageScale.Size = new System.Drawing.Size(193, 20);
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
            this.btn_refresh.Location = new System.Drawing.Point(1077, 12);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(82, 23);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 672);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.nuUpDo_imageScale);
            this.Controls.Add(this.picBx_hlavni);
            this.Controls.Add(this.txtBx_info);
            this.Controls.Add(this.btn_openFile);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

