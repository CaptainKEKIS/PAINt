﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAINt
{
    class RectBrush : Brush
    {
        public RectBrush(Color brushColor, int size)
           : base(brushColor, size)
        {
        }

        public override void Draw(Bitmap image, int x, int y, int width, int height)
        {
            for (int y0 = y - Size/2; y0 < y + Size/2; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    if (x0 > 0 && x0 < width && y0 > 0 && y0 < height)
                    {
                        image.SetPixel(x0, y0, BrushColor);
                    }
                }
            }
        }
    }
}
