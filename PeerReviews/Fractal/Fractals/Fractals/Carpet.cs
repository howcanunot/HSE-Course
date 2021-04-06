using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractals
{
    class Carpet : BaseFractal
    {
        public override int MaxRecursionDepth { get; set; } = 6;
        public override double Len { get; set; }
        public override int CurrentDepth { get; set; }
        public override void PaintFractal(List<Color> colorList, Graphics graphics, float width, float height, int iter, 
            double leftAngle, double rightAngle, double scale)
        {
            CurrentDepth = iter;
            Len = Math.Min(width, height) - 60;
            PointF start;
            if (height <= width)
                start = new PointF((float)(width - Len) / 2, 30);
            else
                start = new PointF(30, (float)(height - Len) / 2);
            graphics.FillRectangle(new SolidBrush(Color.White), new RectangleF(start.X, start.Y, (float)Len, (float)Len));
            Square(start, (float)Len, graphics, colorList, 0);

        }

        private void Square(PointF start, float length, Graphics graphics, List<Color> colorList, int iter)
        {
            if (iter == CurrentDepth)
                return;
            length = length / 3;
            for (int i = 0; i < 9; i++)
                if (i == 4)
                    graphics.FillRectangle(new SolidBrush(colorList[iter]), 
                        new RectangleF(start.X + length, start.Y + length, length, length));
                else
                    Square(new PointF(start.X + (i % 3) * length, start.Y + (i / 3) * length), length, graphics, colorList, iter + 1);
        }
    }
}
