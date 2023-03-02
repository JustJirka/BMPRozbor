using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BMPRozbor
{
    public partial class Form1 : Form
    {
        BMP Soubor;
        bool imgLoaded = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                Soubor = new BMP(openFileDialog1.FileName);
                imgLoaded = true;
                txtBx_info.Text = "bfType: " + Soubor.BfType() + Environment.NewLine + "bfSize: " + Soubor.BfSize() + Environment.NewLine + "bfOffBits: " + Soubor.BfOffBits() + Environment.NewLine + "biSize: " + Soubor.BiSize() + Environment.NewLine + "biWidth: " + Soubor.BiWidth() + Environment.NewLine + "biHeight: " + Soubor.BiHeight() + Environment.NewLine + "biPlanes: " + Soubor.BiPlanes() + Environment.NewLine + "biBitCount: " + Soubor.BiBitCount() + Environment.NewLine + "biCompression: " + Soubor.BiCompression() + Environment.NewLine + "biSizeImage: " + Soubor.BiSizeImage() + Environment.NewLine + "biXPelsPerMeter: " + Soubor.BiXPelsPerMeter() + Environment.NewLine + "biYPelsPerMeter: " + Soubor.BiYPelsPerMeter() + Environment.NewLine + "biClrUsed: " + Soubor.BiClrUsed() + Environment.NewLine + "biClrImportant: " + Soubor.BiClrImportant();
                picBx_hlavni.Refresh();
            } 
        }

        private void picBx_hlavni_Paint(object sender, PaintEventArgs e)
        {
            if (imgLoaded)
            {
                Soubor.DrawImage(e.Graphics, (int)nuUpDo_imageScale.Value);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            picBx_hlavni.Refresh();
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Soubor.SaveFile(saveFileDialog1.FileName);
            }

        }

        private void btn_Invert_Click(object sender, EventArgs e)
        {
            Soubor.Invert();
            picBx_hlavni.Refresh();
        }

        private void btn_90Left_Click(object sender, EventArgs e)
        {
            Soubor.Rotate90Right();
            picBx_hlavni.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn__Click(object sender, EventArgs e)
        {
            Soubor = OperaceSBMP.Mirror(Soubor);
            picBx_hlavni.Refresh();
        }

        private void bnt_Flip_Click(object sender, EventArgs e)
        {
            Soubor.MirrorHorizontal();
            picBx_hlavni.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           Soubor = OperaceSBMP.Blur(Soubor,(int)nUpDo_Blur.Value);
           picBx_hlavni.Refresh();
        }

        private void btn_Grayscale_Click(object sender, EventArgs e)
        {
            Soubor = OperaceSBMP.Grayscale(Soubor);
            picBx_hlavni.Refresh();
        }
    }
}