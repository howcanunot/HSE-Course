using System.Collections.Generic;
using System.IO;
using TaskManagerLibrary;
using TaskManagerLibrary.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace TaskManager
{
    partial class Projects
    {
        /// <summary>
        /// Метод создает поток для чтения сохранения и читает данные из файла.
        /// </summary>
        private void ReadBackup()
        {
            // Создание потока.
            using (StreamReader file = new StreamReader(Directory.GetCurrentDirectory() + "\\..\\Release\\backup.txt"))
            {
                try
                {
                    // Считывание пользователей.
                    int usersCount = int.Parse(file.ReadLine());
                    for (var user = 0; user < usersCount; user++) ReadUsers(file.ReadLine());
                    int projectsCount = int.Parse(file.ReadLine());
                    // Считывание проектов.
                    for (var project = 0; project < projectsCount; project++) ReadProject(file.ReadLine(), file);
                }
                catch (Exception ex) { return; }

            }
        }
        /// <summary>
        /// Метод считывания пользователей.
        /// </summary>
        /// <param name="line">Строка с характеристиками пользователя.</param>
        private void ReadUsers(string line)
        {
            string[] user = line.Split(';');
            User newUser = new User(Properties.Resources.User, Properties.Resources.Edit, Properties.Resources.Delete,
                new TextBox(), this.Height / 40, int.Parse(user[1]), user[0]);
            // Необходимые настройки.
            newUser.EditName.MouseEnter += User.UserMouseEnter;
            newUser.EditName.MouseLeave += User.UserMouseLeave;
            newUser.DeleteUser.MouseLeave += User.UserMouseLeave;
            newUser.DeleteUser.MouseEnter += User.UserMouseEnter;
            newUser.EditName.MouseDown += EditBoxClick;
            newUser.DeleteUser.MouseDown += DeleteBoxClick;
            newUser.UserTextBox.MouseEnter += TextBoxEnter;
            newUser.UserTextBox.LostFocus += TextBoxLostFocus;
            newUser.UserTextBox.Enabled = false;
            // Добавление пользователя.
            users.Add(newUser);
        }
        /// <summary>
        /// Метод считвания проекта.
        /// </summary>
        /// <param name="line">Стрка с характеристиками проекта.</param>
        /// <param name="file">Поток.</param>
        private void ReadProject(string line, StreamReader file)
        {
            string[] project = line.Split(';');
            // Создание нового проекта.
            Project newProject = new Project(project[0].Substring(0, project[0].Length - 2), new RoundedPictureBox(),
                ColorTranslator.FromHtml(project[1]), contextMenuStrip1);
            // Добавление проекта в таблицу проектов.
            projectsTable[currentRow, currentColumn] = newProject.ProjectControl;
            // Необходимые настройки.
            newProject.ProjectControl.Name += currentRow.ToString() + currentColumn.ToString();
            newProject.ProjectControl.MouseEnter += RoundedPictureBoxMouseEnter;
            newProject.ProjectControl.MouseLeave += RoundedPictureBoxMouseLeave;
            newProject.ProjectControl.Paint += ProjectBoxPaint;
            newProject.ProjectControl.MouseClick += ProjectBoxMouseDown;
            // Изменение свободной позиции для некст проекта.
            if (currentColumn == 2) currentRow++;
            currentColumn = (currentColumn + 1) % 3;
            if (currentRow < 3)
                projectsTable[currentRow, currentColumn] = newProjectBox;
            if (projects.Count == 9)
                projectsTable.Controls.Remove(newProjectBox);
            // Считывание задач проекта.
            int tasksCount = int.Parse(project[2]);
            for (var task = 0; task < tasksCount; task++) ReadTask(file.ReadLine(), file, newProject.TaskList);
            // Добавление проекта в список проектов.
            projects.Add(newProject);
        }
        /// <summary>
        /// Считывание задач проекта.
        /// </summary>
        /// <param name="line">Строка с характеристиками проекта.</param>
        /// <param name="file">Поток.</param>
        /// <param name="tasks">Список задач.</param>
        private void ReadTask(string line, StreamReader file, List<BaseTask> tasks)
        {
            BaseTask newTask;
            string[] task = line.Split(';');
            // Создание задачи.
            switch (task[0])
            {
                case "Epic":
                    newTask = new Epic(task[1], Properties.Resources.Epic, Properties.Resources.Users, Properties.Resources.Delete,
                        task[2], task[3]);
                    int subtasksCount = int.Parse(task[4]);
                    // Для задач типа Epic функцию нужно вызвать еще раз, чтобы прочитать список подзадач.
                    for (var subtask = 0; subtask < subtasksCount; subtask++) ReadTask(file.ReadLine(), file, newTask.Subtasks);
                    break;
                case "Story":
                    newTask = new Story(task[1], Properties.Resources.Story, Properties.Resources.Users, Properties.Resources.Delete,
                        task[2], task[3]);
                    break;
                case "Task":
                    newTask = new Task(task[1], Properties.Resources.Task, Properties.Resources.Users, Properties.Resources.Delete,
                        task[2], task[3]);
                    break;
                case "Bug":
                    newTask = new Bug(task[1], Properties.Resources.Bug, Properties.Resources.Users, Properties.Resources.Delete,
                        task[2], task[3]);
                    break;
                default:
                    return;
            }
            // Расположение элементов задачи в таблице задач.
            tasksForm.SetTask(newTask, tasks);
            // Если задача не Epic считывается список исполнителей.
            if (task[0] != "Epic") ReadTaskUsers(newTask, file);
            // Добавление задачи в список задач.
            tasks.Add(newTask);
        }

        /// <summary>
        /// Считвание исполнителей для задачи.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="file"></param>
        private void ReadTaskUsers(BaseTask task, StreamReader file)
        {
            // Количество исполниетей.
            int usersCount = int.Parse(file.ReadLine());
            for (var count = 0; count < usersCount; count++)
            {
                string name = file.ReadLine();
                foreach (var user in users)
                    if (name == user.UserTextBox.Text)
                    {
                        task.AddUser(user);
                        break;
                    }
            }
        }
    }
}
