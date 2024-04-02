using DAL.Context;
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

namespace Project_SHOE.View
{
    public partial class QuanLiNhanVien : Form
    {
        
        private NhanVienService _service;
        private int _idWhenClick;
        public QuanLiNhanVien()
        {
            InitializeComponent();
            _service = new NhanVienService();
            LoadComboBox();
            LoadData();
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
                //số điện thoại phải là số và không có chư và kí tự đặc biệt
                if (txt_sdt.Text.Any(char.IsLetter) || txt_sdt.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Số điện thoại không được chứa chữ hoặc kí tự đặc biệt");
                    return;
                }
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_diachi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
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
            nv.Hovaten = txt_name.Text;
            nv.Sdt = int.Parse(txt_sdt.Text);
             //ngaysinh được đặt là dateonly vậy có hàm nào để lấy ngày sinh không
             nv.Ngaysinh = DateOnly.Parse(dateTimePicker1.Text);


            nv.Diachi = txt_diachi.Text;
            if(radioButton1.Checked)
            {
                nv.Gioitinh = "Nam";
            }
            else
            {
                nv.Gioitinh = "Nữ";
            }
            nv.IdChucvu = int.Parse(cbb_chucvu.SelectedValue.ToString());
            //tôi muốn mật khẩu sẽ được mã hóa
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



        }
        public void LoadData()
        {

            int stt = 1;
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Nhân Viên";
            dataGridView1.Columns[2].Name = "Tên Nhân Viên";
            dataGridView1.Columns[3].Name = "Số Điện Thoại";
            dataGridView1.Columns[4].Name = "Ngày Sinh ";
            dataGridView1.Columns[5].Name = "Địa Chỉ";
            dataGridView1.Columns[6].Name = " Gioi Tính";
            dataGridView1.Columns[7].Name = "Chức Vụ";
            dataGridView1.Columns[8].Name = "Mật Khẩu";
            dataGridView1.Columns[1].Visible = false;

            dataGridView1.Rows.Clear();


            foreach (var nv in _service.GetAll(txt_seach.Text))
            {
                dataGridView1.Rows.Add(stt++, nv.IdNhanvien, nv.Hovaten, nv.Sdt, nv.Ngaysinh, nv.Diachi, nv.Gioitinh, nv.IdChucvu, nv.Matkhau);
            }
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
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                //số điện thoại phải là số
                //số điện thoại phải là số và không có chư và kí tự đặc biệt
                if (txt_sdt.Text.Any(char.IsLetter) || txt_sdt.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Số điện thoại không được chứa chữ hoặc kí tự đặc biệt");
                    return;
                }
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_diachi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
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
            nv.Sdt = int.Parse(txt_sdt.Text);
            nv.Ngaysinh = DateOnly.Parse(dateTimePicker1.Text);
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
     
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var nv = new Nhanvien();
            nv.IdNhanvien = _idWhenClick;
            var option = MessageBox.Show("Bạn Xác Nhận Muốn Xóa", "Xác Nhận", MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes)
            {
                MessageBox.Show(_service.Remove(nv));
                LoadData();
            }
            else
            {
                return;
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //khi click vào 1 dòng trong datagridview sẽ hiện tất cả thông tin lên từng trường tương ứng
            int rowindex = e.RowIndex;
            _idWhenClick = int.Parse(dataGridView1.Rows[rowindex].Cells[1].Value.ToString());
            var nv = _service.GetAll(null).FirstOrDefault(x => x.IdNhanvien == _idWhenClick);
            txt_name.Text = nv.Hovaten;
            txt_sdt.Text = nv.Sdt.ToString();
            dateTimePicker1.Text = nv.Ngaysinh.ToString();
            txt_diachi.Text = nv.Diachi;
            if (nv.Gioitinh == "Nam")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            cbb_chucvu.SelectedValue = nv.IdChucvu;
            txt_pass.Text = nv.Matkhau;
            btn_them.Enabled = false;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;





        }
    }
}
