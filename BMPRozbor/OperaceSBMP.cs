using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BMPRozbor
{
    internal class OperaceSBMP
    {
        public static void Blur(ref BMP image, int blurSize)//jenom  24bit bmp 
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
                        image.byteArray[curentByte++] = (byte)((image.byteArray[curentByte] * selectedColor.B) / 255);
                        image.byteArray[curentByte++] = (byte)((image.byteArray[curentByte] * selectedColor.G) / 255);
                        image.byteArray[curentByte++] = (byte)((image.byteArray[curentByte] * selectedColor.R) / 255);

                    }
                    curentByte += image.ScanlineDoplnek() / 8;
                }
            }
            else if (image.BiBitCount() == 1 || image.BiBitCount() == 4 || image.BiBitCount() == 8)
            {
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int i = 0; i < pocetPalet; i++)
                {
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
        public static void ChangeBrightness(ref BMP image, int brightnessModifier)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            int newColor = image.byteArray[curentByte] + brightnessModifier;
                            if (newColor > 255) newColor = 255;
                            else if (newColor < 0) newColor = 0;
                            image.byteArray[curentByte] = (byte)newColor;
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
                    for (int k = 0; k < 3; k++)
                    {
                        int newColor = image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k] + brightnessModifier;
                        if (newColor > 255) newColor = 255;
                        else if (newColor < 0) newColor = 0;
                        image.byteArray[curentByte] = (byte)newColor;
                    }
                }
            }
        }
        public static void ChangeContrast(ref BMP image, decimal brightnessModifier)
        {
            if (image.BiBitCount() == 24 || image.BiBitCount() == 32 || image.BiBitCount() == 16)
            {
                int curentByte = image.BfOffBits();
                for (int i = image.BiHeight(); i > 0; i--)
                {
                    for (int j = 0; j < image.BiWidth(); j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            int newColor = (int)((image.byteArray[curentByte] - 127) * brightnessModifier);
                            if (newColor > 255) newColor = 255;
                            else if (newColor < 0) newColor = 0;
                            image.byteArray[curentByte] = (byte)newColor;
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
                    for (int k = 0; k < 3; k++)
                    {
                        int newColor = (int)((image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4) + k] - 127) * brightnessModifier);
                        if (newColor > 255) newColor = 255;
                        else if (newColor < 0) newColor = 0;
                        image.byteArray[curentByte] = (byte)newColor;
                    }
                }
            }
        }
        public static void ShiftRow(ref BMP image, int shiftValue, int rowNumber)
        {
            byte[] orignalArray = new byte[image.byteArray.Length];
            Array.Copy(image.byteArray, orignalArray, image.byteArray.Length);
            BMP originalImage = new BMP(orignalArray);
            for (int y = rowNumber; y < image.BiHeight(); y += 2)
            {
                int shiftedIndex = shiftValue;
                for (int x = 0; x < image.BiWidth(); x++)
                {
                    if (shiftedIndex < 0) shiftedIndex += image.BiWidth();
                    else if (shiftedIndex >= image.BiWidth()) shiftedIndex -= image.BiWidth();
                    int[] value = originalImage.GetPixelAtPosition(shiftedIndex, y);
                    image.SetPixelAtPosition(x, y, value);
                    shiftedIndex++;
                }
            }
        }
        public static void ShiftColumn(ref BMP image, int shiftValue, int Column)
        {
            byte[] orignalArray = new byte[image.byteArray.Length];
            Array.Copy(image.byteArray, orignalArray, image.byteArray.Length);
            BMP originalImage = new BMP(orignalArray);
            for (int x = Column; x < image.BiWidth(); x += 2)
            {
                int shiftedIndex = shiftValue;
                for (int y = 0; y < image.BiHeight(); y++)
                {
                    if (shiftedIndex < 0) shiftedIndex += image.BiWidth();
                    else if (shiftedIndex >= image.BiWidth()) shiftedIndex -= image.BiWidth();
                    int[] value = originalImage.GetPixelAtPosition(x, shiftedIndex);
                    image.SetPixelAtPosition(x, y, value);
                    shiftedIndex++;
                }
            }
        }
        public static void ApplyConvolutionMatrix(ref BMP image, int[,] matrix, int divider, int offset)
        {
            if (image.BiBitCount() == 24)
            {
                byte[] orignalArray = new byte[image.byteArray.Length];
                Array.Copy(image.byteArray, orignalArray, image.byteArray.Length);
                BMP originalImage = new BMP(orignalArray);
                for (int y = 0; y < image.BiHeight(); y++)
                {
                    for (int x = 0; x < image.BiWidth(); x++)
                    {
                        int[] newPixel = new int[3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                int newX = x - 1 + j, newY = y - 1 + i;
                                if (newX < 0) newX = 0;
                                if (newX >= image.BiWidth()) newX = image.BiWidth() - 1;
                                if (newY < 0) newY = 0;
                                if (newY >= image.BiWidth()) newY = image.BiHeight() - 1;
                                int[] pixel = originalImage.GetPixelAtPosition(newX, newY);
                                newPixel[0] += pixel[0] * matrix[j, i];
                                newPixel[1] += pixel[1] * matrix[j, i];
                                newPixel[2] += pixel[2] * matrix[j, i];
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            newPixel[i] /= divider;
                            newPixel[i] += offset;
                            if (newPixel[i] > 255) newPixel[i] = 255;
                            else if (newPixel[i] < 0) newPixel[i] = 0;
                        }
                        image.SetPixelAtPosition(x, y, newPixel);
                    }
                }
            }
        }

        public static void ApplyTrasformationMatrix(ref BMP image, double[,] transformationMatrix)
        {
            // saving some stats to adjust the image later  
            int minX = 0, minY = 0;
            int maxX = 0, maxY = 0;
            minX = (int)Math.Min(minX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { 0 } })[0, 0]));
            minY = (int)Math.Min(minY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { 0 } })[1, 0]));
            minX = (int)Math.Min(minX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { 0 } })[0, 0]));
            minY = (int)Math.Min(minY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { 0 } })[1, 0]));
            minX = (int)Math.Min(minX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { image.BiHeight() - 1 } })[0, 0]));
            minY = (int)Math.Min(minY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { image.BiHeight() - 1 } })[1, 0]));
            minX = (int)Math.Min(minX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { image.BiHeight() - 1 } })[0, 0]));
            minY = (int)Math.Min(minY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { image.BiHeight() - 1 } })[1, 0]));
            maxX = (int)Math.Min(maxX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { 0 } })[0, 0]));
            maxY = (int)Math.Max(maxY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { 0 } })[1, 0]));
            maxX = (int)Math.Max(maxX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { 0 } })[0, 0]));
            maxY = (int)Math.Max(maxY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { 0 } })[1, 0]));
            maxX = (int)Math.Max(maxX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { image.BiHeight() - 1 } })[0, 0]));
            maxY = (int)Math.Max(maxY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { image.BiWidth() - 1 }, { image.BiHeight() - 1 } })[1, 0]));
            maxX = (int)Math.Max(maxX, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { image.BiHeight() - 1 } })[0, 0]));
            maxY = (int)Math.Max(maxY, Math.Floor(PomocneMetody.MultiplyMatrix(transformationMatrix, new double[,] { { 0 }, { image.BiHeight() - 1 } })[1, 0]));

            int width = maxX - minX + 1;
            int height = maxY - minY + 1;

            double[,] invertedMatrix = PomocneMetody.ConvertJagedToMultidimensional(PomocneMetody.MatrixInverse(PomocneMetody.ConvertMultidimensionalToJagedTo(transformationMatrix)));

            int[,,] newImage = new int[width, height, 3];
            // scanning points and applying transformations 
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double[,] product = PomocneMetody.MultiplyMatrix(invertedMatrix, new double[,] { { x + minX }, { y + minY } });

                    int newX = (int)Math.Round(product[0, 0]);
                    int newY = (int)Math.Round(product[1, 0]);
                    if (newX > image.BiWidth() - 1 || newX < 0 || newY > image.BiHeight() - 1 || newY < 0)
                    {
                        newImage[x, y, 0] = 255;
                        newImage[x, y, 1] = 255;
                        newImage[x, y, 2] = 255;
                    }
                    else
                    {
                        newImage[x, y, 0] = image.byteArray[image.BfOffBits() + (newY * image.Scanline() / 8 + newX * 3)];
                        newImage[x, y, 1] = image.byteArray[image.BfOffBits() + (newY * image.Scanline() / 8 + newX * 3) + 1];
                        newImage[x, y, 2] = image.byteArray[image.BfOffBits() + (newY * image.Scanline() / 8 + newX * 3) + 2];
                    }
                }
            }
            double nasobek = Convert.ToDouble(image.BiBitCount() * width);
            int scanline = Convert.ToInt32((Math.Ceiling(nasobek / 32.0) * 32));
            int scanlineDoplnek = Convert.ToInt32(scanline - nasobek);
            byte[] newByteArray = new byte[image.BfOffBits() + scanline / 8 * height];
            Array.Copy(image.byteArray, 0, newByteArray, 0, image.BfOffBits());
            byte[] biWidth = PomocneMetody.IntToByteArray((uint)width, 4);
            Array.Copy(biWidth, 0, newByteArray, 18, 4);
            byte[] biHeight = PomocneMetody.IntToByteArray((uint)height, 4);
            Array.Copy(biHeight, 0, newByteArray, 22, 4);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newByteArray[image.BfOffBits() + (y * scanline / 8 + x * 3)] = Convert.ToByte(newImage[x, y, 0]);
                    newByteArray[image.BfOffBits() + (y * scanline / 8 + x * 3) + 1] = Convert.ToByte(newImage[x, y, 1]);
                    newByteArray[image.BfOffBits() + (y * scanline / 8 + x * 3) + 2] = Convert.ToByte(newImage[x, y, 2]);
                }
            }
            image.byteArray = newByteArray;

        }
        public static void ConvertToXBit(ref BMP image, int newBitCount)
        {
            int newScanline = Convert.ToInt32((Math.Ceiling(Convert.ToDouble(newBitCount * image.BiWidth()) / 32.0) * 32));
            byte[] newByteArray = new byte[(54 + (int)Math.Pow(2, newBitCount) * 4) + newScanline * image.BiHeight()];
            Array.Copy(image.byteArray, newByteArray, 54);
            BMP newImage = new BMP(newByteArray);
            newImage.byteArray[28] = Convert.ToByte(newBitCount);
            byte[] bfOffBits = PomocneMetody.IntToByteArray((uint)(54 + (int)Math.Pow(2, newBitCount) * 4), 4);
            Array.Copy(bfOffBits, 0, newImage.byteArray, 10, 4);
            if (newBitCount == 1)
            {
                GrayscaleThreshold(ref image, 127);
                for (int k = 0; k < 3; k++) newImage.byteArray[newImage.BfOffBits() - 2 * 4 + k] = 255;
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                int[] paleta = new int[pocetPalet];
                if (image.BiBitCount() < 24)
                {
                    for (int i = 0; i < pocetPalet; i++)
                    {
                        if (image.byteArray[image.BfOffBits() - pocetPalet * 4 + (i * 4)] > 0) paleta[i] = 1;
                        else paleta[i] = 0;
                    }
                }
                for (int y = 0; y < newImage.BiHeight(); y++)
                {
                    for (int x = 0; x < newImage.BiWidth(); x++)
                    {
                        int indexColor;
                        if (image.BiBitCount() < 24) indexColor = paleta[image.GetPixelAtPosition(x, y)[0]];
                        else if (image.GetPixelAtPosition(x, y)[0] > 125) indexColor = 1;
                        else indexColor = 0;
                        int[] newBitValue = { indexColor };
                        newImage.SetPixelAtPosition(x, y, newBitValue);
                    }
                }

            }
            else if (newBitCount == 4)
            {
                if (newBitCount < image.BiBitCount())
                {

                }
                else
                {
                    for (int y = 0; y < image.BiHeight(); y++)
                    {
                        for (int x = 0; x < image.BiWidth(); x++)
                        {
                            newImage.SetPixelAtPosition(x, y, image.GetPixelAtPosition(x, y));
                        }
                    }
                }

            }
            else if (newBitCount == 8)
            {
                if (newBitCount < image.BiBitCount())
                {

                }
                else
                {
                    for (int y = 0; y < image.BiHeight(); y++)
                    {
                        for (int x = 0; x < image.BiWidth(); x++)
                        {
                            newImage.SetPixelAtPosition(x, y, image.GetPixelAtPosition(x, y));
                        }
                    }
                }

            }
            else if (newBitCount == 24)
            {
                int pocetPalet = (int)Math.Pow(2, image.BiBitCount());
                for (int y = 0; y < newImage.BiHeight(); y++)
                {
                    for (int x = 0; x < newImage.BiWidth(); x++)
                    {
                        int[] color = new int[3];
                        for (int i = 0; i < 3; i++) color[2 - i] = image.byteArray[image.BfOffBits() - pocetPalet * 4 + (image.GetPixelAtPosition(x, y)[0] * 4 + i)];
                        newImage.SetPixelAtPosition(x, y, color);
                    }
                }
            }
            image = newImage;
        }
    }
}
