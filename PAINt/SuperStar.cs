using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAINt
{
    class SuperStar : Brush
    {
        public SuperStar(Color brushColor, int size) : base(brushColor, size)
        {
        }

        public override void Draw(Bitmap image, int x, int y, int width, int height)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                    if (x > 0 && x < width && y0 > 0 && y0 < height)
                    {
                        image.SetPixel(x, y0, BrushColor);
                    }
            }

            for (int x0 = x - Size; x0 < x + Size; ++x0)
            {
                if (x0 > 0 && x0 < width && y > 0 && y < height)
                {
                    image.SetPixel(x0, y, BrushColor);
                }
            }

            int x1 = x - (int)(Size*0.7);
            for (int y0 = y - (int)(Size*0.7); y0 < y + 0.7*Size; ++y0)
            {
                    if (x1 > 0 && x1 < width-1 && y0 > 0 && y0 < height)
                    {
                    ++x1;
                        image.SetPixel(x1, y0, BrushColor);
                    }
            }

            int x2 = x + (int)(Size * 0.7);
            for (int y0 = y - (int)(Size * 0.7); y0 < y + 0.7 * Size; ++y0)
            {
                if (x2 > 0 && x2 < width && y0 > 0 && y0 < height)
                {
                    --x2;
                    image.SetPixel(x2, y0, BrushColor);
                }
            }
        }
    }
}
