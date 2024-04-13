using BUS.Services;
using BUS.ViewModel;
using ExcelDataReader;
using IronXL;
using System.Data;
using System.Windows.Forms;

namespace PRL.Views
{
    public partial class TopSanPham : Form
    {
        TopSanPhamService _topSanPhamService = new TopSanPhamService();
        double tongTien = 0;

        public TopSanPham()
        {
            _topSanPhamService = new TopSanPhamService();
            InitializeComponent();
        }

        private void LoadData(dynamic data)
        {
            DateOnly fromDate = DateOnly.FromDateTime(dateTimePicker1.Value);
            DateOnly toDate = DateOnly.FromDateTime(dateTimePicker2.Value);


            if (toDate < fromDate)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                DateOnly date1 = DateOnly.FromDateTime(dateTimePicker1.Value);
                DateOnly date2 = DateOnly.FromDateTime(dateTimePicker2.Value);
                return;
            }

            if (data == null)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
                return;
            }

            dgrTopSP.Rows.Clear();
            dgrTopSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int stt = 1;
            dgrTopSP.ColumnCount = 7;
            dgrTopSP.Columns[0].Name = "stt"; dgrTopSP.Columns[0].HeaderText = "Số thứ tự";
            dgrTopSP.Columns[1].Name = "idSP";
            dgrTopSP.Columns[2].Name = "nameSP"; dgrTopSP.Columns[2].HeaderText = "Tên Sản phẩm";
            dgrTopSP.Columns[3].Name = "soLuong"; dgrTopSP.Columns[3].HeaderText = "Số lượng bán";
            dgrTopSP.Columns[4].Name = "tongTien"; dgrTopSP.Columns[4].HeaderText = "Tổng doanh thu";
            dgrTopSP.Columns[5].Name = "TrangThai"; dgrTopSP.Columns[5].HeaderText = "Trạng thái";
            dgrTopSP.Columns[6].Name = "TenThuongHieu"; dgrTopSP.Columns[6].HeaderText = "Tên thương hiệu";

            dgrTopSP.Columns[1].Visible = false;

            foreach (var item in data)
            {
                dgrTopSP.Rows.Add(stt++,
                    item.idSP ?? "N/A",
                    item.nameSP ?? "N/A",
                    item.soLuong ?? 0,
                    item.tongTien ?? 0,
                    item.TrangThai ?? "N/A",
                    item.TenThuongHieu ?? "N/A",
                    tongTien += item.tongTien);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData(_topSanPhamService.GetTopSellingProducts(dateTimePicker1.Value, dateTimePicker2.Value));



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData(_topSanPhamService.GetTopSellingProducts(dateTimePicker1.Value, dateTimePicker2.Value));
        }

        private void TopSanPham_Load_2(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date; LoadData(_topSanPhamService.GetTopSellingProducts(dateTimePicker1.Value, dateTimePicker2.Value));
            textBox1.Text = tongTien.ToString();
            textBox1.Enabled = false;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// this method will read the excel file and copy its data into a datatable
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>DataTable</returns>
        //private DataTable ReadExcel(string fileName)
        //{
        //    WorkBook workbook = WorkBook.Load(fileName);
        //    //// Work with a single WorkSheet.
        //    ////you can pass static sheet name like Sheet1 to get that sheet
        //    ////WorkSheet sheet = workbook.GetWorkSheet("Sheet1");
        //    //You can also use workbook.DefaultWorkSheet to get default in case you want to get first sheet only
        //    WorkSheet sheet = workbook.DefaultWorkSheet;
        //    //Convert the worksheet to System.Data.DataTable
        //    //Boolean parameter sets the first row as column names of your table.
        //    return sheet.ToDataTable(true);
        //}




        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            //if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            //{
            //    string fileExt = Path.GetExtension(file.FileName); //get the file extension
            //    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
            //    {
            //        try
            //        {
            //            DataTable dtExcel = ReadExcel(file.FileName); //read excel file
            //            dgrTopSP.Visible = true;
            //            dgrTopSP.DataSource = dtExcel;



            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message.ToString());
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
            //    }
            //}
        }
    




                /// <summary>
                /// this method will close the windows form
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>



            
        





            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }


        
    }
}


