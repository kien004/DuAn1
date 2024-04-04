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
    public partial class SizeForm : Form
    {
        private KichThuocService _service;
        private int _idWhenClick;
        public SizeForm()
        {
            InitializeComponent();
            _service = new KichThuocService();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //validate kích thước không được bỏ trống và không có ký tự đặc biệt và không có chữ
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Kích thước không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsDigit(x)))
            {
                MessageBox.Show("Kích thước không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //nhưng được nhập số
            if (textBox2.Text.Any(x => char.IsLetter(x)))
            {
                MessageBox.Show("Kích thước không được chứa chữ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kichthuoc = new Kichthuoc();
            kichthuoc.Size = int.Parse(textBox2.Text);
            var option = MessageBox.Show("Bạn có chắc chắn thêm kích thước không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Add(kichthuoc);
                MessageBox.Show(result);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validate kích thước không được bỏ trống và không có ký tự đặc biệt và không có chữ
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Kích thước không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsDigit(x)))
            {
                MessageBox.Show("Kích thước không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //nhưng được nhập số
            if (textBox2.Text.Any(x => char.IsLetter(x)))
            {
                MessageBox.Show("Kích thước không được chứa chữ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var kichthuoc = new Kichthuoc();
            kichthuoc.Size = int.Parse(textBox2.Text);
            kichthuoc.IdKichthuoc = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn sửa kích thước không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Update(kichthuoc);
                MessageBox.Show(result);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var kichthuoc = new Kichthuoc();
            kichthuoc.IdKichthuoc = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn xóa kích thước không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Delete(_idWhenClick);
                MessageBox.Show(result);
            }

        }
        public void LoadData()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Kích thước";
            dataGridView1.Columns[2].Name = "Kích thước";
            dataGridView1.Rows.Clear();
            var list = _service.GetAll(textBox1.Text);
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, item.IdKichthuoc, item.Size);
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
