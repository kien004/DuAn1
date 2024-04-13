namespace PRL.Views
{
    partial class HoaDon
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
            txt_sdtKH = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txt_SDTTK = new TextBox();
            txt_KhachHangMoi = new TextBox();
            cbb_KieuKH = new ComboBox();
            label8 = new Label();
            btn_TimSDTKH = new Button();
            txt_diachiKH = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            listView1 = new ListView();
            STT = new ColumnHeader();
            TenGiay = new ColumnHeader();
            Mau = new ColumnHeader();
            kickthuoc = new ColumnHeader();
            SoLuong = new ColumnHeader();
            Gia = new ColumnHeader();
            groupBox3 = new GroupBox();
            cbb_SizeSP = new ComboBox();
            label6 = new Label();
            txt_GiaSP = new TextBox();
            txt_SoLuongConTrongKhoSP = new TextBox();
            txt_SoLuongSP = new TextBox();
            cbb_mauSP = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            txt_XoaSP = new Button();
            txt_ThemSP = new Button();
            label5 = new Label();
            cbb_SanPham = new ComboBox();
            label7 = new Label();
            groupBox4 = new GroupBox();
            btn_lammoihd = new Button();
            txtHoaDon = new TextBox();
            label11 = new Label();
            btn_ThanhToan = new Button();
            btn_InHoaDon = new Button();
            btn_Luu = new Button();
            txt_TongThanhToan = new TextBox();
            label15 = new Label();
            txt_ChietKhau = new TextBox();
            label14 = new Label();
            txt_TongTienHang = new TextBox();
            label13 = new Label();
            dtp_NgayTao = new DateTimePicker();
            label12 = new Label();
            groupBox5 = new GroupBox();
            Cbb_MKM = new ComboBox();
            groupBox6 = new GroupBox();
            cbb_PhuongThucThanhToan = new ComboBox();
            label_NhanVien = new Label();
            button2 = new Button();
            groupBox7 = new GroupBox();
            dataGridView1 = new DataGridView();
            label16 = new Label();
            textBox1 = new TextBox();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(525, 48);
            label4.Name = "label4";
            label4.Size = new Size(238, 67);
            label4.TabIndex = 27;
            label4.Text = "Hoá Đơn";
            // 
            // txt_sdtKH
            // 
            txt_sdtKH.Location = new Point(135, 160);
            txt_sdtKH.Margin = new Padding(3, 4, 3, 4);
            txt_sdtKH.Name = "txt_sdtKH";
            txt_sdtKH.Size = new Size(150, 27);
            txt_sdtKH.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 163);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 1;
            label2.Text = "Số Điện Thoại:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 116);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Khách Hàng:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_SDTTK);
            groupBox1.Controls.Add(txt_KhachHangMoi);
            groupBox1.Controls.Add(cbb_KieuKH);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(btn_TimSDTKH);
            groupBox1.Controls.Add(txt_diachiKH);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txt_sdtKH);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(19, 161);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(291, 249);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Khách Hàng";
            // 
            // txt_SDTTK
            // 
            txt_SDTTK.Location = new Point(133, 25);
            txt_SDTTK.Margin = new Padding(3, 4, 3, 4);
            txt_SDTTK.Name = "txt_SDTTK";
            txt_SDTTK.Size = new Size(141, 27);
            txt_SDTTK.TabIndex = 18;
            txt_SDTTK.TextChanged += txt_SDTTK_TextChanged;
            // 
            // txt_KhachHangMoi
            // 
            txt_KhachHangMoi.Location = new Point(133, 109);
            txt_KhachHangMoi.Margin = new Padding(3, 4, 3, 4);
            txt_KhachHangMoi.Name = "txt_KhachHangMoi";
            txt_KhachHangMoi.Size = new Size(148, 27);
            txt_KhachHangMoi.TabIndex = 16;
            txt_KhachHangMoi.TextChanged += txt_KhachHangMoi_TextChanged;
            // 
            // cbb_KieuKH
            // 
            cbb_KieuKH.FormattingEnabled = true;
            cbb_KieuKH.Location = new Point(133, 59);
            cbb_KieuKH.Name = "cbb_KieuKH";
            cbb_KieuKH.Size = new Size(116, 28);
            cbb_KieuKH.TabIndex = 13;
            cbb_KieuKH.SelectedIndexChanged += cbb_KieuKH_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 67);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 12;
            label8.Text = "Kiểu KH:";
            label8.Click += label8_Click;
            // 
            // btn_TimSDTKH
            // 
            btn_TimSDTKH.Location = new Point(14, 23);
            btn_TimSDTKH.Name = "btn_TimSDTKH";
            btn_TimSDTKH.Size = new Size(112, 31);
            btn_TimSDTKH.TabIndex = 11;
            btn_TimSDTKH.Text = "Tìm KH Bằng SĐT";
            btn_TimSDTKH.UseVisualStyleBackColor = true;
            btn_TimSDTKH.Click += btn_TimSDTKH_Click;
            // 
            // txt_diachiKH
            // 
            txt_diachiKH.Location = new Point(135, 202);
            txt_diachiKH.Margin = new Padding(3, 4, 3, 4);
            txt_diachiKH.Name = "txt_diachiKH";
            txt_diachiKH.Size = new Size(150, 27);
            txt_diachiKH.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 205);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 9;
            label3.Text = "Địa Chỉ:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(325, 656);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(640, 328);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hiển thị thông tin";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { STT, TenGiay, Mau, kickthuoc, SoLuong, Gia });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.ImeMode = ImeMode.NoControl;
            listView1.Location = new Point(19, 25);
            listView1.Name = "listView1";
            listView1.Size = new Size(615, 295);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // STT
            // 
            STT.Text = "STT";
            STT.Width = 55;
            // 
            // TenGiay
            // 
            TenGiay.Text = "Tên Sản Phẩm";
            TenGiay.Width = 200;
            // 
            // Mau
            // 
            Mau.Text = "Màu";
            // 
            // kickthuoc
            // 
            kickthuoc.Text = "Kích Thước";
            // 
            // SoLuong
            // 
            SoLuong.Text = "Số Lượng";
            // 
            // Gia
            // 
            Gia.Text = "Giá";
            Gia.Width = 100;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbb_SizeSP);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txt_GiaSP);
            groupBox3.Controls.Add(txt_SoLuongConTrongKhoSP);
            groupBox3.Controls.Add(txt_SoLuongSP);
            groupBox3.Controls.Add(cbb_mauSP);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txt_XoaSP);
            groupBox3.Controls.Add(txt_ThemSP);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cbb_SanPham);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(315, 187);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(561, 224);
            groupBox3.TabIndex = 25;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sản Phẩm";
            // 
            // cbb_SizeSP
            // 
            cbb_SizeSP.FormattingEnabled = true;
            cbb_SizeSP.Location = new Point(129, 116);
            cbb_SizeSP.Name = "cbb_SizeSP";
            cbb_SizeSP.Size = new Size(150, 28);
            cbb_SizeSP.TabIndex = 24;
            cbb_SizeSP.SelectedIndexChanged += cbb_SizeSP_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 124);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 23;
            label6.Text = "Size:";
            // 
            // txt_GiaSP
            // 
            txt_GiaSP.Location = new Point(398, 76);
            txt_GiaSP.Name = "txt_GiaSP";
            txt_GiaSP.Size = new Size(150, 27);
            txt_GiaSP.TabIndex = 21;
            txt_GiaSP.TextChanged += txt_GiaSP_TextChanged;
            // 
            // txt_SoLuongConTrongKhoSP
            // 
            txt_SoLuongConTrongKhoSP.Location = new Point(478, 35);
            txt_SoLuongConTrongKhoSP.Name = "txt_SoLuongConTrongKhoSP";
            txt_SoLuongConTrongKhoSP.Size = new Size(70, 27);
            txt_SoLuongConTrongKhoSP.TabIndex = 20;
            txt_SoLuongConTrongKhoSP.TextChanged += txt_SoLuongConTrongKhoSP_TextChanged;
            // 
            // txt_SoLuongSP
            // 
            txt_SoLuongSP.Location = new Point(398, 35);
            txt_SoLuongSP.Name = "txt_SoLuongSP";
            txt_SoLuongSP.Size = new Size(70, 27);
            txt_SoLuongSP.TabIndex = 19;
            txt_SoLuongSP.TextChanged += txt_SoLuongSP_TextChanged;
            // 
            // cbb_mauSP
            // 
            cbb_mauSP.FormattingEnabled = true;
            cbb_mauSP.Location = new Point(129, 75);
            cbb_mauSP.Name = "cbb_mauSP";
            cbb_mauSP.Size = new Size(150, 28);
            cbb_mauSP.TabIndex = 17;
            cbb_mauSP.SelectedIndexChanged += cbb_mauSP_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(310, 79);
            label10.Name = "label10";
            label10.Size = new Size(66, 20);
            label10.TabIndex = 15;
            label10.Text = "Giá 1 SP:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(310, 37);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 14;
            label9.Text = "Số Lượng:";
            // 
            // txt_XoaSP
            // 
            txt_XoaSP.Location = new Point(289, 167);
            txt_XoaSP.Name = "txt_XoaSP";
            txt_XoaSP.Size = new Size(96, 45);
            txt_XoaSP.TabIndex = 12;
            txt_XoaSP.Text = "Xoá";
            txt_XoaSP.UseVisualStyleBackColor = true;
            txt_XoaSP.Click += txt_XoaSP_Click;
            // 
            // txt_ThemSP
            // 
            txt_ThemSP.Location = new Point(177, 167);
            txt_ThemSP.Name = "txt_ThemSP";
            txt_ThemSP.Size = new Size(96, 45);
            txt_ThemSP.TabIndex = 11;
            txt_ThemSP.Text = "Thêm";
            txt_ThemSP.UseVisualStyleBackColor = true;
            txt_ThemSP.Click += txt_ThemSP_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 83);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 9;
            label5.Text = "Màu:";
            // 
            // cbb_SanPham
            // 
            cbb_SanPham.FormattingEnabled = true;
            cbb_SanPham.Location = new Point(129, 37);
            cbb_SanPham.Name = "cbb_SanPham";
            cbb_SanPham.Size = new Size(150, 28);
            cbb_SanPham.TabIndex = 8;
            cbb_SanPham.SelectedIndexChanged += cbb_SanPham_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 47);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 0;
            label7.Text = "Sản Phẩm:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btn_lammoihd);
            groupBox4.Controls.Add(txtHoaDon);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(btn_ThanhToan);
            groupBox4.Controls.Add(btn_InHoaDon);
            groupBox4.Controls.Add(btn_Luu);
            groupBox4.Controls.Add(txt_TongThanhToan);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(txt_ChietKhau);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(txt_TongTienHang);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(dtp_NgayTao);
            groupBox4.Controls.Add(label12);
            groupBox4.Location = new Point(43, 419);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(630, 229);
            groupBox4.TabIndex = 26;
            groupBox4.TabStop = false;
            groupBox4.Text = "Hoá Đơn";
            // 
            // btn_lammoihd
            // 
            btn_lammoihd.Location = new Point(482, 170);
            btn_lammoihd.Name = "btn_lammoihd";
            btn_lammoihd.Size = new Size(117, 45);
            btn_lammoihd.TabIndex = 42;
            btn_lammoihd.Text = "Làm Mới HĐ";
            btn_lammoihd.UseVisualStyleBackColor = true;
            btn_lammoihd.Click += btn_lammoihd_Click;
            // 
            // txtHoaDon
            // 
            txtHoaDon.Location = new Point(153, 27);
            txtHoaDon.Name = "txtHoaDon";
            txtHoaDon.Size = new Size(150, 27);
            txtHoaDon.TabIndex = 41;
            txtHoaDon.TextChanged += txtHoaDon_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 34);
            label11.Name = "label11";
            label11.Size = new Size(97, 20);
            label11.TabIndex = 40;
            label11.Text = "Mã Hóa Đơn:";
            // 
            // btn_ThanhToan
            // 
            btn_ThanhToan.Location = new Point(342, 170);
            btn_ThanhToan.Name = "btn_ThanhToan";
            btn_ThanhToan.Size = new Size(111, 45);
            btn_ThanhToan.TabIndex = 39;
            btn_ThanhToan.Text = "Thanh Toán";
            btn_ThanhToan.UseVisualStyleBackColor = true;
            btn_ThanhToan.Click += btn_ThanhToan_Click;
            // 
            // btn_InHoaDon
            // 
            btn_InHoaDon.Location = new Point(54, 170);
            btn_InHoaDon.Name = "btn_InHoaDon";
            btn_InHoaDon.Size = new Size(125, 45);
            btn_InHoaDon.TabIndex = 34;
            btn_InHoaDon.Text = "In Hoá Đơn";
            btn_InHoaDon.UseVisualStyleBackColor = true;
            btn_InHoaDon.Click += btn_InHoaDon_Click;
            // 
            // btn_Luu
            // 
            btn_Luu.Location = new Point(212, 170);
            btn_Luu.Name = "btn_Luu";
            btn_Luu.Size = new Size(96, 45);
            btn_Luu.TabIndex = 22;
            btn_Luu.Text = "Lưu";
            btn_Luu.UseVisualStyleBackColor = true;
            btn_Luu.Click += btn_Luu_Click;
            // 
            // txt_TongThanhToan
            // 
            txt_TongThanhToan.Location = new Point(319, 126);
            txt_TongThanhToan.Name = "txt_TongThanhToan";
            txt_TongThanhToan.Size = new Size(150, 27);
            txt_TongThanhToan.TabIndex = 31;
            txt_TongThanhToan.TextChanged += txt_TongThanhToan_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(187, 129);
            label15.Name = "label15";
            label15.Size = new Size(126, 20);
            label15.TabIndex = 30;
            label15.Text = "Tổng Thanh Toán:";
            // 
            // txt_ChietKhau
            // 
            txt_ChietKhau.Location = new Point(465, 77);
            txt_ChietKhau.Name = "txt_ChietKhau";
            txt_ChietKhau.Size = new Size(150, 27);
            txt_ChietKhau.TabIndex = 29;
            txt_ChietKhau.TextChanged += txt_ChietKhau_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(333, 86);
            label14.Name = "label14";
            label14.Size = new Size(83, 20);
            label14.TabIndex = 28;
            label14.Text = "Chiết Khấu:";
            // 
            // txt_TongTienHang
            // 
            txt_TongTienHang.Location = new Point(153, 73);
            txt_TongTienHang.Name = "txt_TongTienHang";
            txt_TongTienHang.Size = new Size(150, 27);
            txt_TongTienHang.TabIndex = 27;
            txt_TongTienHang.TextChanged += txt_TongTienHang_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 80);
            label13.Name = "label13";
            label13.Size = new Size(118, 20);
            label13.TabIndex = 26;
            label13.Text = "Tổng Tiền Hàng:";
            // 
            // dtp_NgayTao
            // 
            dtp_NgayTao.Location = new Point(449, 29);
            dtp_NgayTao.Name = "dtp_NgayTao";
            dtp_NgayTao.Size = new Size(174, 27);
            dtp_NgayTao.TabIndex = 25;
            dtp_NgayTao.Value = new DateTime(2024, 3, 28, 0, 0, 0, 0);
            dtp_NgayTao.ValueChanged += dtp_NgayTao_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(332, 34);
            label12.Name = "label12";
            label12.Size = new Size(76, 20);
            label12.TabIndex = 24;
            label12.Text = "Ngày Tạo:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(Cbb_MKM);
            groupBox5.Location = new Point(680, 419);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(197, 93);
            groupBox5.TabIndex = 36;
            groupBox5.TabStop = false;
            groupBox5.Text = "Khuyến Mại";
            // 
            // Cbb_MKM
            // 
            Cbb_MKM.FormattingEnabled = true;
            Cbb_MKM.Location = new Point(33, 39);
            Cbb_MKM.Name = "Cbb_MKM";
            Cbb_MKM.Size = new Size(127, 28);
            Cbb_MKM.TabIndex = 36;
            Cbb_MKM.SelectedIndexChanged += Cbb_MKM_SelectedIndexChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(cbb_PhuongThucThanhToan);
            groupBox6.Location = new Point(680, 545);
            groupBox6.Margin = new Padding(3, 4, 3, 4);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 4, 3, 4);
            groupBox6.Size = new Size(197, 103);
            groupBox6.TabIndex = 37;
            groupBox6.TabStop = false;
            groupBox6.Text = "Phương Thức Thanh Toán";
            // 
            // cbb_PhuongThucThanhToan
            // 
            cbb_PhuongThucThanhToan.FormattingEnabled = true;
            cbb_PhuongThucThanhToan.Location = new Point(33, 44);
            cbb_PhuongThucThanhToan.Name = "cbb_PhuongThucThanhToan";
            cbb_PhuongThucThanhToan.Size = new Size(127, 28);
            cbb_PhuongThucThanhToan.TabIndex = 37;
            cbb_PhuongThucThanhToan.SelectedIndexChanged += cbb_PhuongThucThanhToan_SelectedIndexChanged;
            // 
            // label_NhanVien
            // 
            label_NhanVien.AutoSize = true;
            label_NhanVien.Location = new Point(1170, 25);
            label_NhanVien.Name = "label_NhanVien";
            label_NhanVien.Size = new Size(58, 20);
            label_NhanVien.TabIndex = 38;
            label_NhanVien.Text = "label11";
            // 
            // button2
            // 
            button2.Location = new Point(898, 492);
            button2.Name = "button2";
            button2.Size = new Size(151, 29);
            button2.TabIndex = 39;
            button2.Text = "Danh Sách Hóa Đơn Chờ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(dataGridView1);
            groupBox7.Controls.Add(label16);
            groupBox7.Controls.Add(textBox1);
            groupBox7.Location = new Point(883, 188);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(414, 298);
            groupBox7.TabIndex = 40;
            groupBox7.TabStop = false;
            groupBox7.Text = "Hóa Đơn Chờ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(408, 188);
            dataGridView1.TabIndex = 45;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(16, 35);
            label16.Name = "label16";
            label16.Size = new Size(136, 20);
            label16.TabIndex = 43;
            label16.Text = "Tìm Kiếm Hóa Đơn";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 27);
            textBox1.TabIndex = 44;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // HoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 988);
            Controls.Add(groupBox7);
            Controls.Add(label_NhanVien);
            Controls.Add(groupBox6);
            Controls.Add(button2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "HoaDon";
            Text = "HoaDon";
            Load += HoaDon_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem sảnPhẩmChiTiếtToolStripMenuItem;
        private Label label4;
        private TextBox txt_tenSP;
        private TextBox txt_sdtKH;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
        private TextBox txt_SDTTK;
        private Label label3;
        private ComboBox Cbb_MKM;
        private GroupBox groupBox3;
        private Button txt_ThemSP;
        private Button btn_TimSDTKH;
        private TextBox txt_diachiKH;
        private Label label5;
        private ComboBox cbb_SanPham;
        private Label label7;
        private TextBox txt_GiaSP;
        private TextBox txt_SoLuongConTrongKhoSP;
        private TextBox txt_SoLuongSP;
        private ComboBox cbb_mauSP;
        private Label label10;
        private Label label9;
        private Button txt_XoaSP;
        private GroupBox groupBox4;
        private TextBox txt_TongTienHang;
        private Label label13;
        private DateTimePicker dtp_NgayTao;
        private Label label12;
        private TextBox txt_MaHoaDon;
        private TextBox x;
        private TextBox txt_TongThanhToan;
        private Label label15;
        private TextBox txt_ChietKhau;
        private Label label14;
        private Button btn_InHoaDon;
        private Button btn_Luu;
        private ComboBox cbb_KieuKH;
        private Label label8;
        private TextBox txt_KhachHangMoi;
        private GroupBox groupBox5;
        private ComboBox cbb_SizeSP;
        private Label label6;
        private ListView listView1;
        private ColumnHeader STT;
        private ColumnHeader TenGiay;
        private ColumnHeader Mau;
        private ColumnHeader kickthuoc;
        private ColumnHeader SoLuong;
        private ColumnHeader Gia;
        private Button btn_ThanhToan;
        private GroupBox groupBox6;
        private ComboBox cbb_PhuongThucThanhToan;
        private Label label_NhanVien;
        private TextBox txtHoaDon;
        private Label label11;
        private Button btn_lammoihd;
        private Button button2;
        private TextBox textBox1;
        private Label label16;
        private GroupBox groupBox7;
        private DataGridView dataGridView1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}