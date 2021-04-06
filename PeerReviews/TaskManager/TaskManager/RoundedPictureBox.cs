using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace TaskManager
{
    /// <summary>
    /// Класс реализует обычный PictureBox, но с закругленными концами.
    /// </summary>
    public class RoundedPictureBox : PictureBox
    {
        public RoundedPictureBox()
        {
        }
        /// <summary>
        /// Взято со stackoverflow.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var graphics = new GraphicsPath())
            {
                // Индекс округления.
                int roundIndex = 15;
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                graphics.AddArc(rect.X, rect.Y, roundIndex, roundIndex, 180, 90);
                graphics.AddArc(rect.X + rect.Width - roundIndex, rect.Y, roundIndex, roundIndex, 270, 90);
                graphics.AddArc(rect.X + rect.Width - roundIndex, rect.Y + rect.Height - roundIndex, roundIndex, roundIndex, 0, 90);
                graphics.AddArc(rect.X, rect.Y + rect.Height - roundIndex, roundIndex, roundIndex, 90, 90);
                this.Region = new Region(graphics);
            }
        }
    }
}
