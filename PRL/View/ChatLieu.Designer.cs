namespace PRL.View
{
    partial class ChatLieu
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
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(78, 20);
            label4.Name = "label4";
            label4.Size = new Size(452, 67);
            label4.TabIndex = 22;
            label4.Text = "Quản Lý Chất Liệu";
            // 
            // button1
            // 
            button1.Location = new Point(445, 298);
            button1.Name = "button1";
            button1.Size = new Size(94, 25);
            button1.TabIndex = 23;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(445, 251);
            button2.Name = "button2";
            button2.Size = new Size(94, 25);
            button2.TabIndex = 24;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(445, 203);
            button3.Name = "button3";
            button3.Size = new Size(94, 25);
            button3.TabIndex = 25;
            button3.Text = "Thêm";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(445, 342);
            button4.Name = "button4";
            button4.Size = new Size(94, 25);
            button4.TabIndex = 26;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 114);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 28;
            label2.Text = "Tên Chất Liệu";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 193);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(410, 182);
            dataGridView1.TabIndex = 29;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(137, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(285, 25);
            textBox2.TabIndex = 31;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 162);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 25);
            textBox1.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 165);
            label1.Name = "label1";
            label1.Size = new Size(67, 17);
            label1.TabIndex = 32;
            label1.Text = "Tìm Kiếm";
            // 
            // ChatLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 376);
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
            Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Name = "ChatLieu";
            Text = "ChatLieu";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label2;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
    }
}