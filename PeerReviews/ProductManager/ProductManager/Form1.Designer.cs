
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
            this.nodesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNodeNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.rootsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьРазделToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.productsTable = new System.Windows.Forms.TableLayoutPanel();
            this.nameProduct = new System.Windows.Forms.Label();
            this.codeProduct = new System.Windows.Forms.Label();
            this.countProduct = new System.Windows.Forms.Label();
            this.priceProduct = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.nodesMenuStrip.SuspendLayout();
            this.rootsMenuStrip.SuspendLayout();
            this.productsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.nodesMenuStrip.Size = new System.Drawing.Size(167, 76);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.добавитьToolStripMenuItem.Text = "&Добавить раздел";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.CreateNode);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeNodeNameTextBox});
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.переименоватьToolStripMenuItem.Text = "&Переименовать";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.ChengenameToolStripMenuItemClick);
            // 
            // changeNodeNameTextBox
            // 
            this.changeNodeNameTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.changeNodeNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changeNodeNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeNodeNameTextBox.Name = "changeNodeNameTextBox";
            this.changeNodeNameTextBox.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.удалитьToolStripMenuItem.Text = "&Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteNodeToolStripMenuItemClick);
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.rootsMenuStrip;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(278, 511);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeMouseDoubleClick);
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
            // productsTable
            // 
            this.productsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.productsTable.ColumnCount = 5;
            this.productsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.productsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.productsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.productsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.productsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.productsTable.Controls.Add(this.nameProduct, 1, 0);
            this.productsTable.Controls.Add(this.codeProduct, 2, 0);
            this.productsTable.Controls.Add(this.countProduct, 3, 0);
            this.productsTable.Controls.Add(this.priceProduct, 4, 0);
            this.productsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsTable.Location = new System.Drawing.Point(0, 28);
            this.productsTable.Margin = new System.Windows.Forms.Padding(0);
            this.productsTable.Name = "productsTable";
            this.productsTable.RowCount = 2;
            this.productsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.productsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.productsTable.Size = new System.Drawing.Size(864, 483);
            this.productsTable.TabIndex = 0;
            // 
            // nameProduct
            // 
            this.nameProduct.AutoSize = true;
            this.nameProduct.BackColor = System.Drawing.Color.LightGray;
            this.nameProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameProduct.Location = new System.Drawing.Point(22, 1);
            this.nameProduct.Margin = new System.Windows.Forms.Padding(0);
            this.nameProduct.Name = "nameProduct";
            this.nameProduct.Size = new System.Drawing.Size(502, 20);
            this.nameProduct.TabIndex = 0;
            this.nameProduct.Text = "Название товара/услуги";
            this.nameProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codeProduct
            // 
            this.codeProduct.AutoSize = true;
            this.codeProduct.BackColor = System.Drawing.Color.LightGray;
            this.codeProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeProduct.Location = new System.Drawing.Point(525, 1);
            this.codeProduct.Margin = new System.Windows.Forms.Padding(0);
            this.codeProduct.Name = "codeProduct";
            this.codeProduct.Size = new System.Drawing.Size(167, 20);
            this.codeProduct.TabIndex = 1;
            this.codeProduct.Text = "Код";
            this.codeProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // countProduct
            // 
            this.countProduct.AutoSize = true;
            this.countProduct.BackColor = System.Drawing.Color.LightGray;
            this.countProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countProduct.Location = new System.Drawing.Point(693, 1);
            this.countProduct.Margin = new System.Windows.Forms.Padding(0);
            this.countProduct.Name = "countProduct";
            this.countProduct.Size = new System.Drawing.Size(83, 20);
            this.countProduct.TabIndex = 2;
            this.countProduct.Text = "Количество";
            this.countProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceProduct
            // 
            this.priceProduct.AutoSize = true;
            this.priceProduct.BackColor = System.Drawing.Color.LightGray;
            this.priceProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceProduct.Location = new System.Drawing.Point(777, 1);
            this.priceProduct.Margin = new System.Windows.Forms.Padding(0);
            this.priceProduct.Name = "priceProduct";
            this.priceProduct.Size = new System.Drawing.Size(86, 20);
            this.priceProduct.TabIndex = 3;
            this.priceProduct.Text = "Цена";
            this.priceProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1146, 511);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.productsTable, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 511);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ProductManager.Properties.Resources.addthis;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Добавить товар";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 511);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1FormClosed);
            this.nodesMenuStrip.ResumeLayout(false);
            this.rootsMenuStrip.ResumeLayout(false);
            this.productsTable.ResumeLayout(false);
            this.productsTable.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel productsTable;
        private System.Windows.Forms.Label nameProduct;
        private System.Windows.Forms.Label codeProduct;
        private System.Windows.Forms.Label countProduct;
        private System.Windows.Forms.Label priceProduct;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

