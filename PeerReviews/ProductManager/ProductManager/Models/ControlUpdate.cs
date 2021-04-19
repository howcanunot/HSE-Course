using System;
using System.Windows.Forms;

namespace ProductManager
{
    /// <summary>
    /// Класс, хранящий статические методы для заморозки и разморозки компонента.
    /// </summary>
    public class ControlUpdate
    {
        private const int WM_SETREDRAW = 11;
        /// <summary>
        /// Замораживает форму.
        /// </summary>
        /// <param name="control">Visual control.</param>
        public static void BeginControlUpdate(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                  IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }

        /// <summary>
        /// Размораживает форму.
        /// </summary>
        /// <param name="control">Visual control.</param>
        public static void EndControlUpdate(Control control)
        {
            IntPtr wparam = new IntPtr(1);
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                  IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Invalidate();
            control.Refresh();
        }
    }
}
