using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Fractals
{
    class FractalTree : BaseFractal
    {
        public override double Len { get; set; }
        public override int MaxRecursionDepth { get; set; } = 14;
        public override int CurrentDepth { get; set; }
        private double LeftAngle { get; set; }
        private double RightAngle { get; set; }
        private double Scale { get; set; }
        public override void PaintFractal(List<Color> colorList, Graphics graphics, float width, float height, int iter,
            double leftAngle, double rightAngle, double scale)
        {
            CurrentDepth = iter;
            Scale = scale;
            LeftAngle = Math.PI * leftAngle / 180;
            RightAngle = Math.PI * rightAngle / 180;
            Len = Math.Min(width, height) * 0.35;
            PointF root = new PointF(width / 2, height - 20);
            Tree(root, Math.PI / 2, Len, graphics, 0, colorList);
        }
        private void Tree(PointF root, double angle, double length, Graphics graphics, int iter, List<Color> colorList)
        {
            if (iter == CurrentDepth)
                return;
            PointF point = new PointF(root.X + (float)(length * Math.Cos(angle)), root.Y - (float)(length * Math.Sin(angle)));
            graphics.DrawLine(new Pen(colorList[iter], 1), root, point);
            Tree(point, angle + LeftAngle, length * Scale, graphics, iter + 1, colorList);
            Tree(point, angle - RightAngle, length * Scale, graphics, iter + 1, colorList);
        }
    }
}
