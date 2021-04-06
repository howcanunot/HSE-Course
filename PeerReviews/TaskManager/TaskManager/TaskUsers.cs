using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TaskManagerLibrary;

namespace TaskManager
{
    partial class Tasks
    {
        /// <summary>
        /// Обрабочик нажания на инонку списка исполнителей задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskUsersClick(object sender, EventArgs e)
        {
            // Прячет кнопку создания новоя задачи.
            toolStripButton3.Visible = false;
            User.BeginControlUpdate(tableLayoutPanel1);
            this.Text += "\\Users";
            // Удаление списка задач.
            tableLayoutPanel1.Controls.Remove(tasksTable);
            // Добавление таблицы исполнителей.
            tableLayoutPanel1.Controls.Add(usersTable, 0, 1);
            usersTable.Dock = DockStyle.Fill;
            // Обнуляет исполнителей.
            for (int row = 0; row < users.Count; row++)
            {
                users[row].Check.MouseClick -= CheckClick;
                users[row].Check.Checked = false;
            }
            usersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            // Сравнивает список исполнителей и список пользователь.
            // Если найдено соответствие, в checkBox'e будет стоять галочка.
            for (var pos = 0; pos < currentTask.Users.Count; pos++)
                for (var ind = 0; ind < users.Count; ind++)
                    if (currentTask.Users[pos].UserTextBox.Text == users[ind].UserTextBox.Text)
                    {
                        users[ind].Check.Checked = true;
                        break;
                    }
             for (int row = 0; row < users.Count; row++) users[row].Check.MouseClick += CheckClick;

            User.EndControlUpdate(tableLayoutPanel1);

        }
        /// <summary>
        /// Создает и редактирует таблицу исполниетелей.
        /// </summary>
        private void EditUsersTable()
        {
            // Создание таблицы.
            usersTable = new TableLayoutPanel();
            usersTable.BackColor = Color.Bisque;
            // Создание столбцов.
            usersTable.ColumnCount = 3;
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            usersTable.Location = new System.Drawing.Point(10, 10);
            // Создание строк.
            usersTable.RowCount = 10;
            for (var count = 0; count < 10; count++)
                usersTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            for (int row = 0; row < users.Count; row++)
            {
                usersTable.Controls.Add(users[row].UserPictureBox, 0, row);
                usersTable.Controls.Add(users[row].UserTextBox, 1, row);
                usersTable.Controls.Add(users[row].Check, 2, row);
                users[row].Check.Dock = DockStyle.Fill;
                users[row].Check.MouseClick -= CheckClick;
                users[row].Check.MouseClick += CheckClick;
            }

        }

        /// <summary>
        /// Обработчик событий при добавлении или удалении исполнителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckClick(object sender, EventArgs e)
        {
            CheckBox check = (sender as CheckBox);
            int row = int.Parse(check.Name);
            if (check.Checked)
            {
                try
                {
                    // Добавление задачи.
                    currentTask.AddUser(users[row]);
                    users[row].TasksAmount.Text = (int.Parse(users[row].TasksAmount.Text) + 1).ToString();
                    return;
                } catch (Exception ex)
                {
                    // Если количество исполнителей максимально.
                    MessageBox.Show("Максимальное количество исполнителей", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check.Checked = false; 
                    return;
                }
            }
            else
            {
                // Удаление исполнителя.
                currentTask.RemoveUser(users[row]);
                users[row].TasksAmount.Text = (int.Parse(users[row].TasksAmount.Text) - 1).ToString();
                return;
            }
        }
    }
}
