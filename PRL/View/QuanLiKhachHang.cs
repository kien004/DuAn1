using DAL.Models;
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

namespace Project_SHOE
{
    public partial class QuanLiKhachHang : Form
    {
        private KhachHangService _service;
        private int _id_whenClick;
        public QuanLiKhachHang()
        {
            InitializeComponent();
            _service = new KhachHangService();
            LoadData(null);
        }

        private void txt_add_Click(object sender, EventArgs e)
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
                if (txt_phonenumber.Text.Any(char.IsLetter) || txt_phonenumber.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Số điện thoại không được chứa chữ hoặc kí tự đặc biệt");
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
            kh.Diachi = txt_location.Text;
            kh.Hovaten = txt_name.Text;
            kh.Sdt = txt_phonenumber.Text;
            var option = MessageBox.Show("Bạn Xác Nhận Muốn Thêm ?", " Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Add(kh));
            }
            else
            {
                return;
            }
        }
        public void LoadData(string vl)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Khách Hàng";
            dataGridView1.Columns[2].Name = "Họ và Tên";
            dataGridView1.Columns[3].Name = "Số Điện Thoại";
            dataGridView1.Columns[4].Name = "Email";
            dataGridView1.Columns[5].Name = "Địa Chỉ";
            dataGridView1.Columns[1].Visible = false;

            dataGridView1.Rows.Clear();
            foreach (var kh in _service.GetAll(txt_seach.Text))
            {
                dataGridView1.Rows.Add(stt++, kh.IdKhachhang, kh.Hovaten, kh.Sdt, kh.Diachi);
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
                if (txt_phonenumber.Text.Any(char.IsLetter) || txt_phonenumber.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Số điện thoại không được chứa chữ hoặc kí tự đặc biệt");
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
            }
            else
            {
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void txt_delete_Click(object sender, EventArgs e)
        {

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
            //tôi muốn tìm kiếm theo tên
            LoadData(txt_seach.Text);
        }
    }
}
