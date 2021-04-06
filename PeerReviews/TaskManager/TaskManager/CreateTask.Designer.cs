
namespace TaskManager
{
    partial class CreateTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.typeLabel = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPictureBox1 = new TaskManager.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.BackColor = System.Drawing.Color.Linen;
            this.typeLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.typeLabel.Location = new System.Drawing.Point(9, 9);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(67, 13);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Тип задачи:";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.ItemHeight = 13;
            this.type.Items.AddRange(new object[] {
            "Epic",
            "Story",
            "Task",
            "Bug"});
            this.type.Location = new System.Drawing.Point(12, 34);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(184, 21);
            this.type.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 93);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(413, 20);
            this.textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Описание:";
            // 
            // roundedPictureBox1
            // 
            this.roundedPictureBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.roundedPictureBox1.Location = new System.Drawing.Point(155, 132);
            this.roundedPictureBox1.Name = "roundedPictureBox1";
            this.roundedPictureBox1.Size = new System.Drawing.Size(119, 27);
            this.roundedPictureBox1.TabIndex = 4;
            this.roundedPictureBox1.TabStop = false;
            this.roundedPictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedPictureBoxPaint);
            this.roundedPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RoundedPictureBoxMouseDown);
            this.roundedPictureBox1.MouseEnter += new System.EventHandler(this.RoundedPictureBoxMouseEnter);
            this.roundedPictureBox1.MouseLeave += new System.EventHandler(this.RoundedPictureBoxMouseLeave);
            // 
            // CreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(442, 171);
            this.Controls.Add(this.roundedPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.type);
            this.Controls.Add(this.typeLabel);
            this.Name = "CreateTask";
            this.Text = "CreateTask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private RoundedPictureBox roundedPictureBox1;
    }
}