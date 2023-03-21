using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BMPRozbor
{
    internal class PomocneMetody
    {
        public static double[,] MultiplyMatrix(double[,] matrix1, double[,] matrix2)
        {
            // cahing matrix lengths for better performance  
            var matrix1Rows = matrix1.GetLength(0);
            var matrix1Cols = matrix1.GetLength(1);
            var matrix2Rows = matrix2.GetLength(0);
            var matrix2Cols = matrix2.GetLength(1);

            // checking if product is defined  
            if (matrix1Cols != matrix2Rows)
                throw new InvalidOperationException
                  ("Product is undefined. n columns of first matrix must equal to n rows of second matrix");

            // creating the final product matrix  
            double[,] product = new double[matrix1Rows, matrix2Cols];

            // looping through matrix 1 rows  
            for (int matrix1_row = 0; matrix1_row < matrix1Rows; matrix1_row++)
            {
                // for each matrix 1 row, loop through matrix 2 columns  
                for (int matrix2_col = 0; matrix2_col < matrix2Cols; matrix2_col++)
                {
                    // loop through matrix 1 columns to calculate the dot product  
                    for (int matrix1_col = 0; matrix1_col < matrix1Cols; matrix1_col++)
                    {
                        product[matrix1_row, matrix2_col] +=
                          matrix1[matrix1_row, matrix1_col] *
                          matrix2[matrix1_col, matrix2_col];
                    }
                }
            }

            return product;
        }
        public static double[][] MatrixInverse(double[][] matrix)
        {
            // assumes determinant is not 0
            // that is, the matrix does have an inverse
            int n = matrix.Length;
            double[][] result = MatrixCreate(n, n); // make a copy of matrix
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    result[i][j] = matrix[i][j];

            double[][] lum; // combined lower & upper
            int[] perm;
            int toggle;
            toggle = MatrixDecompose(matrix, out lum, out perm);

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;

                double[] x = Helper(lum, b); // 
                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }
        static int MatrixDecompose(double[][] m, out double[][] lum, out int[] perm)
        {
            // Crout's LU decomposition for matrix determinant and inverse
            // stores combined lower & upper in lum[][]
            // stores row permuations into perm[]
            // returns +1 or -1 according to even or odd number of row permutations
            // lower gets dummy 1.0s on diagonal (0.0s above)
            // upper gets lum values on diagonal (0.0s below)

            int toggle = +1; // even (+1) or odd (-1) row permutatuions
            int n = m.Length;

            // make a copy of m[][] into result lu[][]
            lum = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    lum[i][j] = m[i][j];


            // make perm[]
            perm = new int[n];
            for (int i = 0; i < n; ++i)
                perm[i] = i;

            for (int j = 0; j < n - 1; ++j) // process by column. note n-1 
            {
                double max = Math.Abs(lum[j][j]);
                int piv = j;

                for (int i = j + 1; i < n; ++i) // find pivot index
                {
                    double xij = Math.Abs(lum[i][j]);
                    if (xij > max)
                    {
                        max = xij;
                        piv = i;
                    }
                } // i

                if (piv != j)
                {
                    double[] tmp = lum[piv]; // swap rows j, piv
                    lum[piv] = lum[j];
                    lum[j] = tmp;

                    int t = perm[piv]; // swap perm elements
                    perm[piv] = perm[j];
                    perm[j] = t;

                    toggle = -toggle;
                }

                double xjj = lum[j][j];
                if (xjj != 0.0)
                {
                    for (int i = j + 1; i < n; ++i)
                    {
                        double xij = lum[i][j] / xjj;
                        lum[i][j] = xij;
                        for (int k = j + 1; k < n; ++k)
                            lum[i][k] -= xij * lum[j][k];
                    }
                }

            } // j

            return toggle;
        }

        static double[] Helper(double[][] luMatrix, double[] b)
        {
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }
        public static byte[] IntToByteArray(uint vstup, int byteCount)
        {
            byte[] byteArray = new byte[byteCount];
            string vystup = "";
            for (uint i = (uint)Math.Pow(2, (double)(byteCount) * 8 - 1); i > 0; i /= 2)
            {
                if (vstup >= i)
                {
                    vstup -= i;
                    vystup += 1;
                }
                else
                {
                    vystup += 0;
                }
            }
            for (int i = 0; i < byteCount; i++)
            {
                byteArray[byteCount - i - 1] = Convert.ToByte(BinaryToInt(vystup.Substring(i * 8, 8)));
            }
            return byteArray;
        }
        public static double[][] ConvertMultidimensionalToJagedTo(double[,] multiDimensionalArray)
        {
            double[][] jagedArray = new double[multiDimensionalArray.GetLength(0)][];
            for (int i = 0; i < multiDimensionalArray.GetLength(0); i++)
            {
                jagedArray[i] = new double[multiDimensionalArray.GetLength(1)];
                for (int j = 0; j < multiDimensionalArray.GetLength(1); j++)
                {
                    jagedArray[i][j] = multiDimensionalArray[i, j];
                }
            }
            return jagedArray;
        }

        public static double[,] ConvertJagedToMultidimensional(double[][] multiDimensionalArray)
        {
            double[,] jagedArray = new double[multiDimensionalArray.Length, multiDimensionalArray[0].Length];
            for (int i = 0; i < multiDimensionalArray.Length; i++)
            {
                for (int j = 0; j < multiDimensionalArray[0].Length; j++)
                {
                    jagedArray[i, j] = multiDimensionalArray[i][j];
                }
            }
            return jagedArray;
        }
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
        public static int GetClosestColor(List<Color> paleta, Color color)
        {
            int closestColor = 0;
            int distance = 256 * 3;
            for (int i = 0; i < paleta.Count; i++)
            {
                int currentDistance = Math.Abs(paleta[i].R - color.R) + Math.Abs(paleta[i].B - color.B) + Math.Abs(paleta[i].G - color.G);
                if (currentDistance < distance)
                {
                    closestColor = i;
                    distance = currentDistance;
                }
            }
            return closestColor;
        }
    }
}
