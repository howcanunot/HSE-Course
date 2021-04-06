using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractals
{
    class Curve : BaseFractal
    {
        public override double Len { get; set; }
        public override int MaxRecursionDepth { get; set; } = 6;
        public override int CurrentDepth { get; set; }
        
        public override void PaintFractal(List<Color> colorList, Graphics graphics, float width, float height, int iter, 
            double leftAngle, double rightAngle, double scale)
        {
            CurrentDepth = iter;
            Len = width - 30;
            PointF start = new PointF(30, height / 3 * 2);
            PointF end = new PointF(width - 30, height / 3 * 2);
            Line(start, end, 0, graphics, colorList, 0);
        }
        private void Line(PointF start, PointF end, double angle, Graphics graphics, List<Color> colorList, int iter)
        {
            double length = Math.Sqrt((end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y)) / 3.0;
            if (iter == CurrentDepth)
            {
                graphics.DrawLine(new Pen(colorList[iter-1], 1), start, end);
                return;
            }
            PointF first = new PointF((float)(start.X + length * (Math.Cos(angle))), (float)(start.Y + length * Math.Sin(angle + Math.PI)));
            PointF second = new PointF((float)(first.X + length * (Math.Cos(angle + Math.PI / 3))), (float)(first.Y + length * Math.Sin(angle + Math.PI + Math.PI / 3)));
            PointF third = new PointF((float)(second.X + length * (Math.Cos(angle - Math.PI / 3))), (float)(second.Y + length * Math.Sin(angle + Math.PI - Math.PI / 3)));
            Line(start, first, angle, graphics, colorList, iter + 1);
            Line(first, second, angle + Math.PI / 3, graphics, colorList, iter + 1);
            Line(second, third, angle - Math.PI / 3, graphics, colorList, iter + 1);
            Line(third, end, angle, graphics, colorList, iter + 1);

        }
    }
}
