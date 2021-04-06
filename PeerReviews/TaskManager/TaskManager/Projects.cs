using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskManagerLibrary;
using TaskManagerLibrary.Tasks;
using System.Drawing.Text;
using System.IO;

namespace TaskManager
{
    /// <summary>
    /// Форма, которая отображает проекты и пользователей.
    /// </summary>
    public partial class Projects : Form
    {
        // Свободная ячейка в таблице проектов.
        int currentRow;
        int currentColumn;
        // Список проектов.
        List<Project> projects = new List<Project>();
        // Текущий проект.
        Project currentProject;
        // Форма создания проекта.
        CreateProject newProjectSettingsForm;
        // Форма отображения задач в проекте.
        Tasks tasksForm;
        // Шрифт.
        public static PrivateFontCollection myFont = new PrivateFontCollection();
        /// <summary>
        /// Контструктор формы.
        /// Задает нужные параметры и вызывает необходимые методы.
        /// </summary>
        public Projects()
        {
            InitializeComponent();
            this.Text = "Task Manager";
            // Создание шрифта.
            myFont.AddFontFile(Directory.GetCurrentDirectory() + "..\\..\\..\\" + "Montserrat-Bold.ttf");
            usersTable = new ProjectsTableLayout();
            // Редактирование таблицы пользователей.
            EditRowsAndCells();
            this.MinimumSize = new Size(580, 400);
            currentRow = 0;
            currentColumn = 0;
            toolStripButton3.Visible = false;
            this.KeyPreview = true;
            tasksForm = new Tasks();
            // Считывание последнего сохранения.
            ReadBackup();
            // Расположение пользователей в таблице.
            for (int row = 0; row < users.Count; row++) users[row].SetControls(usersTable, row);
        }

        /// <summary>
        /// Обработчик события при наведения мышкой на элемент проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxMouseEnter(object sender, EventArgs e)
        {
            try
            {
                var unboxedSender = (RoundedPictureBox)sender;
                unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
                if (unboxedSender.Name == "newProjectBox") return;
                var number = unboxedSender.Name.Substring(unboxedSender.Name.Length - 2, 2);
                currentProject = projects[3 * (number[0] - '0') + (number[1] - '0')];
            }
            catch (Exception ex)
            {
                var unboxedSender = (PictureBox)sender;
                unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
            }
        }

        /// <summary>
        /// Обработчик события после наведения мышкой на элемент проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxMouseLeave(object sender, EventArgs e)
        {
            try
            {
                var unboxedSender = (RoundedPictureBox)sender;
                if (unboxedSender.Name == "newProjectBox")
                    unboxedSender.BackColor = Color.Gainsboro;
                else
                    unboxedSender.BackColor = ControlPaint.LightLight(unboxedSender.BackColor);
            }
            catch (Exception ex)
            {
                var unboxedSender = (PictureBox)sender;
                if (unboxedSender.Name == "newProjectBox")
                    unboxedSender.BackColor = Color.Gainsboro;
                else
                    unboxedSender.BackColor = ControlPaint.LightLight(unboxedSender.BackColor);
            }
        }

