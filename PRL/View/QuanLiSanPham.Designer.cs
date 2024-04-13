namespace Project_SHOE.View
{
    partial class QuanLiSanPham
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
            components = new System.ComponentModel.Container();
            groupBox2 = new GroupBox();
            btn_TimKiem = new Button();
            txt_TimKiem = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            cbb_Hang = new ComboBox();
            txt_tenSP = new TextBox();
            txt_maSP = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_delete = new Button();
            btn_update = new Button();
            btn_add = new Button();
            groupBox3 = new GroupBox();
            btn_Clean = new Button();
            label4 = new Label();
            thuonghieuBindingSource = new BindingSource(components);
            menuStrip1 = new MenuStrip();
            sảnPhẩmChiTiếtToolStripMenuItem = new ToolStripMenuItem();
            thươngHiệuToolStripMenuItem = new ToolStripMenuItem();
            chấtLiệuToolStripMenuItem = new ToolStripMenuItem();
            màuSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            loạiSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            màuSảnPhẩmToolStripMenuItem1 = new ToolStripMenuItem();
            label_NhanVien = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)thuonghieuBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_TimKiem);
            groupBox2.Controls.Add(txt_TimKiem);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(14, 357);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(886, 328);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hiển thị thông tin";
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.Location = new Point(231, 27);
            btn_TimKiem.Margin = new Padding(3, 4, 3, 4);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.Size = new Size(89, 27);
            btn_TimKiem.TabIndex = 12;
            btn_TimKiem.Text = "Tìm Kiếm";
            btn_TimKiem.UseVisualStyleBackColor = true;
            btn_TimKiem.Click += btn_TimKiem_Click;
            // 
            // txt_TimKiem
            // 
            txt_TimKiem.Location = new Point(8, 27);
            txt_TimKiem.Margin = new Padding(3, 4, 3, 4);
            txt_TimKiem.Name = "txt_TimKiem";
            txt_TimKiem.Size = new Size(212, 27);
            txt_TimKiem.TabIndex = 13;
            txt_TimKiem.Tag = "Nhập Tên Sản Phẩm";
            txt_TimKiem.TextChanged += txt_TimKiem_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 61);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(869, 257);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbb_Hang);
            groupBox1.Controls.Add(txt_tenSP);
            groupBox1.Controls.Add(txt_maSP);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 155);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(887, 88);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sản Phẩm";
            // 
            // cbb_Hang
            // 
            cbb_Hang.FormattingEnabled = true;
            cbb_Hang.Location = new Point(685, 33);
            cbb_Hang.Margin = new Padding(3, 4, 3, 4);
            cbb_Hang.Name = "cbb_Hang";
            cbb_Hang.Size = new Size(195, 28);
            cbb_Hang.TabIndex = 11;
            cbb_Hang.SelectedIndexChanged += cbb_Hang_SelectedIndexChanged;
            // 
            // txt_tenSP
            // 
            txt_tenSP.Location = new Point(383, 35);
            txt_tenSP.Margin = new Padding(3, 4, 3, 4);
            txt_tenSP.Name = "txt_tenSP";
            txt_tenSP.Size = new Size(212, 27);
            txt_tenSP.TabIndex = 7;
            txt_tenSP.TextChanged += txt_tenSP_TextChanged;
            // 
            // txt_maSP
            // 
            txt_maSP.Location = new Point(77, 35);
            txt_maSP.Margin = new Padding(3, 4, 3, 4);
            txt_maSP.Name = "txt_maSP";
            txt_maSP.Size = new Size(212, 27);
            txt_maSP.TabIndex = 4;
            txt_maSP.TextChanged += txt_maSP_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(617, 41);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Hãng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 37);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = " Tên SP";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 37);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã SP:";
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(383, 37);
            btn_delete.Margin = new Padding(3, 4, 3, 4);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(109, 41);
            btn_delete.TabIndex = 10;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(208, 37);
            btn_update.Margin = new Padding(3, 4, 3, 4);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(109, 41);
            btn_update.TabIndex = 9;
            btn_update.Text = "Sửa";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Click += btn_update_Click;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(27, 37);
            btn_add.Margin = new Padding(3, 4, 3, 4);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(109, 41);
            btn_add.TabIndex = 8;
            btn_add.Text = "Thêm";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btn_Clean);
            groupBox3.Controls.Add(btn_add);
            groupBox3.Controls.Add(btn_update);
            groupBox3.Controls.Add(btn_delete);
            groupBox3.Location = new Point(117, 253);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(686, 97);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức Năng";
            // 
            // btn_Clean
            // 
            btn_Clean.Location = new Point(550, 37);
            btn_Clean.Margin = new Padding(3, 4, 3, 4);
            btn_Clean.Name = "btn_Clean";
            btn_Clean.Size = new Size(109, 41);
            btn_Clean.TabIndex = 11;
            btn_Clean.Text = "Clean";
            btn_Clean.UseVisualStyleBackColor = true;
            btn_Clean.Click += btn_Clean_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(245, 56);
            label4.Name = "label4";
            label4.Size = new Size(467, 67);
            label4.TabIndex = 21;
            label4.Text = "Quản Lý Sản Phẩm";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sảnPhẩmChiTiếtToolStripMenuItem, thươngHiệuToolStripMenuItem, chấtLiệuToolStripMenuItem, màuSảnPhẩmToolStripMenuItem, loạiSảnPhẩmToolStripMenuItem, màuSảnPhẩmToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 22;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // sảnPhẩmChiTiếtToolStripMenuItem
            // 
            sảnPhẩmChiTiếtToolStripMenuItem.Name = "sảnPhẩmChiTiếtToolStripMenuItem";
            sảnPhẩmChiTiếtToolStripMenuItem.Size = new Size(142, 24);
            sảnPhẩmChiTiếtToolStripMenuItem.Text = "Sản Phẩm Chi Tiết";
            sảnPhẩmChiTiếtToolStripMenuItem.Click += sảnPhẩmChiTiếtToolStripMenuItem_Click;
            // 
            // thươngHiệuToolStripMenuItem
            // 
            thươngHiệuToolStripMenuItem.Name = "thươngHiệuToolStripMenuItem";
            thươngHiệuToolStripMenuItem.Size = new Size(109, 24);
            thươngHiệuToolStripMenuItem.Text = "Thương Hiệu";
            thươngHiệuToolStripMenuItem.Click += thươngHiệuToolStripMenuItem_Click;
            // 
            // chấtLiệuToolStripMenuItem
            // 
            chấtLiệuToolStripMenuItem.Name = "chấtLiệuToolStripMenuItem";
            chấtLiệuToolStripMenuItem.Size = new Size(84, 24);
            chấtLiệuToolStripMenuItem.Text = "Chất Liệu";
            chấtLiệuToolStripMenuItem.Click += chấtLiệuToolStripMenuItem_Click;
            // 
            // màuSảnPhẩmToolStripMenuItem
            // 
            màuSảnPhẩmToolStripMenuItem.Name = "màuSảnPhẩmToolStripMenuItem";
            màuSảnPhẩmToolStripMenuItem.Size = new Size(121, 24);
            màuSảnPhẩmToolStripMenuItem.Text = "Màu Sản Phẩm";
            màuSảnPhẩmToolStripMenuItem.Click += màuSảnPhẩmToolStripMenuItem_Click;
            // 
            // loạiSảnPhẩmToolStripMenuItem
            // 
            loạiSảnPhẩmToolStripMenuItem.Name = "loạiSảnPhẩmToolStripMenuItem";
            loạiSảnPhẩmToolStripMenuItem.Size = new Size(120, 24);
            loạiSảnPhẩmToolStripMenuItem.Text = "Loại Sản Phẩm";
            loạiSảnPhẩmToolStripMenuItem.Click += loạiSảnPhẩmToolStripMenuItem_Click;
            // 
            // màuSảnPhẩmToolStripMenuItem1
            // 
            màuSảnPhẩmToolStripMenuItem1.Name = "màuSảnPhẩmToolStripMenuItem1";
            màuSảnPhẩmToolStripMenuItem1.Size = new Size(121, 24);
            màuSảnPhẩmToolStripMenuItem1.Text = "Màu Sản Phẩm";
            màuSảnPhẩmToolStripMenuItem1.Click += màuSảnPhẩmToolStripMenuItem1_Click;
            // 
            // label_NhanVien
            // 
            label_NhanVien.AutoSize = true;
            label_NhanVien.Location = new Point(823, 35);
            label_NhanVien.Name = "label_NhanVien";
            label_NhanVien.Size = new Size(58, 20);
            label_NhanVien.TabIndex = 39;
            label_NhanVien.Text = "label11";
            // 
            // QuanLiSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 691);
            Controls.Add(label_NhanVien);
            Controls.Add(label4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLiSanPham";
            Text = "QuanLiSanPham";
            Load += QuanLiSanPham_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)thuonghieuBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private ComboBox cbb_Hang;
        private TextBox txt_tenSP;
        private TextBox txt_maSP;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private Button btn_delete;
        private Button btn_add;
        private Button btn_update;
        private GroupBox groupBox3;
        private Label label4;
        private BindingSource thuonghieuBindingSource;
        private Button btn_Clean;
        private MenuStrip menuStrip1;
        private Button btn_TimKiem;
        private TextBox txt_TimKiem;
        private ToolStripMenuItem sảnPhẩmChiTiếtToolStripMenuItem;
        private Label label_NhanVien;
        private ToolStripMenuItem thươngHiệuToolStripMenuItem;
        private ToolStripMenuItem chấtLiệuToolStripMenuItem;
        private ToolStripMenuItem màuSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem loạiSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem màuSảnPhẩmToolStripMenuItem1;
    }
}