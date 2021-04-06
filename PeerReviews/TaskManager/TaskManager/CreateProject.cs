using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    /// <summary>
    /// Форма для создания нового проекта.
    /// </summary>
    public partial class CreateProject : Form
    {
        // Статические члены.
        // Название и цвет проекта.
        public static bool formClosed;
        static string name;
        static Color color;
        // Св-ва для нужных полей.
        public static string ProjectName
        {
            get => name;
            set => name = value;
        }
        public static Color ProjectColor
        {
            get => color;
            set => color = value;
        }
        /// <summary>
        /// Эта форма вызывается при создании нового провета и при изменении старого.
        /// Если проект новый, но text == "", иначе text == старое название проекта.
        /// </summary>
        /// <param name="text"></param>
        public CreateProject(string text)
        {
            InitializeComponent();
            this.Text = "Create project";
            formClosed = false;
            textBox1.Text = text;
            roundedPictureBox1.BackColor = pictureBox1.BackColor;
            roundedPictureBox1.BackColor = ControlPaint.Light(roundedPictureBox1.BackColor);
            ProjectColor = roundedPictureBox1.BackColor;
            this.KeyPreview = true;
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
            } catch (Exception ex)
            {
                var unboxedSender = (PictureBox)sender;
                unboxedSender.BackColor = ControlPaint.LightLight(unboxedSender.BackColor);
            }
        }

        /// <summary>
        /// Отрисовка текста на элементе создания проекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxPaint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font(Projects.myFont.Families[0], 10))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawString("Создать проект", font, Brushes.White, new Point(7
                    , 4));
            }
        }

        /// <summary>
        /// Обработчик, который вызывается при нажатии кнопки создать проект.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundedPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            ProjectName = textBox1.Text;
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
        private void SettingsClosing(object sender, FormClosingEventArgs e)
        {
            if (!formClosed)
            {
                formClosed = true;
                ProjectName = null;
                this.Close();
            }
        }

        /// <summary>
        /// Обработчик наведения на боксы цветов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            Color pbColor = (sender as PictureBox).BackColor;
            pbColor = ControlPaint.LightLight(pbColor);
            roundedPictureBox1.BackColor = pbColor;
            ProjectColor = roundedPictureBox1.BackColor;
        }

        /// <summary>
        /// Обработчик нажания enter на клавиатуре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RoundedPictureBoxMouseDown(sender, new MouseEventArgs(new MouseButtons(), 0, 0, 0, 0));
        }
    }
}
