using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            fs.Close();
        }
        public BMP(byte[] pole) 
        {
            byteArray = pole;
        }
        public string BfType()
        {
            return Convert.ToString(Convert.ToChar(byteArray[0])) + Convert.ToString(Convert.ToChar(byteArray[1]));//ASCII řetězce "BM"
        }
        public int BfSize()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 2, 4)); //Tyto 4 bajty určují celkovou velikost souboru s obrazovými údaji.
        }
        public int BfOffBits()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 10, 4));//Posun struktury BMP File Header od začátku vlastních obrazových dat
        }
        public int BiSize()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 14, 4)); //Tato položka specifikuje celkovou velikost datové struktury Bitmap Information.
        }
        public int BiWidth()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 18, 4));  //Tato položka udává šířku obrazu zadávanou v pixelech.
        }
        public int BiHeight()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 22, 4)); //Tato položka udává výšku obrazu zadávanou taktéž v pixelech
        }
        public int BiPlanes()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 26, 2)); //V této položce je zadaný počet bitových rovin pro výstupní zařízení.V BMP, jakožto formátu nezávislého na zařízení, je zde vždy hodnota 1
        }
        public int BiBitCount()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 28, 2)); //Tato položka udává počet bitů na pixel. V BMP jsou povoleny pouze hodnoty 1, 4, 8, 16, 24 a 32.
        }
        public int BiCompression()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 30, 4)); //Tato položka určuje typ komprese použitého pro uložení obrazových dat. V BMP jsou povoleny pouze hodnoty 0, 1, 2 a 3.
        }
        public int BiSizeImage()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 34, 4)); //Tato položka udává velikost obrazových dat v bajtech. Pokud je hodnota 0, pak je velikost obrazových dat určena způsobem, který je popsán v této stránce.
        }
        public int BiXPelsPerMeter()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 38, 4)); //Udává horizontální rozlišení výstupního zařízení v pixelech na metr. Tato hodnota může být použita například pro výběr obrazu ze skupiny obrazů, který nejlépe odpovídá rozlišení daného výstupního zařízení. Většina aplikací však nemá potřebné informace o výstupním zařízení, a proto do této položky vkládá hodnotu 0.
        }
        public int BiYPelsPerMeter()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 42, 4)); //dává vertikální rozlišení výstupního zařízení v pixelech na metr.Opět, jako u předchozí položky, zde většina programů zapisuje hodnotu 0.
        }
        public int BiClrUsed()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 46, 4)); //Udává celkový počet barev, které jsou použité v dané bitmapě.Jestliže je tato hodnota nastavena na nulu, znamená to, že bitmapa používá maximální počet barev.Tento počet lze jednoduše zjistit z položky biBitCount. Nenulová hodnota může být použita například při optimalizacích zobrazování.
        }
        public int BiClrImportant()
        {
            return PomocneMetody.ByteArrayToWholeValue(PomocneMetody.SubArray(byteArray, 50, 4));//dává počet barev, které jsou důležité pro vykreslení bitmapy.Pokud je tato hodnota nulová, jsou všechny barvy důležité.Tento údaj je používán při zobrazování na zařízeních, které mají omezený počet současně zobrazitelných barev. Ovladač displeje může upravit systémovou paletu tak, aby zobrazil daný obrázek co nejvěrněji.Také je vhodné upravit paletu metodou seřazení jednotlivých barev podle důležitosti
        }
        public int Scanline()
        {
            double nasobek = Convert.ToDouble(BiBitCount() * BiWidth());
            return Convert.ToInt32((Math.Ceiling(nasobek / 32.0) * 32));
        }
        public int ScanlineDoplnek()
        {
            double nasobek = Convert.ToDouble(BiBitCount() * BiWidth());
            return Convert.ToInt32((Math.Ceiling(nasobek / 32.0) * 32 - nasobek));
        }
        public void SaveFile(string path)
        {
            File.WriteAllBytes(path, byteArray);
        }
        public int[] GetPixelAtPosition(int x, int y)//chyba v 8 bit obrázkach
        {
            int byteOffset = BfOffBits()*8 + y * Scanline()+ x * BiBitCount(); // calculate the byte offset for the pixel
            if (BiBitCount() == 1 || BiBitCount() == 4 || BiBitCount() == 8 || BiBitCount() == 16)
            {
                string hodnota = PomocneMetody.IntToBinary(byteArray[byteOffset / 8]);
                StringBuilder hodnota2 = new StringBuilder();
                for (int i = 0; i < BiBitCount(); i++) hodnota2.Append(hodnota[x*BiBitCount() % 8 + i]);
                int[] vystup = { PomocneMetody.BinaryToInt(hodnota2.ToString()) };
                return vystup;
            }
            else
            {
                int[] hodnota = { byteArray[byteOffset/8 + 2], byteArray[byteOffset / 8 + 1], byteArray[byteOffset / 8] };
                return hodnota;
            }
        }
        public void SetPixelAtPosition(int x, int y, int[] setValue)//chyba v 8 bit obrázkach
        {
            int byteOffset = BfOffBits() * 8 + y * Scanline() + x * BiBitCount(); // calculate the byte offset for the pixel
            if (BiBitCount() == 1 || BiBitCount() == 2 || BiBitCount() == 4 || BiBitCount() == 8 || BiBitCount() == 16)
            {
                int byteIndex = byteOffset/8;
                int bitOffset = BiBitCount()*x % 8;
                string binaryValue = PomocneMetody.IntToBinary( byteArray[byteIndex]); // get the binary representation of the byte at byteIndex 
                for (int i = 0; i < BiBitCount(); i++)
                {
                    int pos = bitOffset + i;
                    int setValueBit = (setValue[0] >> i) & 1; // get the i-th bit of the setValue
                    if (BiBitCount() == 4) pos = bitOffset + 3 - i;
                    if (BiBitCount() == 8) pos = bitOffset + 7 - i;
                    if (pos < 8)
                    {
                        binaryValue = binaryValue.Remove(pos, 1).Insert(pos, setValueBit.ToString()); // set the bit value of the binary string
                    }
                    else break;
                }
                byteArray[byteIndex] = (byte)PomocneMetody.BinaryToInt(binaryValue); //convert the binary string back to byte and update the byte array
            }
            else
            {
                byteArray[byteOffset/8 + 2] = Convert.ToByte(setValue[0]); // blue channel
                byteArray[byteOffset/8 + 1] = Convert.ToByte(setValue[1]); // green channel
                byteArray[byteOffset/8] = Convert.ToByte(setValue[2]); // red channel
            }
        }
        public void DrawImage(Graphics g, int imageScale)
        {
            if (BiBitCount() == 1 || BiBitCount() == 4 || BiBitCount() == 8)
            {
                int curentByte = BfOffBits();
                int pocetPalet = (int)Math.Pow(2, BiBitCount());
                Brush[] paleta = new Brush[pocetPalet];
                for (int i = 0; i < pocetPalet; i++)
                {
                    paleta[i] = new SolidBrush(Color.FromArgb(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 2], byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 1], byteArray[BfOffBits() - pocetPalet * 4 + (i * 4)]));
                }
                for (int i = BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < BiWidth();)
                    {
                        string hodnoty = PomocneMetody.IntToBinary(byteArray[curentByte]);
                        for (int k = 0; k < 8; k += BiBitCount())
                        {
                            int indexPalety = 0;
                            if (BiBitCount() == 1) indexPalety = (int)(hodnoty[k]) - 48;
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
            }
            else if (BiBitCount() == 24)
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
                int pocetPalet = (int)Math.Pow(2, BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = Convert.ToByte(255 - Convert.ToInt32(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 2]));
                    byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = Convert.ToByte(255 - Convert.ToInt32(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4) + 1]));
                    byteArray[BfOffBits() - pocetPalet * 4 + (i * 4)] = Convert.ToByte(255 - Convert.ToInt32(byteArray[BfOffBits() - pocetPalet * 4 + (i * 4)]));
                }
            }
        }
        public void MirrorHorizontal()
        {
            int bytusirka = 0;
            if (BiBitCount() == 1) bytusirka = BiWidth() / 8;
            else if (BiBitCount() == 4) bytusirka = BiWidth() / 2;
            else if (BiBitCount() == 8) bytusirka = BiWidth();
            else if (BiBitCount() == 16) bytusirka = BiWidth() * 2;
            else if (BiBitCount() == 24) bytusirka = BiWidth() * 3;
            else if (BiBitCount() == 32) bytusirka = BiWidth() * 4;
            byte[] MirroredArray = new byte[byteArray.Length];
            Array.Copy(byteArray, MirroredArray, byteArray.Length);
            int curentByte = BfOffBits();
            for (int i = BiHeight() - 1; i >= 0; i--)
            {
                for (int j = 0; j < bytusirka; j++)
                {
                    int byteOffset =((BfOffBits() * 8 + i * (BiWidth() * BiBitCount() + ScanlineDoplnek()))/8 + j); // calculate the byte offset for the pixel

                    MirroredArray[curentByte] = byteArray[byteOffset];
                    curentByte++;
                }
                curentByte += ScanlineDoplnek() / 8;
            }
            byteArray = MirroredArray;
        }
    }
}