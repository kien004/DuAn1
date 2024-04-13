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
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Project_SHOE
{
    public partial class QuanLiKhuyenMai : Form
    {
        //vậy nếu tôi muốn gửi email thông báo cho khách hàng khi khuyến mãi hết hạn thì tôi phải làm thế nào ?
        //bạn có thể giúp tôi được không ?
        //tôi muốn thêm 1 button để gửi email thông báo cho khách hàng khi khuyến mãi hết hạn
        private KhuyenMaiService _service;
        private string _id_WhenClick;
        string username;
        public QuanLiKhuyenMai(string username)
        {
            InitializeComponent();
            _service = new KhuyenMaiService();
            LoadData();
            this.username = username;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            //tôi muốn validate thông tin của khuyến mãi
            if (string.IsNullOrEmpty(txt_tenKM.Text))
            {
                //Nếu tên khuyến mãi đã tồn tại thì sẽ thông báo tên khuyến mãi và check trống
                if (_service.GetAll(null).Any(x => x.Tenkhuyenmai == txt_tenKM.Text))
                {
                    MessageBox.Show("Tên Khuyến Mãi đã tồn tại");
                    return;
                }
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
                // số lượng không được để trống và phải là số và không được có kí tự đặc biệt
                if (txt_soluong.Text.Any(char.IsLetter) || txt_soluong.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Số Lượng không được chứa chữ hoặc kí tự đặc biệt");
                    return;
                }
            }
           
            //ngày tạo không được để trống
            if (dateTimePicker3.Value == null)
            {
                MessageBox.Show("Ngày Tạo không được để trống");
                return;
            }
            //ngày kết thúc không được để trống
            if (dateTimePicker2.Value == null)
            {
                MessageBox.Show("Ngày Kết Thúc không được để trống");
                return;
            }
            //ngày bắt đầu không được để trống
            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Ngày Bắt Đầu không được để trống");
                return;
            }
        
            //số phần tră, khuyến mãi không được có chữ
            if (txt_chietkhau.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Số Phần Trăm Khuyến Mãi không được chứa chữ ");
                return;
            }
            //nếu mã khuyến mãi trùng với mã khuyến mãi đã tồn tại thì sẽ thông báo mã khuyến mãi đã tồn tại
            if (_service.GetAll(null).Any(x => x.IdKhuyenmai == textBox1.Text))
            {
                MessageBox.Show("Mã Khuyến Mãi đã tồn tại");
                return;
            }




            var km = new Khuyenmai();

            km.IdKhuyenmai = _id_WhenClick;
            //Tôi muốn mã khuyến mãi random
            km.IdKhuyenmai = textBox1.Text;
          
            


            km.Tenkhuyenmai = txt_tenKM.Text;
            txt_tenKM.KeyPress += txt_tenKM_KeyPress;
            km.Ngayhethan = dateTimePicker1.Value;
            km.Ngaybatdau = dateTimePicker2.Value;
            km.Ngaytao = dateTimePicker3.Value;
            km.Sophantramkhuyenmai = decimal.Parse(txt_chietkhau.Text);
            km.Soluong = int.Parse(txt_soluong.Text);
            txt_soluong.KeyPress += txt_soluong_KeyPress;
            txt_chietkhau.KeyPress += txt_chietkhau_KeyPress;
            //nếu số lượng khuyến mãi = 0 thì trạng thái sẽ là đã hết
            if (km.Soluong == 0)
            {
                km.Trangthai = "Đã Hết";
            }
            //nếu số lượng khuyến mãi > 0 thì trạng thái sẽ là đang hoạt động
            else if (km.Soluong > 0)
            {
                km.Trangthai = "Đang Diễn Ra";
            }
            var option = MessageBox.Show("Bạn có chắc chắn muốn thêm khuyến mãi này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {

                _service.Add(km);
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            else
            {
                return;
            }
            btn_sua.Enabled = false;
            textBox1.Enabled = false;





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
            dateTimePicker3.Enabled = false;

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
        
            if (string.IsNullOrEmpty(txt_chietkhau.Text))
            {
                MessageBox.Show("Chiết Khấu không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(txt_soluong.Text))
            {
                // số lượng không được để trống và phải là số và không được có kí tự đặc biệt
                if (txt_soluong.Text.Any(char.IsLetter) || txt_soluong.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Số Lượng không được chứa chữ hoặc kí tự đặc biệt");
                    return;
                }
            }
           
           
            //số phần tră, khuyến mãi không được có chữ
            if (txt_chietkhau.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Số Phần Trăm Khuyến Mãi không được chứa chữ ");
                return;
            }
            //Ngày bắt đầu không được để trống
            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Ngày Bắt Đầu không được để trống");
                return;
            }
            //Ngày kết thúc không được để trống
            if (dateTimePicker2.Value == null)
            {
                MessageBox.Show("Ngày Kết Thúc không được để trống");
                return;
            }
            //Ngày tạo không được để trống
            if (dateTimePicker3.Value == null)
            {
                MessageBox.Show("Ngày Tạo không được để trống");
                return;
            }

            var km = new Khuyenmai();
            km.IdKhuyenmai = _id_WhenClick;
            
            
            km.Tenkhuyenmai = txt_tenKM.Text;
            txt_tenKM.KeyPress += txt_tenKM_KeyPress;
            km.Ngaybatdau = dateTimePicker1.Value;
            km.Ngayhethan = dateTimePicker2.Value;
            km.Ngaytao = dateTimePicker3.Value;
            km.Soluong = int.Parse(txt_soluong.Text);
            txt_soluong.KeyPress += txt_soluong_KeyPress;
            km.Sophantramkhuyenmai = decimal.Parse(txt_chietkhau.Text);
            txt_chietkhau.KeyPress += txt_chietkhau_KeyPress;
            //nếu số lượng khuyến mãi = 0 thì trạng thái sẽ là đã hết
            if (km.Soluong == 0)
            {
                km.Trangthai = "Đã Hết";
            }
            //nếu số lượng khuyến mãi > 0 thì trạng thái sẽ là đang hoạt động
            else if (km.Soluong > 0)
            {
                km.Trangthai = "Đang Diễn Ra";
            }
            var option = MessageBox.Show("Bạn có chắc chắn muốn sửa khuyến mãi này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                _service.Update(km);
                LoadData();
            }
            else
            {
                return;
            }



            btn_them.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //nếu sự kiện cell click sẽ lấy dữ liệu từ cell đó
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                _id_WhenClick = row.Cells[8].Value.ToString();
                txt_tenKM.Text = row.Cells[1].Value.ToString();
                txt_chietkhau.Text = row.Cells[2].Value.ToString();
                txt_soluong.Text = row.Cells[7].Value.ToString();
                dateTimePicker1.Value = (DateTime)row.Cells[4].Value;
                dateTimePicker2.Value = (DateTime)row.Cells[5].Value;
                dateTimePicker3.Value = (DateTime)row.Cells[6].Value;
                textBox1.Text = row.Cells[8].Value.ToString();
                txt_idKM.Enabled = false;
                btn_sua.Enabled = true;
                btn_them.Enabled = false;
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Thông tin tài khoản Twilio
            string accountSid = "YOUR_TWILIO_ACCOUNT_SID";
            string authToken = "YOUR_TWILIO_AUTH_TOKEN";

            TwilioClient.Init(accountSid, authToken);

            // Số điện thoại bạn muốn gửi tin nhắn từ
            var from = new PhoneNumber("0972396946");

            // Số điện thoại bạn muốn gửi tin nhắn đến
            var to = new PhoneNumber("0988885990");

            // Nội dung tin nhắn
            string messageBody = "Hello from Twilio!";

            try
            {
                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: messageBody);

                Console.WriteLine($"Tin nhắn đã được gửi, SID: {message.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
            }
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            //khi tôi ấn click vào button này sẽ clear tất cả các ô text và ngày tháng
            txt_tenKM.Text = "";
            txt_chietkhau.Text = "";
            txt_soluong.Text = "";
            textBox1.Text = ""; 
            
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            txt_idKM.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = false;

        }

        private void txt_tenKM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tenKM_KeyPress(object sender, KeyPressEventArgs e)
        {



        }

        private void txt_chietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra chỉ nhập số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Kiểm tra không có kí tự đặc biệt
            if (e.KeyChar == 32)
            {

                MessageBox.Show("Số Phần Trăm Khuyến Mãi không được chứa kí tự đặc biệt");
                e.Handled = true;
            }

        }

        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra chỉ nhập số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Kiểm tra không có kí tự đặc biệt
            if (e.KeyChar == 32)
            {
                MessageBox.Show("Số Lượng không được chứa kí tự đặc biệt");
                e.Handled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
