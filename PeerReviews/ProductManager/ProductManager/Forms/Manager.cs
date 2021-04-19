using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace ProductManager
{
    public partial class Manager : Form
    {
        // связывает ноды и список товаров для каждого раздела
        Dictionary<string, List<Product>> nodesProducts;
        List<Product> currentList;
        int tableColsCount = 5;
        string path = Directory.GetCurrentDirectory() + "..\\..\\..\\";
        string savepath = Directory.GetCurrentDirectory() + "..\\..\\..\\storages";

        public Manager()
        {
            InitializeComponent();
            // DesializeTreeView();
            nodesProducts = new Dictionary<string, List<Product>>();
            treeView.BackColor = Color.FromArgb(255, 37, 37, 38);
            treeView.ForeColor = Color.White;
            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.Folder1);
            imageList.Images.Add(Properties.Resources.opened_folder);
            productsTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            productsTable.RowCount = 2;
            treeView.ImageList = imageList;
        }

        /// <summary>
        /// Импортирует склад.
        /// Сначала восстанавливается словарь разделов, а потом массив нод.
        /// Словарь хранится в json формате, ноды в bin.
        /// </summary>
        /// <param name="path"></param>
        private void DesializeTreeView(string path)
        {

            string json;
            using (StreamReader stream = new StreamReader(path + "/nodes_products.json"))
            {
                json = stream.ReadToEnd();
            }
            nodesProducts = JsonConvert.DeserializeObject<Dictionary<string, List<Product>>>(json);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream data = new FileStream(path + "/data.bin", FileMode.Open);

            while (true)
                try
                {
                    treeView.Nodes.Add((TreeNode)formatter.Deserialize(data));
                }
                catch (SerializationException)
                {
                    data.Close();
                    break;
                }
            // Рекурсивный перебор всех нод.
            CallRecursive(treeView);
            if (nodesProducts == null)
                nodesProducts = new Dictionary<string, List<Product>>();
        }

        /// <summary>
        /// После десириализации ноды не сохраняют свое меню, так что их приходится восстанавливать.
        /// </summary>
        /// <param name="treeNode"></param>
        private void SetMenuStripRecursive(TreeNode treeNode)
        {
            treeNode.ContextMenuStrip = nodesMenuStrip;
            foreach (var product in nodesProducts[treeNode.Name])
                product.Icon.ContextMenuStrip = productsMenuStrip;
            foreach (TreeNode node in treeNode.Nodes)
                SetMenuStripRecursive(node);
        }

        // Call the procedure using the TreeView.  
        private void CallRecursive(TreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode node in nodes)
            {
                SetMenuStripRecursive(node);
            }
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagerClose(object sender, FormClosedEventArgs e)
        {
            return;
        }

        /// <summary>
        /// Создание корневого раздера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CteareRoot(object sender, EventArgs e)
        {
            try
            {
                var node = new TreeNode();

                node.Text = GetCurrectName(null);
                node.Name = node.Text + "/";
                // Добавление пустого списка товаров.
                nodesProducts.Add(node.Name, new List<Product>());
                save.Enabled = true;
                import.Enabled = true;

                node.ImageIndex = 0;
                node.ContextMenuStrip = nodesMenuStrip;

                treeView.Nodes.Add(node);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Создание ноды у которой есть родитель.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNode(object sender, EventArgs e)
        {
            ToolStripItem menu = sender as ToolStripItem;

            var node = new TreeNode();
            try
            {
                node.Text = GetCurrectName(treeView.SelectedNode);
                node.Name = treeView.SelectedNode.FullPath + "/" + node.Text + "/";
                // Добавление пустого списка товаров.
                nodesProducts.Add(node.Name, new List<Product>());

                node.ImageIndex = 0;
                node.ContextMenuStrip = nodesMenuStrip;
                treeView.SelectedNode.Nodes.Add(node);
                treeView.SelectedNode.Expand();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Возвращает корректное начальное имя, чтобы никакие разделы не имели одинаковые имена.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private string GetCurrectName(TreeNode parent)
        {
            int count = 0;
            var nodes = parent == null ? treeView.Nodes : parent.Nodes;
            if (nodes.Count == 0)
                return "new1";
            foreach (TreeNode node in nodes)
                if (node.Text.Contains("new")) count = Math.Max(count, int.Parse(node.Text.Substring(3)));
            return "new" + (count + 1).ToString();
        }

        /// <summary>
        /// Изменение имени раздела.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChengenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            if (ValidateNodesName(changeNodeNameTextBox.Text))
            {
                var list = nodesProducts[node.Name];
                nodesProducts.Remove(node.Name);
                node.Text = changeNodeNameTextBox.Text;
                node.Name = node.FullPath + "/";
                nodesProducts.Add(node.Name, list);
                nodesMenuStrip.Close();
            }
            else
            {
                MessageBox.Show("Имя уде занято. Выберите другое", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// Проверяет новое имя раздела на уникальность.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool ValidateNodesName(string text)
        {
            var nodes = treeView.SelectedNode.Nodes;
            foreach (TreeNode node in nodes)
                if (node.Text == text)
                    return false;
            return true;
        }

        /// <summary>
        /// Удаление ноды.
        /// Ноду можно удалить только если раздел пустой.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteNodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            string name = treeView.SelectedNode.Name;
            if (treeView.SelectedNode.Nodes.Count != 0)
            {
                MessageBox.Show("Нельзя удалить непустой раздел", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            treeView.Nodes.Remove(treeView.SelectedNode);
            nodesProducts.Remove(name);
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// Выбор какой-то ноды.
        /// После нажатия мыши в таблице отображается список товаров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodePath = e.Node.Name;
            List<Product> products = nodesProducts[nodePath];
            currentList = products;
            tableLayoutPanel1.Visible = true;
            this.Text = nodePath.Replace("\\", "/");
            productsTable.RowCount = currentList.Count + 2;
            ControlUpdate.BeginControlUpdate(productsTable);
            for (var i = 1; i < productsTable.RowStyles.Count; i++)
                for (var j = 0; j < tableColsCount; j++)
                    productsTable.Controls.Remove(productsTable.GetControlFromPosition(j, i));

            // Устанавливает контролы товаров в таблицу.
            for (var row = 0; row < currentList.Count; row++)
            {
                productsTable.RowStyles[row + 1].SizeType = SizeType.Absolute;
                productsTable.RowStyles[row + 1].Height = 20;
                currentList[row].SetControl(productsTable, row + 1);
            }

            ControlUpdate.EndControlUpdate(productsTable);
        }

        /// <summary>
        /// Выбор ноды левой кнопкой мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// Создание CSV отчета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CSVreview(object sender, EventArgs e)
        {
            if (!int.TryParse(countTb.Text, out int number) || number < 0)
            {
                MessageBox.Show("Количество товаров для дозаказа должно быть целым неотрицательным числом", "Exeption",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (var stream = new StreamWriter(path + "review.csv", false, Encoding.UTF8))
                {

                    stream.WriteLine("путь,атикул,название,количество");
                    foreach (var key in nodesProducts.Keys)
                        foreach (var product in nodesProducts[key])
                            if (product.count <= number)
                                stream.WriteLine(key + "," + product.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Сохранение состояния склада.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClick(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo(savepath);
            int count = dir.GetDirectories().Length;
            string newpath = Path.Combine(savepath, "storage" + count.ToString());
            Directory.CreateDirectory(newpath);

            // Сериализация.

            var formatter = new BinaryFormatter();
            using (FileStream file = new FileStream(newpath + "\\data.bin", FileMode.OpenOrCreate))
            {
                file.SetLength(0);
                foreach (var node in treeView.Nodes)
                    formatter.Serialize(file, node);
            }

            string json = JsonConvert.SerializeObject(nodesProducts, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(newpath + "\\nodes_products.json"))
            {
                writer.Write(json);
            }
        }

        /// <summary>
        /// Импортирование сохраненного склада.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportClick(object sender, EventArgs e)
        {
            save.Enabled = true;
            var dir = new DirectoryInfo(savepath);

            folderBrowserDialog1.SelectedPath = dir.FullName;
            //folderBrowserDialog1.FileName = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    DesializeTreeView(folderBrowserDialog1.SelectedPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
        }

    }
}
