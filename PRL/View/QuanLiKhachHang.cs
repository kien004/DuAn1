using BUS.Services;
using DAL.Models;
using PRL.Views;
using Project_SHOE.Controller.Repositori;
using Project_SHOE.Controller.Servicer;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SHOE
{
    public partial class QuanLiKhachHang : Form
    {
        KhachHangRepository khachHangRepository;
        private KhachHangService _service;
        private int _id_whenClick;
        string username;
        private HoaDonSer hoadonser = new HoaDonSer();
        public QuanLiKhachHang(string username)
        {
            InitializeComponent();
            _service = new KhachHangService();
            this.username = username;
            LoadData();
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng số điện thoại
            string pattern = @"^0\d{9}$"; // Bắt đầu bằng số 0 và theo sau là 9 chữ số khác
            return Regex.IsMatch(phoneNumber, pattern);
        }
        private void txt_add_Click(object sender, EventArgs e)
        {
            string? sdt = txt_phonenumber.Text;
            txt_phonenumber.KeyPress += txt_phonenumber_KeyPress;
            txt_name.KeyPress += txt_name_KeyPress;
            string tenKhachHang = txt_name.Text;
            string diaChi = txt_location.Text;
            // Kiểm tra xem các trường thông tin có được điền đầy đủ không
            if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thực hiện thêm nếu thiếu thông tin
            }

            // Kiểm tra xem số điện thoại có đúng định dạng không (10 ký tự và bắt đầu bằng số 0)
            if (!IsValidPhoneNumber(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            var kh = new Khachhang();
            kh.Diachi = txt_location.Text;
            kh.Hovaten = txt_name.Text;
            kh.Sdt = txt_phonenumber.Text;
            var option = MessageBox.Show("Bạn Xác Nhận Muốn Thêm ?", " Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Add(kh));
                LoadData();
            }
            else
            {
                return;
            }
           //khi tôi add xong thì sẽ load lại dữ liệu
           
            txt_update.Enabled = false;
            txt_delete.Enabled = false;
            txt_add.Enabled = true;
            
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            int stt = 1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Khách Hàng";
            dataGridView1.Columns[2].Name = "Họ và Tên";
            dataGridView1.Columns[3].Name = "Số Điện Thoại";
            
            dataGridView1.Columns[4].Name = "Địa Chỉ";
            dataGridView1.Columns[1].Visible = false;
          foreach(var item in _service.GetAll(txt_seach.Text))
            {
                dataGridView1.Rows.Add(stt, item.IdKhachhang, item.Hovaten, item.Sdt, item.Diachi);
                stt++;
            }

        }

        private void txt_update_Click(object sender, EventArgs e)
        {
            //validate data
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                //tên không có kí tự số hoặc kí tự đặc biệt
                if (txt_name.Text.Any(char.IsDigit) || txt_name.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Tên không được chứa số hoặc kí tự đặc biệt");
                    return;
                }
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_phonenumber.Text))
            {
                //số điện thoại phải là số và không có chư và kí tự đặc biệt
                if (txt_phonenumber.Text.Any(char.IsLetter) || txt_phonenumber.Text.Any(char.IsPunctuation) || txt_phonenumber.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại không  được quá 10 kí tự và chứa chữ hoặc kí tự đặc biệt");
                    return;
                }
                //Khách hàng không được trùng số điện thoại
                if (_service.GetAll(null).Any(x => x.Sdt == txt_phonenumber.Text))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại");
                    return;
                }
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }

            if (string.IsNullOrEmpty(txt_location.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            var kh = new Khachhang();
            kh.IdKhachhang = _id_whenClick;
            kh.Hovaten = txt_name.Text;
            kh.Diachi = txt_location.Text;
            kh.Sdt = txt_phonenumber.Text;
            var option = MessageBox.Show("Bạn Xác Nhận Muốn Sửa", "Xác Nhận", MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Update(kh));
                LoadData();
            }
            else
            {
                return;
            }
            
            txt_add.Enabled = false;
            txt_delete.Enabled = true;
            txt_update.Enabled = true;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                int rowindex = e.RowIndex;
                _id_whenClick = int.Parse(dataGridView1.Rows[rowindex].Cells[1].Value.ToString());
                var kh = _service.GetAll(null).FirstOrDefault(x => x.IdKhachhang == _id_whenClick);
                txt_name.Text = kh.Hovaten;
                txt_location.Text = kh.Diachi;
                txt_phonenumber.Text = kh.Sdt;
                txt_add.Enabled = false;
                txt_delete.Enabled = true;
                txt_update.Enabled = true;

            }
            else
            {
                // Nếu người dùng bấm vào bảng trống hoặc bảng tiêu đề, hiển thị một thông báo
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void txt_delete_Click(object sender, EventArgs e)
        {
            //nếu khách hàng đã tồn tại trong hóa đơn thì sẽ không được xóa và thông báo
            if (_service.GetAll(null).Any(x => x.IdKhachhang == _id_whenClick))
            {
                MessageBox.Show("Khách hàng đã tồn tại trong hóa đơn không thể xóa");
                return;
            }
            var kh = new Khachhang();
            kh.IdKhachhang = _id_whenClick;
            var option = MessageBox.Show("Xác nhận muốn Xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Remove(kh));
            }
            else
            {
                return;
            }

        }

        private void txt_seach_TextChanged(object sender, EventArgs e)
        {
            //tôi muốn tìm kiếm theo tên khách hàng
            LoadData();
            
        }
        private void txt_KhachHangMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự được nhập không phải là chữ cái, khoảng trắng hoặc phím Backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Chặn việc nhập ký tự và số bằng cách huỷ bỏ sự kiện KeyPress
                e.Handled = true;
            }
        }
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_name.Text = "";
            txt_phonenumber.Text = "";
            txt_location.Text = "";
            txt_seach.Text = "";
            txt_add.Enabled = true;
            txt_update.Enabled = false;
            txt_delete.Enabled = false;
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuanLiKhachHang_Load(object sender, EventArgs e)
        {
           
            txt_name.KeyPress += txt_KhachHangMoi_KeyPress;
        }

        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra không được nhập số
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
            //kiểm tra không được nhập kí tự đặc biệt
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_phonenumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_phonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //kiểm tra không được nhập kí tự đặc biệt
          
            //kiểm tra không được nhập quá 10 kí tự
            if (txt_phonenumber.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại không được quá 10 kí tự");
                txt_phonenumber.Text = "";
            }
            //kiểm tra phải là số 0 đầu tiên
            if (txt_phonenumber.Text.Length == 1)
            {
                if (txt_phonenumber.Text != "0")
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0");
                    txt_phonenumber.Text = "";
                }
            }
        }
    }
}
