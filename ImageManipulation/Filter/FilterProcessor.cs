/*
 * This code was inspired by https://github.com/artbobrov/ConvolutionFilter
 */

using System.Windows.Media;

namespace ImageManipulation.Filter
{
    public class FilterProcessor
    {
        private readonly CopyableBitmap _sourceBitmap;
        private readonly EditableBitmap _editBitmap;

        public FilterProcessor(CopyableBitmap bitmap)
        {
            _sourceBitmap = bitmap;
            _editBitmap = new EditableBitmap(bitmap.Width, bitmap.Height);
        }

        public EditableBitmap ApplyFilter(BaseFilter filter)
        {
            var offset = filter.Size / 2;

            for (int xBitmap = 0; xBitmap < _sourceBitmap.Width; xBitmap++)
            {
                for (int yBitmap = 0; yBitmap < _sourceBitmap.Height; yBitmap++)
                {
                    var colorMap = new Color[filter.Size, filter.Size];

                    for (int filterX = 0; filterX < filter.Size; filterX++)
                    {
                        int offsetX = (filterX + yBitmap - offset <= 0) ? 0 :
                            (filterX + yBitmap - offset >= _sourceBitmap.Height - 1) ?
                            _sourceBitmap.Height - 1 : filterX + yBitmap - offset;

                        for (int filterY = 0; filterY < filter.Size; filterY++)
                        {
                            int offsetY = (filterY + xBitmap - offset <= 0) ? 0 :
                                (filterY + xBitmap - offset >= _sourceBitmap.Width - 1) ?
                                _sourceBitmap.Width - 1 : filterY + xBitmap - offset;

                            colorMap[filterX, filterY] = _sourceBitmap.GetPixel(offsetX, offsetY);
                        }
                    }

                    _editBitmap.SetPixelColor(xBitmap, yBitmap, colorMap * filter);
                }
            }

            return _editBitmap;
        }
    }
}
