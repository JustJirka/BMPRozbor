using System;
using System.Collections;
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
        BMP Soubor= new BMP();
        int uprava = 3;
        public MainWindow()
        {
            InitializeComponent();
            CoBox_Order.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void PicBx_hlavni_Paint(object sender, PaintEventArgs e)
        {
            txtBx_Informations.Text = "bfType: " + Soubor.BfType() + Environment.NewLine + "bfSize: " + Soubor.BfSize() + Environment.NewLine + "bfOffBits: " + Soubor.BfOffBits() + Environment.NewLine + "biSize: " + Soubor.BiSize() + Environment.NewLine + "biWidth: " + Soubor.BiWidth() + Environment.NewLine + "biHeight: " + Soubor.BiHeight() + Environment.NewLine + "biPlanes: " + Soubor.BiPlanes() + Environment.NewLine + "biBitCount: " + Soubor.BiBitCount() + Environment.NewLine + "biCompression: " + Soubor.BiCompression() + Environment.NewLine + "biSizeImage: " + Soubor.BiSizeImage() + Environment.NewLine + "biXPelsPerMeter: " + Soubor.BiXPelsPerMeter() + Environment.NewLine + "biYPelsPerMeter: " + Soubor.BiYPelsPerMeter() + Environment.NewLine + "biClrUsed: " + Soubor.BiClrUsed() + Environment.NewLine + "biClrImportant: " + Soubor.BiClrImportant();
            Soubor.DrawImage(e.Graphics, (int)nuUpDo_imageScale.Value);
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            picBx_hlavni.Refresh();
        }

        private void OpenFileToolStripMenu_Click(object sender, EventArgs e)
        {
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Soubor = new BMP(openFileDialog1.FileName);
                picBx_hlavni.Refresh();
            }
        }

        private void SaveToolStripMenu_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Soubor.SaveFile(saveFileDialog1.FileName);
        }

        private void InvetColorToolStripMenu_Click(object sender, EventArgs e)
        {
            Soubor.Invert();
            picBx_hlavni.Refresh();
        }

        private void GrayscaleByAvaregingToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.GrayscaleByAveraging(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void EpiricGrayscaleToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.GrayscaleEpirical(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void GrayscaleColorTransitionToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.GrayscaleTransition(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void ThresholdGrayscaleToolStripMenu_Click(object sender, EventArgs e)
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

        private void SepieToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.Sepie(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void OneColorShadeToolStripMenu_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK) OperatinsBMP.OneColorShades(ref Soubor, colorDialog1.Color);
            picBx_hlavni.Refresh();
        }

        private void PhotoFiltrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK) OperatinsBMP.PhotoFiltr(ref Soubor, colorDialog1.Color);
            picBx_hlavni.Refresh();
        }

        private void OnlyRedToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.OnlyRGB(ref Soubor, 0);
            picBx_hlavni.Refresh();
        }

        private void OnlyGreenToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.OnlyRGB(ref Soubor, 1);
            picBx_hlavni.Refresh();
        }

        private void OnlyBlueToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.OnlyRGB(ref Soubor, 2);
            picBx_hlavni.Refresh();
        }

        private void MajorityColorToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.MajorityColor(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void VerticalMirrorToolStripMenu_Click(object sender, EventArgs e)
        {
            Soubor = OperatinsBMP.Mirror(Soubor);
            picBx_hlavni.Refresh();
        }

        private void HorizontalMirrorToolStripMenu_Click(object sender, EventArgs e)
        {
            Soubor.MirrorHorizontal();
            picBx_hlavni.Refresh();
        }

        private void BlurToolStripMenu_Click(object sender, EventArgs e)//pridat nastavení maximální velikosti
        {
            lbl_specific1.Text = "Zadejte úroveň rozmazání:";
            uprava = 1;//rozmazani
            tabPage2.Text = "Rozmazání";
            TbCont_RightTabs.SelectedIndex = 1;
        }

        private void BtnApplyTrasnformation(object sender, EventArgs e)
        {
            if (uprava == 1) OperatinsBMP.Blur(ref Soubor, (int)nuUpDo_specific1.Value);
            else if (uprava == 2) OperatinsBMP.GrayscaleThreshold(ref Soubor, (int)nuUpDo_specific1.Value);
            else if (uprava == 3) OperatinsBMP.ChangeBrightness(ref Soubor, (int)nuUpDo_specific1.Value);
            else if (uprava == 4) OperatinsBMP.ChangeContrast(ref Soubor, nuUpDo_specific1.Value);
            else if (uprava == 5) OperatinsBMP.ShiftRow(ref Soubor, (int)nuUpDo_specific1.Value, 0);
            else if (uprava == 6) OperatinsBMP.ShiftRow(ref Soubor, (int)nuUpDo_specific1.Value, 1);
            else if (uprava == 7) OperatinsBMP.ShiftColumn(ref Soubor, (int)nuUpDo_specific1.Value, 0);
            else if (uprava == 8) OperatinsBMP.ShiftColumn(ref Soubor, (int)nuUpDo_specific1.Value, 1);
            picBx_hlavni.Refresh();
        }

        private void ChangeBrightnessToolStripMenu_Click(object sender, EventArgs e)
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

        private void ChangeContrastToolStripMenu_Click(object sender, EventArgs e)
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

        private void MoveEvenRowsToolStripMenu_Click(object sender, EventArgs e)
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

        private void MovedOddColumsToolStripMenu_Click(object sender, EventArgs e)
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

        private void MoveEvenColumnsToolStripMenu_Click(object sender, EventArgs e)
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

        private void MoveOddColumsToolStripMenu_Click(object sender, EventArgs e)
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

        private void ConvertTo1bitToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.ConvertToXBit(ref Soubor, 1);
            picBx_hlavni.Refresh();
        }

        private void GauseanFiltrToolStripMenu_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {1,2,1},
                {2,4,2},
                {1,2,1}
            };
            OperatinsBMP.ApplyConvolutionMatrix(ref Soubor, matice, 16, 0);
            picBx_hlavni.Refresh();
        }

        private void FilterSharpenToolStripMenu_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {0,-1,0},
                {-1,5,-1},
                {0,-1,0}
            };
            OperatinsBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 0);
            picBx_hlavni.Refresh();
        }

        private void DetectEdgesToolStripMenu_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {1,0,-1},
                {0,0,0},
                {-1,0,1}
            };
            OperatinsBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 0);
            picBx_hlavni.Refresh();
        }

        private void EmbosToolStripMenu_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {0,-1,0},
                {0,0,0},
                {0,1,0}
            };
            OperatinsBMP.ApplyConvolutionMatrix(ref Soubor, matice, 1, 128);
            picBx_hlavni.Refresh();
        }

        private void ConvertTo24bitToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.ConvertToXBit(ref Soubor, 24);
            picBx_hlavni.Refresh();
        }

        private void ConvertTo4bitToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.ConvertToXBit(ref Soubor, 4);
            picBx_hlavni.Refresh();
        }

        private void ConvertTo8bitToolStripMenu_Click(object sender, EventArgs e)
        {
            OperatinsBMP.ConvertToXBit(ref Soubor, 8);
            picBx_hlavni.Refresh();
        }

        private void Btn_TransformMatrix_Click(object sender, EventArgs e)
        {
            double angleRadians = (double)nUpDo_Rotate.Value * Math.PI / 180;
            double[,] matrixRotate =
            {
                {Math.Cos(angleRadians),-1* Math.Sin(angleRadians),0},
                {Math.Sin(angleRadians),Math.Cos(angleRadians),0},
                {0,0,1 }
            };
            double[,] matrixScale =
            {
                {(double)NuUpDo_scaleX.Value,0,0},
                {0,(double)NuUpDo_scaleY.Value,0},
                {0,0,1 }
            };
            double[,] matrixZkos =
            {
                {1, (double)NuUpDo_zkosY.Value,0},
                {(double)NuUpDo_zkosX.Value,1,0},
                {0,0,1 }
            };
            double[,] transformations= new double[3,3];
            if (CoBox_Order.Text == "Rotace, Zkosení, Zvětšení")
            {
                transformations = Helpers.MultiplyMatrix(matrixRotate, matrixZkos );
                transformations = Helpers.MultiplyMatrix(transformations, matrixScale);
            }
            else if (CoBox_Order.Text == "Rotace, Zvětšení, Zkosení")
            {
                transformations = Helpers.MultiplyMatrix(matrixRotate, matrixScale);
                transformations = Helpers.MultiplyMatrix(transformations, matrixZkos);
            }
            else if (CoBox_Order.Text == "Zkosení, Zvětšení, Rotace")
            {
                transformations = Helpers.MultiplyMatrix(matrixZkos, matrixScale);
                transformations = Helpers.MultiplyMatrix(transformations, matrixRotate);
            }
            else if (CoBox_Order.Text == "Zkosení, Rotace, Zvětšení")
            {
                transformations = Helpers.MultiplyMatrix(matrixZkos, matrixRotate);
                transformations = Helpers.MultiplyMatrix(transformations, matrixScale);
            }
            else if (CoBox_Order.Text == "Zvětšení, Zkosení, Rotace")
            {
                transformations = Helpers.MultiplyMatrix(matrixScale, matrixZkos);
                transformations = Helpers.MultiplyMatrix(transformations, matrixRotate);
            }
            else if (CoBox_Order.Text == "Zvětšení, Rotace, Zkosení")
            {
                transformations = Helpers.MultiplyMatrix(matrixScale, matrixRotate);
                transformations = Helpers.MultiplyMatrix(transformations, matrixZkos);
            }
            OperatinsBMP.ApplyTrasformationMatrix(ref Soubor, transformations);
            Helpers.CalculateCorrectHeader(ref Soubor);
            picBx_hlavni.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] matrixCustom =
{
                {(double)nUpDo_Matrix0_0.Value,(double)nUpDo_Matrix0_1.Value,(double)nUpDo_Matrix0_2.Value},
                {(double)nUpDo_Matrix1_0.Value,(double)nUpDo_Matrix1_1.Value,(double)nUpDo_Matrix1_2.Value},
                {(double)nUpDo_Matrix2_0.Value,(double)nUpDo_Matrix2_1.Value,(double)nUpDo_Matrix2_2.Value},
            };
            OperatinsBMP.ApplyTrasformationMatrix(ref Soubor, matrixCustom);
            Helpers.CalculateCorrectHeader(ref Soubor);
            picBx_hlavni.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] matice = {
                {(int)nUpDo_KonMatrix0_0.Value,(int)nUpDo_KonMatrix0_1.Value,(int)nUpDo_KonMatrix0_2.Value},
                {(int)nUpDo_KonMatrix1_0.Value,(int)nUpDo_KonMatrix1_1.Value,(int)nUpDo_KonMatrix1_2.Value},
                {(int)nUpDo_KonMatrix2_0.Value,(int)nUpDo_KonMatrix2_1.Value,(int)nUpDo_KonMatrix2_2.Value}
            };
            OperatinsBMP.ApplyConvolutionMatrix(ref Soubor, matice, (int)nUpDo_KonMatrixDivider.Value, (int)nUpDo_KonMatrixOffset.Value);
            picBx_hlavni.Refresh();

        }
    }
}