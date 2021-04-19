using System;
using System.Windows.Forms;

namespace ProductManager
{

    /// <summary>
    /// Класс, который описывает продукт, хранящийся на складе.
    /// Атрибут не обязателен.
    /// </summary>
    [Serializable]
    public class Product
    {
        // Поля публичные, потому что объекты сохраняются в json формате.
        public string name;
        public string code;
        public double price;
        public int count;
        internal Label Name { get; } = new Label();
        internal Label Code { get; } = new Label();
        internal Label Price { get; } = new Label();
        internal Label Count { get; } = new Label();
        internal PictureBox Icon { get; } = new PictureBox();

        /// <summary>
        /// Стандартный конструктор товара.
        /// </summary>
        /// <param name="name">Название товара.</param>
        /// <param name="code">Артикул.</param>
        /// <param name="count">Количество на складе.</param>
        /// <param name="price">Цена товара.</param>
        public Product(string name, string code, int count, double price)
        {
            this.name = name;
            this.code = code;
            this.count = count;
            this.price = price;
            Name.Text = name;
            Code.Text = code;
            Price.Text = price.ToString();
            Count.Text = count.ToString();
            Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Icon.BackgroundImage = Properties.Resources.zxc; // count >= 2 ? Properties.Resources.zxc : Properties.Resources.bodnal;
            Icon.BackgroundImageLayout = ImageLayout.Zoom;
            Icon.Cursor = Cursors.Hand;
        }
        
        /// <summary>
        /// Устанавливает контролы товара в таблицу.
        /// </summary>
        /// <param name="table">Таблица.</param>
        /// <param name="row">Строка таблицы.</param>
        public void SetControl(TableLayoutPanel table, int row)
        {
            table.Controls.Add(Name, 1, row);
            table.Controls.Add(Code, 2, row);
            table.Controls.Add(Count, 3, row);
            table.Controls.Add(Price, 4, row);
            table.Controls.Add(Icon, 0, row);
            Name.Dock = DockStyle.Fill;
            Price.Dock = DockStyle.Fill;
            Count.Dock = DockStyle.Fill;
            Code.Dock = DockStyle.Fill;
            Icon.Dock = DockStyle.Fill;
            Icon.Margin = new Padding(1);
            Icon.Name = (row - 1).ToString();
        }

        public override string ToString()
        {
            return code + "," + name + "," + count;
        }

    }
}
