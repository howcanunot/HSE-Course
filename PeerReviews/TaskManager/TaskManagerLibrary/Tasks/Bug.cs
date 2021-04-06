using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс, реалиющий сущность задачи типа Bug.
    /// </summary>
    public class Bug : BaseTask
    {
        public Bug(string name, Bitmap icon, Bitmap user, Bitmap delete, string status = "open", string date = "")
          : base(name, icon, user, delete, status, date)
        {

        }
    }
}
