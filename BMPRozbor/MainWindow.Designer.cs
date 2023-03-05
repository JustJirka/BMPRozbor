namespace BMPRozbor
{
    partial class MainWindow
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
            this.picBx_hlavni = new System.Windows.Forms.PictureBox();
            this.nuUpDo_imageScale = new System.Windows.Forms.NumericUpDown();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_ = new System.Windows.Forms.Button();
            this.btn_blur = new System.Windows.Forms.Button();
            this.nUpDo_Blur = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítSouborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.úpravyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverzeBarevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přechodBarevšedáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstínyŠedéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstínyŠediPomocíPrůměruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empirickéOdstínyŠediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prádhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstínVybranéBarvyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sépieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pouzeRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pouzeRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pouzeGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pouzeBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.majoritníBarvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoFiltrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.TbCont_RightTabs = new System.Windows.Forms.TabControl();
            this.Informace = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBx_Informations = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nuUpDo_ = new System.Windows.Forms.NumericUpDown();
            this.rozmazáníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.úpravyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zrcadlitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertikálněToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontálněToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDo_Blur)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.TbCont_RightTabs.SuspendLayout();
            this.Informace.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "BMP Soubor (*.bmp)|*.bmp|All files (*.*)|*.*\"";
            this.openFileDialog1.Title = "Výběr souboru";
            // 
            // picBx_hlavni
            // 
            this.picBx_hlavni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBx_hlavni.Location = new System.Drawing.Point(12, 27);
            this.picBx_hlavni.Name = "picBx_hlavni";
            this.picBx_hlavni.Size = new System.Drawing.Size(1037, 511);
            this.picBx_hlavni.TabIndex = 2;
            this.picBx_hlavni.TabStop = false;
            this.picBx_hlavni.Paint += new System.Windows.Forms.PaintEventHandler(this.picBx_hlavni_Paint);
            // 
            // nuUpDo_imageScale
            // 
            this.nuUpDo_imageScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuUpDo_imageScale.Location = new System.Drawing.Point(1055, 518);
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
            this.btn_refresh.Location = new System.Drawing.Point(1166, 515);
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
            // btn_
            // 
            this.btn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_.Location = new System.Drawing.Point(1201, 455);
            this.btn_.Name = "btn_";
            this.btn_.Size = new System.Drawing.Size(49, 23);
            this.btn_.TabIndex = 9;
            this.btn_.Text = "Zrcadlit";
            this.btn_.UseVisualStyleBackColor = true;
            this.btn_.Click += new System.EventHandler(this.btn__Click);
            // 
            // btn_blur
            // 
            this.btn_blur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_blur.Location = new System.Drawing.Point(1120, 455);
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
            this.nUpDo_Blur.Location = new System.Drawing.Point(1060, 455);
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
            this.úpravyToolStripMenuItem,
            this.filtryToolStripMenuItem,
            this.úpravyToolStripMenuItem1});
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
            this.přechodBarevšedáToolStripMenuItem,
            this.odstínyŠedéToolStripMenuItem,
            this.odstínVybranéBarvyToolStripMenuItem,
            this.sépieToolStripMenuItem,
            this.pouzeRGBToolStripMenuItem,
            this.majoritníBarvaToolStripMenuItem});
            this.úpravyToolStripMenuItem.Name = "úpravyToolStripMenuItem";
            this.úpravyToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.úpravyToolStripMenuItem.Text = "Barvy";
            // 
            // inverzeBarevToolStripMenuItem
            // 
            this.inverzeBarevToolStripMenuItem.Name = "inverzeBarevToolStripMenuItem";
            this.inverzeBarevToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.inverzeBarevToolStripMenuItem.Text = "Inverze barev";
            this.inverzeBarevToolStripMenuItem.Click += new System.EventHandler(this.inverzeBarevToolStripMenuItem_Click);
            // 
            // přechodBarevšedáToolStripMenuItem
            // 
            this.přechodBarevšedáToolStripMenuItem.Name = "přechodBarevšedáToolStripMenuItem";
            this.přechodBarevšedáToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.přechodBarevšedáToolStripMenuItem.Text = "Přechod barev ->šedá";
            this.přechodBarevšedáToolStripMenuItem.Click += new System.EventHandler(this.přechodBarevšedáToolStripMenuItem_Click);
            // 
            // odstínyŠedéToolStripMenuItem
            // 
            this.odstínyŠedéToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odstínyŠediPomocíPrůměruToolStripMenuItem,
            this.empirickéOdstínyŠediToolStripMenuItem,
            this.prádhToolStripMenuItem});
            this.odstínyŠedéToolStripMenuItem.Name = "odstínyŠedéToolStripMenuItem";
            this.odstínyŠedéToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
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
            // prádhToolStripMenuItem
            // 
            this.prádhToolStripMenuItem.Name = "prádhToolStripMenuItem";
            this.prádhToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.prádhToolStripMenuItem.Text = "Práh";
            this.prádhToolStripMenuItem.Click += new System.EventHandler(this.prádhToolStripMenuItem_Click);
            // 
            // odstínVybranéBarvyToolStripMenuItem
            // 
            this.odstínVybranéBarvyToolStripMenuItem.Name = "odstínVybranéBarvyToolStripMenuItem";
            this.odstínVybranéBarvyToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.odstínVybranéBarvyToolStripMenuItem.Text = "Odstín vybrané barvy";
            this.odstínVybranéBarvyToolStripMenuItem.Click += new System.EventHandler(this.odstínVybranéBarvyToolStripMenuItem_Click);
            // 
            // sépieToolStripMenuItem
            // 
            this.sépieToolStripMenuItem.Name = "sépieToolStripMenuItem";
            this.sépieToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sépieToolStripMenuItem.Text = "Sépie";
            this.sépieToolStripMenuItem.Click += new System.EventHandler(this.sépieToolStripMenuItem_Click);
            // 
            // pouzeRGBToolStripMenuItem
            // 
            this.pouzeRGBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pouzeRToolStripMenuItem,
            this.pouzeGToolStripMenuItem,
            this.pouzeBToolStripMenuItem});
            this.pouzeRGBToolStripMenuItem.Name = "pouzeRGBToolStripMenuItem";
            this.pouzeRGBToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.pouzeRGBToolStripMenuItem.Text = "Pouze R/G/B";
            // 
            // pouzeRToolStripMenuItem
            // 
            this.pouzeRToolStripMenuItem.Name = "pouzeRToolStripMenuItem";
            this.pouzeRToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pouzeRToolStripMenuItem.Text = "Pouze R";
            this.pouzeRToolStripMenuItem.Click += new System.EventHandler(this.pouzeRToolStripMenuItem_Click);
            // 
            // pouzeGToolStripMenuItem
            // 
            this.pouzeGToolStripMenuItem.Name = "pouzeGToolStripMenuItem";
            this.pouzeGToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pouzeGToolStripMenuItem.Text = "Pouze G";
            this.pouzeGToolStripMenuItem.Click += new System.EventHandler(this.pouzeGToolStripMenuItem_Click);
            // 
            // pouzeBToolStripMenuItem
            // 
            this.pouzeBToolStripMenuItem.Name = "pouzeBToolStripMenuItem";
            this.pouzeBToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pouzeBToolStripMenuItem.Text = "Pouze B";
            this.pouzeBToolStripMenuItem.Click += new System.EventHandler(this.pouzeBToolStripMenuItem_Click);
            // 
            // majoritníBarvaToolStripMenuItem
            // 
            this.majoritníBarvaToolStripMenuItem.Name = "majoritníBarvaToolStripMenuItem";
            this.majoritníBarvaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.majoritníBarvaToolStripMenuItem.Text = "Majoritní barva";
            this.majoritníBarvaToolStripMenuItem.Click += new System.EventHandler(this.majoritníBarvaToolStripMenuItem_Click);
            // 
            // filtryToolStripMenuItem
            // 
            this.filtryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoFiltrToolStripMenuItem,
            this.rozmazáníToolStripMenuItem});
            this.filtryToolStripMenuItem.Name = "filtryToolStripMenuItem";
            this.filtryToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filtryToolStripMenuItem.Text = "Filtry";
            // 
            // photoFiltrToolStripMenuItem
            // 
            this.photoFiltrToolStripMenuItem.Name = "photoFiltrToolStripMenuItem";
            this.photoFiltrToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.photoFiltrToolStripMenuItem.Text = "Photo filtr";
            this.photoFiltrToolStripMenuItem.Click += new System.EventHandler(this.photoFiltrToolStripMenuItem_Click);
            // 
            // TbCont_RightTabs
            // 
            this.TbCont_RightTabs.Controls.Add(this.Informace);
            this.TbCont_RightTabs.Controls.Add(this.tabPage2);
            this.TbCont_RightTabs.Location = new System.Drawing.Point(1054, 27);
            this.TbCont_RightTabs.Name = "TbCont_RightTabs";
            this.TbCont_RightTabs.SelectedIndex = 0;
            this.TbCont_RightTabs.Size = new System.Drawing.Size(200, 422);
            this.TbCont_RightTabs.TabIndex = 15;
            // 
            // Informace
            // 
            this.Informace.Controls.Add(this.txtBx_Informations);
            this.Informace.Location = new System.Drawing.Point(4, 22);
            this.Informace.Name = "Informace";
            this.Informace.Padding = new System.Windows.Forms.Padding(3);
            this.Informace.Size = new System.Drawing.Size(192, 229);
            this.Informace.TabIndex = 0;
            this.Informace.Text = "Informace";
            this.Informace.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nuUpDo_);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBx_Informations
            // 
            this.txtBx_Informations.Location = new System.Drawing.Point(6, 6);
            this.txtBx_Informations.Multiline = true;
            this.txtBx_Informations.Name = "txtBx_Informations";
            this.txtBx_Informations.ReadOnly = true;
            this.txtBx_Informations.Size = new System.Drawing.Size(180, 217);
            this.txtBx_Informations.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Provést";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // nuUpDo_
            // 
            this.nuUpDo_.Location = new System.Drawing.Point(6, 34);
            this.nuUpDo_.Name = "nuUpDo_";
            this.nuUpDo_.Size = new System.Drawing.Size(89, 20);
            this.nuUpDo_.TabIndex = 2;
            // 
            // rozmazáníToolStripMenuItem
            // 
            this.rozmazáníToolStripMenuItem.Name = "rozmazáníToolStripMenuItem";
            this.rozmazáníToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rozmazáníToolStripMenuItem.Text = "Rozmazání";
            // 
            // úpravyToolStripMenuItem1
            // 
            this.úpravyToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zrcadlitToolStripMenuItem});
            this.úpravyToolStripMenuItem1.Name = "úpravyToolStripMenuItem1";
            this.úpravyToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.úpravyToolStripMenuItem1.Text = "Úpravy";
            // 
            // zrcadlitToolStripMenuItem
            // 
            this.zrcadlitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vertikálněToolStripMenuItem,
            this.horizontálněToolStripMenuItem});
            this.zrcadlitToolStripMenuItem.Name = "zrcadlitToolStripMenuItem";
            this.zrcadlitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zrcadlitToolStripMenuItem.Text = "Zrcadlit";
            // 
            // vertikálněToolStripMenuItem
            // 
            this.vertikálněToolStripMenuItem.Name = "vertikálněToolStripMenuItem";
            this.vertikálněToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vertikálněToolStripMenuItem.Text = "Vertikálně";
            this.vertikálněToolStripMenuItem.Click += new System.EventHandler(this.vertikálněToolStripMenuItem_Click);
            // 
            // horizontálněToolStripMenuItem
            // 
            this.horizontálněToolStripMenuItem.Name = "horizontálněToolStripMenuItem";
            this.horizontálněToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.horizontálněToolStripMenuItem.Text = "Horizontálně";
            this.horizontálněToolStripMenuItem.Click += new System.EventHandler(this.horizontálněToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 550);
            this.Controls.Add(this.TbCont_RightTabs);
            this.Controls.Add(this.nUpDo_Blur);
            this.Controls.Add(this.btn_blur);
            this.Controls.Add(this.btn_);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.nuUpDo_imageScale);
            this.Controls.Add(this.picBx_hlavni);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainWindow";
            this.Text = "BMP Image Manipulation Program";
            ((System.ComponentModel.ISupportInitialize)(this.picBx_hlavni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_imageScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDo_Blur)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TbCont_RightTabs.ResumeLayout(false);
            this.Informace.ResumeLayout(false);
            this.Informace.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDo_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picBx_hlavni;
        private System.Windows.Forms.NumericUpDown nuUpDo_imageScale;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_;
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
        private System.Windows.Forms.ToolStripMenuItem přechodBarevšedáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prádhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sépieToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem odstínVybranéBarvyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photoFiltrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pouzeRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pouzeRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pouzeGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pouzeBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem majoritníBarvaToolStripMenuItem;
        private System.Windows.Forms.TabControl TbCont_RightTabs;
        private System.Windows.Forms.TabPage Informace;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtBx_Informations;
        private System.Windows.Forms.ToolStripMenuItem rozmazáníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem úpravyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zrcadlitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vertikálněToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontálněToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nuUpDo_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

