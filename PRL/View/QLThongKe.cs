using BUS.Services;
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

namespace PRL.Views
{
    public partial class QLThongKe : Form
    {
        HoaDonSer hoadonser = new HoaDonSer();
        TopSanPhamService _sanPham = new TopSanPhamService();
        TopKhachHangSer _khachhang = new TopKhachHangSer();
        string username;
        public QLThongKe(string username)
        {
            _khachhang = new TopKhachHangSer();
            _sanPham = new TopSanPhamService();
            InitializeComponent();
            this.username = username;
        }
        int totalOrders = 0;
        double totalPrice = 0;
        private void LoadData(dynamic data)
        {

            if (data == null)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
                return;
            }

            dgrTopKH.Rows.Clear();
            dgrTopKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int stt = 1;
            dgrTopKH.ColumnCount = 5;
            dgrTopKH.Columns[0].Name = "stt"; dgrTopKH.Columns[0].HeaderText = "Số thứ tự";
            dgrTopKH.Columns[1].Name = "Id";
            dgrTopKH.Columns[2].Name = "Name"; dgrTopKH.Columns[2].HeaderText = "Tên Khách hàng";
            dgrTopKH.Columns[3].Name = "soLuongMua"; dgrTopKH.Columns[3].HeaderText = "Tổng hóa đơn";
            dgrTopKH.Columns[4].Name = "tongTien"; dgrTopKH.Columns[4].HeaderText = "Tổng chi tiêu";
            dgrTopKH.Columns[1].Visible = false;

            foreach (var item in data)
            {
                dgrTopKH.Rows.Add(stt++,
                    item.Id ?? "N/A",
                    item.Name ?? "N/A",
                    item.soLuongMua ?? 0,
                    item.tongTien ?? 0,
                    item.tongTien ?? "N/A",
                    totalOrders += item.soLuongMua ?? 0);
            }
        }
        public void LoadSanPham(dynamic data)
        {

            dgrTopSanPham.Rows.Clear();
            dgrTopSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int stt = 1;
            dgrTopSanPham.ColumnCount = 7;
            dgrTopSanPham.Columns[0].Name = "stt"; dgrTopSanPham.Columns[0].HeaderText = "Số thứ tự";
            dgrTopSanPham.Columns[1].Name = "idSP";
            dgrTopSanPham.Columns[2].Name = "nameSP"; dgrTopSanPham.Columns[2].HeaderText = "Tên Sản phẩm";
            dgrTopSanPham.Columns[3].Name = "soLuong"; dgrTopSanPham.Columns[3].HeaderText = "Số lượng bán";
            dgrTopSanPham.Columns[4].Name = "tongTien"; dgrTopSanPham.Columns[4].HeaderText = "Tổng doanh thu";
            dgrTopSanPham.Columns[5].Name = "TrangThai"; dgrTopSanPham.Columns[5].HeaderText = "Trạng thái";
            dgrTopSanPham.Columns[6].Name = "TenThuongHieu"; dgrTopSanPham.Columns[6].HeaderText = "Tên thương hiệu";

            dgrTopSanPham.Columns[1].Visible = false;

            foreach (var item in data)
            {
                dgrTopSanPham.Rows.Add(stt++,
                    item.idSP ?? "N/A",
                    item.nameSP ?? "N/A",
                    item.soLuong ?? 0,
                    item.tongTien ?? 0,
                    item.TrangThai ?? "N/A",
                    item.TenThuongHieu ?? "N/A",
                    totalPrice += item.tongTien);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void topKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void QLThongKe_Load(object sender, EventArgs e)
        {

            DateTime fromDate = DateTime.Now.Date;
            DateTime toDate = DateTime.Now.Date;


            LoadData(_khachhang.GetTopCustomers(toDate, fromDate));
            LoadSanPham(_sanPham.GetTopSellingProducts(toDate, fromDate));
            textBox2.Text = totalOrders.ToString();
            textBox1.Text = totalPrice.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopSanPham sp = new TopSanPham();
            sp.Show();
        }

        private void thốngKêKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopKhachHang khachHang = new TopKhachHang();
            khachHang.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
