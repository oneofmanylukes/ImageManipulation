/*
 * This code was inspired by https://github.com/artbobrov/ConvolutionFilter
 */

using System;
using System.Windows.Media;

namespace ImageManipulation.Filter
{
    public abstract class BaseFilter
    {
        abstract public double[,] Data { get; }

        abstract public double NormalizationRate { get; }

        abstract public double Bias { get; }

        abstract public int Size { get; }

        public int Length => Data.Length;

        public double this[int x, int y] => Data[x, y];

        public static Color operator *(Color[,] map, BaseFilter filter)
        {
            if (map.Length != filter.Length)
                throw new Exception("Color map and filter size mismatch");

            double r = 0, g = 0, b = 0;

            for (int x = 0; x < filter.Size; x++)
            {
                for (int y = 0; y < filter.Size; y++)
                {
                    r += map[x, y].R * filter[x, y];
                    g += map[x, y].G * filter[x, y];
                    b += map[x, y].B * filter[x, y];
                }
            }

            r = Norm(r, filter);
            g = Norm(g, filter);
            b = Norm(b, filter);

            return Color.FromRgb((byte)r, (byte)g, (byte)b);
        }

        protected static int Norm(double val, BaseFilter filter)
        {
            var valN = (int)(val / filter.NormalizationRate + filter.Bias);
            return valN <= 0 ? 0 : valN >= 255 ? 255 : valN;
        }
    }
}
