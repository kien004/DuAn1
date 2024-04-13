using Microsoft.Data.SqlClient;
using Project_SHOE.View;

namespace Project_SHOE
{
    public partial class Form1 : Form
    {
        public string sdt;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (!ValidateInput())
            {
                return;
            }

            string username = textBox1.Text;
            string password = textBox2.Text;
            string trangthaihoatdong = "";
            textBox1.KeyPress += textBox1_KeyPress;


            string connectionString = @"Data Source=HHUNGDZ\SQLEXPRESS;Initial Catalog=CuaHangBanHang_1;Integrated Security=True;TrustServerCertificate=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT ID_CHUCVU FROM NHANVIEN WHERE SDT = @username AND MATKHAU = @password ";
                string query1 = "SELECT TRANGTHAI FROM NHANVIEN WHERE SDT = @username AND MATKHAU = @password ";




                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    //nếu trạng thái hoạt động = đang hoạt động thì đăng nhập được




                    

                    // Thực hiện truy vấn SQL và gán giá trị cho biến trangthaihoatdong
                   


                    if (reader.Read())
                    {
                        string id = reader[0].ToString();
                        sdt = id;
                    }


                    if (reader.HasRows)
                    {
                        MessageBox.Show("Đăng nhập thành công!");

                        TrangChu trangchu = new TrangChu(username);
                        trangchu.idcv = sdt;
                        trangchu.ShowDialog();
                        Form1 form1 = new Form1();
                        form1.Close();
                        this.Hide();
                    }
                   
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    }

                    reader.Close();
                }
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string errorMessage = "";
            //đăng nhập không quá 10 ký tự
            if (textBox1.Text.Length > 10)
            {
                errorMessage += "Tên đăng nhập không được quá 10 ký tự!\n";
                isValid = false;
            }
            //số điện thoại không được có ký tự và ký tự đặc biệt
            if (!textBox1.Text.All(char.IsDigit))
            {
                errorMessage += "Tên đăng nhập không được chứa ký tự đặc biệt!\n";
                isValid = false;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorMessage += "Tên đăng nhập không được trống!\n";
                isValid = false;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorMessage += "Mật khẩu không được trống!\n";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            return isValid;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var option = MessageBox.Show("Bạn Thoát Thật à ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }


        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPass reset = new ResetPass();
            reset.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự được nhập có phải là số không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự được nhập vào ô đăng nhập
            }
            //Kiểm tra nếu ký tự đầu tiên bắt buộc phải là số 0 và nếu nhập số khác sẽ không được nhập
            if (textBox1.Text.Length == 0 && e.KeyChar != '0')
            {
                e.Handled = true;
            }
        }
    }
}
