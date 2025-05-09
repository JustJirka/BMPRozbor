﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPRozbor
{
    public interface IColorQuantizer
    {
        /// <summary>
        /// Adds the color to quantizer.
        /// </summary>
        /// <param name="color">The color to be added.</param>
        void AddColor(Color color);

        /// <summary>
        /// Gets the palette with specified count of the colors.
        /// </summary>
        /// <param name="colorCount">The color count.</param>
        /// <returns></returns>
        List<Color> GetPalette(Int32 colorCount);

        /// <summary>
        /// Gets the index of the palette for specific color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        Byte GetPaletteIndex(Color color);

        /// <summary>
        /// Gets the color count.
        /// </summary>
        /// <returns></returns>
        Int32 GetColorCount();

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();
    }
}
