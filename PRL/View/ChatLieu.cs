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
    public partial class ChatLieu : Form
    {
        private ChatlieuService _service;
        private int _idWhenClick;
        public ChatLieu()
        {
            InitializeComponent();
            _service = new ChatlieuService();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //validate chất liệu không được bỏ trống và không có ký tự đặc biệt
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Chất liệu không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Chất liệu không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //nhưng được nhập tiếng việt
            if (textBox2.Text.Any(x => char.IsDigit(x)))
            {
                MessageBox.Show("Chất liệu không được chứa số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Add
            var chatlieu = new Chatlieu();
            chatlieu.Tenchatlieu = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn thêm chất liệu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Add(chatlieu);
                MessageBox.Show(result);
                LoadData();

            }
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validate chất liệu không được bỏ trống và không có ký tự đặc biệt
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Chất liệu không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Chất liệu không được chứa ký tự đặc biệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Update
            var chatlieu = new Chatlieu();
            chatlieu.Tenchatlieu = textBox2.Text;
            var option = MessageBox.Show("Bạn có chắc chắn sửa chất liệu không ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (option == DialogResult.OK)
            {
                var result = _service.Update(chatlieu);
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
            var chatlieu = new Chatlieu();
            chatlieu.IdChatlieu = _idWhenClick;
            var option = MessageBox.Show("Bạn có chắc chắn xóa chất liệu không ?", "Thông báo", MessageBoxButtons.OKCancel);
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
            dataGridView1.Columns[1].Name = "ID Chất Liệu";
            dataGridView1.Columns[2].Name = "Tên Chất Liệu";
            dataGridView1.Rows.Clear();
            foreach (var item in _service.GetAll(textBox1.Text))
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, item.IdChatlieu, item.Tenchatlieu);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            _idWhenClick = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
    }
}
