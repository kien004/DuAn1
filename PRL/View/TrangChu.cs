using BUS.Servicer;
using BUS.Services;
using PRL.View;
using PRL.Views;
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
    public partial class TrangChu : Form
    {
        private Button selectedButton;
        private readonly HoaDonSer hoaDonSer;
        private readonly KhachHangService khachHangService;
        private readonly HoaDonCTSer hoaDonCTSer;
        private readonly KhuyenMaiService khuyenMaiSer;
        private readonly SanPhamSer sanPhamSer;
        private readonly KhuyenMaiService khachHangSer;
        private readonly NhanVienService nhanVienSer;
      
        private readonly NhanVienService nhanVienService;

        string username;
        public string idcv { get; set; }
        public TrangChu(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private Form curentChillForm;
        private void OpentChillForm(Form ChillForm)
        {
            if (curentChillForm != null)
            {
                curentChillForm.Close();
            }
            curentChillForm = ChillForm;
            ChillForm.TopLevel = false;
            ChillForm.FormBorderStyle = FormBorderStyle.None;

            // Dock form Hóa Đơn vào panel1
            ChillForm.Dock = DockStyle.Fill;

            panel1.Controls.Clear(); // Xóa tất cả các controls trong panel trước khi thêm form mới
            panel1.Controls.Add(curentChillForm);
            ChillForm.BringToFront();
            ChillForm.Show();
        }

        private void SetButtonColor(Button button)
        {
            // Reset the color of the previously selected button
            if (selectedButton != null)
            {
                selectedButton.BackColor = SystemColors.ControlLight;
            }

            // Set the color of the currently selected button
            button.BackColor = Color.YellowGreen;

            // Update the selectedButton reference
            selectedButton = button;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            OpentChillForm(new HoaDon(username));
            SetButtonColor(button2);


            var option =
                 MessageBox.Show("Chức Năng Quản Lí Bán Hàng", "Thông báo", MessageBoxButtons.OK);

           
            









        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (idcv == "1")
            {
               OpentChillForm(new QuanLiKhuyenMai(username));
                SetButtonColor(button3);
               

            }
            else
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này,chỉ quản lí mới được sử dụng chức năng");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpentChillForm(new QuanLiSanPham(username));
            SetButtonColor(button4);

            MessageBox.Show("Chức Năng Quản Lí Sản Phẩm", "Thông báo", MessageBoxButtons.OK);
          







        }

        private void button5_Click(object sender, EventArgs e)
        {


            OpentChillForm(new QuanLiKhachHang(username));
            SetButtonColor(button5);
            MessageBox.Show("Chức Năng Quản Lí Khách Hàng", "Thông báo", MessageBoxButtons.OK);
           



        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (idcv == "1")
            {
                OpentChillForm(new QuanLiNhanVien(username));
                SetButtonColor(button6);
                MessageBox.Show("Chức Năng Quản Lí Nhân Viên", "Thông báo", MessageBoxButtons.OK);
             

            }
            else
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này,chỉ quản lí mới được sử dụng chức năng");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idcv == "1")
            {
                OpentChillForm(new QLThongKe(username));
                SetButtonColor(button1);
                MessageBox.Show("Chức Năng Thống Kê", "Thông báo", MessageBoxButtons.OK);
               
            }
            else
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này,chỉ quản lí mới được sử dụng chức năng");

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            label_NhanVien.Text = username;
            label_NhanVien.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
           //khi đăng xuất sẽ back về form đăng nhập
           MessageBox.Show("Đăng xuất thành công");
            this.Close();
            //thông báo bạn đã vào form đăng nhập
            MessageBox.Show("Bạn đã vào form đăng nhập");
            Form1 form1 = new Form1();
            form1.Show();

        }
    }
}
