using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerLibrary;
using TaskManagerLibrary.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManager
{
    partial class Projects
    {
        // Таблица пользователей.
        ProjectsTableLayout usersTable;
        // Текущий пользователь.
        User currentUser;
        // Список пользователей.
        List<User> users = new List<User>();
        int tailRow = 0;
        /// <summary>
        /// Редактирует таблицу пользователей.
        /// </summary>
        private void EditRowsAndCells()
        {
            // Создание столбцов.
            usersTable.ColumnCount = 5;
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            usersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            usersTable.Location = new System.Drawing.Point(10, 10);
            // Создание строк.
            usersTable.RowCount = 10;
            for (var count = 0; count < 10; count++)
                usersTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            usersTable.Size = new System.Drawing.Size(300, 300);
        }

        /// <summary>
        /// Обработчик создания нового пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewUserClick(object sender, EventArgs e)
        {
            // Если достигнуто максимальное количество пользователей.
            if (users.Count == 10)
            {
                MessageBox.Show("Максимальное количество пользователей", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Создание нового пользователя.
            User user = new User(Properties.Resources.User, Properties.Resources.Edit,
                Properties.Resources.Delete, new TextBox(), 1.0f * this.Height / 40, 0, "Unnamed");
            User.BeginControlUpdate(usersTable);
            // Расположение элементов пользователя в таблице пользователей.
            user.SetControls(usersTable, users.Count);
            User.EndControlUpdate(usersTable);
            user.EditName.MouseEnter += User.UserMouseEnter;
            user.EditName.MouseLeave += User.UserMouseLeave;
            user.DeleteUser.MouseLeave += User.UserMouseLeave;
            user.DeleteUser.MouseEnter += User.UserMouseEnter;
            user.EditName.MouseDown += EditBoxClick;
            user.DeleteUser.MouseDown += DeleteBoxClick;
            user.UserTextBox.MouseEnter += TextBoxEnter;
            user.UserTextBox.LostFocus += TextBoxLostFocus;
            user.UserTextBox.Focus();
            users.Add(user);
            currentUser = user;

            tailRow++;
        }

        /// <summary>
        /// Обработчик наведение на текстБокс пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxEnter(object sender, EventArgs e)
        {
            currentUser = users[int.Parse((sender as TextBox).Name)];
        }

        /// <summary>
        /// Обработчик события при нажатии мышкой на редактирование пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBoxClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (!int.TryParse(pb.Name, out int row))
                throw new ArgumentException("NullReference exception");
            TextBox userTb = users[row].UserTextBox;
            userTb.Enabled = true;
            userTb.Focus();
            userTb.SelectAll();
        }

        /// <summary>
        /// Обработчик события при наведения мышкой на удаление пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBoxClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (!int.TryParse(pb.Name, out int row))
                throw new ArgumentException("NullReference exception");
            tailRow--;
            RemoveControl(row);
        }


        /// <summary>
        /// Удаляет пользователя из таблицы пользователей и двигает остальных.
        /// </summary>
        /// <param name="row"></param>
        private void RemoveControl(int row)
        {
            User.BeginControlUpdate(usersTable);

            for (var col = 0; col < 5; col++) usersTable.Controls.Remove(usersTable[row, col]);
            for (var pos = row + 1; pos < users.Count; pos++)
                users[pos].SetControls(usersTable, pos - 1);

            User user = users[row];
            // Удаление пользователя из списка исполнителей всех задач.
            foreach (var project in projects)
            {
                foreach (var task in project.TaskList)
                {
                    for (var i = 0; i < task.Users.Count; i++)
                        if (task.Users[i].UserTextBox.Text == user.UserTextBox.Text)
                            task.Users.RemoveAt(i);
                    if (task.Subtasks != null) {
                        foreach (var subtask in task.Subtasks)
                        {
                            for (var j = 0; j < subtask.Users.Count; j++)
                                if (subtask.Users[j].UserTextBox.Text == user.UserTextBox.Text)
                                    subtask.Users.RemoveAt(j);
                        }
                    }
                }
            }
                

            users.RemoveAt(row);

            User.EndControlUpdate(usersTable);

        }

        /// <summary>
        /// Обработчик события при нажатии кнопки Enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectsKeyDown(object sender, KeyEventArgs e)
        {
            if (toolStripButton3.Visible && currentUser != null && e.KeyCode == Keys.Enter)
            {
                tableLayoutPanel2.Focus();

            }
        }

        /// <summary>
        /// Обработчик события при потере фокуса с текущего текстБокса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxLostFocus(object sender, EventArgs e)
        {
            foreach (var user in users)
                if (user.UserTextBox.Text == currentUser.UserTextBox.Text && user != currentUser)
                {
                    MessageBox.Show("Пользователь с таким именем уже существует", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentUser.UserTextBox.Focus();
                    currentUser.UserTextBox.SelectAll();
                    return;
                }
            currentUser.UserTextBox.Enabled = false;
        }


    }
}
