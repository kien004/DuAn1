using PRL.View;
using PRL.Views;
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
    public partial class TrangChu : Form
    {
        string username;
        public string idcv { get; set; }
        public TrangChu()
        {
            InitializeComponent();

        }





        private void button2_Click(object sender, EventArgs e)
        {

            var option =
                 MessageBox.Show("Chức Năng Quản Lí Bán Hàng", "Thông báo", MessageBoxButtons.OK);

            if (option == DialogResult.OK)
            {
                QuanLiBanHang quanLiBanHang = new QuanLiBanHang(username);
                quanLiBanHang.ShowDialog();


            }









        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (idcv == "2")
            {
                MessageBox.Show("Chức Năng Quản Lí Khuyến Mãi", "Thông báo", MessageBoxButtons.OK);
                QuanLiKhuyenMai qlkm = new QuanLiKhuyenMai();
                qlkm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {


            MessageBox.Show("Chức Năng Quản Lí Sản Phẩm", "Thông báo", MessageBoxButtons.OK);
            QuanLiSanPham qlsp = new QuanLiSanPham(username);
            qlsp.ShowDialog();







        }

        private void button5_Click(object sender, EventArgs e)
        {



            MessageBox.Show("Chức Năng Quản Lí Khách Hàng", "Thông báo", MessageBoxButtons.OK);
            QuanLiKhachHang quanLiKhachHang = new QuanLiKhachHang();
            quanLiKhachHang.ShowDialog();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (idcv == "2")
            {
                MessageBox.Show("Chức Năng Quản Lí Nhân Viên", "Thông báo", MessageBoxButtons.OK);
                QuanLiNhanVien quanLiNhanVien = new QuanLiNhanVien();
                quanLiNhanVien.ShowDialog();

            }
            else
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(idcv == "2")
            {
                MessageBox.Show("Chức Năng Thống Kê", "Thông báo", MessageBoxButtons.OK);
               QLThongKe qLThongKe = new QLThongKe();
                qLThongKe.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này");

            }
           
        }
    }
}
