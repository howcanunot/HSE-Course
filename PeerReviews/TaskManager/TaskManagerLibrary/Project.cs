using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс, реализующий сущность проекта.
    /// </summary>
    public class Project
    {
        // Список задач.
        List<BaseTask> taskList;

        // Элемент, который будет отображать проект.
        // Поле могло бы иметь тип PictureBox, но я использовал кастомный элемент, которого нет в библиотеке.
        private Control control;
        public Control ProjectControl { get => control; set => control = value; }
        public List<BaseTask> TaskList { get => taskList; set => taskList = value; }
        // Название проекта.
        public string Name { get; }

        /// <summary>
        /// Конструктор задает нужные параметры для ProjectControl.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="control"></param>
        /// <param name="backcolor"></param>
        /// <param name="menu"></param>
        public Project(string name, Control control, Color backcolor, ContextMenuStrip menu)
        {
            Name = name;
            taskList = new List<BaseTask>();
            ProjectControl = control;
            ProjectControl.BackColor = backcolor;
            ProjectControl.Name = Name != "" ? Name : "Undefined";
            ProjectControl.ContextMenuStrip = menu;
            ProjectControl.Cursor = Cursors.Hand;
            ProjectControl.Dock = DockStyle.Fill;
            ProjectControl.Margin = new Padding(10);
            ProjectControl.Size = new System.Drawing.Size(69, 105);
        }
    }
}
