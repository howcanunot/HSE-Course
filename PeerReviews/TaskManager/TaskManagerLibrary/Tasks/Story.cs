using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс, реализующий сущность задачи типа Story.
    /// </summary>
    public class Story : BaseTask
    {
        public Story(string name, Bitmap icon, Bitmap user, Bitmap delete, string status = "open", string date = "")
           : base(name, icon, user, delete, status, date)
        {

        }

        /// <summary>
        /// Переопределенный метод для добавления исполнителя.
        /// </summary>
        /// <param name="user"></param>
        public override void AddUser(User user)
        {
            if (Users.Count == 3)
            {
                throw new ArgumentException();
            }
            Users.Add(user);
        }
    }
}
