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
    public partial class ColorForm : Form
    {
        private MauService _service;
        private int _idWhenClick;
        public ColorForm()
        {
            InitializeComponent();
            _service = new MauService();
            _idWhenClick = 0;
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //validate màu không được bỏ trống và không có ký tự đặc biệt và không có số
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Màu không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Màu không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //nhưng được nhập tiếng việt
            if (textBox2.Text.Any(x => char.IsDigit(x)))
            {
                MessageBox.Show("Màu không được chứa số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var MauSax = new Mau();
            MauSax.Tenmau = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn thêm màu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Add(MauSax);
                MessageBox.Show(result);
                LoadData();
            }
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;


        }

        public void LoadData()
        {

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Màu";
            dataGridView1.Columns[2].Name = "Tên màu";
            dataGridView1.Rows.Clear();
            //còn cách nào để hiển thị danh sách màu không
            foreach (var item in _service.GetAll(textBox1.Text))
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, item.IdMau, item.Tenmau);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validate màu không được bỏ trống và không có ký tự đặc biệt và không có số
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Màu không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Màu không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //nhưng được nhập tiếng việt
            if (textBox2.Text.Any(x => char.IsDigit(x)))
            {
                MessageBox.Show("Màu không được chứa số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Update
            var MauSax = new Mau();
            MauSax.IdMau = _idWhenClick;
            MauSax.Tenmau = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn sửa màu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Update(MauSax);
                MessageBox.Show(result);
                LoadData();

            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Delete
            var MauSax = new Mau();
            MauSax.IdMau = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn xóa màu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Delete(_idWhenClick);
                MessageBox.Show(result);
                LoadData();

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn Muốn Thoát Chức Năng ?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
