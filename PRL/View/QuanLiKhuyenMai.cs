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
    public partial class QuanLiKhuyenMai : Form
    {
        //vậy nếu tôi muốn gửi email thông báo cho khách hàng khi khuyến mãi hết hạn thì tôi phải làm thế nào ?
        //bạn có thể giúp tôi được không ?
        //tôi muốn thêm 1 button để gửi email thông báo cho khách hàng khi khuyến mãi hết hạn
        private KhuyenMaiService _service;
        private string _id_WhenClick;
        public QuanLiKhuyenMai()
        {
            InitializeComponent();
            _service = new KhuyenMaiService();
            LoadData();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            //tôi muốn validate thông tin của khuyến mãi
            if (string.IsNullOrEmpty(txt_tenKM.Text))
            {
                MessageBox.Show("Tên Khuyến Mãi không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_chietkhau.Text))
            {
                MessageBox.Show("Chiết Khấu không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_soluong.Text))
            {
                MessageBox.Show("Số Lượng không được để trống");
                return;
            }
            //và các radio button
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Trạng Thái không được để trống");
                return;
            }



            var km = new Khuyenmai();

            km.IdKhuyenmai = _id_WhenClick;
            km.IdKhuyenmai = textBox1.Text;


            km.Tenkhuyenmai = txt_tenKM.Text;
            km.Ngayhethan = DateOnly.FromDateTime(dateTimePicker2.Value);
            km.Ngaybatdau = DateOnly.FromDateTime(dateTimePicker1.Value);
            km.Ngaytao = DateOnly.FromDateTime(dateTimePicker3.Value);
            km.Sophantramkhuyenmai = decimal.Parse(txt_chietkhau.Text);
            km.Soluong = int.Parse(txt_soluong.Text);
            if (radioButton2.Checked)
            {
                km.Trangthai = " Đang Hoạt Động";
            }
            else if (radioButton3.Checked)
            {
                km.Trangthai = "Hết Hạn";
            }
            else if (km.Soluong == 0)
            {
                km.Trangthai = "Đã Hết";
            }
            var option = MessageBox.Show("Bạn có chắc chắn muốn thêm khuyến mãi này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                _service.Add(km);
                LoadData();
            }
            else
            {
                return;
            }
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;




        }
        public void LoadData()
        {
            int stt = 1;
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "STT";

            dataGridView1.Columns[1].Name = "Tên Khuyến Mãi";
            dataGridView1.Columns[2].Name = "Số Phần Trăm Khuyến Mãi";
            dataGridView1.Columns[3].Name = "Trạng Thái";
            dataGridView1.Columns[4].Name = "Ngày Bắt Đầu";
            dataGridView1.Columns[5].Name = "Ngày Kết Thúc";
            dataGridView1.Columns[6].Name = "Ngày Tạo";
            dataGridView1.Columns[7].Name = "Số Lượng";
            dataGridView1.Columns[8].Name = "ID Khuyến Mãi";
          


            dataGridView1.Rows.Clear();
            foreach (var kh in _service.GetAll(txt_seach.Text))
            {
                dataGridView1.Rows.Add(stt++, kh.Tenkhuyenmai, kh.Sophantramkhuyenmai, kh.Trangthai, kh.Ngaybatdau, kh.Ngayhethan, kh.Ngaytao, kh.Soluong, kh.IdKhuyenmai);
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var km = new Khuyenmai();
            km.IdKhuyenmai = _id_WhenClick;
            km.Tenkhuyenmai = txt_tenKM.Text;
            km.Ngaybatdau = DateOnly.FromDateTime(dateTimePicker1.Value);
            km.Ngayhethan = DateOnly.FromDateTime(dateTimePicker2.Value);
            km.Ngaytao = DateOnly.FromDateTime(dateTimePicker3.Value);
            km.Soluong = int.Parse(txt_soluong.Text);
            if (radioButton1.Checked)
            {
                km.Trangthai = "Đang áp dụng";
            }
            else if (radioButton2.Checked)
            {
                km.Trangthai = "Hết hạn";
            }
            else
            {
                km.Trangthai = "Đã Hết";
            }
            km.Sophantramkhuyenmai = decimal.Parse(txt_chietkhau.Text);
            btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //tôi muốn khi click vào 1 dòng thì tất cả các cột đều hiển thị lên datagridview
            _id_WhenClick = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_tenKM.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_chietkhau.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_soluong.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
       textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Đang Hoạt Động")
            {
                radioButton2.Checked = true;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Hết Hạn")
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            dateTimePicker3.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());

            txt_idKM.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_them.Enabled = false;




        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var km = new Khuyenmai();
            km.IdKhuyenmai = _id_WhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                _service.Delete(km);
                LoadData();
            }
            else
            {
                return;
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_seach_TextChanged(object sender, EventArgs e)
        {
            //tôi muốn tìm theo tên khuyến mãi
            LoadData();
        }

        private void QuanLiKhuyenMai_Load(object sender, EventArgs e)
        {
            txt_idKM.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
