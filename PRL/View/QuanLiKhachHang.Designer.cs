namespace Project_SHOE
{
    partial class QuanLiKhachHang
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
            groupBox2 = new GroupBox();
            btn_Clean = new Button();
            txt_update = new Button();
            txt_delete = new Button();
            txt_add = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txt_location = new TextBox();
            txt_phonenumber = new TextBox();
            txt_name = new TextBox();
            label4 = new Label();
            txt_seach = new TextBox();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_Clean);
            groupBox2.Controls.Add(txt_update);
            groupBox2.Controls.Add(txt_delete);
            groupBox2.Controls.Add(txt_add);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txt_location);
            groupBox2.Controls.Add(txt_phonenumber);
            groupBox2.Controls.Add(txt_name);
            groupBox2.Location = new Point(16, 165);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(501, 288);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = " ";
            // 
            // btn_Clean
            // 
            btn_Clean.Location = new Point(401, 227);
            btn_Clean.Margin = new Padding(3, 4, 3, 4);
            btn_Clean.Name = "btn_Clean";
            btn_Clean.Size = new Size(75, 36);
            btn_Clean.TabIndex = 29;
            btn_Clean.Text = "Clean";
            btn_Clean.UseVisualStyleBackColor = true;
            btn_Clean.Click += btn_Clean_Click;
            // 
            // txt_update
            // 
            txt_update.Location = new Point(144, 227);
            txt_update.Margin = new Padding(3, 4, 3, 4);
            txt_update.Name = "txt_update";
            txt_update.Size = new Size(89, 38);
            txt_update.TabIndex = 13;
            txt_update.Text = "Sửa";
            txt_update.UseVisualStyleBackColor = true;
            txt_update.Click += txt_update_Click;
            // 
            // txt_delete
            // 
            txt_delete.Location = new Point(276, 227);
            txt_delete.Margin = new Padding(3, 4, 3, 4);
            txt_delete.Name = "txt_delete";
            txt_delete.Size = new Size(89, 38);
            txt_delete.TabIndex = 12;
            txt_delete.Text = "Xóa";
            txt_delete.UseVisualStyleBackColor = true;
            txt_delete.Click += txt_delete_Click;
            // 
            // txt_add
            // 
            txt_add.Location = new Point(15, 227);
            txt_add.Margin = new Padding(3, 4, 3, 4);
            txt_add.Name = "txt_add";
            txt_add.Size = new Size(89, 38);
            txt_add.TabIndex = 10;
            txt_add.Text = "Thêm";
            txt_add.UseVisualStyleBackColor = true;
            txt_add.Click += txt_add_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 164);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 8;
            label3.Text = "Địa Chỉ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 103);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 7;
            label2.Text = "SĐT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 32);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 6;
            label1.Text = "Họ và Tên";
            // 
            // txt_location
            // 
            txt_location.Location = new Point(137, 153);
            txt_location.Margin = new Padding(3, 4, 3, 4);
            txt_location.Name = "txt_location";
            txt_location.Size = new Size(316, 27);
            txt_location.TabIndex = 4;
            // 
            // txt_phonenumber
            // 
            txt_phonenumber.Location = new Point(137, 92);
            txt_phonenumber.Margin = new Padding(3, 4, 3, 4);
            txt_phonenumber.Name = "txt_phonenumber";
            txt_phonenumber.Size = new Size(316, 27);
            txt_phonenumber.TabIndex = 2;
            txt_phonenumber.TextChanged += txt_phonenumber_TextChanged;
            txt_phonenumber.KeyPress += txt_phonenumber_KeyPress;
            // 
            // txt_name
            // 
            txt_name.Location = new Point(137, 29);
            txt_name.Margin = new Padding(3, 4, 3, 4);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(316, 27);
            txt_name.TabIndex = 1;
            txt_name.TextChanged += txt_name_TextChanged;
            txt_name.KeyPress += txt_name_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(553, 134);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 11;
            label4.Text = "Tìm Kiếm";
            // 
            // txt_seach
            // 
            txt_seach.Location = new Point(669, 130);
            txt_seach.Margin = new Padding(3, 4, 3, 4);
            txt_seach.Name = "txt_seach";
            txt_seach.Size = new Size(316, 27);
            txt_seach.TabIndex = 3;
            txt_seach.Tag = "Tìm Kiếm Theo Tên";
            txt_seach.TextChanged += txt_seach_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(523, 165);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(501, 288);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = " ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 20);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(483, 268);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label5.ForeColor = SystemColors.HotTrack;
            label5.Location = new Point(209, 28);
            label5.Name = "label5";
            label5.Size = new Size(505, 67);
            label5.TabIndex = 28;
            label5.Text = "Quản Lí Khách Hàng";
            // 
            // QuanLiKhachHang
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 461);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(groupBox2);
            Controls.Add(txt_seach);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLiKhachHang";
            Text = "QuanLiKhachHang";
            Load += QuanLiKhachHang_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label label4;
        private Button txt_add;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txt_location;
        private TextBox txt_seach;
        private TextBox txt_phonenumber;
        private TextBox txt_name;
        private Button txt_update;
        private Button txt_delete;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Label label5;
        private Button btn_Clean;
    }
}