        /// <summary>
        /// Обработчик события при создании нового проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewRoundedPictureBoxMouseClick(object sender, MouseEventArgs e)
        {
            // Если число проектов уже максимально.
            if (projects.Count == 9)
            {
                MessageBox.Show("Максимальное количество проектов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            newProjectSettingsForm = new CreateProject("");
            // Отображение формы создания проекта.
            DialogResult result = newProjectSettingsForm.ShowDialog();
            newProjectSettingsForm.Dispose();
            if (CreateProject.ProjectName == null)
                return;
            else
            {
                // Создание нового проекта.
                Project project = new Project(CreateProject.ProjectName, new RoundedPictureBox(),
                    CreateProject.ProjectColor, contextMenuStrip1);
                // Добавление проекта в таблицу проектов.
                projectsTable[currentRow, currentColumn] = project.ProjectControl;
                project.ProjectControl.Name += currentRow.ToString() + currentColumn.ToString();
                // Добавление обработчиков событий.
                project.ProjectControl.MouseEnter += RoundedPictureBoxMouseEnter;
                project.ProjectControl.MouseLeave += RoundedPictureBoxMouseLeave;
                project.ProjectControl.Paint += ProjectBoxPaint;
                project.ProjectControl.MouseClick += ProjectBoxMouseDown;
                projects.Add(project);
                // Изменение свободной позиции.
                if (currentColumn == 2) currentRow++;
                currentColumn = (currentColumn + 1) % 3;
                if (currentRow < 3)
                    projectsTable[currentRow, currentColumn] = newProjectBox;
                if (projects.Count == 9)
                    projectsTable.Controls.Remove(newProjectBox);
            }

        }

        /// <summary>
        /// Обработчик при нажатии на текущий проект.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectBoxMouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            tasksForm.SetData(currentProject, users);
            tasksForm.ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// Отрисовка название на элементе проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectBoxPaint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font(myFont.Families[0], 13, FontStyle.Bold))
            {
                e.Graphics.DrawString((sender as RoundedPictureBox).Name.Substring(0,
                    (sender as RoundedPictureBox).Name.Length - 2), font,
                    Brushes.Black, new Point(12, 10));
            }
        }

        /// <summary>
        /// Изменение названия проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeNameToolStripMenuItemClick(object sender, EventArgs e)
        {
            newProjectSettingsForm = new CreateProject(currentProject.Name);
            DialogResult result = newProjectSettingsForm.ShowDialog();
            newProjectSettingsForm.Dispose();
            if (CreateProject.ProjectName != null)
            {
                currentProject.ProjectControl.Name = CreateProject.ProjectName;
                currentProject.ProjectControl.Invalidate();
            }
        }

        /// <summary>
        /// Удаление проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите безвозвратно удалить проект " +
                currentProject.ProjectControl.Name + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            // Удаление проекта из таблицы.
            projectsTable.Controls.Remove(currentProject.ProjectControl);
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    if (projectsTable[row, column] == null)
                    {
                        // Удаление всех задач, подзадач и исполнителей.
                        Project project = projects[row * 3 + column];
                        int count = project.TaskList.Count;
                        for (var pos = 0; pos < count; pos++)
                            tasksForm.RemoveControl(0);
                        projects.RemoveAt(row * 3 + column);
                        // Перемещает все проекты на нужные позиции после удаления.
                        SwapAllProjects(row, column);
                        if (currentColumn == 0)
                        {
                            currentRow--;
                            currentColumn = 2;
                        }
                        else currentColumn--;
                        if (projects.Count == 8)
                            projectsTable[2, 2] = newProjectBox;

                        return;
                    }
        }

        /// <summary>
        /// Метод расставляет оставшиеся проеты после удаления одного.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private void SwapAllProjects(int row, int column)
        {
            int previ = row, prevj = column;
            for (var i = row; i < 3; i++)
                for (var j = i == previ ? column + 1 : 0; j < 3; j++)
                {
                    try
                    {
                        projectsTable[previ, prevj] = projectsTable[i, j];
                        if (projectsTable[previ, prevj].Name == "newProjectBox") return;
                        previ = i; prevj = j;
                    }
                    catch (Exception ex) { return; }
                }
        }

        /// <summary>
        /// Нажатие кнопки отображение пользователей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            User.BeginControlUpdate(tableLayoutPanel2);
            // Удаление таблица проектов.
            tableLayoutPanel2.Controls.Remove(projectsTable);
            for (int row = 0; row < users.Count; row++) users[row].SetControls(usersTable, row);
            // Добавление таблицы пользователей.
            tableLayoutPanel2.Controls.Add(usersTable, 0, 1);
            usersTable.Dock = DockStyle.Fill;
            toolStripButton3.Visible = true;
            usersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            User.EndControlUpdate(tableLayoutPanel2);
        }

        /// <summary>
        /// Нажание кнопки отображение проектов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel2.Controls.Add(projectsTable);
            tableLayoutPanel2.Controls.Remove(usersTable);
            toolStripButton3.Visible = false;
            tableLayoutPanel2.ResumeLayout();
        }

        /// <summary>
        /// Зактытие формы.
        /// При закрытии формы создается сохрание состоятий всех проектов и пользователей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectsFormClosing(object sender, FormClosingEventArgs e)
        {
            Backup.MakeBackup(projects, users);
        }
    }
}
