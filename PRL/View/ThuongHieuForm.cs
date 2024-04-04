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
    public partial class ThuongHieuForm : Form
    {
        private ThuongHieuService _service;
        private int _idWhenClick;
        public ThuongHieuForm()
        {
            _service = new ThuongHieuService();
            InitializeComponent();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //validate thương hiệu không được bỏ trống và không có ký tự đặc biệt
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Thương hiệu không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Thương hiệu không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var thuongHieu = new Thuonghieu();
            thuongHieu.Tenthuonghieu = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn thêm thương hiệu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Add(thuongHieu);
                MessageBox.Show(result);
                LoadData();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validate thương hiệu không được bỏ trống và không có ký tự đặc biệt
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Thương hiệu không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Thương hiệu không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var thuongHieu = new Thuonghieu();
            thuongHieu.Tenthuonghieu = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn sửa thương hiệu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                thuongHieu.IdThuonghieu = _idWhenClick;
                var result = _service.Update(thuongHieu);
                MessageBox.Show(result);
                LoadData();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Delete
            var thuongHieu = new Thuonghieu();
            thuongHieu.IdThuonghieu = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn xóa thương hiệu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Delete(_idWhenClick);
                MessageBox.Show(result);
                LoadData();
            }

        }
        public void LoadData()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Thương hiệu";
            dataGridView1.Columns[2].Name = "Tên thương hiệu";

            dataGridView1.Rows.Clear();
            foreach (var item in _service.GetAll(textBox1.Text))
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, item.IdThuonghieu, item.Tenthuonghieu);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _idWhenClick = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;

        }
    }
}
