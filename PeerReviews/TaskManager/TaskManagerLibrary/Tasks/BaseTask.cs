using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс, реализующий базовый функционал для задач в проекте.
    /// Наследует интерфейс IAssignable для контроля количества пользователей - исполнителей.
    /// </summary>
    public abstract class BaseTask : IAssignable
    {
        // Список пользователей - исполнителей.
        List<User> users;
        public List<User> Users { get => users; }
        // Описание задачи.
        public Label Name { get; }
        // Список подзадач для Epic.
        // Я его сделал виртуальным, чтобы переопределить в классе Epic.
        public virtual List<BaseTask> Subtasks { get; set; }
        // Инонка задачи.
        public PictureBox Icon { get; }
        // Иконка исполнителей.
        public PictureBox UsersIcon { get; }
        // Иконка удаления задачи.
        public PictureBox Delete { get; }
        // Дата создания.
        public Label CreationDate { get; }
        // Статус.
        public Label StatusLabel { get; }
        public Status Status { get; }

        /// <summary>
        /// Конструктор задает всем элементам нужные параметры.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="icon"></param>
        /// <param name="user"></param>
        /// <param name="delete"></param>
        /// <param name="status"></param>
        /// <param name="date"></param>
        public BaseTask(string name, Bitmap icon, Bitmap user, Bitmap delete, 
            string status = "open", string date = "")
        {
            users = new List<User>();
            Name = new Label();
            CreationDate = new Label();
            StatusLabel = new Label();
            Icon = new PictureBox();
            UsersIcon = new PictureBox();
            Delete = new PictureBox();
            Name.Text = name;
            CreationDate.Text = date == "" ? DateTime.Now.ToString() : date;
            Status = new Status(status);
            StatusLabel.Text = Status.Type;
            Icon = new PictureBox();
            Icon.BackgroundImage = icon;
            Icon.BackgroundImageLayout = ImageLayout.Zoom;
            UsersIcon.BackgroundImage = user;
            UsersIcon.BackgroundImageLayout = ImageLayout.Zoom;
            Delete.BackgroundImage = delete;
            Delete.BackgroundImageLayout = ImageLayout.Zoom;
        }

        /// <summary>
        /// Метод располагает элементы в таблице задач.
        /// </summary>
        /// <param name="table">Таблица задач.</param>
        /// <param name="row">Нужная строка.</param>
        public virtual void SetControl(TableLayoutPanel table, int row)
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
            UsersIcon.Cursor = Cursors.Hand;
            Delete.Cursor = Cursors.Hand;
            Icon.Name = row.ToString();
            Delete.Name = Icon.Name; UsersIcon.Name = Icon.Name;
        }

        /// <summary>
        /// Метод интерфейса для добавления исполнителя.
        /// Виртуальный, чтобы перегрузить его в классе Story, где максимальное кол-во исполнителей - 3.
        /// </summary>
        /// <param name="user"></param>
        public virtual void AddUser(User user)
        {
            if (Users.Count == 1)
            {
                throw new ArgumentException();
            }
            Users.Add(user);
        }
        /// <summary>
        /// Метод удаления исполнителя.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            users.Remove(user);
        }
    }
}
