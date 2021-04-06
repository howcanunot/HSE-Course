using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractals
{
    class Triangle : BaseFractal
    {
        public override double Len { get; set; }
        public override int MaxRecursionDepth { get; set; } = 8;
        public override int CurrentDepth { get; set; }
        public override void PaintFractal(List<Color> colorList, Graphics graphics, float width, float height, int iter, 
            double leftAngle, double rightAngle, double scale)
        {
            Len = 0;
            CurrentDepth = iter;
            PointF p1 = new PointF(width / 2, height / 10);
            PointF p2 = new PointF((float)(width / 2 - 8 * height / 10 / Math.Sqrt(3)), height * 9 / 10);
            PointF p3 = new PointF((float)(width / 2 + 8 * height / 10 / Math.Sqrt(3)), height * 9 / 10);
            graphics.DrawLine(new Pen(colorList[0], 1), p1, p2);
            graphics.DrawLine(new Pen(colorList[0], 1), p1, p3);
            graphics.DrawLine(new Pen(colorList[0], 1), p2, p3);
            PaintTriangle(p1, p2, p3, graphics, colorList, 1);
        }

        private void PaintTriangle(PointF p1, PointF p2, PointF p3, Graphics graphics, List<Color> colorList, int iter)
        {
            if (iter == CurrentDepth)
                return;
            graphics.DrawLine(new Pen(colorList[iter], 1), GetMid(p1, p2), GetMid(p1, p3));
            graphics.DrawLine(new Pen(colorList[iter], 1), GetMid(p1, p2), GetMid(p2, p3));
            graphics.DrawLine(new Pen(colorList[iter], 1), GetMid(p2, p3), GetMid(p1, p3));
            PaintTriangle(p1, GetMid(p1, p2), GetMid(p1, p3), graphics, colorList, iter + 1);
            PaintTriangle(GetMid(p1, p2), p2, GetMid(p2, p3), graphics, colorList, iter + 1);
            PaintTriangle(GetMid(p1, p3), GetMid(p2, p3), p3, graphics, colorList, iter + 1);
        }

        private PointF GetMid(PointF p1, PointF p2) => new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
    }
}
