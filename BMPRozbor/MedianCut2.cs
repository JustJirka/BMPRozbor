using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPRozbor
{
    internal class MedianCut2
    {
        //private List<Color> _palette;

        public static List<Color> GeneratePalette(List<Color> pixels, int paletteSize)
        {
            var colorCubes = new List<ColorCube> { new ColorCube(pixels) };
            List<int> skipIndex = new List<int>();
            while (colorCubes.Count < paletteSize && skipIndex.Count < colorCubes.Count)
            {
                var longestCubeIndex = 0;
                var longestCubeLength = 0;

                // Find the cube with the longest dimension
                for (var i = 0; i < colorCubes.Count; i++)
                {
                    if (skipIndex.Contains(i))
                        continue;
                    var length = colorCubes[i].LongestDimensionLength();
                    if (length > longestCubeLength)
                    {
                        longestCubeLength = length;
                        longestCubeIndex = i;
                    }
                }

                // Split the longest cube into two new cubes
                var newCubes = colorCubes[longestCubeIndex].Split();
                if (newCubes.Count == 1)
                {
                    skipIndex.Add(longestCubeIndex);
                }
                else
                {
                    colorCubes.RemoveAt(longestCubeIndex);
                    colorCubes.AddRange(newCubes);
                }
            }

            List<Color> _palette = colorCubes.Select(c => c.GetAverageColor()).ToList();
            return _palette;
        }
        public static int GetClosestColor(List<Color> paleta, Pixel color)
        {
            int closestColor = 0;
            int distance = 256 * 3;
            for (int i = 0; i < paleta.Count; i++)
            {
                Color pixel = paleta[i];
                int currentDistance = Math.Abs(pixel.R - color.Red) + Math.Abs(pixel.B - color.Blue) + Math.Abs(pixel.G - color.Green);
                if (currentDistance < distance)
                {
                    closestColor = i;
                    distance = currentDistance;
                }
            }
            return closestColor;
        }
        private class ColorCube
        {
            private List<Color> _colors;
            private int _minR, _maxR, _minG, _maxG, _minB, _maxB;

            public ColorCube(List<Color> colors)
            {
                _colors = colors;
                FindBounds();
            }

            public Color GetAverageColor()
            {
                var r = _colors.Average(c => c.R);
                var g = _colors.Average(c => c.G);
                var b = _colors.Average(c => c.B);
                return Color.FromArgb((int)r, (int)g, (int)b);
                /*int r = 0, g = 0, b = 0;
                foreach (var color in _colors)
                {
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }
                r = r / _colors.Count;
                g = g / _colors.Count;
                b = b / _colors.Count;
                return Color.FromArgb(r, g, b);*/
            }

            public int LongestDimensionLength()
            {
                var r = _maxR - _minR;
                var g = _maxG - _minG;
                var b = _maxB - _minB;
                return Math.Max(Math.Max(r, g), b);
            }

            public List<ColorCube> Split()
            {
                var cubes = new List<ColorCube>();

                if (LongestDimensionLength() == 0)
                {
                    cubes.Add(this);
                    return cubes;
                }

                var splitColor = GetSplitColor();
                var colors1 = new List<Color>();
                var colors2 = new List<Color>();
                double avarageDistance = 0;
                foreach (var color in _colors)
                {
                    avarageDistance += Math.Sqrt(Math.Pow(color.R - splitColor.R, 2) + Math.Pow(color.G - splitColor.G, 2) + Math.Pow(color.B - splitColor.B, 2));
                }
                avarageDistance /= _colors.Count;
                foreach (var color in _colors)
                {
                    /*//if (color.R <= splitColor.R && color.G <= splitColor.G && color.B <= splitColor.B)
                    if (Math.Sqrt(Math.Pow(color.R - splitColor.R, 2) + Math.Pow(color.G - splitColor.G, 2) + Math.Pow(color.B - splitColor.B, 2)) <= avarageDistance)
                    {
                        colors1.Add(color);
                    }
                    else
                    {
                        colors2.Add(color);
                    }*/
                    if (Math.Abs(_maxR - _minR) > Math.Abs(_maxG - _minG) && Math.Abs(_maxR - _minR) > Math.Abs(_maxB - _minB))
                    {
                        if (color.R <= splitColor.R)
                        {
                            colors1.Add(color);
                        }
                        else
                        {
                            colors2.Add(color);
                        }
                    }
                    else if (Math.Abs(_maxR - _minR) < Math.Abs(_maxG - _minG) && Math.Abs(_maxG - _minG) > Math.Abs(_maxB - _minB))
                    {
                        if (color.G <= splitColor.G)
                        {
                            colors1.Add(color);
                        }
                        else
                        {
                            colors2.Add(color);
                        }
                    }
                    else
                    {
                        if (color.B <= splitColor.B)
                        {
                            colors1.Add(color);
                        }
                        else
                        {
                            colors2.Add(color);
                        }
                    }
                }

                if (colors1.Count == 0 || colors2.Count == 0)
                {
                    cubes.Add(this);
                    return cubes;
                }

                cubes.Add(new ColorCube(colors1));
                cubes.Add(new ColorCube(colors2));
                return cubes;
            }

            private Color GetSplitColor()
            {
                FindBounds();
                //int r = 0, g = 0, b = 0;
                var r = (_maxR + _minR) / 2;
                var g = (_maxG + _minG) / 2;
                var b = (_maxB + _minB) / 2;
                r = Math.Max(Math.Min(r, 255), 0);
                g = Math.Max(Math.Min(g, 255), 0);
                b = Math.Max(Math.Min(b, 255), 0);
                /* foreach (var color in _colors)
                 {
                     r += color.R;
                     g += color.G;
                     b += color.B;
                 }
                 r = r / _colors.Count;
                 g = g / _colors.Count;
                 b = b / _colors.Count;*/
                return Color.FromArgb(r, g, b);
            }
            private void FindBounds()
            {
                _minR = _minG = _minB = 255;
                _maxR = _maxG = _maxB = 0;

                foreach (var color in _colors)
                {
                    if (color.R < _minR) _minR = color.R;
                    if (color.R > _maxR) _maxR = color.R;
                    if (color.G < _minG) _minG = color.G;
                    if (color.G > _maxG) _maxG = color.G;
                    if (color.B < _minB) _minB = color.B;
                    if (color.B > _maxB) _maxB = color.B;
                }
            }
        }
    }
}
