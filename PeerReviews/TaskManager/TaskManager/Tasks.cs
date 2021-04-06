using System;
using System.Drawing;
using System.Windows.Forms;
using TaskManagerLibrary.Tasks;
using TaskManagerLibrary;
using System.Drawing.Text;
using System.IO;
using System.Collections.Generic;

namespace TaskManager
{
    /// <summary>
    /// Форма, которая отображает задачи текущего проекта.
    /// </summary>
    public partial class Tasks : Form
    {
        // Проект.
        Project project;
        // Список задач.
        List<BaseTask> tasks;
        // Текущая задача типа Epic.
        Epic currentEpic;
        // Текущая задача.
        BaseTask currentTask;
        // Таблица исполнителей.
        TableLayoutPanel usersTable;
        // Список исполнителей.
        List<User> users;
        Font myFont;

        /// <summary>
        /// Задает текущий проект и список пользователей.
        /// </summary>
        /// <param name="project"></param>
        /// <param name="users"></param>
        public void SetData(Project project, List<User> users)
        {
            this.project = project;
            this.users = users;
            tasks = project.TaskList;
            this.Text = project.Name == "" ? "Unnamed" : project.Name;
            EditUsersTable();
            tasksTable.Controls.Clear();
            for (var row = 0; row < tasks.Count; row++)
                tasks[row].SetControl(tasksTable, row);
        }
        /// <summary>
        /// Конструктор формы.
        /// Задает необходимые параметры.
        /// </summary>
        public Tasks()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(400, 300);
            // Обработчики изменения статусов.
            open.Click += delegate (object sender, EventArgs e)
            {
                currentTask.StatusLabel.Text = Status.Open;
            };
            inwork.Click += delegate (object sender, EventArgs e)
            {
                currentTask.StatusLabel.Text = Status.Inwork;
            };
            closed.Click += delegate (object sender, EventArgs e)
            {
                currentTask.StatusLabel.Text = Status.Closed;
            };
            myFont = new Font(Projects.myFont.Families[0], 10);
            this.Font = myFont;
        }

