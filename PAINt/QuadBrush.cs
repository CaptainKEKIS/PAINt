using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAINt
{
    class QuadBrush : Brush
    {
        public QuadBrush(Color brushColor, int size)
            : base(brushColor, size)
        {
        }

        public override void Draw(Bitmap image, int x, int y, int width, int height, Graphics Graph)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    if ((x0 > 0 && x0 < width && y0 > 0 && y0 < height) && x0 + y0 == y + x + Size)
                    {
                        image.SetPixel(x0, y0, BrushColor);
                    }
                }
            }
        }
    }
}
