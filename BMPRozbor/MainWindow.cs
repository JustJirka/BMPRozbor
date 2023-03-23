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
    public partial class MainWindow : Form
    {
        BMP Soubor;
        int uprava = -1;
        bool imgLoaded = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
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

        private void otevřítSouborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Soubor = new BMP(openFileDialog1.FileName);
                imgLoaded = true;
                txtBx_Informations.Text = "bfType: " + Soubor.BfType() + Environment.NewLine + "bfSize: " + Soubor.BfSize() + Environment.NewLine + "bfOffBits: " + Soubor.BfOffBits() + Environment.NewLine + "biSize: " + Soubor.BiSize() + Environment.NewLine + "biWidth: " + Soubor.BiWidth() + Environment.NewLine + "biHeight: " + Soubor.BiHeight() + Environment.NewLine + "biPlanes: " + Soubor.BiPlanes() + Environment.NewLine + "biBitCount: " + Soubor.BiBitCount() + Environment.NewLine + "biCompression: " + Soubor.BiCompression() + Environment.NewLine + "biSizeImage: " + Soubor.BiSizeImage() + Environment.NewLine + "biXPelsPerMeter: " + Soubor.BiXPelsPerMeter() + Environment.NewLine + "biYPelsPerMeter: " + Soubor.BiYPelsPerMeter() + Environment.NewLine + "biClrUsed: " + Soubor.BiClrUsed() + Environment.NewLine + "biClrImportant: " + Soubor.BiClrImportant();
                picBx_hlavni.Refresh();
            }
        }

        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Soubor.SaveFile(saveFileDialog1.FileName);
        }

        private void inverzeBarevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor.Invert();
            picBx_hlavni.Refresh();
        }

        private void odstínyŠediPomocíPrůměruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.GrayscaleByAveraging(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void empirickéOdstínyŠediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.GrayscaleEpirical(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void přechodBarevšedáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.GrayscaleTransition(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void prádhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte práh:";
            uprava = 2;//rozmazani
            TbCont_RightTabs.SelectedIndex = 1;
            tabPage2.Text = "Práh";
            nuUpDo_specific1.Maximum = 255;
            nuUpDo_specific1.Minimum = 0;
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.DecimalPlaces = 0;
            nuUpDo_specific1.Value = 125;
        }

        private void sépieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.Sepie(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void odstínVybranéBarvyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK) OperaceSBMP.OneColorShades(ref Soubor, colorDialog1.Color);
            picBx_hlavni.Refresh();
        }

        private void photoFiltrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK) OperaceSBMP.PhotoFiltr(ref Soubor, colorDialog1.Color);
            picBx_hlavni.Refresh();
        }

        private void pouzeRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.OnlyRGB(ref Soubor, 0);
            picBx_hlavni.Refresh();
        }

        private void pouzeGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.OnlyRGB(ref Soubor, 1);
            picBx_hlavni.Refresh();
        }

        private void pouzeBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.OnlyRGB(ref Soubor, 2);
            picBx_hlavni.Refresh();
        }

        private void majoritníBarvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.MajorityColor(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void vertikálněToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor = OperaceSBMP.Mirror(Soubor);
            picBx_hlavni.Refresh();
        }

        private void horizontálněToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor.MirrorHorizontal();
            picBx_hlavni.Refresh();
        }

        private void rozmazáníToolStripMenuItem_Click(object sender, EventArgs e)//pridat nastavení maximální velikosti
        {
            lbl_specific1.Text = "Zadejte úroveň rozmazání:";
            uprava = 1;//rozmazani
            tabPage2.Text = "Rozmazání";
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (uprava == 1) OperaceSBMP.Blur(ref Soubor, (int)nuUpDo_specific1.Value);
            else if (uprava == 2) OperaceSBMP.GrayscaleThreshold(ref Soubor, (int)nuUpDo_specific1.Value);
            else if (uprava == 3) OperaceSBMP.ChangeBrightness(ref Soubor, (int)nuUpDo_specific1.Value);
            else if (uprava == 4) OperaceSBMP.ChangeContrast(ref Soubor, nuUpDo_specific1.Value);
            else if (uprava == 5) OperaceSBMP.ShiftRow(ref Soubor, (int)nuUpDo_specific1.Value, 0);
            else if (uprava == 6) OperaceSBMP.ShiftRow(ref Soubor, (int)nuUpDo_specific1.Value, 1);
            else if (uprava == 7) OperaceSBMP.ShiftColumn(ref Soubor, (int)nuUpDo_specific1.Value, 0);
            else if (uprava == 8) OperaceSBMP.ShiftColumn(ref Soubor, (int)nuUpDo_specific1.Value, 1);
            else if (uprava == 9)
            {
                double angleRadians = (double)nuUpDo_specific1.Value * Math.PI / 180;
                double[,] matrix =
                {
                    {Math.Cos(angleRadians),-1* Math.Sin(angleRadians),0},
                    {Math.Sin(angleRadians),Math.Cos(angleRadians),0},
                    {0,0,1 }
                };
                OperaceSBMP.ApplyTrasformationMatrix(ref Soubor, matrix);
            }
            else if (uprava == 94)
            {
                double angleRadians = (double)nuUpDo_specific1.Value * Math.PI / 180;
                double[,] matrix =
                {
                    {1,30,0},
                    {30,1,0},
                    {0,0,1 }
                };
                OperaceSBMP.ApplyTrasformationMatrix(ref Soubor, matrix);
            }
            picBx_hlavni.Refresh();
        }

        private void úpravaJasuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte modifikátor Jasu";
            uprava = 3;//jas
            tabPage2.Text = "Jas";
            nuUpDo_specific1.Maximum = 255;
            nuUpDo_specific1.Minimum = -255;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.DecimalPlaces = 0;
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void úpravaKontrastuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte modifikátor Jasu";
            uprava = 4;//kontrast
            tabPage2.Text = "Kontrast";
            nuUpDo_specific1.Maximum = 255;
            nuUpDo_specific1.Minimum = 0;
            nuUpDo_specific1.Increment = 0.01m;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.DecimalPlaces = 2;
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void posunSudýchŘádkůToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte posun řádku";
            uprava = 5;//
            tabPage2.Text = "Posun";
            nuUpDo_specific1.Maximum = Soubor.BiWidth();
            nuUpDo_specific1.Minimum = 0 - Soubor.BiWidth();
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.DecimalPlaces = 0;
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void posunLichýchSloupcůToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte posun řádku";
            uprava = 6;//
            tabPage2.Text = "Posun";
            nuUpDo_specific1.Maximum = Soubor.BiWidth();
            nuUpDo_specific1.Minimum = 0 - Soubor.BiWidth();
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.DecimalPlaces = 0;
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void posunSudýchSloupcůToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte posun sloupce";
            uprava = 7;//
            tabPage2.Text = "Posun";
            nuUpDo_specific1.Maximum = Soubor.BiHeight();
            nuUpDo_specific1.Minimum = 0 - Soubor.BiHeight();
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.DecimalPlaces = 0;
            TbCont_RightTabs.SelectedIndex = 1;

        }

        private void posunLichýchSloupcůToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte posun sloupce";
            uprava = 8;//
            tabPage2.Text = "Posun";
            nuUpDo_specific1.Maximum = Soubor.BiHeight();
            nuUpDo_specific1.Minimum = 0 - Soubor.BiHeight();
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.DecimalPlaces = 0;
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void použíKonvelčníMaticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {0,-1,0},
                {-1,5,-1},
                {0,-1,0}
            };
            OperaceSBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 0);
            picBx_hlavni.Refresh();
        }

        private void konvertovatNa1BitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.ConvertToXBit(ref Soubor, 1);
            picBx_hlavni.Refresh();
        }

        private void otočitOÚhelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gaussůvFiltrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {1,2,1},
                {2,4,2},
                {1,2,1}
            };
            OperaceSBMP.ApplyConvolutionMatrix(ref Soubor, matice, 16, 0);
            picBx_hlavni.Refresh();
        }

        private void filtrZaostřeníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {0,-1,0},
                {-1,5,-1},
                {0,-1,0}
            };
            OperaceSBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 0);
            picBx_hlavni.Refresh();
        }

        private void detekceHranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {1,0,-1},
                {0,0,0},
                {-1,0,1}
            };
            OperaceSBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 0);
            picBx_hlavni.Refresh();
        }

        private void reliefToolStripMenuItem_Click(object sender, EventArgs e) //idk jestli nepadá
        {
            int[,] matice = {
                {0,-1,0},
                {0,0,0},
                {0,1,0}
            };
            OperaceSBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 128);
            picBx_hlavni.Refresh();
        }

        private void otočitOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_specific1.Text = "Zadejte úhel otočení";
            uprava = 9;//
            tabPage2.Text = "Otočení";
            nuUpDo_specific1.Maximum = 360;
            nuUpDo_specific1.Minimum = -360;
            nuUpDo_specific1.Increment = 1;
            nuUpDo_specific1.Value = 0;
            nuUpDo_specific1.DecimalPlaces = 0;
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void konvertovatNa24BitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.ConvertToXBit(ref Soubor, 24);
            picBx_hlavni.Refresh();
        }

        private void konvertovatNa4BitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.ConvertToXBit(ref Soubor, 4);
            picBx_hlavni.Refresh();
        }

        private void konvertovatNa8BitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperaceSBMP.ConvertToXBit(ref Soubor, 8);
            picBx_hlavni.Refresh();
        }
    }
}