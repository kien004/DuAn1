using BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRL.Views
{
    public partial class TopKhachHang : Form
    {
        TopKhachHangSer services = new TopKhachHangSer();
        public TopKhachHang()
        {
            services = new TopKhachHangSer();
            InitializeComponent();
        }
        private void LoadData(dynamic data)
        {
            DateTime fromDate = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;



            if (toDate < fromDate)
            {
                dateTimePicker1.Value = DateTime.Now.Date;
                dateTimePicker2.Value = DateTime.Now.Date;

                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.");
              
                return;
            }

            if (data == null)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
                return;
            }

            dgrTopKhachHang.Rows.Clear();
            dgrTopKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int stt = 1;
            dgrTopKhachHang.ColumnCount = 5;
            dgrTopKhachHang.Columns[0].Name = "stt"; dgrTopKhachHang.Columns[0].HeaderText = "Số thứ tự";
            dgrTopKhachHang.Columns[1].Name = "Id";
            dgrTopKhachHang.Columns[2].Name = "Name"; dgrTopKhachHang.Columns[2].HeaderText = "Tên Khách hàng";
            dgrTopKhachHang.Columns[3].Name = "soLuongMua"; dgrTopKhachHang.Columns[3].HeaderText = "Số lần mua";
            dgrTopKhachHang.Columns[4].Name = "tongTien"; dgrTopKhachHang.Columns[4].HeaderText = "Tổng chi tiêu";
            dgrTopKhachHang.Columns[1].Visible = false;

            foreach (var item in data)
            {
                dgrTopKhachHang.Rows.Add(stt++,
                    item.Id ?? "N/A",
                    item.Name ?? "N/A",
                    item.soLuongMua ?? 0,
                    item.tongTien ?? 0,
                    item.tongTien ?? "N/A");
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TopKhachHang_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            LoadData(services.GetTopCustomers(dateTimePicker1.Value, dateTimePicker2.Value));
        }

            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            LoadData(services.GetTopCustomers(dateTimePicker1.Value, dateTimePicker2.Value));
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {


            LoadData(services.GetTopCustomers(dateTimePicker1.Value, dateTimePicker2.Value));
        }
    }
}
