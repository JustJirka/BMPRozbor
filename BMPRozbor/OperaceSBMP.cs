using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BMPRozbor
{
    internal class OperaceSBMP
    {
        //10.leave color
        //11. Color Exchange
        //13 rotate RGB
        public static T[] SubArray<T>(T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static int ByteArrayToWholeValue(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            for (int i = ba.Length - 1; i >= 0; i--)
            {
                hex.AppendFormat("{0:x2}", ba[i]);
            }
            return int.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
        public static string IntToBinary(int vstup)
        {
            string vystup = "";
            for (int i = 128; i > 0; i /= 2)
            {
                if (vstup - i >= 0)
                {
                    vstup -= i;
                    vystup += 1;
                }
                else
                {
                    vystup += 0;
                }
            }
            return vystup;
        }
        public static int BinaryToInt(string vstup)
        {
            int vystup = 0;
            int nasobek = 1;
            for (int i = 1; i <= vstup.Length; i++)
            {
                vystup += int.Parse(vstup[vstup.Length - i].ToString()) * nasobek;
                nasobek *= 2;
            }
            return vystup;
        }
        public static BMP Blur(BMP image, int blurSize)//jenom  24bit bmp 
        {
            for (int imageY = 0; imageY < image.BiHeight(); imageY += image.BiHeight() / blurSize)
            {
                for (int imageX = 0; imageX < image.BiHeight(); imageX += image.BiWidth() / blurSize)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;
                    for (int blurX = imageX; blurX < imageX + image.BiWidth() / blurSize; blurX++)
                    {
                        for (int blurY = imageY; blurY < imageY + image.BiHeight() / blurSize; blurY++)
                        {
                            // average the color of the red, green and blue for each pixel in the blur size while making sure you don't go outside the image bounds
                            int[] colorData = image.GetPixelAtPosition(blurX, blurY);

                            avgR += colorData[2];
                            avgG += colorData[1];
                            avgB += colorData[0];

                            blurPixelCount++;
                        }
                    }
                    avgR /= blurPixelCount;
                    avgG /= blurPixelCount;
                    avgB /= blurPixelCount;
                    int[] setValue = { avgB, avgG, avgR };

                    //  set each pixel to that color
                    for (int blurX = imageX; blurX < imageX + (image.BiHeight() / blurSize); blurX++)
                    {
                        for (int blurY = imageY; blurY < imageY + (image.BiWidth() / blurSize); blurY++)
                        {
                            image.SetPixelAtPosition(blurX, blurY, setValue);
                        }

                    }

                }
            }
            return image;
        }
        public static BMP Mirror(BMP image)
        {
            byte[] mirroredArray = new byte[image.byteArray.Length];
            Array.Copy(image.byteArray, mirroredArray, image.byteArray.Length);
            BMP mirroredImage = new BMP(mirroredArray);
            if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                for (int i = 0; i < image.BiHeight(); i++)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int[] value = { image.GetPixelAtPosition(image.BiWidth() - j - 1, i)[0] };
                        mirroredImage.SetPixelAtPosition(j, i, value);
                    }
                }
            }
            else if (image.BiBitCount() == 16 || image.BiBitCount() == 24 || image.BiBitCount() == 32)
            {
                for (int i = 0; i < image.BiHeight(); i++)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int bytesPerPixel = image.BiBitCount() / 8;
                        int currentPixelIndex = i * image.BiWidth() + j;
                        int currentByteIndex = image.BfOffBits() + currentPixelIndex * bytesPerPixel;
                        int mirroredPixelIndex = i * image.BiWidth() + (image.BiWidth() - j - 1);
                        int mirroredByteIndex = image.BfOffBits() + mirroredPixelIndex * bytesPerPixel;
                        mirroredImage.byteArray[mirroredByteIndex] = image.byteArray[currentByteIndex];
                        mirroredImage.byteArray[mirroredByteIndex + 1] = image.byteArray[currentByteIndex + 1];
                        mirroredImage.byteArray[mirroredByteIndex + 2] = image.byteArray[currentByteIndex + 2];
                    }
                }

            }
            return mirroredImage;
        }
        public static void GrayscaleByAveraging(ref BMP image)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int color = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            color += image.byteArray[curentByte];
                            curentByte++;
                        }
                        curentByte -= 3;
                        for (int k = 0; k < 3; k++)
                        {
                            image.byteArray[curentByte] = Convert.ToByte(color / 3);
                            curentByte++;
                        }
                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int color = 0;
                    for (int k = 0; k < 3; k++) color += image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k];
                    for (int k = 0; k < 3; k++) image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k] = Convert.ToByte(color / 3);
                }
            }
        }
        public static void GrayscaleEpirical(ref BMP image)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int empir = (299 * image.byteArray[curentByte + 2] + 587 * image.byteArray[curentByte + 1] + 114 * image.byteArray[curentByte]) / 1000;
                        for (int k = 0; k < 3; k++)
                        {
                            image.byteArray[curentByte] = (byte)empir;
                            curentByte++;
                        }

                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int empir = (299 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 587 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 114 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    for (int k = 0; k < 3; k++) image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k] = (byte)empir;
                }
            }
        }
        public static void GrayscaleTransition(ref BMP image)//24 bit
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int s = (299 * image.byteArray[curentByte + 2] + 587 * image.byteArray[curentByte + 1] + 114 * image.byteArray[curentByte]) / 1000;
                        for (int k = 0; k < 3; k++)
                        {
                            image.byteArray[curentByte] = (byte)(((image.BiWidth() - 1 - j) * s + j * image.byteArray[curentByte]) / image.BiWidth());
                            curentByte++;
                        }

                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                /*int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int empir = (299 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 587 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 114 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    for (int k = 0; k < 3; k++) image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k] = (byte)empir;
                }*/
            }
        }
        public static void GrayscaleThreshold(ref BMP image, int threshold)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int color = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            color += image.byteArray[curentByte];
                            curentByte++;
                        }
                        if (color / 3 < threshold) color = 255;
                        else color = 0;
                        curentByte -= 3;
                        for (int k = 0; k < 3; k++)
                        {
                            image.byteArray[curentByte] = Convert.ToByte(color);
                            curentByte++;
                        }
                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int color = 0;
                    for (int k = 0; k < 3; k++) color += image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k];
                    if (color / 3 < threshold) color = 255;
                    else color = 0;
                    for (int k = 0; k < 3; k++) image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k] = Convert.ToByte(color / 3);
                }
            }
        }
        public static void Sepie(ref BMP image)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int red = (393 * image.byteArray[curentByte + 2] + 769 * image.byteArray[curentByte + 1] + 189 * image.byteArray[curentByte]) / 1000;
                        if (red > 255) red = 255;
                        int green = (349 * image.byteArray[curentByte + 2] + 686 * image.byteArray[curentByte + 1] + 168 * image.byteArray[curentByte]) / 1000;
                        if (green > 255) green = 255;
                        int blue = (272 * image.byteArray[curentByte + 2] + 534 * image.byteArray[curentByte + 1] + 131 * image.byteArray[curentByte]) / 1000;
                        if (blue > 255) blue = 255;
                        image.byteArray[curentByte++] = (byte)blue;
                        image.byteArray[curentByte++] = (byte)green;
                        image.byteArray[curentByte++] = (byte)red;

                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int red = (393 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 769 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 189 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    if (red > 255) red = 255;
                    int green = (349 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 686 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 168 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    if (green > 255) green = 255;
                    int blue = (272 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 534 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 131 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    if (blue > 255) blue = 255;
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = (byte)blue;
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = (byte)green;
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = (byte)red;
                }
            }
        }
        public static void OneColorShades(ref BMP image, Color selectedColor)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int empir = (299 * image.byteArray[curentByte + 2] + 587 * image.byteArray[curentByte + 1] + 114 * image.byteArray[curentByte]) / 1000;
                        image.byteArray[curentByte++] = (byte)((empir * selectedColor.B) / 255);
                        image.byteArray[curentByte++] = (byte)((empir * selectedColor.G) / 255);
                        image.byteArray[curentByte++] = (byte)((empir * selectedColor.R) / 255);

                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int empir = (299 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 587 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 114 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = (byte)((empir * selectedColor.B) / 255);
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = (byte)((empir * selectedColor.G) / 255);
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = (byte)((empir * selectedColor.R) / 255);
                }
            }
        }
        public static void PhotoFiltr(ref BMP image, Color selectedColor)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int empir = (299 * image.byteArray[curentByte + 2] + 587 * image.byteArray[curentByte + 1] + 114 * image.byteArray[curentByte]) / 1000;
                        image.byteArray[curentByte++] = (byte)((image.byteArray[curentByte] * selectedColor.B) / 255);
                        image.byteArray[curentByte++] = (byte)((image.byteArray[curentByte] * selectedColor.G) / 255);
                        image.byteArray[curentByte++] = (byte)((image.byteArray[curentByte] * selectedColor.R) / 255);

                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }
            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int empir = (299 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] + 587 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] + 114 * image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) / 1000;
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = (byte)((image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)]) * selectedColor.B / 255);
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = (byte)((image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1]) * selectedColor.G / 255);
                    image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = (byte)((image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2]) * selectedColor.R / 255);
                }
            }
        }
        public static void OnlyRGB(ref BMP image, int RGB)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        if (RGB == 0)
                        {
                            image.byteArray[curentByte++] = 0;
                            image.byteArray[curentByte++] = 0;
                            curentByte++;
                        }
                        else if (RGB == 1)
                        {
                            image.byteArray[curentByte++] = 0;
                            curentByte++;
                            image.byteArray[curentByte++] = 0;
                        }
                        else if (RGB == 2)
                        {
                            curentByte++;
                            image.byteArray[curentByte++] = 0;
                            image.byteArray[curentByte++] = 0;
                        }
                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    if (RGB == 0)
                    {
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = 0;
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = 0;
                    }
                    else if (RGB == 1)
                    {
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = 0;
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = 0;
                    }
                    else if (RGB == 2)
                    {
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = 0;
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = 0;
                    }
                }
            }
        }
        public static void MajorityColor(ref BMP image)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        int R = image.byteArray[curentByte++];
                        int G = image.byteArray[curentByte++];
                        int B = image.byteArray[curentByte++];
                        if (R > G && R > B)
                        {
                            image.byteArray[curentByte - 2] = 0;
                            image.byteArray[curentByte - 1] = 0;
                        }
                        else if (G > B && G > R)
                        {
                            image.byteArray[curentByte] = 0;
                            image.byteArray[curentByte - 1] = 0;
                        }
                        else if (G > B && G > R)
                        {
                            image.byteArray[curentByte - 2] = 0;
                            image.byteArray[curentByte] = 0;
                        }
                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }

            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int curentByte = image.BfOffBits();
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
                    int R = image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2];
                    int G = image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1];
                    int B = image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)];
                    if (R > G && R > B)
                    {
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = 0;
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = 0;
                    }
                    else if (G > B && G > R)
                    {
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] = 0;
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = 0;
                    }
                    else if (G > B && G > R)
                    {
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 1] = 0;
                        image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + 2] = 0;
                    }
                }
            }
        }

    }
}
