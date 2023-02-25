using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPRozbor
{
    class BMP
    {
        public byte[] byteArray;
        public BMP(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            var memoryStream = new MemoryStream();
            fs.CopyTo(memoryStream);
            byteArray = memoryStream.ToArray();
        }
        public string BfType()
        {
            return Convert.ToString(Convert.ToChar(byteArray[0])) + Convert.ToString(Convert.ToChar(byteArray[1]));//ASCII řetězce "BM"
        }
        public int BfSize()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 2, 4)); //Tyto 4 bajty určují celkovou velikost souboru s obrazovými údaji.

        }
        public int BfOffBits()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 10, 4));//Posun struktury BMP File Header od začátku vlastních obrazových dat
        }
        public int BiSize()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 14, 4)); //Tato položka specifikuje celkovou velikost datové struktury Bitmap Information.
        }
        public int BiWidth()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 18, 4));  //Tato položka udává šířku obrazu zadávanou v pixelech.
        }
        public int BiHeight()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 22, 4)); //Tato položka udává výšku obrazu zadávanou taktéž v pixelech

        }
        public int BiPlanes()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 26, 2)); //V této položce je zadaný počet bitových rovin pro výstupní zařízení.V BMP, jakožto formátu nezávislého na zařízení, je zde vždy hodnota 1
        }
        public int BiBitCount()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 28, 2)); //Tato položka udává počet bitů na pixel. V BMP jsou povoleny pouze hodnoty 1, 4, 8, 16, 24 a 32.
        }
        public int BiCompression()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 30, 4)); //Tato položka určuje typ komprese použitého pro uložení obrazových dat. V BMP jsou povoleny pouze hodnoty 0, 1, 2 a 3.
        }
        public int BiSizeImage()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 34, 4)); //Tato položka udává velikost obrazových dat v bajtech. Pokud je hodnota 0, pak je velikost obrazových dat určena způsobem, který je popsán v této stránce.
        }
        public int BiXPelsPerMeter()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 38, 4)); //Udává horizontální rozlišení výstupního zařízení v pixelech na metr. Tato hodnota může být použita například pro výběr obrazu ze skupiny obrazů, který nejlépe odpovídá rozlišení daného výstupního zařízení. Většina aplikací však nemá potřebné informace o výstupním zařízení, a proto do této položky vkládá hodnotu 0.
        }
        public int BiYPelsPerMeter()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 42, 4)); //dává vertikální rozlišení výstupního zařízení v pixelech na metr.Opět, jako u předchozí položky, zde většina programů zapisuje hodnotu 0.
        }
        public int BiClrUsed()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 46, 4)); //Udává celkový počet barev, které jsou použité v dané bitmapě.Jestliže je tato hodnota nastavena na nulu, znamená to, že bitmapa používá maximální počet barev.Tento počet lze jednoduše zjistit z položky biBitCount. Nenulová hodnota může být použita například při optimalizacích zobrazování.
        }
        public int BiClrImportant()
        {
            return OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 50, 4));//dává počet barev, které jsou důležité pro vykreslení bitmapy.Pokud je tato hodnota nulová, jsou všechny barvy důležité.Tento údaj je používán při zobrazování na zařízeních, které mají omezený počet současně zobrazitelných barev. Ovladač displeje může upravit systémovou paletu tak, aby zobrazil daný obrázek co nejvěrněji.Také je vhodné upravit paletu metodou seřazení jednotlivých barev podle důležitosti
        }
        public int ScanlineDoplnek()
        {
            double nasobek = Convert.ToDouble(OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 28, 2)) * OperaceSBMP.ByteArrayToWholeValue(OperaceSBMP.SubArray(byteArray, 18, 4)));
            return Convert.ToInt32((Math.Ceiling(nasobek / 32.0) * 32 - nasobek));
        }
        public void SaveFile(string path)
        {
            File.WriteAllBytes(path, byteArray);
        }
        public void DrawImage(Graphics g, int imageScale)
        {
            if (BiBitCount() == 24 || BiBitCount() == 32 || BiBitCount() == 16)
            {
                int curentByte = BfOffBits();
                for (int i = BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < BiWidth(); j++)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(byteArray[curentByte + 2], byteArray[curentByte + 1], byteArray[curentByte])), j * imageScale, i * imageScale, imageScale, imageScale);
                        curentByte += 3;
                    }
                    curentByte += ScanlineDoplnek() / 8;
                }
            }
            else if (BiBitCount() == 1 || BiBitCount() == 4 || BiBitCount() == 8)
            {
                int curentByte = BfOffBits();
                int pocetPalet = (int)Math.Pow(2, BiBitCount());
                Brush[] paleta = new Brush[pocetPalet];
                for (int i = 0; i < pocetPalet; i++)
                {
                    paleta[i] = new SolidBrush(Color.FromArgb(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 2], byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 1], byteArray[BfOffBits() - pocetPalet * 4 + (i * 4)]));
                }
                //if (BiBitCount() == 1)
                //{
                for (int i = BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < BiWidth();)
                    {
                        string hodnoty = OperaceSBMP.IntToBinary(byteArray[curentByte]);
                        for (int k = 0; k < 8; k += BiBitCount())
                        {
                            int indexPalety = 0;
                            if (BiBitCount() == 1) indexPalety = (int)(hodnoty[k]) - 48;
                            else if (BiBitCount() == 2) indexPalety = ((int)(hodnoty[k]) - 48) * 2 + ((int)(hodnoty[k + 1]) - 48);
                            else if (BiBitCount() == 4) indexPalety = ((int)(hodnoty[k]) - 48) * 8 + ((int)(hodnoty[k + 1]) - 48) * 4 + ((int)(hodnoty[k + 2]) - 48) * 2 + ((int)(hodnoty[k + 3]) - 48);
                            else if (BiBitCount() == 8) indexPalety = byteArray[curentByte];
                            g.FillRectangle(paleta[indexPalety], j * imageScale, i * imageScale, imageScale, imageScale);
                            j++;
                            if (j > BiWidth() - 1)
                            {
                                curentByte += ScanlineDoplnek() / 8;
                                break;
                            }
                        }
                        curentByte++;
                    }
                }
                    //}
                    /*
                else if (BiBitCount() == 8)
                {
                    for (int i = BiHeight(); i > 0; i--)
                    {
                        for (int j = 0; j < BiWidth(); j++)
                        {
                            g.FillRectangle(paleta[byteArray[curentByte]], j * imageScale, i * imageScale, imageScale, imageScale);
                            curentByte++;
                        }
                        curentByte += ScanlineDoplnek() / 8;
                    }
                }*/
            }
        }
        public void Invert()
        {
            if (BiBitCount() == 24 || BiBitCount() == 32 || BiBitCount() == 16)
            {
                int curentByte = BfOffBits();
                for (int i = BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < BiWidth() * 3; j++)
                    {
                        byteArray[curentByte] = Convert.ToByte(255 - byteArray[curentByte]);
                        curentByte++;
                    }
                    curentByte += ScanlineDoplnek() / 8;
                }

            }
            else if (BiBitCount() == 1 || BiBitCount() == 4 || BiBitCount() == 8)
            {
                int curentByte = BfOffBits();
                int pocetPalet = (int)Math.Pow(2, BiBitCount());
                Brush[] paleta = new Brush[pocetPalet];
                for (int i = 0; i < pocetPalet; i++)
                {
                    byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = Convert.ToByte(255 - Convert.ToInt32(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 2]));
                    byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = Convert.ToByte(255 - Convert.ToInt32(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 1]));
                    byteArray[BfOffBits() - pocetPalet * 4 + (i * 4)] = Convert.ToByte(255 - Convert.ToInt32(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4)]));
                }
            }
        }
        public void Rotate90Right()
        {

        }
    }
}