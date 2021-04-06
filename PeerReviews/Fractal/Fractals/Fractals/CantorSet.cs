using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractals
{
    class CantorSet : BaseFractal
    {
        public override int MaxRecursionDepth { get; set; } = 8;
        public override int CurrentDepth { get; set; }
        public override double Len { get; set; }
        public override void PaintFractal(List <Color> colorList, Graphics graphics, float width, float height, int iter,
            double leftAngle, double rightAngle, double scale)
        {
            CurrentDepth = iter;
            Len = width - 60;
            PointF start = new PointF(30, 30);
            PointF end = new PointF(width - 30, 30);
            float penWidth = height / 45;
            Set(start, end, height / CurrentDepth, graphics, colorList, 0, penWidth);
        }

        private void Set(PointF start, PointF end, float gap, Graphics graphics, List<Color> colorList, int iter, float penWidth)
        {
            if (iter == CurrentDepth)
                return;
            graphics.DrawLine(new Pen(colorList[iter], penWidth), start, end);
            Set(new PointF(start.X, start.Y + gap), new PointF(start.X + (end.X - start.X) / 3.0F, start.Y + gap), 
                gap, graphics, colorList, iter + 1, penWidth);
            Set(new PointF(end.X - (end.X - start.X) / 3.0F, start.Y + gap), new PointF(end.X, end.Y + gap), 
                gap, graphics, colorList, iter + 1, penWidth);
        }
    }
}
