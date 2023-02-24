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
        int imageScale = 8;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            var memoryStream = new MemoryStream();
            // Use the .CopyTo() method and write current filestream to memory stream
            fs.CopyTo(memoryStream);
            // Convert Stream To Array
            Soubor = new BMP(memoryStream.ToArray());
            imgLoaded = true;
            txtBx_info.Text = "bfType: " + Soubor.BfType() + Environment.NewLine + "bfSize: " + Soubor.BfSize() + Environment.NewLine + "bfOffBits: " + Soubor.BfOffBits() + Environment.NewLine + "biSize: " + Soubor.BiSize() + Environment.NewLine + "biWidth: " + Soubor.BiWidth() + Environment.NewLine + "biHeight: " + Soubor.BiHeight() + Environment.NewLine + "biPlanes: " + Soubor.BiPlanes() + Environment.NewLine + "biBitCount: " + Soubor.BiBitCount() + Environment.NewLine + "biCompression: " + Soubor.BiCompression() + Environment.NewLine + "biSizeImage: " + Soubor.BiSizeImage() + Environment.NewLine + "biXPelsPerMeter: " + Soubor.BiXPelsPerMeter() + Environment.NewLine + "biYPelsPerMeter: " + Soubor.BiYPelsPerMeter() + Environment.NewLine + "biClrUsed: " + Soubor.BiClrUsed() + Environment.NewLine + "biClrImportant: " + Soubor.BiClrImportant();
            picBx_hlavni.Refresh();
        }
        public String intToHex(int i)
        {
            StringBuilder hex = new StringBuilder();
            hex.AppendFormat("{0:x2}", i);
            return hex.ToString();
        }

        private void picBx_hlavni_Paint(object sender, PaintEventArgs e)
        {
            if (imgLoaded)
            {
                if (Soubor.BiBitCount() == 24)
                {
                    int curentByte = Soubor.BfOffBits();
                    for (int i = Soubor.BiHeight(); i > 0; i--)
                    {
                        for (int j = 0; j < Soubor.BiWidth(); j++)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(Soubor.byteArray[curentByte + 2], Soubor.byteArray[curentByte + 1], Soubor.byteArray[curentByte])), j * imageScale, i * imageScale, imageScale, imageScale);
                            curentByte += 3;
                        }
                        // curentByte += Soubor.ScanlineDoplnek();
                    }
                }
                else if (Soubor.BiBitCount() == 1)
                {
                    int curentByte = Soubor.BfOffBits();
                    Brush[] paleta = new Brush[2];
                    for (int i = 0; i < 2; i++)
                    {
                        paleta[i] = new SolidBrush(Color.FromArgb(Soubor.byteArray[Soubor.BfOffBits() - 8 + (i * 4) + 2], Soubor.byteArray[Soubor.BfOffBits() - 8 + (i * 4) + 1], Soubor.byteArray[Soubor.BfOffBits() - 8 + (i * 4)]));
                    }
                    for (int i = Soubor.BiHeight(); i > 0; i--)
                    {
                        for (int j = 0; j < Soubor.BiWidth();)
                        {
                            string hodnoty = Soubor.IntToBinary(Soubor.byteArray[curentByte]);
                            for (int k = 0; k < 8; k++)
                            {
                                int indexPalety = (int)(hodnoty[k]) - 48;
                                e.Graphics.FillRectangle(paleta[indexPalety], j * imageScale, i * imageScale, imageScale, imageScale);
                                j++;
                                if (j > Soubor.BiWidth()-1)
                                {
                                    curentByte += Soubor.ScanlineDoplnek()/8;
                                    break;
                                }
                            }
                            curentByte++;

                        }
                    }
                }
            }
        }
    }
}