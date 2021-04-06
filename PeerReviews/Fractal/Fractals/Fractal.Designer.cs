
namespace Fractals
{
    partial class Fractal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fractal));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.serpinskyCarpet = new System.Windows.Forms.Button();
            this.kokhCurveLabel = new System.Windows.Forms.Label();
            this.kokhCurve = new System.Windows.Forms.Button();
            this.fractTree = new System.Windows.Forms.Button();
            this.serpinskyTriag = new System.Windows.Forms.Button();
            this.kantorSet = new System.Windows.Forms.Button();
            this.fractTreeLabel = new System.Windows.Forms.Label();
            this.serpinskyCarpetLabel = new System.Windows.Forms.Label();
            this.serpinskyTriagLabel = new System.Windows.Forms.Label();
            this.kantorSetLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.serpinskyCarpet, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.kokhCurveLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kokhCurve, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fractTree, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.serpinskyTriag, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.kantorSet, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.fractTreeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.serpinskyCarpetLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.serpinskyTriagLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.kantorSetLabel, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 273);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 228);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // serpinskyCarpet
            // 
            this.serpinskyCarpet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serpinskyCarpet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("serpinskyCarpet.BackgroundImage")));
            this.serpinskyCarpet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.serpinskyCarpet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serpinskyCarpet.Location = new System.Drawing.Point(379, 55);
            this.serpinskyCarpet.Name = "serpinskyCarpet";
            this.serpinskyCarpet.Size = new System.Drawing.Size(182, 170);
            this.serpinskyCarpet.TabIndex = 2;
            this.serpinskyCarpet.UseVisualStyleBackColor = true;
            this.serpinskyCarpet.Click += new System.EventHandler(this.SerpinskyCarpetClick);
            // 
            // kokhCurveLabel
            // 
            this.kokhCurveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.kokhCurveLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kokhCurveLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.kokhCurveLabel.Location = new System.Drawing.Point(191, 0);
            this.kokhCurveLabel.Name = "kokhCurveLabel";
            this.kokhCurveLabel.Size = new System.Drawing.Size(182, 52);
            this.kokhCurveLabel.TabIndex = 5;
            this.kokhCurveLabel.Text = "Кривая \r\nКоха";
            this.kokhCurveLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // kokhCurve
            // 
            this.kokhCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kokhCurve.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kokhCurve.BackgroundImage")));
            this.kokhCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kokhCurve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kokhCurve.Location = new System.Drawing.Point(191, 55);
            this.kokhCurve.Name = "kokhCurve";
            this.kokhCurve.Size = new System.Drawing.Size(182, 170);
            this.kokhCurve.TabIndex = 1;
            this.kokhCurve.UseVisualStyleBackColor = true;
            this.kokhCurve.Click += new System.EventHandler(this.KokhKurveClick);
            // 
            // fractTree
            // 
            this.fractTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fractTree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fractTree.BackgroundImage")));
            this.fractTree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fractTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fractTree.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fractTree.Location = new System.Drawing.Point(3, 55);
            this.fractTree.Name = "fractTree";
            this.fractTree.Size = new System.Drawing.Size(182, 170);
            this.fractTree.TabIndex = 0;
            this.fractTree.UseVisualStyleBackColor = true;
            this.fractTree.Click += new System.EventHandler(this.FractTreeClick);
            // 
            // serpinskyTriag
            // 
            this.serpinskyTriag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serpinskyTriag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("serpinskyTriag.BackgroundImage")));
            this.serpinskyTriag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.serpinskyTriag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serpinskyTriag.Location = new System.Drawing.Point(567, 55);
            this.serpinskyTriag.Name = "serpinskyTriag";
            this.serpinskyTriag.Size = new System.Drawing.Size(182, 170);
            this.serpinskyTriag.TabIndex = 3;
            this.serpinskyTriag.UseVisualStyleBackColor = true;
            this.serpinskyTriag.Click += new System.EventHandler(this.SerpinskyTriagClick);
            // 
            // kantorSet
            // 
            this.kantorSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kantorSet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.kantorSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kantorSet.BackgroundImage")));
            this.kantorSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kantorSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kantorSet.Location = new System.Drawing.Point(755, 55);
            this.kantorSet.Name = "kantorSet";
            this.kantorSet.Size = new System.Drawing.Size(186, 170);
            this.kantorSet.TabIndex = 4;
            this.kantorSet.UseVisualStyleBackColor = false;
            this.kantorSet.Click += new System.EventHandler(this.KantorSetClick);
            // 
            // fractTreeLabel
            // 
            this.fractTreeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fractTreeLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.fractTreeLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.fractTreeLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fractTreeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fractTreeLabel.Location = new System.Drawing.Point(3, 0);
            this.fractTreeLabel.Name = "fractTreeLabel";
            this.fractTreeLabel.Size = new System.Drawing.Size(182, 52);
            this.fractTreeLabel.TabIndex = 1;
            this.fractTreeLabel.Text = "Фрактальное \r\nдерево";
            this.fractTreeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // serpinskyCarpetLabel
            // 
            this.serpinskyCarpetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.serpinskyCarpetLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serpinskyCarpetLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.serpinskyCarpetLabel.Location = new System.Drawing.Point(379, 0);
            this.serpinskyCarpetLabel.Name = "serpinskyCarpetLabel";
            this.serpinskyCarpetLabel.Size = new System.Drawing.Size(182, 52);
            this.serpinskyCarpetLabel.TabIndex = 6;
            this.serpinskyCarpetLabel.Text = "Ковёр \r\nСерпинского";
            this.serpinskyCarpetLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // serpinskyTriagLabel
            // 
            this.serpinskyTriagLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.serpinskyTriagLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serpinskyTriagLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.serpinskyTriagLabel.Location = new System.Drawing.Point(567, 0);
            this.serpinskyTriagLabel.Name = "serpinskyTriagLabel";
            this.serpinskyTriagLabel.Size = new System.Drawing.Size(182, 52);
            this.serpinskyTriagLabel.TabIndex = 7;
            this.serpinskyTriagLabel.Text = "Треугольник\r\nСерпинского\r\n";
            this.serpinskyTriagLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // kantorSetLabel
            // 
            this.kantorSetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.kantorSetLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kantorSetLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.kantorSetLabel.Location = new System.Drawing.Point(755, 0);
            this.kantorSetLabel.Name = "kantorSetLabel";
            this.kantorSetLabel.Size = new System.Drawing.Size(186, 52);
            this.kantorSetLabel.TabIndex = 8;
            this.kantorSetLabel.Text = "Множество\r\nКантора";
            this.kantorSetLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Fractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(960, 540);
            this.Name = "Fractal";
            this.Text = "Factorial";
            this.Load += new System.EventHandler(this.FactorialLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button fractTree;
        //private System.Windows.Forms.Button kokhKurveLb;
        private System.Windows.Forms.Button serpinskyCarpet;
        private System.Windows.Forms.Button serpinskyTriag;
        private System.Windows.Forms.Button kantorSet;
        private System.Windows.Forms.Label fractTreeLabel;
        //private System.Windows.Forms.Label kokh;
        private System.Windows.Forms.Label kokhCurveLabel;
        private System.Windows.Forms.Button kokhCurve;
        private System.Windows.Forms.Label serpinskyCarpetLabel;
        private System.Windows.Forms.Label serpinskyTriagLabel;
        private System.Windows.Forms.Label kantorSetLabel;
    }
}

