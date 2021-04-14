using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace ProductManager
{
    public partial class Form1 : Form
    {

        Dictionary<string, List<Product>> nodesProducts;
        List<Product> currentList;
        public Form1()
        {
            InitializeComponent();
            DesializeTreeView();
            nodesProducts = new Dictionary<string, List<Product>>();
            treeView.BackColor = Color.FromArgb(255, 37, 37, 38);
            treeView.ForeColor = Color.White;
            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.Folder1);

            treeView.ImageList = imageList;
        }

        private void DesializeTreeView()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("data.bin", FileMode.Open))
            {

            }
        }

        private void CteareRoot(object sender, EventArgs e)
        {
            try
            {
                var node = new TreeNode();

                node.Text = GetCurrectName(null);
                node.Name = node.Text + "/";
                nodesProducts.Add(node.Name, new List<Product>());

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

        private void CreateNode(object sender, EventArgs e)
        {
            ToolStripItem menu = sender as ToolStripItem;

            var node = new TreeNode();
            try
            {
                node.Text = GetCurrectName(treeView.SelectedNode);
                node.Name = treeView.SelectedNode.FullPath + node.Text;
                nodesProducts.Add(node.Name, new List<Product>());

                node.ImageIndex = 0;
                node.ContextMenuStrip = nodesMenuStrip;
                treeView.SelectedNode.Nodes.Add(node);
                treeView.SelectedNode.Expand();

            }
            catch (Exception ex)
            {
                treeView.Nodes[0].Nodes.Add(node);
                return;
            }
        }

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

        private void ChengenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            if (ValidateNodesName(changeNodeNameTextBox.Text))
            {
                node.Text = changeNodeNameTextBox.Text;
                node.Name = node.FullPath + node.Text;
                nodesMenuStrip.Close();
            }
            else
            {
                MessageBox.Show("Имя уде занято. Выберите другое", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private bool ValidateNodesName(string text)
        {
            var nodes = treeView.SelectedNode.Nodes;
            foreach (TreeNode node in nodes)
                if (node.Text == text)
                    return false;
            return true;
        }

        private void DeleteNodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Nodes.Count != 0)
            {
                MessageBox.Show("Нельзя удалить непустой раздел", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            treeView.Nodes.Remove(treeView.SelectedNode);
            var formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("data.bin", FileMode.OpenOrCreate))
            {
                foreach (var node in treeView.Nodes)
                {
                    formatter.Serialize(file, node);
                }
            }
        }

        private void Form1FormClosed(object sender, FormClosedEventArgs e)
        {
            var formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("data.bin", FileMode.OpenOrCreate))
            {
                foreach (var node in treeView.Nodes)
                    formatter.Serialize(file, node);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodePath = e.Node.Name;
            var products = nodesProducts[nodePath];
            currentList = products;
            productsTable.RowCount = 2;
            tableLayoutPanel1.Visible = true;
            this.Text = nodePath;
            ControlUpdate.BeginControlUpdate(productsTable);
            // TODO
            ControlUpdate.EndControlUpdate(productsTable);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
