using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagerLibrary
{
    /// <summary>
    /// Класс, реализующий сущность пользователя.
    /// </summary>
    public class User
    {
        // Поле для "заморозки" формы.
        private const int WM_SETREDRAW = 11;

        // Иконка пользователя.
        public PictureBox UserPictureBox { get; }
        // Иконка изменения названия пользователя.
        public PictureBox EditName { get; }
        // Иконка удаления пользователя.
        public PictureBox DeleteUser { get; }
        // CheckBox для задач, в которых пользователь является исполнителем.
        public CheckBox Check { get; }
        // TextBox, который хранит имя пользоавтеля.
        public TextBox UserTextBox { get; }
        // Количество задач у пользователя на исполнении.
        public Label TasksAmount { get; }

        /// <summary>
        /// Конструктор задает нужные параметры элементам пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="edit"></param>
        /// <param name="delete"></param>
        /// <param name="tb"></param>
        /// <param name="height"></param>
        /// <param name="tasks"></param>
        /// <param name="name"></param>
        public User(Bitmap user, Bitmap edit, Bitmap delete, TextBox tb, float height, int tasks, string name)
        {
            UserPictureBox = new PictureBox();
            EditName = new PictureBox();
            DeleteUser = new PictureBox();
            UserTextBox = tb;
            TasksAmount = new Label();
            Check = new CheckBox();
            Check.CheckAlign = ContentAlignment.MiddleCenter;
            Check.AutoSize = false; Check.Size = new Size(40, 40);
            UserPictureBox.BackgroundImage = user;
            UserPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            EditName.BackgroundImage = edit;
            EditName.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteUser.BackgroundImage = delete;
            DeleteUser.BackgroundImageLayout = ImageLayout.Zoom;
            UserTextBox.ForeColor = SystemColors.WindowText;
            UserTextBox.Text = name;
            UserTextBox.Font = new Font("Vardana", height, FontStyle.Bold);
            UserTextBox.BackColor = Color.LightSteelBlue;
            TasksAmount.Text = tasks.ToString();
            TasksAmount.TextAlign = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Метод, который распологает все нужные элементы в таблице пользователей.
        /// </summary>
        /// <param name="table">Таблица пользователей.</param>
        /// <param name="row">Нужная строка.</param>
        public void SetControls(TableLayoutPanel table, int row)
        {
            table.Controls.Add(UserPictureBox, 0, row);
            table.Controls.Add(UserTextBox, 1, row);
            table.Controls.Add(TasksAmount, 2, row);
            table.Controls.Add(EditName, 3, row);
            table.Controls.Add(DeleteUser, 4, row);
            UserPictureBox.Dock = DockStyle.Fill;
            EditName.Dock = DockStyle.Fill;
            DeleteUser.Dock = DockStyle.Fill;
            TasksAmount.Dock = DockStyle.Fill;
            UserTextBox.Dock = DockStyle.Fill;
            EditName.Cursor = Cursors.Hand;
            DeleteUser.Cursor = Cursors.Hand;
            EditName.Name = row.ToString();
            DeleteUser.Name = row.ToString();
            UserTextBox.Name = row.ToString();
            Check.Name = row.ToString();
        }

        /// <summary>
        /// Обработчик событий при наведении на иконки пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void UserMouseEnter(object sender, EventArgs e)
        {
            var unboxedSender = (PictureBox)sender;
            unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
        }

        /// <summary>
        /// Обработчик событий после наведения на иконки пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void UserMouseLeave(object sender, EventArgs e)
        {
            var unboxedSender = (PictureBox)sender;
            unboxedSender.BackColor = Color.Bisque;
        }


        /// <summary>
        /// Этот метод я взял со stackOverflow.
        /// Его цель - "морозить" форму, чтобы при добавлений на нее элементов это не выглядело коряво.
        /// Честно понятия не имею, что он делает, но работает это хорошо.
        /// </summary>
        /// <param name="control">visual control</param>
        public static void BeginControlUpdate(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                  IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }

        /// <summary>
        /// Размораживает форму.
        /// </summary>
        /// <param name="control">visual control</param>
        public static void EndControlUpdate(Control control)
        {
            IntPtr wparam = new IntPtr(1);
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                  IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Invalidate();
            control.Refresh();
        }

    }
}
