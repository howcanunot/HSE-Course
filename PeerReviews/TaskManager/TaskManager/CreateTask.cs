using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagerLibrary.Tasks;

namespace TaskManager
{
    /// <summary>
    /// Форма для создания новой задачи.
    /// </summary>
    public partial class CreateTask : Form
    {
        bool formClosed = false;
        // Тип задачи.
        static string tasktype;
        // Описания задачи.
        static string description;
        public static string TaskType
        {
            get => tasktype;
            set => tasktype = value;
        }
        public static string Description
        {
            get => description;
            set => description = value;
        }
        /// <summary>
        /// Форма работает по-разному в зависимости от того, создаются ли задачи внутри Epic.
        /// </summary>
        /// <param name="epic"></param>
        public CreateTask(Epic epic)
        {
            InitializeComponent();
            // При создании задач внутри Epic удалются некоторые типы.
            if (epic != null)
            {
                type.Items.RemoveAt(0);
                type.Items.RemoveAt(2);
            }
            this.Text = "Create task";
            type.SelectedIndex = 0;
            //this.MinimumSize = new Size(458, 210);
            //this.MaximumSize = this.MinimumSize;
            this.KeyPreview = true;
            this.KeyDown += FormKeyDown;
            typeLabel.Font = new Font(Projects.myFont.Families[0], 9);
            label1.Font = typeLabel.Font;
            textBox.Font = typeLabel.Font;
            textBox.Focus();
            type.Font = new Font(Projects.myFont.Families[0], 7);
        }

        /// <summary>
        /// Отрисовка текста на боксе создания задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxPaint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font(Projects.myFont.Families[0], 10))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawString("Создать задачу", font, Brushes.White, new Point(2, 4));
            }
        }

        /// <summary>
        /// Обработчик события при наведения мышкой на элемент.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxMouseEnter(object sender, EventArgs e)
        {
            try
            {
                var unboxedSender = (RoundedPictureBox)sender;
                unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
            }
            catch (Exception ex)
            {
                var unboxedSender = (PictureBox)sender;
                unboxedSender.BackColor = ControlPaint.Dark(unboxedSender.BackColor);
            }
        }

        /// <summary>
        /// Обработчик события после наведения мышкой на элемент.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxMouseLeave(object sender, EventArgs e)
        {
            try
            {
                var unboxedSender = (RoundedPictureBox)sender;
                unboxedSender.BackColor = ControlPaint.LightLight(unboxedSender.BackColor);
            }
            catch (Exception ex)
            {
                var unboxedSender = (PictureBox)sender;
                unboxedSender.BackColor = ControlPaint.LightLight(unboxedSender.BackColor);
            }
        }

        /// <summary>
        /// Обработчик, который вызывается при нажатии кнопки создать задачу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            TaskType = type.Text;
            Description = textBox.Text;
            if (!formClosed)
            {
                formClosed = true;
                this.Close();
            }
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!formClosed)
            {
                TaskType = null;
                Description = null;
                formClosed = true;
                this.Close();
            }
        }

        /// <summary>
        /// Обработчик нажания enter на клавиатуре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RoundedPictureBoxMouseDown(sender, new MouseEventArgs(new MouseButtons(), 0, 0, 0, 0));
        }
    }
}
