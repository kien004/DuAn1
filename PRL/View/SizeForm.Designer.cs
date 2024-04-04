namespace PRL.View
{
    partial class SizeForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(148, 183);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(163, 27);
            textBox1.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 186);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 61;
            label1.Text = "Tìm Kiếm";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(148, 141);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(320, 27);
            textBox2.TabIndex = 60;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 225);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(461, 155);
            dataGridView1.TabIndex = 59;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 143);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 58;
            label2.Text = "Size";
            // 
            // button4
            // 
            button4.Location = new Point(504, 352);
            button4.Name = "button4";
            button4.Size = new Size(106, 29);
            button4.TabIndex = 57;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(504, 234);
            button3.Name = "button3";
            button3.Size = new Size(106, 29);
            button3.TabIndex = 56;
            button3.Text = "Thêm";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(504, 275);
            button2.Name = "button2";
            button2.Size = new Size(106, 29);
            button2.TabIndex = 55;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(504, 315);
            button1.Name = "button1";
            button1.Size = new Size(106, 29);
            button1.TabIndex = 54;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(28, 40);
            label4.Name = "label4";
            label4.Size = new Size(568, 67);
            label4.TabIndex = 53;
            label4.Text = "Quản Lý Kích Thước SP";
            // 
            // SizeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 450);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Name = "SizeForm";
            Text = "SizeForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Label label2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label4;
    }
}