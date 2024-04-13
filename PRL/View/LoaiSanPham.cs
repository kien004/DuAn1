using BUS.Servicer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRL.View
{
    public partial class LoaiSanPham : Form
    {
        private LoaiSanPhamService _service;
        private int _idWhenClick;
        public LoaiSanPham()
        {
            InitializeComponent();
            _service = new LoaiSanPhamService();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //validate loại sản phẩm không được bỏ trống và không có ký tự đặc biệt
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Loại sản phẩm không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Loại sản phẩm không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var loaiSanPham = new Loaisanpham();
            loaiSanPham.Tenloaisanpham = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn thêm loại sản phẩm không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Add(loaiSanPham);
                MessageBox.Show(result);
                LoadData();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validate loại sản phẩm không được bỏ trống và không có ký tự đặc biệt
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Loại sản phẩm không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Loại sản phẩm không được chứa ký tự đặc biệt");
                return;
            }
            var loaiSanPham = new Loaisanpham();
            loaiSanPham.Tenloaisanpham = textBox2.Text;
            loaiSanPham.IdLoaisanpham = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn sửa loại sản phẩm không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Update(loaiSanPham);
                MessageBox.Show(result);
                LoadData();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loaiSanPham = new Loaisanpham();
            loaiSanPham.IdLoaisanpham = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn xóa loại sản phẩm không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Delete(_idWhenClick);
                MessageBox.Show(result);
                LoadData();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //thoát chương trình
            MessageBox.Show("Bạn có chắc chắn thoát chương trình không ?", "Thông báo", MessageBoxButtons.OKCancel);
            Application.Exit();

        }
        public void LoadData()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "Mã Loại Sản Phẩm";
            dataGridView1.Columns[2].Name = "Tên Loại Sản Phẩm";
            dataGridView1.Rows.Clear();
            foreach (var item in _service.GetAll(textBox1.Text))
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, item.IdLoaisanpham, item.Tenloaisanpham);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                _idWhenClick = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else
            {
                // Nếu người dùng bấm vào bảng trống hoặc bảng tiêu đề, hiển thị một thông báo
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}
