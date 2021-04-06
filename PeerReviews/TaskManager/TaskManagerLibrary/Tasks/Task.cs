using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс, реализующий сущность задачи типа Task.
    /// </summary>
    public class Task : BaseTask
    {
        public Task(string name, Bitmap icon, Bitmap user, Bitmap delete, string status = "open", string date = "")
           : base(name, icon, user, delete, status, date)
        {

        }
    }
}
