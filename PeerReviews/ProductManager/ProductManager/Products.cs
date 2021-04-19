using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProductManager
{
    partial class Manager
    {

        /// <summary>
        /// Вызывает форму создания нового товара и вставляет его в таблицу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewProductClick(object sender, EventArgs e)
        {
            // Вызов формы.
            var productForm = new CreateProductForm();
            productForm.ShowDialog();
            if (CreateProductForm.product == null) return;
            try
            {
                // Создание товара.
                Product newProduct = CreateProductForm.product;
                newProduct.Icon.ContextMenuStrip = productsMenuStrip;

                currentList.Add(newProduct);
                ControlUpdate.BeginControlUpdate(productsTable);
                // Расположение в таблице.
                productsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                productsTable.RowCount++;
                productsTable.RowStyles[currentList.Count].SizeType = SizeType.Absolute;
                productsTable.RowStyles[currentList.Count].Height = 20;
                newProduct.SetControl(productsTable, currentList.Count);

                ControlUpdate.EndControlUpdate(productsTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        /// <summary>
        /// Изменение товара.
        /// Изменение товара вызывает форму, после которой создается новый товар, а не меняется старый.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeProductClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripItem;
            var owner = menu.Owner as ContextMenuStrip;

            PictureBox pb = (PictureBox)owner.SourceControl;
            var product = currentList[int.Parse(pb.Name)];
            var productForm = new CreateProductForm(product);

            // Вызов формы.
            productForm.ShowDialog();
            if (CreateProductForm.product == null) return;

            for (var col = 0; col < tableColsCount; col++)
                productsTable.Controls.Remove(productsTable.GetControlFromPosition(col, int.Parse(pb.Name) + 1));
            currentList[int.Parse(pb.Name)] = CreateProductForm.product;

            ControlUpdate.BeginControlUpdate(productsTable);
            currentList[int.Parse(pb.Name)].SetControl(productsTable, int.Parse(pb.Name) + 1);
            ControlUpdate.EndControlUpdate(productsTable);
        }

        /// <summary>
        /// Удаление товара и сдвиг остальных товаров вверх.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProductClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripItem;
            var owner = menu.Owner as ContextMenuStrip;

            PictureBox pb = (PictureBox)owner.SourceControl;
            var product = currentList[int.Parse(pb.Name)];
            int row = int.Parse(pb.Name);

            ControlUpdate.BeginControlUpdate(productsTable);

            for (var col = 0; col < tableColsCount; col++) productsTable.Controls.Remove(productsTable.GetControlFromPosition(col, row+1));
            for (var pos = row + 1; pos < currentList.Count; pos++)
                currentList[pos].SetControl(productsTable, pos);


            productsTable.RowCount--;

            currentList.RemoveAt(row);

            ControlUpdate.EndControlUpdate(productsTable);

        }

    }
}
