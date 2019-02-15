using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAINt
{
    class CircleBrush : Brush
    {
        public CircleBrush(Color brushColor, int size)
           : base(brushColor, size)
        {
        }

        public override void Draw(Bitmap image, int x, int y, int weigth, int height, Graphics Graph)
        {
            Graph.DrawEllipse(new Pen(Brushes.Red), x - Size, y - Size, Size, Size);
        }
    }
}
