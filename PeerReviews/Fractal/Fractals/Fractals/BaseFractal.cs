using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Fractals
{
    abstract class BaseFractal
    {
        public abstract double Len { get; set; }
        public abstract int CurrentDepth { get; set; }
        public abstract int MaxRecursionDepth { get; set; }
        public abstract void PaintFractal(List<Color> colorList, Graphics graphics, float width, float height, int iter,
            double leftAngle, double rightAngle, double scale);
    }
}
