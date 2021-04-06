using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public class ScreenFeatures
    {
        public static int MaxWidth { get; private set; } = Screen.PrimaryScreen.Bounds.Width;
        public static int MaxHeight { get; private set; } = Screen.PrimaryScreen.Bounds.Height;
        public static int MinWidth { get; private set; } = Screen.PrimaryScreen.Bounds.Width / 2;
        public static int MinHeight { get; private set; } = Screen.PrimaryScreen.Bounds.Height / 2;

    }
}
