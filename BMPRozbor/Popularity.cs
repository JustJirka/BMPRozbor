using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPRozbor
{
    internal class Popularity
    {/*
        public static int[] PopularityQuantizationApply(int[,] colors ,int colorsNum)
        {

            for (int j = 0; j < colors.GetLength(0); j++)
            {
                for (int k = 0; k < colors.GetLength(0); k++)
                {
                    if (colors[k,4]< colors[k+1, 4])
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            int temp = colors[k, l];
                            colors[k, l] = colors[k+1, l];
                            colors[k+1, l] = temp;
                        }
                    }
                }
            }

            List<Color> topColors = new List<Color>();
            int i = colors.GetLength(0) - 1;
            int counter = 0;
            while (counter < colorsNum)
            {
                topColors.Add(myList[i].Key);

                counter++;
                i--;
            }

            #region lockbits
            BitmapData bData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

            int bitsPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat);

            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            #endregion // lockbits

            for (int x = 0; x < bitmap.Width; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    int r, g, b;

                    byte* data = scan0 + x * bData.Stride + y * bitsPerPixel / 8;

                    r = data[2];
                    g = data[1];
                    b = data[0];

                    Color currentColor = Color.FromArgb(r, g, b);
                    Color newColor = FindNearestNeighborColor(x, y, currentColor, topColors);

                    data[2] = newColor.R;
                    data[1] = newColor.G;
                    data[0] = newColor.B;
                }
            bitmap.UnlockBits(bData);

            return ImageConverters.Bitmap2BitmapImage(bitmap);
        }

        private Color FindNearestNeighborColor(int x, int y, Color currentColor, List<Color> candidateColors)
        {
            int dMin = int.MaxValue;
            Color nearestCandidate = currentColor;

            foreach (Color candidateColor in candidateColors)
            {
                int distance = CalculateDistance(currentColor, candidateColor);
                if (distance < dMin)
                {
                    dMin = distance;
                    nearestCandidate = candidateColor;
                }
            }

            return nearestCandidate;
        }

        private int CalculateDistance(Color currentColor, Color candidateColor)
        {
            int distR = candidateColor.R - currentColor.R;
            int distG = candidateColor.G - currentColor.G;
            int distB = candidateColor.B - currentColor.B;

            return (int)(Math.Pow(distR, 2) + Math.Pow(distG, 2) + Math.Pow(distB, 2));
        }*/
    }
}