        /// <summary>
        /// Создание новой задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTaskButton(object sender, EventArgs e)
        {
            // Если количество задач максимально.
            if (tasks.Count == 10)
            {
                MessageBox.Show("Максимальное количество пользователей", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Отображение формы создания задачи.
            var newTask = new CreateTask(currentEpic);
            newTask.ShowDialog();
            if (CreateTask.TaskType == null && CreateTask.Description == null) return;
            BaseTask task;
            // Создание задачи.
            switch (CreateTask.TaskType)
            {
                case "Epic":
                    task = new Epic(CreateTask.Description, Properties.Resources.Epic, Properties.Resources.Users,
                        Properties.Resources.Delete);
                    task.Icon.MouseClick += EpicMouseClick;
                    break;
                case "Story":
                    task = new Story(CreateTask.Description, Properties.Resources.Story, Properties.Resources.Users,
                        Properties.Resources.Delete);
                    break;
                case "Task":
                    task = new Task(CreateTask.Description, Properties.Resources.Task, Properties.Resources.Users,
                        Properties.Resources.Delete);
                    break;
                case "Bug":
                    task = new Bug(CreateTask.Description, Properties.Resources.Bug, Properties.Resources.Users,
                        Properties.Resources.Delete);
                    break;
                default:
                    MessageBox.Show("Неправильный тип задачи", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (currentEpic != null && (CreateTask.TaskType == "Epic" || CreateTask.TaskType == "Bug"))
            {
                MessageBox.Show("Неправильный тип задачи", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User.BeginControlUpdate(tasksTable);
            task.Name.Font = myFont;
            task.CreationDate.Font = new Font(Projects.myFont.Families[0], 8);
            task.StatusLabel.Font = myFont;
            EditControls(task);
        }

        /// <summary>
        /// Настройка новой задачи.
        /// </summary>
        /// <param name="task">Новая задача.</param>
        private void EditControls(BaseTask task)
        {
            // Задает необходимые обработчики для новой задачи.
            task.UsersIcon.MouseEnter += UserMouseEnter;
            task.UsersIcon.MouseLeave += UserMouseLeave;
            task.Delete.MouseEnter += UserMouseEnter;
            task.Delete.MouseLeave += UserMouseLeave;
            task.Delete.MouseClick += DeleteTask;
            task.Icon.ContextMenuStrip = contextMenuStrip1;
            task.Icon.MouseEnter += TaskMouseEnter;
            task.Icon.MouseLeave += TaskMouseLeave;
            task.UsersIcon.MouseClick += TaskUsersClick;
            if (task.GetType().Name == "Epic")
            {
                task.UsersIcon.MouseClick -= TaskUsersClick;
                task.UsersIcon.MouseEnter -= UserMouseEnter;
                task.UsersIcon.MouseLeave -= UserMouseLeave;
            }
            // Располагает элементы задачи в таблице задач.
            task.SetControl(tasksTable, tasks.Count);
            tasks.Add(task);
            User.EndControlUpdate(tasksTable);
        }

        /// <summary>
        /// Обработчик события при наведения мышкой на элемент задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMouseEnter(object sender, EventArgs e)
        {
            var unboxedSender = (PictureBox)sender;
            currentTask = tasks[int.Parse(unboxedSender.Name)];
            unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
        }

        /// <summary>
        /// Обработчик события после наведения мышкой на элемент задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMouseLeave(object sender, EventArgs e)
        {
            var unboxedSender = (PictureBox)sender;
            unboxedSender.BackColor = Color.Bisque;
        }

        /// <summary>
        /// Обработчки событий при нажатии на иконку задачи типа Epic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EpicMouseClick(object sender, EventArgs e)
        {
            User.BeginControlUpdate(tableLayoutPanel1);
            project.TaskList = tasks;
            // Очищает таблицу задач, чтобы расположить там подзадачи Epic.
            tasksTable.Controls.Clear();
            int row = int.Parse((sender as PictureBox).Name);
            Epic epic = (Epic)tasks[row];
            for (var pos = 0; pos < epic.Subtasks.Count; pos++)
                epic.Subtasks[pos].SetControl(tasksTable, pos);
            tasks = epic.Subtasks;
            currentEpic = epic;
            this.Text += "\\" + epic.Name.Text;
            User.EndControlUpdate(tableLayoutPanel1);
        }

        /// <summary>
        /// Удаление задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTask(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int row = int.Parse(pb.Name);
            RemoveControl(row);
        }

        /// <summary>
        /// Очищает таблицу задач и всех исполнителей.
        /// </summary>
        /// <param name="row"></param>
        public void RemoveControl(int row)
        {
            User.BeginControlUpdate(tasksTable);
            for (int col = 0; col < 6; col++)
                tasksTable.Controls.Remove(tasksTable.GetControlFromPosition(col, row));
            // Если тип задачи Epic - нужно очистить исполнителей всех подзадач.
            if (tasks[row].GetType().Name == "Epic")
            {
                foreach (var task in tasks[row].Subtasks)
                {
                    List<User> deleteUsers = task.Users;
                    for (var i = 0; i < deleteUsers.Count; i++)
                        for (var j = 0; j < users.Count; j++)
                            if (deleteUsers[i].UserTextBox.Text == users[j].UserTextBox.Text)
                            {
                                users[j].TasksAmount.Text = (int.Parse(users[j].TasksAmount.Text) - 1).ToString();
                                break;
                            }
                }
            }
            else
            {
                List<User> deleteUsers = tasks[row].Users;
                for (var i = 0; i < deleteUsers.Count; i++)
                    for (var j = 0; j < users.Count; j++)
                        if (deleteUsers[i].UserTextBox.Text == users[j].UserTextBox.Text)
                        {
                            users[j].TasksAmount.Text = (int.Parse(users[j].TasksAmount.Text) - 1).ToString();
                            break;
                        }
            }
            // Располагает оставшиеся задачи в таблице.
            for (int pos = row + 1; pos < tasks.Count; pos++)
                tasks[pos].SetControl(tasksTable, pos - 1);
            tasks.RemoveAt(row);
            User.EndControlUpdate(tasksTable);
        }

        /// <summary>
        /// Обработчик нажатия кнопки назад.
        /// Если отображается список подзадач Epic - после нажатия будет отображаться список задач проекта.
        /// Если отображается список исполнителей - после нажатия будет отобраться список задач проекта или Epic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButtonClick(object sender, EventArgs e)
        {
            // Если отображается список исполнителей.
            if (tableLayoutPanel1.Controls.Contains(usersTable))
            {
                User.BeginControlUpdate(tasksTable);
                tableLayoutPanel1.Controls.Remove(usersTable);
                tableLayoutPanel1.Controls.Add(tasksTable);
                this.Text = this.Text.Substring(0, this.Text.Length - 6);
                User.EndControlUpdate(tasksTable);
                toolStripButton3.Visible = true;
                return;
            }
            // Если отображается список задач проекта.
            if (currentEpic == null) return;
            User.BeginControlUpdate(tasksTable);
            tasksTable.Controls.Clear();
            currentEpic.Subtasks = tasks;
            tasks = project.TaskList;
            for (var row = 0; row < tasks.Count; row++)
                tasks[row].SetControl(tasksTable, row);
            currentEpic = null;
            this.Text = project.Name;
            User.EndControlUpdate(tasksTable);
        }

        /// <summary>
        /// Обработчик события при наведении мышкой на элемент задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskMouseEnter(object sender, EventArgs e)
        {
            var unboxedSender = (PictureBox)sender;
            currentTask = tasks[int.Parse(unboxedSender.Name)];
            if (currentTask.GetType().Name == "Epic")
                unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
        }

        /// <summary>
        /// Обработчик события после наведении мышкой на элемент задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskMouseLeave(object sender, EventArgs e)
        {
            var unboxedSender = (PictureBox)sender;
            unboxedSender.BackColor = Color.Bisque;
        }

        /// <summary>
        /// Закрытие формы и возврат к списку проектов и пользователей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            User.BeginControlUpdate(tasksTable);
            if (tableLayoutPanel1.Controls.Contains(usersTable))
            {
                tableLayoutPanel1.Controls.Remove(usersTable);
                tableLayoutPanel1.Controls.Add(tasksTable, 0, 1);
                tasksTable.Dock = DockStyle.Fill;
            }
            toolStripButton3.Visible = true;
            project.TaskList = tasks;
            User.EndControlUpdate(tasksTable);
            this.Close();
        }

        /// <summary>
        /// Публичный метод, который задает характеристики задаче.
        /// Нужен для корректной работы сохранения.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public BaseTask SetTask(BaseTask task, List<BaseTask> tasks)
        {
            task.Name.Font = myFont;
            task.CreationDate.Font = new Font(Projects.myFont.Families[0], 8);
            task.StatusLabel.Font = myFont;
            task.UsersIcon.MouseEnter += UserMouseEnter;
            task.UsersIcon.MouseLeave += UserMouseLeave;
            task.Delete.MouseEnter += UserMouseEnter;
            task.Delete.MouseLeave += UserMouseLeave;
            task.Delete.MouseClick += DeleteTask;
            task.Icon.ContextMenuStrip = contextMenuStrip1;
            task.Icon.MouseEnter += TaskMouseEnter;
            task.Icon.MouseLeave += TaskMouseLeave;
            task.UsersIcon.MouseClick += TaskUsersClick;
            if (task.GetType().Name == "Epic")
            {
                task.Icon.MouseClick += EpicMouseClick;
                task.UsersIcon.MouseClick -= TaskUsersClick;
                task.UsersIcon.MouseEnter -= UserMouseEnter;
                task.UsersIcon.MouseLeave -= UserMouseLeave;
            }
            task.SetControl(tasksTable, tasks.Count);
            return task;
        }
    }
}
