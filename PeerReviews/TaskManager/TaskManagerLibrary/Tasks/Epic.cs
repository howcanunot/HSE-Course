using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс, реализующий сущность задачи типа Epic.
    /// </summary>
    public class Epic : BaseTask
    {
        // Список подзадач.
        List<BaseTask> subtasks;
        public override List<BaseTask> Subtasks { get => subtasks; set => subtasks = value; }
        public Epic(string name, Bitmap icon, Bitmap user, Bitmap delete, string status = "open", string date = "")
           : base(name, icon, user, delete, status, date)
        {
            // Инициализация списка подзадач.
            // У всех остальных задач будет null.
            subtasks = new List<BaseTask>();
            Icon.Cursor = Cursors.Hand;
        }

       /// <summary>
       /// Переопределенный метод, который располагает элементы в таблице задач.
       /// </summary>
       /// <param name="table"></param>
       /// <param name="row"></param>
        public override void SetControl(TableLayoutPanel table, int row)
        {
            table.Controls.Add(Icon, 0, row);
            table.Controls.Add(Name, 1, row);
            table.Controls.Add(CreationDate, 2, row);
            table.Controls.Add(StatusLabel, 3, row);
            table.Controls.Add(UsersIcon, 4, row);
            table.Controls.Add(Delete, 5, row);
            Icon.Dock = DockStyle.Fill;
            Name.Dock = DockStyle.Fill;
            CreationDate.Dock = DockStyle.Fill;
            StatusLabel.Dock = DockStyle.Fill;
            UsersIcon.Dock = DockStyle.Fill;
            Delete.Dock = DockStyle.Fill;
            Name.TextAlign = ContentAlignment.MiddleCenter;
            CreationDate.TextAlign = ContentAlignment.MiddleCenter;
            StatusLabel.TextAlign = Name.TextAlign;
            Icon.Cursor = Cursors.Hand;
            Delete.Cursor = Cursors.Hand;
            Icon.Name = row.ToString();
            Delete.Name = Icon.Name; UsersIcon.Name = Icon.Name;
            UsersIcon.MouseClick += null;
        }

    }
}
