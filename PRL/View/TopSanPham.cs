using BUS.Services;
using BUS.ViewModel;

using System.Windows.Forms;

namespace PRL.Views
{
    public partial class TopSanPham : Form
    {
        TopSanPhamService _topSanPhamService = new TopSanPhamService();

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
                    item.TenThuongHieu ?? "N/A");
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           LoadData(_topSanPhamService.GetTopSellingProducts(DateOnly.FromDateTime(dateTimePicker1.Value),DateOnly.FromDateTime(dateTimePicker2.Value)));
            

           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData(_topSanPhamService.GetTopSellingProducts(DateOnly.FromDateTime(dateTimePicker1.Value), DateOnly.FromDateTime(dateTimePicker2.Value)));
        }

        private void TopSanPham_Load_2(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            LoadData(_topSanPhamService.GetTopSellingProducts(DateOnly.FromDateTime(dateTimePicker1.Value), DateOnly.FromDateTime(dateTimePicker2.Value)));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
