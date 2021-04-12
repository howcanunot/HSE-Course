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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            treeView.Nodes[0].Checked = false;
            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.Folder1);

            treeView.ImageList = imageList;
        }

        private void CteareRoot(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = new TreeNode();

                node.Text = GetCurrectName(null);
                node.Name = node.Text;

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

            TreeNode node = new TreeNode();
            try
            {
                node.Text = GetCurrectName(treeView.SelectedNode);
                node.Name = node.Text;

                node.ImageIndex = 0;
                node.ContextMenuStrip = nodesMenuStrip;
                treeView.SelectedNode.Nodes.Add(node);
                treeView.SelectedNode.Expand();

            }
            catch (Exception ex)
            {
                treeView.Nodes[0].Nodes.Add(node);
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
        }
    }
}
