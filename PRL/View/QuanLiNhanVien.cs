using DAL.Context;
using DAL.Models;
using Project_SHOE.Controller.Servicer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SHOE.View
{
    public partial class QuanLiNhanVien : Form
    {









        private NhanVienService _service;
        private int _idWhenClick;
        string username;
        public QuanLiNhanVien(string username)
        {
            InitializeComponent();
            _service = new NhanVienService();
            LoadComboBox();
            LoadData();
            this.username = username;
        }



        private void LoadComboBox()
        {
            // Load dữ liệu vào combobox
            cbb_chucvu.DataSource = _service.GetChucvus();
            cbb_chucvu.DisplayMember = "TenChucVu";
            cbb_chucvu.ValueMember = "IdChucVu";






        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            //tôi cần validate dữ liệu ở đây
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                //tên không có kí tự số hoặc kí tự đặc biệt
                if (txt_name.Text.Any(char.IsDigit) || txt_name.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Tên không được chứa số hoặc kí tự đặc biệt");
                    return;
                }
                //Nếu tên bị trùng thì lập tức sẽ thông báo
                if (_service.GetAll(null).Any(x => x.Hovaten == txt_name.Text))
                {
                    MessageBox.Show("Tên đã tồn tại");
                    return;
                }
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                //số điện thoại phải là số và không có chư và kí tự đặc biệt và không quá 10 kí tự
                if (txt_sdt.Text.Any(char.IsLetter) || txt_sdt.Text.Any(char.IsPunctuation) || txt_sdt.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại không được chứa chữ hoặc kí tự đặc biệt và không quá 10 kí tự");
                    return;
                }

            }
            if (string.IsNullOrEmpty(txt_diachi.Text))
            {
                //Địa hỉ không chứa kí tự đặc biệt và không được để trống
                if (txt_diachi.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Địa chỉ không được chứa kí tự đặc biệt và không có kí tự đặc biệt");
                    return;
                }


            }
            if (string.IsNullOrEmpty(txt_pass.Text))
            {


                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }
            //check radio button
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                return;
            }
            //check ngày sinh
            if (dateTimePicker1.Value > DateTime.Now && dateTimePicker1.Value == null)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                return;
            }
            var nv = new Nhanvien();
            nv.Ngaysinh = dateTimePicker1.Value;
            nv.Hovaten = txt_name.Text;
            nv.Sdt = txt_sdt.Text;
            txt_sdt.KeyPress += txt_sdt_KeyPress;
            //ngaysinh được đặt là dateonly vậy có hàm nào để lấy ngày sinh không
            //nv.Ngaysinh = dateTimePicker1.Value;
            if (checkBox1.Checked)
            {
                nv.Trangthai = "Đang Hoạt Động";
            }
            else
            {
                nv.Trangthai = "Ngưng Hoạt Động";
            }


            nv.Diachi = txt_diachi.Text;
            if (radioButton1.Checked)
            {
                nv.Gioitinh = "Nam";
            }
            else
            {
                nv.Gioitinh = "Nữ";
            }
            nv.IdChucvu = int.Parse(cbb_chucvu.SelectedValue.ToString());

            nv.Matkhau = txt_pass.Text;




            var option = MessageBox.Show("Bạn Xác Nhận Muốn Thêm ?", " Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Add(nv));
                LoadData();
            }
            else
            {
                return;
            }
            btn_sua.Enabled = false;




        }
        public void LoadData()
        {
            int stt = 1;
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Nhân Viên";
            dataGridView1.Columns[2].Name = "Tên Nhân Viên";
            dataGridView1.Columns[3].Name = "Số Điện Thoại";
            dataGridView1.Columns[4].Name = "Ngày Sinh";
            dataGridView1.Columns[5].Name = "Địa Chỉ";
            dataGridView1.Columns[6].Name = "Gioi Tính";
            dataGridView1.Columns[7].Name = "Chức Vụ";
            dataGridView1.Columns[8].Name = "Mật Khẩu";
            dataGridView1.Columns[9].Name = "Trạng Thái";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            dataGridView1.Rows.Clear();

            foreach (var nv in _service.GetAll(txt_seach.Text))
            {

                dataGridView1.Rows.Add(stt++, nv.IdNhanvien, nv.Hovaten, nv.Sdt, nv.Ngaysinh, nv.Diachi, nv.Gioitinh, nv.IdChucvu, nv.Matkhau, nv.Trangthai);
            }

            // Thiết lập RadioButton mặc định (nếu cần)
            radioButton1.Checked = true;
        }


        private void btn_sua_Click(object sender, EventArgs e)
        {
            //tôi cần validate dữ liệu ở đây
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                //tên không có kí tự số hoặc kí tự đặc biệt
                if (txt_name.Text.Any(char.IsDigit) || txt_name.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Tên không được chứa số hoặc kí tự đặc biệt");
                    return;
                }
                //Nếu tên bị trùng thì lập tức sẽ thông báo
                if (_service.GetAll(null).Any(x => x.Hovaten == txt_name.Text))
                {
                    MessageBox.Show("Tên đã tồn tại");
                    return;
                }
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                //số điện thoại phải là số và không có chư và kí tự đặc biệt và không quá 10 kí tự
                if (txt_sdt.Text.Any(char.IsLetter) || txt_sdt.Text.Any(char.IsPunctuation) || txt_sdt.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại không được chứa chữ hoặc kí tự đặc biệt và không quá 10 kí tự");
                    return;
                }

            }
            if (string.IsNullOrEmpty(txt_diachi.Text))
            {
                //Địa hỉ không chứa kí tự đặc biệt và không được để trống
                if (txt_diachi.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Địa chỉ không được chứa kí tự đặc biệt và không có kí tự đặc biệt");
                    return;
                }


            }
            if (string.IsNullOrEmpty(txt_pass.Text))
            {


                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }
            //check radio button
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                return;
            }
            //check ngày sinh
            if (dateTimePicker1.Value > DateTime.Now && dateTimePicker1.Value == null)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                return;
            }
            var nv = new Nhanvien();
            nv.IdNhanvien = _idWhenClick;
            nv.Hovaten = txt_name.Text;
            nv.Sdt = txt_sdt.Text;
            nv.Ngaysinh = dateTimePicker1.Value;
            nv.Diachi = txt_diachi.Text;
            if (checkBox1.Checked)
            {
                nv.Trangthai = "Đang Hoạt Động";
            }
            else
            {
                nv.Trangthai = "Ngưng Hoạt Động";
            }

            if (radioButton1.Checked)
            {
                nv.Gioitinh = "Nam";
            }
            else
            {
                nv.Gioitinh = "Nữ";
            }
            nv.IdChucvu = int.Parse(cbb_chucvu.SelectedValue.ToString());
            nv.Matkhau = txt_pass.Text;
            var option = MessageBox.Show("Bạn Xác Nhận Muốn Sửa", "Xác Nhận", MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Update(nv));
                LoadData();
            }
            else
            {
                return;
            }
            btn_them.Enabled = false;


        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //khi click vào 1 dòng trong datagridview sẽ hiện tất cả thông tin lên từng trường tương ứng
            _idWhenClick = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            //tôi muốn lấy dữ liệu ngày sinh từ datagridview
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            //nếu lấy ngày sinh từ cell click bị lỗi thông báo lỗi
            
           

            txt_diachi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string gender = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (gender.Equals("Nam"))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }



            cbb_chucvu.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value;
            txt_pass.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            string status = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            if (status.Equals("Đang Hoạt Động"))
            {
                checkBox1.Checked = true;
            } else if (status.Equals("Ngưng Hoạt Động"))
            {
                checkBox1.Checked = false;
            }
          

            btn_them.Enabled = false;
            btn_sua.Enabled = true;






        }



        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra tên không được có số 
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //Kiểm tra tên không được có kí tự đặc biệt
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra số điện thoại không được có chữ
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //Kiểm tra số điện thoại không được có kí tự đặc biệt
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            //Kiểm tra phải là số 0 đầu tiên
            if (txt_sdt.Text.Length == 0 && e.KeyChar != '0')
            {
                e.Handled = true;
            }
            //Kiểm tra số điện thoại không quá 10 kí tự
            if (txt_sdt.Text.Length >= 10)
            {
                e.Handled = true;
            }

        }

        private void txt_seach_TextChanged(object sender, EventArgs e)
        {
            //Tôi muốn tìm kiếm bằng tên nhân viên
            LoadData();
        }

        private void QuanLiNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //khi tôi click button này sẽ hiện mật khẩu từ * ******* thành mật khẩu thật 
            if (txt_pass.PasswordChar == '*')
            {
                txt_pass.PasswordChar = '\0';
            }
            else
            {
                txt_pass.PasswordChar = '*';
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Khi tôi click vào button này sẽ xóa tất cả thông tin trong các ô
            txt_name.Text = "";
            txt_sdt.Text = "";
            txt_diachi.Text = "";
            txt_pass.Text = "";
            radioButton1.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            cbb_chucvu.SelectedIndex = 0;
            btn_them.Enabled = true;
            btn_sua.Enabled = false;

        }
    }
}
