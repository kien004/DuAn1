using BUS.Services;
using BUS.Viewmoder;
using DAL.Models;
using DAL.Repositori;
using Project_SHOE.Controller.Servicer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_SHOE.View
{
    public partial class QuanLiSanPhamChiTiet : Form
    {
        int idCellClick = -1;
        SanPhamCTSer _SanPhamctSer = new SanPhamCTSer();
        SanPhamSer _SanPhamSer = new SanPhamSer();
        NhanVienService NhanVienService = new NhanVienService();
        string username;
        public QuanLiSanPhamChiTiet(string username)
        {
            _SanPhamSer = new SanPhamSer();
            _SanPhamctSer = new SanPhamCTSer();
            InitializeComponent();
            this.username = username;
        }
        public void loatData(dynamic data)
        {
            dataGridView1.Rows.Clear();
            int stt = 1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "Mã Sản Phẩm Chi Tiết";
            dataGridView1.Columns[2].Name = "Tên Sản Phẩm";
            dataGridView1.Columns[3].Name = "Chất Liệu";
            dataGridView1.Columns[4].Name = "Màu";
            dataGridView1.Columns[5].Name = "Kích Thước";
            dataGridView1.Columns[6].Name = "Loại Sản Phẩm";
            dataGridView1.Columns[7].Name = "Số Lượng";
            dataGridView1.Columns[8].Name = "Giá";
            dataGridView1.Columns[9].Name = "Nhân Viên";
            dataGridView1.Columns[10].Name = "Trạng Thái";
            foreach (var s in data)
            {
                dataGridView1.Rows.Add(stt++, s.IdSanphamct, s.TenSanPham, s.ChatLieu, s.Mau, s.KichThuoc, s.LoaiSanPham, s.Soluong, s.Dongia, s.IdNhanvien, s.TrangThai);
            }
        }
        private void Clean()
        {
            txt_giaban.Text = "";
            txt_soluong.Text = "";
            // Xóa lựa chọn trong ComboBox nếu có
            cbb_ChatLieu.ResetText();
            cbb_LoaiSP.ResetText();
            cbb_Mau.ResetText();
            cbb_Size.ResetText();
            cbb_SP.ResetText();
        }
        private void cbb_SP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLiSanPhamChiTiet_Load(object sender, EventArgs e)
        {
            loatData(_SanPhamctSer.Getview());
            foreach (var item in _SanPhamctSer.GetAllSPCT_KichThuoc())
            {
                cbb_LocSize.Items.Add(item.Size);
            }
            foreach (var item in _SanPhamSer.GetAllSP())
            {
                cbb_SP.Items.Add(item.Tensanpham);
            }
            foreach (var item in _SanPhamctSer.GetAllSPCT_KichThuoc())
            {
                cbb_Size.Items.Add(item.Size);
            }

            foreach (var item in _SanPhamctSer.GetAllSPCT_LSP())
            {
                cbb_LoaiSP.Items.Add(item.Tenloaisanpham);
            }
            foreach (var item in _SanPhamctSer.GetAllSPCT_Mau())
            {
                cbb_Mau.Items.Add(item.Tenmau);
            }
            foreach (var item in _SanPhamctSer.GetAllSPCT_ChatLieu())
            {
                cbb_ChatLieu.Items.Add(item.Tenchatlieu);
            }

            btn_add.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            txt_Idspct.Enabled = false;
            txt_soluong.KeyPress += txt_soluong_KeyPress;
            txt_giaban.KeyPress += txt_soluong_KeyPress;
            cbb_ChatLieu.KeyDown += comboBox1_KeyDown;
            cbb_ChatLieu.KeyPress += comboBox1_KeyPress;
            cbb_LoaiSP.KeyDown += comboBox1_KeyDown;
            cbb_LoaiSP.KeyPress += comboBox1_KeyPress;
            cbb_LocSize.KeyDown += comboBox1_KeyDown;
            cbb_LocSize.KeyPress += comboBox1_KeyPress;
            cbb_Mau.KeyDown += comboBox1_KeyDown;
            cbb_Mau.KeyPress += comboBox1_KeyPress;
            cbb_Size.KeyDown += comboBox1_KeyDown;
            cbb_Size.KeyPress += comboBox1_KeyPress;
            cbb_SP.KeyDown += comboBox1_KeyDown;
            cbb_SP.KeyPress += comboBox1_KeyPress;
            label_NhanVien.Text = username;
           loatData(_SanPhamctSer.Getview());
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Ngăn chặn ComboBox nhận ký tự từ bàn phím
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true; // Ngăn chặn ComboBox nhận sự kiện phím từ bàn phím
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            // Đoạn mã hiển thị thông báo xác nhận trước khi thêm sản phẩm
            DialogResult resultConfirm = MessageBox.Show("Bạn có muốn thêm sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultConfirm == DialogResult.Yes)
            {
                if (cbb_SP.Text == "" || cbb_LoaiSP.Text == "" || cbb_ChatLieu.Text == "" || cbb_Mau.Text == "" || cbb_Size.Text == "" || txt_giaban.Text == "" || txt_soluong.Text == "" || (!radioButton1.Checked && !radioButton2.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm và chọn trạng thái.");
                    return;
                }
                else if (!int.TryParse(txt_giaban.Text, out int giaban) || giaban <= 10000 || giaban > 1000000000)
                {
                    MessageBox.Show("Giá Bán Không Được Nhập Nhỏ Hơn 10.000 và Lớn Hơn 1.000.000.000", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Không thêm sản phẩm vào danh sách và kết thúc phương thức
                }
                else if (!int.TryParse(txt_soluong.Text, out int soLuong) || soLuong <= 0 || soLuong > 1000)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương không vượt quá 1000 cho số lượng sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Không thêm sản phẩm vào danh sách và kết thúc phương thức
                }
                else
                {
                    int idnhanvien = NhanVienService.GetIdNhanVien(label_NhanVien.Text);
                    var s1 = new Sanphamct();
                    int m = cbb_SP.SelectedIndex;
                    int n = cbb_LoaiSP.SelectedIndex;
                    int b = cbb_Mau.SelectedIndex;
                    int v = cbb_Size.SelectedIndex;
                    int c = cbb_ChatLieu.SelectedIndex;

                    s1.IdSanpham = _SanPhamSer.GetAllSP().ElementAt(m).IdSanpham;
                    s1.IdLoaisanpham = _SanPhamctSer.GetAllSPCT_LSP().ElementAt(n).IdLoaisanpham;
                    s1.IdMau = _SanPhamctSer.GetAllSPCT_Mau().ElementAt(b).IdMau;
                    s1.IdChatlieu = _SanPhamctSer.GetAllSPCT_ChatLieu().ElementAt(c).IdChatlieu;
                    s1.IdKichthuoc = _SanPhamctSer.GetAllSPCT_KichThuoc().ElementAt(v).IdKichthuoc;
                    s1.Soluong = Convert.ToInt32(txt_soluong.Text);
                    s1.Dongia = Convert.ToInt32(txt_giaban.Text);
                    s1.IdNhanvien = idnhanvien;
                    s1.Trangthai = radioButton1.Checked ? "Còn Hàng" : "Hết Hàng"; // Gán trạng thái từ radio button

                    bool isDuplicate = _SanPhamctSer.CheckTrum(s1);
                    if (isDuplicate)
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại trong cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(_SanPhamctSer.AddSPCT(s1));
                        loatData(_SanPhamctSer.Getview());
                        Clean();
                    }
                }
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            // Đoạn mã hiển thị thông báo xác nhận trước khi cập nhật thông tin sản phẩm chi tiết
            DialogResult resultConfirm = MessageBox.Show("Bạn có muốn cập nhật thông tin sản phẩm chi tiết này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultConfirm == DialogResult.Yes)
            {
                if (cbb_SP.Text == "" || cbb_LoaiSP.Text == "" || cbb_ChatLieu.Text == "" || cbb_Mau.Text == "" || cbb_Size.Text == "" || txt_giaban.Text == "" || txt_soluong.Text == "" || (!radioButton1.Checked && !radioButton2.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.");
                    return;
                }
                else if (!int.TryParse(txt_giaban.Text, out int giaban) || giaban <= 10000 || giaban > 1000000000)
                {
                    MessageBox.Show("Giá Bán Không Được Nhập Nhỏ Hơn 10.000 và Lớn Hơn 1.000.000.000", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Không cập nhật thông tin sản phẩm chi tiết và kết thúc phương thức
                }
                else if (!int.TryParse(txt_soluong.Text, out int soLuong) || soLuong <= 0 || soLuong > 1000)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương không vượt quá 1000 cho số lượng sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Không cập nhật thông tin sản phẩm chi tiết và kết thúc phương thức
                }
                else
                {
                    int idnhanvien = NhanVienService.GetIdNhanVien(label_NhanVien.Text);
                    int n = cbb_LoaiSP.SelectedIndex;
                    int b = cbb_Mau.SelectedIndex;
                    int v = cbb_Size.SelectedIndex;
                    int c = cbb_ChatLieu.SelectedIndex;
                    int d = cbb_SP.SelectedIndex;
                    int maSP = int.Parse(txt_Idspct.Text);

                    // Khởi tạo đối tượng sản phẩm chi tiết mới
                    var updatedProduct = new Sanphamct()
                    {
                        IdSanpham = _SanPhamSer.GetAllSP().ElementAtOrDefault(d)?.IdSanpham ?? 0,
                        IdLoaisanpham = _SanPhamctSer.GetAllSPCT_LSP().ElementAtOrDefault(n)?.IdLoaisanpham ?? 0,
                        IdMau = _SanPhamctSer.GetAllSPCT_Mau().ElementAtOrDefault(b)?.IdMau ?? 0,
                        IdChatlieu = _SanPhamctSer.GetAllSPCT_ChatLieu().ElementAtOrDefault(c)?.IdChatlieu ?? 0,
                        IdKichthuoc = _SanPhamctSer.GetAllSPCT_KichThuoc().ElementAtOrDefault(v)?.IdKichthuoc ?? 0,
                        Soluong = Convert.ToInt32(txt_soluong.Text),
                        Dongia = Convert.ToInt32(txt_giaban.Text),
                        IdNhanvien = idnhanvien,
                        Trangthai = radioButton1.Checked ? "Còn Hàng" : "Hết Hàng" // Gán trạng thái từ radio button
                    };

                    bool isDuplicate = _SanPhamctSer.CheckTrumSua(maSP, updatedProduct);
                    if (isDuplicate)
                    {
                        MessageBox.Show("Sản phẩm chi tiết đã tồn tại trong cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var result = _SanPhamctSer.UpdateSPCT(maSP, updatedProduct);

                        if (result == 3)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            loatData(_SanPhamctSer.Getview());
                            Clean();
                        }
                        else if (result == 2)
                        {
                            MessageBox.Show("Tên không được để trống");
                            loatData(_SanPhamctSer.Getview());
                            Clean();
                        }
                        else if (result == 1)
                        {
                            MessageBox.Show("Cập nhật thất bại");
                            Clean();
                        }
                    }
                }
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu nào được chọn để xóa không
            if (string.IsNullOrEmpty(txt_Idspct.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa từ người dùng
            var thongBao = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongBao == DialogResult.Yes)
            {
                int maSP = int.Parse(txt_Idspct.Text);

                // Xóa sản phẩm
                string errorMessage;
                int check = _SanPhamctSer.checkspctcotronghoadon(maSP);
                if (check == 1)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại trong hóa đơn, không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool result = _SanPhamctSer.DeleteSPCT(maSP);
                if (result)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loatData(_SanPhamctSer.Getview());
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btn_Clean_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true; // Chọn "Còn Hàng"
            radioButton2.Checked = false; // Bỏ chọn "Hết Hàng"
            txt_giaban.Text = "";
            txt_soluong.Text = "";
            // Xóa lựa chọn trong ComboBox nếu có
            cbb_ChatLieu.ResetText();
            cbb_LoaiSP.ResetText();
            cbb_Mau.ResetText();
            cbb_Size.ResetText();
            cbb_SP.ResetText();
            btn_add.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectChild = dataGridView1.Rows[index];
            txt_Idspct.Text = selectChild.Cells[1].Value.ToString();
            cbb_SP.Text = selectChild.Cells[2].Value.ToString();
            cbb_LoaiSP.Text = selectChild.Cells[6].Value.ToString();
            cbb_ChatLieu.Text = selectChild.Cells[3].Value.ToString();
            cbb_Mau.Text = selectChild.Cells[4].Value.ToString();
            cbb_Size.Text = selectChild.Cells[5].Value.ToString();
            txt_soluong.Text = selectChild.Cells[7].Value.ToString();
            txt_giaban.Text = selectChild.Cells[8].Value.ToString();

            // Kiểm tra và thiết lập trạng thái radio button
            string trangThai = selectChild.Cells[9].Value.ToString();
            if (trangThai == "Còn Hàng")
            {
                radioButton1.Checked = true; // Chọn "Còn Hàng"
                radioButton2.Checked = false; // Bỏ chọn "Hết Hàng"
            }
            else
            {
                radioButton1.Checked = false; // Bỏ chọn "Còn Hàng"
                radioButton2.Checked = true; // Chọn "Hết Hàng"
            }

            btn_add.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbb_LocSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có kích thước nào được chọn hay không
            if (cbb_LocSize.SelectedIndex != -1)
            {
                // Lấy kích thước được chọn từ ComboBox cbb_LocSize
                int selectedSize = (int)cbb_LocSize.SelectedItem;

                // Lọc danh sách sản phẩm chi tiết theo kích thước được chọn và hiển thị kết quả
                loatData(_SanPhamctSer.GetSearch(selectedSize));
            }
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
        }
        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
       {
            // Kiểm tra nếu kí tự là khoảng trắng và không phải là phím Backspace
            if (e.KeyChar == ' ' && e.KeyChar != (char)Keys.Back)
            {
                // Ngăn chặn kí tự khoảng trắng được nhập vào
                e.Handled = true;
            }
            // Nếu kí tự không phải là số và không phải là phím Backspace
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Ngăn chặn kí tự được nhập vào
                e.Handled = true;
            }
        }
        private void txt_giaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu kí tự là khoảng trắng và không phải là phím Backspace
            if (e.KeyChar == ' ' && e.KeyChar != (char)Keys.Back)
            {
                // Ngăn chặn kí tự khoảng trắng được nhập vào
                e.Handled = true;
            }
            // Nếu kí tự không phải là số và không phải là phím Backspace
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Ngăn chặn kí tự được nhập vào
                e.Handled = true;
            }
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng của Form2
            QuanLiSanPham form2 = new QuanLiSanPham(username);

            //// Lưu tham chiếu đến form hiện tại vào biến cục bộ
            //Form currentForm = this;

            //// Đóng form hiện tại (Form1)
            //currentForm.Close();

            // Hiển thị Form2
            form2.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
