using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SHOE.View
{
    public partial class ResetPass : Form
    {
        public ResetPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string Sodienthoai = txt_sdt.Text;
            string MatkhauCu = textBox1.Text;
            string MatkhauMoi = txt_newpass.Text;
            string XacNhanMatKhau = txt_confirmpass.Text;

            //check mật khẩu cũ có đúng không
            string connectionString = @"Data Source=HHUNGDZ\SQLEXPRESS;Initial Catalog=CuaHangBanHang_1;Integrated Security=True;TrustServerCertificate=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NHANVIEN WHERE SDT = @SDT AND MATKHAU = @MatKhauCu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SDT", Sodienthoai);
                    command.Parameters.AddWithValue("@MatKhauCu", MatkhauCu);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng!");
                        return;
                    }
                }
            }
            // Kiểm tra mật khẩu mới và xác nhận mật khẩu
            if (MatkhauMoi != XacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!");
                return;
            }

            // Update mật khẩu mới vào cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE NHANVIEN SET MATKHAU = @MatKhauMoi WHERE SDT = @SDT";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@MatKhauMoi", MatkhauMoi);
                    updateCommand.Parameters.AddWithValue("@SDT", Sodienthoai);

                    connection.Open();
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!");
                        // Reset các ô nhập liệu
                        textBox1.Text = "";
                        txt_newpass.Text = "";
                        txt_confirmpass.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại!");
                    }
                }
            }








        }
        //nếu mật khẩu cũ không đúng thì sẽ hiển thị thông báo lỗi

        private bool ValidateInput()
        {
            bool isValid = true;
            string errorMessage = "";

            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                errorMessage += "Số điện thoại không được trống!\n";
                isValid = false;
            }
            // Kiểm tra số điện thoại có hợp lệ không và không được quá 10 kí tự
            if (!ValidatePhoneNumber(txt_sdt.Text))
            {
                errorMessage += "Số điện thoại không hợp lệ!\n";
                isValid = false;
            }


          

            if (string.IsNullOrEmpty(txt_newpass.Text))
            {
                errorMessage += "Mật khẩu mới không được trống!\n";
                isValid = false;
            }

            if (string.IsNullOrEmpty(txt_confirmpass.Text))
            {
                errorMessage += "Xác nhận mật khẩu không được trống!\n";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Lỗi lấy lại mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            string regex = @"^[0-9]+$";
            if (!Regex.IsMatch(phoneNumber, regex))
            {
                MessageBox.Show("Mật khẩu không được có A-Z,a-z và kí tự đặc biệt");
            }
            return Regex.IsMatch(phoneNumber, regex);
        }

        private string GenerateNewPassword()
        {

            string password = "";
            return password;
        }

        private void SendEmail(string email, string password) // xóa
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

            
        }
    }
}

    

