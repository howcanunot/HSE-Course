using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Settings : Form
    {

        static Graphics graphics;
        static Pen startPen;
        static Pen endPen;
        static BaseFractal fractal;
        static int maxDepth;
        static Bitmap bmp;
        static bool isImage = false;
        static int saveCount = 1;

        public Settings(string name)
        {
            InitializeComponent();
            nameOfFractal.Text = name;
            startPen = new Pen(Color.White, 1);
            endPen = new Pen(Color.White, 1);
            bool flag = false;

            switch (name.Replace("\r", "").Replace("\n", "").Replace(" ", ""))
            {
                case "Фрактальноедерево":
                    fractal = new FractalTree();
                    label2.Visible = true; numericUpDown2.Visible = true;
                    label3.Visible = true; numericUpDown3.Visible = true;
                    label4.Visible = true; numericUpDown4.Visible = true;
                    flag = true;
                    break;
                case "КриваяКоха":
                    fractal = new Curve();
                    break;
                case "КовёрСерпинского":
                    fractal = new Carpet();
                    startPen.Color = Color.DarkBlue;
                    endPen.Color = Color.DarkBlue;
                    pictureBox1.BackColor = startPen.Color;
                    pictureBox2.BackColor = startPen.Color;
                    break;
                case "ТреугольникСерпинского":
                    fractal = new Triangle();
                    break;
                case "МножествоКантора":
                    fractal = new CantorSet();
                    break;
            }
            if (!flag)
            {
                label5.Location = new Point(42, 174);
                pictureBox1.Location = new Point(257, 174);
                label6.Location = new Point(42, 218);
                pictureBox2.Location = new Point(257, 217);
            }
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(ScreenFeatures.MaxWidth, ScreenFeatures.MaxHeight);
            this.MinimumSize = new Size(ScreenFeatures.MinWidth, ScreenFeatures.MinHeight);
            this.Size = new Size(ScreenFeatures.MinWidth + 100, ScreenFeatures.MinHeight + 100);
            this.Visible = false;

        }

        private void SettingsLoad(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maxDepth = fractal.MaxRecursionDepth;
            numericUpDown1.Maximum = maxDepth + 1;
            numericUpDown1.Value = maxDepth / 2;
        }

        private void backToFractalClick(object sender, EventArgs e)
        {
            this.Dispose();
            Program.mainForm.Visible = true;
        }

        private void PaintButtonClick(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            isImage = true;
            using (graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.Black);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                fractal.PaintFractal(GetColorList((int)numericUpDown1.Value), graphics, pictureBox.Width, pictureBox.Height,
                    (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (double)numericUpDown4.Value);
                pictureBox.Image = bmp;
            }
        }

        private List<Color> GetColorList(int size)
        {
            int rMax = endPen.Color.R;
            int rMin = startPen.Color.R;
            int bMax = endPen.Color.B;
            int bMin = startPen.Color.B;
            int gMax = endPen.Color.G;
            int gMin = startPen.Color.G;
            List<Color> colorList = new List<Color>();
            colorList.Add(startPen.Color);
            for (int i = 1; i < size - 1; i++)
            {
                var rAverage = rMin + (int)((rMax - rMin) * i / size);
                var gAverage = gMin + (int)((gMax - gMin) * i / size);
                var bAverage = bMin + (int)((bMax - bMin) * i / size);
                colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
            colorList.Add(endPen.Color);
            return colorList;
        }

        private void SettingsFormClosed(object sender, FormClosedEventArgs e)
        {
            backToFractalClick(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(numericUpDown1.Value.ToString(), out int number))
            {
                MessageBox.Show($"[!] Глубина рекурсии - натуральное число [1; {maxDepth}]!");
                numericUpDown1.Value = Math.Round(numericUpDown1.Value);
            }
            if ((int)numericUpDown1.Value > maxDepth)
            {
                MessageBox.Show($"[!] Глубина рекурсии - натуральное число [1; {maxDepth}]!");
                numericUpDown1.Value = maxDepth;
            }
            if ((int)numericUpDown1.Value < 1)
            {
                MessageBox.Show($"[!] Глубина рекурсии - натуральное число [1; {maxDepth}]!");
                numericUpDown1.Value = 1;
            }
        }

        private void NumericUpDown2ValueChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(numericUpDown2.Value.ToString(), out int number))
            {
                MessageBox.Show("[!] Угол наклона - натуральное число [15; 90]!");
                numericUpDown2.Value = Math.Round(numericUpDown1.Value);
            }
            if ((int)numericUpDown2.Value > 90)
            {
                MessageBox.Show("[!] Угол наклона - натуральное число [15; 90]!");
                numericUpDown2.Value = 90;
            }
            if ((int)numericUpDown2.Value < 15)
            {
                MessageBox.Show("[!] Угол наклона - натуральное число [15; 90]!");
                numericUpDown2.Value = 15;
            }
        }

        private void NumericUpDown3ValueChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(numericUpDown3.Value.ToString(), out int number))
            {
                MessageBox.Show("[!] Угол наклона - натуральное число [15; 90]!");
                numericUpDown3.Value = Math.Round(numericUpDown1.Value);
            }
            if ((int)numericUpDown3.Value > 90)
            {
                MessageBox.Show("[!] Угол наклона - натуральное число [15; 90]!");
                numericUpDown3.Value = 90;
            }
            if ((int)numericUpDown3.Value < 15)
            {
                MessageBox.Show("[!] Угол наклона - натуральное число [15; 90]!");
                numericUpDown3.Value = 15;
            }
        }

        private void NumericUpDown4ValueChanged(object sender, EventArgs e)
        {

            if ((double)numericUpDown4.Value > 0.64)
            {
                MessageBox.Show("[!] Отношение отрезков - вещественное число [0,4; 0,64]");
                numericUpDown4.Value = 0.64M;
            }
            if ((double)numericUpDown4.Value < 0.4)
            {
                MessageBox.Show("[!] Отношение отрезков - вещественное число [0,4; 0,64]");
                numericUpDown4.Value = 0.4M;
            }
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                startPen.Color = colorDialog1.Color;
            }
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
                endPen.Color = colorDialog1.Color;

            }
        }

        private void SaveImageClick(object sender, EventArgs e)
        {
            if (!isImage)
            {
                MessageBox.Show("Сначала нарисуйте фрактал!");
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image.Save(folderBrowserDialog1.SelectedPath + "\\fractal" + saveCount.ToString() + ".png", ImageFormat.Png);
                }
                catch (Exception)
                {
                    MessageBox.Show("Нельзя сохранить фрактал в этой папке!");
                }
            }

        }
    }
}
