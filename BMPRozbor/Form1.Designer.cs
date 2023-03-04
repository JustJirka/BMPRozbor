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
            this.txtBx_info = new System.Windows.Forms.TextBox();
            this.picBx_hlavni = new System.Windows.Forms.PictureBox();
            this.nuUpDo_imageScale = new System.Windows.Forms.NumericUpDown();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_90Left = new System.Windows.Forms.Button();
            this.btn_90Right = new System.Windows.Forms.Button();
            this.btn_ = new System.Windows.Forms.Button();
            this.bnt_Flip = new System.Windows.Forms.Button();
            this.btn_blur = new System.Windows.Forms.Button();
            this.nUpDo_Blur = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítSouborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.úpravyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverzeBarevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstínyŠedéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstínyŠediPomocíPrůměruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empirickéOdstínyŠediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDo_Blur)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "BMP Soubor (*.bmp)|*.bmp|All files (*.*)|*.*\"";
            this.openFileDialog1.Title = "Výběr souboru";
            // 
            // txtBx_info
            // 
            this.txtBx_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBx_info.Location = new System.Drawing.Point(1055, 288);
            this.txtBx_info.Multiline = true;
            this.txtBx_info.Name = "txtBx_info";
            this.txtBx_info.ReadOnly = true;
            this.txtBx_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBx_info.Size = new System.Drawing.Size(193, 250);
            this.txtBx_info.TabIndex = 1;
            // 
            // picBx_hlavni
            // 
            this.picBx_hlavni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBx_hlavni.Location = new System.Drawing.Point(12, 38);
            this.picBx_hlavni.Name = "picBx_hlavni";
            this.picBx_hlavni.Size = new System.Drawing.Size(1037, 529);
            this.picBx_hlavni.TabIndex = 2;
            this.picBx_hlavni.TabStop = false;
            this.picBx_hlavni.Paint += new System.Windows.Forms.PaintEventHandler(this.picBx_hlavni_Paint);
            // 
            // nuUpDo_imageScale
            // 
            this.nuUpDo_imageScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuUpDo_imageScale.Location = new System.Drawing.Point(1055, 41);
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
            this.btn_refresh.Location = new System.Drawing.Point(1166, 38);
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
            // btn_90Left
            // 
            this.btn_90Left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_90Left.Location = new System.Drawing.Point(1204, 67);
            this.btn_90Left.Name = "btn_90Left";
            this.btn_90Left.Size = new System.Drawing.Size(17, 23);
            this.btn_90Left.TabIndex = 7;
            this.btn_90Left.Text = "90° doleva";
            this.btn_90Left.UseVisualStyleBackColor = true;
            this.btn_90Left.Click += new System.EventHandler(this.btn_90Left_Click);
            // 
            // btn_90Right
            // 
            this.btn_90Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_90Right.Location = new System.Drawing.Point(1227, 67);
            this.btn_90Right.Name = "btn_90Right";
            this.btn_90Right.Size = new System.Drawing.Size(21, 23);
            this.btn_90Right.TabIndex = 8;
            this.btn_90Right.Text = "90° doprava";
            this.btn_90Right.UseVisualStyleBackColor = true;
            // 
            // btn_
            // 
            this.btn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_.Location = new System.Drawing.Point(1173, 99);
            this.btn_.Name = "btn_";
            this.btn_.Size = new System.Drawing.Size(75, 23);
            this.btn_.TabIndex = 9;
            this.btn_.Text = "Zrcadlit";
            this.btn_.UseVisualStyleBackColor = true;
            this.btn_.Click += new System.EventHandler(this.btn__Click);
            // 
            // bnt_Flip
            // 
            this.bnt_Flip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnt_Flip.Location = new System.Drawing.Point(1055, 99);
            this.bnt_Flip.Name = "bnt_Flip";
            this.bnt_Flip.Size = new System.Drawing.Size(112, 23);
            this.bnt_Flip.TabIndex = 10;
            this.bnt_Flip.Text = "Horizontální zrcadlo";
            this.bnt_Flip.UseVisualStyleBackColor = true;
            this.bnt_Flip.Click += new System.EventHandler(this.bnt_Flip_Click);
            // 
            // btn_blur
            // 
            this.btn_blur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_blur.Location = new System.Drawing.Point(1123, 67);
            this.btn_blur.Name = "btn_blur";
            this.btn_blur.Size = new System.Drawing.Size(75, 23);
            this.btn_blur.TabIndex = 11;
            this.btn_blur.Text = "Blur";
            this.btn_blur.UseVisualStyleBackColor = true;
            this.btn_blur.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // nUpDo_Blur
            // 
            this.nUpDo_Blur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nUpDo_Blur.Location = new System.Drawing.Point(1063, 67);
            this.nUpDo_Blur.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpDo_Blur.Name = "nUpDo_Blur";
            this.nUpDo_Blur.Size = new System.Drawing.Size(54, 20);
            this.nUpDo_Blur.TabIndex = 12;
            this.nUpDo_Blur.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.úpravyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1260, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otevřítSouborToolStripMenuItem,
            this.uložitToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // otevřítSouborToolStripMenuItem
            // 
            this.otevřítSouborToolStripMenuItem.Name = "otevřítSouborToolStripMenuItem";
            this.otevřítSouborToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.otevřítSouborToolStripMenuItem.Text = "Otevřít";
            this.otevřítSouborToolStripMenuItem.Click += new System.EventHandler(this.otevřítSouborToolStripMenuItem_Click);
            // 
            // uložitToolStripMenuItem
            // 
            this.uložitToolStripMenuItem.Name = "uložitToolStripMenuItem";
            this.uložitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uložitToolStripMenuItem.Text = "Uložit ";
            this.uložitToolStripMenuItem.Click += new System.EventHandler(this.uložitToolStripMenuItem_Click);
            // 
            // úpravyToolStripMenuItem
            // 
            this.úpravyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inverzeBarevToolStripMenuItem,
            this.odstínyŠedéToolStripMenuItem});
            this.úpravyToolStripMenuItem.Name = "úpravyToolStripMenuItem";
            this.úpravyToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.úpravyToolStripMenuItem.Text = "Barvy";
            // 
            // inverzeBarevToolStripMenuItem
            // 
            this.inverzeBarevToolStripMenuItem.Name = "inverzeBarevToolStripMenuItem";
            this.inverzeBarevToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inverzeBarevToolStripMenuItem.Text = "Inverze barev";
            this.inverzeBarevToolStripMenuItem.Click += new System.EventHandler(this.inverzeBarevToolStripMenuItem_Click);
            // 
            // odstínyŠedéToolStripMenuItem
            // 
            this.odstínyŠedéToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odstínyŠediPomocíPrůměruToolStripMenuItem,
            this.empirickéOdstínyŠediToolStripMenuItem});
            this.odstínyŠedéToolStripMenuItem.Name = "odstínyŠedéToolStripMenuItem";
            this.odstínyŠedéToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.odstínyŠedéToolStripMenuItem.Text = "Odstíny šedé";
            // 
            // odstínyŠediPomocíPrůměruToolStripMenuItem
            // 
            this.odstínyŠediPomocíPrůměruToolStripMenuItem.Name = "odstínyŠediPomocíPrůměruToolStripMenuItem";
            this.odstínyŠediPomocíPrůměruToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.odstínyŠediPomocíPrůměruToolStripMenuItem.Text = "Odstíny šedi pomocí průměru";
            this.odstínyŠediPomocíPrůměruToolStripMenuItem.Click += new System.EventHandler(this.odstínyŠediPomocíPrůměruToolStripMenuItem_Click);
            // 
            // empirickéOdstínyŠediToolStripMenuItem
            // 
            this.empirickéOdstínyŠediToolStripMenuItem.Name = "empirickéOdstínyŠediToolStripMenuItem";
            this.empirickéOdstínyŠediToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.empirickéOdstínyŠediToolStripMenuItem.Text = "Empirické odstíny šedi";
            this.empirickéOdstínyŠediToolStripMenuItem.Click += new System.EventHandler(this.empirickéOdstínyŠediToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 550);
            this.Controls.Add(this.nUpDo_Blur);
            this.Controls.Add(this.btn_blur);
            this.Controls.Add(this.bnt_Flip);
            this.Controls.Add(this.btn_);
            this.Controls.Add(this.btn_90Right);
            this.Controls.Add(this.btn_90Left);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.nuUpDo_imageScale);
            this.Controls.Add(this.picBx_hlavni);
            this.Controls.Add(this.txtBx_info);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "BMP Image Manipulation Program";
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDo_Blur)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtBx_info;
        private System.Windows.Forms.PictureBox picBx_hlavni;
        private System.Windows.Forms.NumericUpDown nuUpDo_imageScale;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_90Left;
        private System.Windows.Forms.Button btn_90Right;
        private System.Windows.Forms.Button btn_;
        private System.Windows.Forms.Button bnt_Flip;
        private System.Windows.Forms.Button btn_blur;
        private System.Windows.Forms.NumericUpDown nUpDo_Blur;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítSouborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem úpravyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverzeBarevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odstínyŠedéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odstínyŠediPomocíPrůměruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empirickéOdstínyŠediToolStripMenuItem;
    }
}

