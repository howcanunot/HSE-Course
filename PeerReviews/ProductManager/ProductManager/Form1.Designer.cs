
namespace ProductManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Полотенцосушители");
            this.nodesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.rootsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьРазделToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNodeNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.nodesMenuStrip.SuspendLayout();
            this.rootsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodesMenuStrip
            // 
            this.nodesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.переименоватьToolStripMenuItem,
            this.toolStripSeparator1,
            this.удалитьToolStripMenuItem});
            this.nodesMenuStrip.Name = "nodesMenuStrip";
            this.nodesMenuStrip.Size = new System.Drawing.Size(162, 76);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.добавитьToolStripMenuItem.Text = "&Добавить товар";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.CreateNode);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeNodeNameTextBox});
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.переименоватьToolStripMenuItem.Text = "&Переименовать";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.ChengenameToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.удалитьToolStripMenuItem.Text = "&Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteNodeToolStripMenuItemClick);
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.rootsMenuStrip;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.ContextMenuStrip = this.nodesMenuStrip;
            treeNode1.ImageIndex = -2;
            treeNode1.Name = "root";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode1.Text = "Полотенцосушители";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.Size = new System.Drawing.Size(265, 450);
            this.treeView.TabIndex = 0;
            // 
            // rootsMenuStrip
            // 
            this.rootsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьРазделToolStripMenuItem});
            this.rootsMenuStrip.Name = "rootsMenuStrip";
            this.rootsMenuStrip.Size = new System.Drawing.Size(158, 26);
            // 
            // создатьРазделToolStripMenuItem
            // 
            this.создатьРазделToolStripMenuItem.Name = "создатьРазделToolStripMenuItem";
            this.создатьРазделToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.создатьРазделToolStripMenuItem.Text = "&Создать раздел";
            this.создатьРазделToolStripMenuItem.Click += new System.EventHandler(this.CteareRoot);
            // 
            // changeNodeNameTextBox
            // 
            this.changeNodeNameTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.changeNodeNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changeNodeNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeNodeNameTextBox.Name = "changeNodeNameTextBox";
            this.changeNodeNameTextBox.Size = new System.Drawing.Size(100, 22);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.nodesMenuStrip.ResumeLayout(false);
            this.rootsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip rootsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem создатьРазделToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nodesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox changeNodeNameTextBox;
    }
}

