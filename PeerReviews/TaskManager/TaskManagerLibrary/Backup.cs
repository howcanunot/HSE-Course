using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace TaskManagerLibrary.Tasks
{
    /// <summary>
    /// Класс реализует функционал сохранения данных при закрытии формы.
    /// </summary>
    public class Backup
    {
        /// <summary>
        /// </summary>
        /// <param name="projects">Список проектов для сохранения.</param>
        /// <param name="users">Список пользователей для сохранения.</param>
        public static void MakeBackup(List<Project> projects, List<User> users)
        {
            try
            {
                // Создание потока для сохранения.
                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + "\\..\\Release\\backup.txt"))
                {
                    // Запись всех пользователей.
                    file.WriteLine(users.Count.ToString());
                    foreach (var user in users)
                        file.WriteLine(user.UserTextBox.Text + ";" + user.TasksAmount.Text);

                    file.WriteLine(projects.Count.ToString());
                    // Запись проектов.
                    foreach (var project in projects)
                        WriteProject(project, file);
                }
            }
            catch (Exception ex)
            {

                // Создание потока для сохранения.
                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + "\\..\\Debug\\backup.txt"))
                {
                    // Запись всех пользователей.
                    file.WriteLine(users.Count.ToString());
                    foreach (var user in users)
                        file.WriteLine(user.UserTextBox.Text + ";" + user.TasksAmount.Text);

                    file.WriteLine(projects.Count.ToString());
                    // Запись проектов.
                    foreach (var project in projects)
                        WriteProject(project, file);
                }
            }
        }

        /// <summary>
        /// Записывает проект в поток для сохранения.
        /// </summary>
        /// <param name="project">Нужный проект.</param>
        /// <param name="file">Поток.</param>
        private static void WriteProject(Project project, StreamWriter file)
        {
            // Запись характеристик проекта.
            file.WriteLine(project.ProjectControl.Name + ";" + ColorTranslator.ToHtml(project.ProjectControl.BackColor) +
                ";" + project.TaskList.Count.ToString());

            // Запись каждой задачи в проекте.
            foreach (var task in project.TaskList)
            {
                // Задачи типа Epic записываются немного по-другому.
                if (task.GetType().Name == "Epic")
                {
                    file.WriteLine(task.GetType().Name + ";" + task.Name.Text + ";" + task.StatusLabel.Text + 
                        ";" + task.CreationDate.Text + ";" +task.Subtasks.Count.ToString());
                    foreach (var subtask in task.Subtasks)
                        WriteTask(subtask, file);
                    continue; 
                }
                WriteTask(task, file);

            }
        }

        /// <summary>
        /// Записывает нужную задачу в поток для сохранения.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <param name="file">Поток.</param>
        private static void WriteTask(BaseTask task, StreamWriter file)
        {
            // Запись характеристик задачи.
            file.WriteLine(task.GetType().Name + ";" + task.Name.Text + ";" + task.StatusLabel.Text + ";" + task.CreationDate.Text);
            file.WriteLine(task.Users.Count.ToString());
            // Запись пользователей - исполнителей.
            foreach (var user in task.Users)
                file.WriteLine(user.UserTextBox.Text);
        }
    }
}
