using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BMPRozbor
{
    internal class OperaceSBMP
    {
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
        public static BMP Blur(BMP image, int blurSize)
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
        public static BMP Grayscale(BMP image)
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
            return image;
        }
    }
}
