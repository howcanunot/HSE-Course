using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class CreateProductForm : Form
    {
        public static Product product;
        bool formClose = false;

        /// <summary>
        /// Конструктор вызывается при создании нового товара.
        /// </summary>
        public CreateProductForm()
        {
            InitializeComponent();
            product = null;
            this.KeyPreview = true;
            button2.Click += delegate (object sender, EventArgs e)
            {
                this.Close();
            };
        }

        /// <summary>
        /// Конструктор вызывается при изменение существующего товара.
        /// </summary>
        public CreateProductForm(Product oldProduct)
        {
            InitializeComponent();
            name.Text = oldProduct.Name.Text;
            code.Text = oldProduct.Code.Text;
            countTb.Text = oldProduct.Count.Text;
            priceTb.Text = oldProduct.Price.Text;
            product = null;
            this.KeyPreview = true;
            button2.Click += delegate (object sender, EventArgs e)
            {
                this.Close();
            };

        }

        /// <summary>
        /// Обработчик нажатия на кнопку создания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateClick(object sender, EventArgs e)
        {
            double price;
            int count;

            try
            {
                ValidatesTextBoxes(out count, out price);
            } catch (ArgumentException exeption)
            {
                MessageBox.Show(exeption.Message, "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            product = new Product(name.Text, code.Text, count, price);
            this.Close();
        }

        /// <summary>
        /// Проверка корректности полей.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="price"></param>
        private void ValidatesTextBoxes(out int count, out double price)
        {
            count = 0;
            price = 0;

            if (name.Text.Length == 0)
                throw new ArgumentException("Название не может быть пустым");

            if (code.Text.Length == 0)
                throw new ArgumentException("Код не может быть пустым");

            if (!int.TryParse(countTb.Text.Replace(".", ","), out count))
                throw new ArgumentException("Количество должно быть целым значением");

            if (!double.TryParse(priceTb.Text.Replace(".", ","), out price))
                throw new ArgumentException("Количество должно быть целым значением");

        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProductFormClosed(object sender, FormClosedEventArgs e)
        {
            if (formClose == true)
                return;
            formClose = true;
            this.Close();
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CreateClick(sender, new EventArgs());
        }
    }
}
