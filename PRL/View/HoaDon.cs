using BUS.Services;
using BUS.Viewmoder;
using DAL.IRepository;
using DAL.Models;
using DAL.Repositori;
using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;
using Project_SHOE.Controller.Repositori;
using Project_SHOE.Controller.Servicer;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml;
using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Printing;
using PRL.View;
using IronSoftware;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SixLabors.Fonts;
using System.Reflection.Metadata;
using iText.StyledXmlParser.Jsoup.Nodes;
using Microsoft.Office.Interop.Excel;
using SixLabors.ImageSharp.Drawing.Processing;
using System.Xml.Linq;
using ZXing.QrCode.Internal;
using QRCoder;

namespace PRL.Views
{
    public partial class HoaDon : Form
    {
        string username;
        HashSet<string> addedColors = new HashSet<string>();
        HashSet<int?> addedSizes = new HashSet<int?>();
        HashSet<int> addedIds = new HashSet<int>();
        IHoaDonCTRepos HoaDonCTRepos = new IHoaDonCTRepos();
        HoaDonRepos HoaDonRepos = new HoaDonRepos();
        SanPhamCTSer SanPhamChiTietRepos = new SanPhamCTSer();
        SanPhamSer SanPhamRepos = new SanPhamSer();
        KhachHangRepository KhachHangRepository = new KhachHangRepository();
        KhuyenMaiService KhuyenMaiService = new KhuyenMaiService();
        NhanVienService NhanVienService = new NhanVienService();
        HoaDonSer hoaDonSer = new HoaDonSer();

        public HoaDon(string username)
        {
            this.username = username;
            KhuyenMaiService = new KhuyenMaiService();
            KhachHangRepository = new KhachHangRepository();
            HoaDonCTRepos = new IHoaDonCTRepos();
            HoaDonRepos = new HoaDonRepos();
            SanPhamChiTietRepos = new SanPhamCTSer();
            SanPhamRepos = new SanPhamSer();
            InitializeComponent();

        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            cbb_PhuongThucThanhToan.Items.Add("Chuyển Khoảng");
            cbb_PhuongThucThanhToan.Items.Add("Tiền Mặt");
            cbb_KieuKH.Items.Add("Khách Lẻ");
            cbb_KieuKH.Items.Add("Thành Viên");
            foreach (var sanPhamChiTiet in SanPhamChiTietRepos.GetAllSPCT())
            {
                // Kiểm tra nếu số lượng sản phẩm lớn hơn hoặc bằng 1
                if (sanPhamChiTiet.Soluong >= 1 || sanPhamChiTiet.Trangthai == "Hết Hàng")
                {
                    int? idSanPhamNullable = sanPhamChiTiet.IdSanpham;
                    if (idSanPhamNullable.HasValue && !addedIds.Contains(idSanPhamNullable.Value))
                    {
                        int idSanPham = idSanPhamNullable.Value; // Ép kiểu từ int? sang int
                        string tenSanPham = SanPhamRepos.GetTenSanPhamById(idSanPham);
                        cbb_SanPham.Items.Add(tenSanPham);
                        addedIds.Add(idSanPham); // Thêm id đã thêm vào HashSet
                    }
                }
            }


            foreach (var i in KhuyenMaiService.GetALLKhuyenMai())
            {
                Cbb_MKM.Items.Add(i.IdKhuyenmai);
            }
            LoadData(hoaDonSer.Getview());
            groupBox7.Enabled = false;
            txtHoaDon.Text = GenerateInvoiceCode();
            txt_KhachHangMoi.Enabled = false;

            txtHoaDon.Enabled = false;
            txt_sdtKH.Enabled = false;
            btn_TimSDTKH.Enabled = false;
            dtp_NgayTao.Enabled = false;
            txt_GiaSP.Enabled = false;
            btn_ThanhToan.Enabled = false;
            txt_SoLuongConTrongKhoSP.Enabled = false;
            txt_ChietKhau.Enabled = false;
            txt_SoLuongSP.Enabled = false;
            txt_TongTienHang.Enabled = false;
            txt_XoaSP.Enabled = false;
            cbb_SizeSP.Enabled = false;
            cbb_mauSP.Enabled = false;
            txt_diachiKH.Enabled = false;
            txt_TongThanhToan.Enabled = false;
            txt_ThemSP.Enabled = false;
            btn_Luu.Enabled = false;
            txt_SDTTK.Enabled = false;
            cbb_SanPham.Enabled = false;
            Cbb_MKM.Enabled = false;
            btn_InHoaDon.Enabled = false;
            cbb_PhuongThucThanhToan.Enabled = false;
            txt_KhachHangMoi.KeyPress += txt_KhachHangMoi_KeyPress;
            txt_sdtKH.KeyPress += txt_sdtKH_KeyPress;
            txt_SoLuongSP.KeyPress += txt_sdtKH_KeyPress;

            cbb_KieuKH.KeyDown += comboBox1_KeyDown;
            cbb_KieuKH.KeyPress += comboBox1_KeyPress;
            cbb_mauSP.KeyDown += comboBox1_KeyDown;
            cbb_mauSP.KeyPress += comboBox1_KeyPress;
            cbb_SanPham.KeyPress += comboBox1_KeyPress;
            cbb_SanPham.KeyDown += comboBox1_KeyDown;
            cbb_SizeSP.KeyDown += comboBox1_KeyDown;
            cbb_SizeSP.KeyPress += comboBox1_KeyPress;
            Cbb_MKM.KeyDown += comboBox1_KeyDown;
            Cbb_MKM.KeyPress += comboBox1_KeyPress;
            cbb_PhuongThucThanhToan.KeyDown += comboBox1_KeyDown;
            cbb_PhuongThucThanhToan.KeyPress += comboBox1_KeyPress;
            UpdateDateTimePickerValue();
            label_NhanVien.Text = username;
        }
        private void LoadData(dynamic data)
        {
            dataGridView1.Rows.Clear();
            int stt = 1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 9;
            // Đặt tên cho các cột
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "ID Hóa Đơn";
            dataGridView1.Columns[2].Name = "ID Khuyến Mãi";
            dataGridView1.Columns[3].Name = "Ngày Tạo";
            dataGridView1.Columns[4].Name = "Tổng Tiền";
            dataGridView1.Columns[5].Name = "Số Điện Thoại";
            dataGridView1.Columns[6].Name = "ID Nhân Viên";
            dataGridView1.Columns[7].Name = "Phương Thức Thanh Toán";
            dataGridView1.Columns[8].Name = "Trạng Thái";
            dataGridView1.Columns[8].Visible = false; // 8 là chỉ số của cột "Trạng Thái"
            dataGridView1.Columns[7].Visible = false; // 8 là chỉ số của cột "Phương Thức Thanh Toán"
            dataGridView1.Columns[6].Visible = false; // 8 là chỉ số của cột "ID Nhân Viên"
            dataGridView1.Columns[3].Visible = false; // 8 là chỉ số của cột "Ngày Tạo"
            dataGridView1.Columns[4].Visible = false; // 8 là chỉ số của cột "Tổng Tiền"

            foreach (var sp in data)
            {
                // Kiểm tra trạng thái của hóa đơn là "Chưa Thanh Toán" và ngày tạo là ngày hôm nay
                if (sp.TrangThai == "Chưa thanh toán" && sp.NgayTao.Date == DateTime.Today)
                {
                    dataGridView1.Rows.Add(stt++, sp.IdHoaDon, sp.IdKhuyenMai, sp.NgayTao, sp.TongTien, sp.SoDienThoai, sp.idnhanvien, sp.PhuongThucThanhToan, sp.TrangThai);
                }
            }

        }


        private void UpdateDateTimePickerValue()
        {
            // Lấy thời gian hiện tại
            DateOnly thoiGianHienTai = DateOnly.FromDateTime(DateTime.Now);

            // Gán giá trị cho DateTimePicker
            dtp_NgayTao.Value = new DateTime(thoiGianHienTai.Year, thoiGianHienTai.Month, thoiGianHienTai.Day);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txt_XoaSP.Enabled = true;
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Ngăn chặn ComboBox nhận ký tự từ bàn phím
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true; // Ngăn chặn ComboBox nhận sự kiện phím từ bàn phím
        }



        private void cbb_KieuKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_KieuKH.Text == "Khách Lẻ")
            {
                // Các thay đổi khi chọn Khách Lẻ
                txt_sdtKH.Enabled = true;
                txt_diachiKH.Enabled = true;

                txt_KhachHangMoi.Enabled = true;
                btn_TimSDTKH.Enabled = false;
                txt_SDTTK.Enabled = false;
                cbb_SanPham.Enabled = true;
                ResetSP();

                // Xoá dữ liệu trong các TextBox và ComboBox
                ResetCustomerData();
            }
            else if (cbb_KieuKH.Text == "Thành Viên")
            {
                // Các thay đổi khi chọn Thành Viên
                txt_sdtKH.Enabled = false;
                txt_diachiKH.Enabled = false;

                btn_TimSDTKH.Enabled = true;
                txt_KhachHangMoi.Enabled = false;
                txt_SDTTK.Enabled = true;
                cbb_SanPham.Enabled = true;
                Cbb_MKM.Enabled = true;
                ResetSP();

                // Xoá dữ liệu trong các TextBox và ComboBox
                ResetCustomerData();
            }
            else
            {
                // Các thay đổi khi chọn mục khác
                DisableAllControls();

                // Xoá dữ liệu trong các TextBox và ComboBox
                ResetCustomerData();
            }
        }

        // Phương thức để vô hiệu hóa tất cả các control
        private void DisableAllControls()
        {
            txt_sdtKH.Enabled = false;
            txt_diachiKH.Enabled = false;

            btn_TimSDTKH.Enabled = false;
            txt_KhachHangMoi.Enabled = false;
            txt_SDTTK.Enabled = false;
            cbb_SanPham.Enabled = false;
            cbb_PhuongThucThanhToan.Enabled = true;
        }

        // Phương thức để xoá dữ liệu trong các TextBox và ComboBox
        private void ResetCustomerData()
        {
            txt_sdtKH.Text = "";
            txt_diachiKH.Text = "";

            txt_KhachHangMoi.Text = "";
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void txt_sdtKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu kí tự là khoảng trắng và không phải là phím Backspace
            if (e.KeyChar == ' ' && e.KeyChar != (char)Keys.Back)
            {
                // Ngăn chặn kí tự khoảng trắng được nhập vào
                e.Handled = true;
            }
            // Nếu kí tự không phải là số và không phải là phím Backspace
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Ngăn chặn kí tự được nhập vào
                e.Handled = true;
            }
        }
        private void btn_ThemKH_Click()
        {
            // Lấy thông tin khách hàng từ các TextBox
            string tenKhachHang = txt_KhachHangMoi.Text;
            string sdt = txt_sdtKH.Text;
            string diaChi = txt_diachiKH.Text;

            // Kiểm tra xem các trường thông tin có được điền đầy đủ không
            if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thực hiện thêm nếu thiếu thông tin
            }

            // Kiểm tra xem số điện thoại có đúng định dạng không (10 ký tự và bắt đầu bằng số 0)
            if (!IsValidPhoneNumber(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem số điện thoại đã tồn tại trong cơ sở dữ liệu hay chưa
            if (KhachHangRepository.IsSDTExist(sdt))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thực hiện thêm nếu số điện thoại đã tồn tại
            }


            // Tạo đối tượng Khachhang mới
            Khachhang newCustomer = new Khachhang
            {
                Hovaten = tenKhachHang,
                Sdt = sdt,
                Diachi = diaChi
            };

            // Thực hiện thêm khách hàng vào cơ sở dữ liệu
            bool result = KhachHangRepository.AddKH(newCustomer);

            // Kiểm tra kết quả thêm

        }

        // Phương thức kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng số điện thoại
            string pattern = @"^0\d{9}$"; // Bắt đầu bằng số 0 và theo sau là 9 chữ số khác
            return Regex.IsMatch(phoneNumber, pattern);
        }
        private void ClearTextBoxes()
        {

            txt_sdtKH.Clear();
            txt_KhachHangMoi.Clear();
            txt_diachiKH.Clear();
        }

        private void btn_TimSDTKH_Click(object sender, EventArgs e)
        {
            // Lấy số điện thoại từ TextBox
            string sdt = txt_SDTTK.Text;

            // Tìm khách hàng có số điện thoại tương ứng trong danh sách khách hàng
            Khachhang customer = KhachHangRepository.GetAllKH().FirstOrDefault(kh => kh.Sdt == sdt);

            // Nếu không tìm thấy khách hàng, thông báo và thoát
            if (customer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng có số điện thoại này.");
                return;
            }

            // Hiển thị thông tin của khách hàng trong các TextBox
            txt_KhachHangMoi.Text = customer.Hovaten;

            txt_sdtKH.Text = customer.Sdt;
            txt_diachiKH.Text = customer.Diachi;
        }
        private string previousSelectedItem;
        private void cbb_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên sản phẩm mới được chọn
            string selectedSanPham = cbb_SanPham.SelectedItem?.ToString();

            // Kiểm tra nếu sản phẩm đã được thay đổi
            if (selectedSanPham != previousSelectedItem)
            {
                // Xóa hết các mục đã được thêm vào ComboBox màu và ComboBox size
                cbb_mauSP.Items.Clear();
                cbb_SizeSP.Items.Clear();

                // Gán giá trị rỗng cho ComboBox màu và ComboBox size để chỉ hiển thị một dòng trống
                cbb_mauSP.Text = "";
                cbb_SizeSP.Text = "";
                txt_SoLuongConTrongKhoSP.Text = "";
                txt_GiaSP.Text = "";
                txt_SoLuongSP.Text = "";
                txt_SoLuongSP.Enabled = false;
                // Vô hiệu hóa cbb_SizeSP
                cbb_SizeSP.Enabled = false;

                // Lấy ID sản phẩm từ ComboBox sản phẩm
                int? idSanPham = null;
                if (!string.IsNullOrWhiteSpace(selectedSanPham))
                {
                    idSanPham = SanPhamChiTietRepos.GetSanPhamId(selectedSanPham);
                }

                // Kiểm tra nếu idSanPham có giá trị
                if (idSanPham.HasValue)
                {
                    // Tạo một HashSet để lưu trữ các id màu đã thêm vào ComboBox
                    HashSet<int> idMauSet = new HashSet<int>();

                    // Lọc và thêm các màu có trong sản phẩm đã chọn
                    foreach (var sanPhamChiTiet in SanPhamChiTietRepos.GetMauBySanPhamId(idSanPham.Value))
                    {
                        int idMau = sanPhamChiTiet.IdMau.Value;

                        // Kiểm tra xem id màu đã tồn tại trong HashSet chưa
                        if (!idMauSet.Contains(idMau))
                        {
                            // Thêm id màu vào HashSet và ComboBox màu
                            idMauSet.Add(idMau);
                            string mau = SanPhamChiTietRepos.GetMauById(idMau);
                            if (!string.IsNullOrWhiteSpace(mau))
                            {
                                cbb_mauSP.Items.Add(mau);
                            }
                        }
                    }

                    // Hiển thị ComboBox màu nếu có ít nhất một màu
                    cbb_mauSP.Enabled = cbb_mauSP.Items.Count > 0;
                }

                // Lưu giá trị mới được chọn vào biến previousSelectedItem
                previousSelectedItem = selectedSanPham;
            }
        }

        private string previousSelectedMau;
        private void cbb_mauSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên màu mới được chọn
            string selectedMau = cbb_mauSP.SelectedItem?.ToString();

            // Kiểm tra nếu màu đã được thay đổi
            if (selectedMau != previousSelectedMau)
            {
                // Xóa dữ liệu cũ trong ComboBox kích thước
                cbb_SizeSP.Items.Clear();
                cbb_SizeSP.Text = "";
                txt_SoLuongConTrongKhoSP.Text = "";
                txt_GiaSP.Text = "";
                txt_SoLuongSP.Text = "";
                txt_SoLuongSP.Enabled = false;

                // Lấy ID sản phẩm từ ComboBox sản phẩm
                string selectedSanPham = cbb_SanPham.SelectedItem as string;
                int? idSanPham = null;
                if (!string.IsNullOrWhiteSpace(selectedSanPham))
                {
                    idSanPham = SanPhamChiTietRepos.GetSanPhamId(selectedSanPham);
                }

                // Kiểm tra nếu idSanPham có giá trị
                if (idSanPham.HasValue)
                {
                    // Lấy ID màu từ tên màu
                    int? idMau = SanPhamChiTietRepos.GetMauId(selectedMau);

                    // Kiểm tra nếu có ID sản phẩm và ID màu
                    if (idSanPham.HasValue && idMau.HasValue)
                    {
                        // Tạo một HashSet để lưu trữ các kích thước đã thêm vào ComboBox
                        HashSet<int> idSizeSet = new HashSet<int>();

                        // Lọc và thêm các kích thước có trong sản phẩm và màu đã chọn
                        foreach (var sanPhamChiTiet in SanPhamChiTietRepos.GetSizeBySanPhamId(idSanPham.Value, idMau.Value))
                        {
                            int idSize = sanPhamChiTiet.IdKichthuoc.Value;

                            // Kiểm tra xem id kích thước đã tồn tại trong HashSet chưa
                            if (!idSizeSet.Contains(idSize))
                            {
                                // Thêm id kích thước vào HashSet và ComboBox kích thước
                                idSizeSet.Add(idSize);
                                int? size = SanPhamChiTietRepos.GetSizeById(idSize);
                                if (size.HasValue)
                                {
                                    cbb_SizeSP.Items.Add(size.Value);
                                }
                            }
                        }
                    }
                }

                // Ẩn ComboBox kích thước nếu không có sản phẩm nào hoặc không có màu nào được chọn
                cbb_SizeSP.Enabled = cbb_SizeSP.Items.Count > 0;
                cbb_SizeSP.Enabled = true;


            }

            // Lưu lại màu được chọn mới vào biến previousSelectedMau
            previousSelectedMau = selectedMau;
            cbb_SizeSP.Enabled = true;
        }
        private void cbb_SizeSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? selectedSize = cbb_SizeSP.SelectedItem as int?;
            // Kiểm tra xem có kích thước được chọn hay không
            if (selectedSize.HasValue)
            {
                // Lấy thông tin từ ComboBox
                string selectedSanPham = cbb_SanPham.SelectedItem as string;
                string selectedMau = cbb_mauSP.SelectedItem as string;

                // Kiểm tra nếu có sản phẩm và màu được chọn
                if (!string.IsNullOrEmpty(selectedSanPham) && !string.IsNullOrEmpty(selectedMau))
                {
                    // Lấy ID sản phẩm, màu và kích thước từ tên sản phẩm, màu và kích thước
                    int? idSanPham = SanPhamChiTietRepos.GetSanPhamId(selectedSanPham);
                    int? idMau = SanPhamChiTietRepos.GetMauId(selectedMau);

                    // Kiểm tra xem selectedSize có giá trị không
                    if (selectedSize.HasValue)
                    {
                        // Chuyển đổi selectedSize từ int? sang int
                        int size = selectedSize.Value;

                        // Lấy ID kích thước từ kích thước đã chọn
                        int? idKichThuoc = SanPhamChiTietRepos.GetSizeId(size);

                        // Kiểm tra xem có ID sản phẩm, màu và kích thước hay không
                        if (idSanPham.HasValue && idMau.HasValue && idKichThuoc.HasValue)
                        {
                            // Tìm id sản phẩm chi tiết
                            int idSanPhamCT = SanPhamChiTietRepos.GetIdSPCT(idSanPham.Value, idMau.Value, idKichThuoc.Value);

                            // Kiểm tra và hiển thị kết quả
                            if (idSanPhamCT > 0)
                            {
                                // Tìm thông tin chi tiết sản phẩm
                                Sanphamct sanPhamCT = SanPhamChiTietRepos.GetById(idSanPhamCT);
                                txt_SoLuongConTrongKhoSP.Text = sanPhamCT.Soluong.ToString(); // Hiển thị số lượng trong TextBox
                                txt_GiaSP.Text = sanPhamCT.Dongia.ToString();
                                txt_SoLuongSP.Enabled = true;
                                return; // Thoát khỏi phương thức
                            }
                        }
                    }
                }
            }

            // Nếu không có phần tử nào được chọn hoặc không tìm thấy sản phẩm
            txt_SoLuongConTrongKhoSP.Text = "";
            txt_GiaSP.Text = "";
            txt_SoLuongSP.Enabled = false;

            // Hiển thị thông báo lỗi trên màn hình
            MessageBox.Show("Sản phẩm không tồn tại hoặc số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txt_SoLuongSP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_SoLuongSP.Text))
            {
                txt_ThemSP.Enabled = false;
            }
            else
            {
                txt_ThemSP.Enabled = true;
            }

        }


        private void txt_SoLuongConTrongKhoSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_tkSoLuong_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ ComboBox
            int idSanPham = cbb_SanPham.SelectedIndex;
            int idMau = cbb_mauSP.SelectedIndex;
            int idKichThuoc = cbb_SizeSP.SelectedIndex;

            // Kiểm tra xem các giá trị Index có hợp lệ không
            if (idSanPham < 0)
            {
                MessageBox.Show("Sản Phẩm Không Được Để Trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (idKichThuoc < 0)
            {
                MessageBox.Show("Size Sản Phẩm Không Được Để Trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (idMau < 0)
            {
                MessageBox.Show("Màu Sản Phẩm Không Được Để Trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy Id sản phẩm, màu và kích thước từ ComboBox
            int IdSanPham = SanPhamRepos.GetAllSP().ElementAt(idSanPham).IdSanpham;
            int IdMau = SanPhamChiTietRepos.GetAllSPCT_Mau().ElementAt(idMau).IdMau;
            int IdKichThuoc = SanPhamChiTietRepos.GetAllSPCT_KichThuoc().ElementAt(idKichThuoc).IdKichthuoc;

            // Tìm kiếm idSanPhamct
            int idSanPhamCT = SanPhamChiTietRepos.GetIdSPCT(IdSanPham, IdMau, IdKichThuoc);

            // Kiểm tra và hiển thị kết quả
            if (idSanPhamCT > 0)
            {
                // Tìm thông tin chi tiết sản phẩm
                Sanphamct sanPhamCT = SanPhamChiTietRepos.GetById(idSanPhamCT);
                txt_SoLuongConTrongKhoSP.Text = sanPhamCT.Soluong.ToString(); // Hiển thị số lượng trong TextBox
                txt_GiaSP.Text = sanPhamCT.Dongia.ToString();
                txt_SoLuongSP.Enabled = true;

            }
            else
            {
                // Hiển thị thông báo lỗi trên màn hình
                MessageBox.Show("Sản phẩm không tồn tại hoặc số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            string idhoadon = txtHoaDon.Text;
            string pttt = cbb_PhuongThucThanhToan.Text;
            if (string.IsNullOrEmpty(cbb_PhuongThucThanhToan.Text))
            {
                MessageBox.Show("Phương Thức Thanh Toán Không Được Bỏ Trống");
                return;
            }
            // Gọi phương thức để cập nhật trạng thái hóa đơn
            if (HoaDonRepos.CapNhatTrangThaiHoaDon(idhoadon, pttt, "Đã Thanh Toán"))
            {
                // Thông báo cho người dùng rằng hóa đơn đã được thanh toán thành công
                MessageBox.Show("Hóa đơn đã được thanh toán thành công!");

                btn_InHoaDon.Enabled = true;
                
                // Cập nhật giao diện hoặc các hoạt động khác nếu cần thiết
                // Ví dụ: cập nhật giao diện để hiển thị rằng hóa đơn đã được thanh toán
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái của hóa đơn!");
                return;
            }
            LoadData(hoaDonSer.Getview());
        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thêm hóa đơn
            DialogResult confirmation = MessageBox.Show("Bạn có chắc muốn thêm hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng xác nhận muốn thêm
            if (confirmation == DialogResult.Yes)
            {
                var hoadon = new Hoadon();
                int idnhanvien = NhanVienService.GetIdNhanVien(label_NhanVien.Text);
                // Lấy thông tin khách hàng từ ComboBox và TextBox
                string tenKhachHang = txt_KhachHangMoi.Text;
                string sdtKhachHang = txt_sdtKH.Text;

                // Kiểm tra xem loại khách hàng là Khách Lẻ hay Thành Viên
                if (cbb_KieuKH.Text == "Khách Lẻ")
                {
                    MessageBox.Show("Thông Báo Bạn Đang Thêm Khách Hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Nếu là Khách Lẻ, tự động thêm mới khách hàng
                    btn_ThemKH_Click();
                }
                else if (cbb_KieuKH.Text == "Thành Viên")
                {
                    // Kiểm tra xem đã chọn khách hàng chưa
                    if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(sdtKhachHang))
                    {
                        MessageBox.Show("Vui lòng chọn một khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Tìm kiếm id khách hàng
                int idKhachHang = KhachHangRepository.GetIdSPCT(tenKhachHang, sdtKhachHang);

                // Kiểm tra xem có tìm thấy id của khách hàng không
                if (idKhachHang == -1)
                {
                    MessageBox.Show($"Không tìm thấy khách hàng có tên '{tenKhachHang}' và số điện thoại '{sdtKhachHang}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(cbb_PhuongThucThanhToan.Text))
                {
                    hoadon.Phuongthucthanhtoan = "";
                }
                // Lấy ngày tạo từ DateTimePicker
                DateTime ngayTao = dtp_NgayTao.Value;

                // Gán giá trị cho hóa đơn
                hoadon.IdNhanvien = Convert.ToInt32(label_NhanVien.Text);
                hoadon.IdKhachhang = KhachHangRepository.GetIdSPCT(tenKhachHang, sdtKhachHang);
                hoadon.Ngaytao = ngayTao;
                hoadon.Trangthai = "Chưa thanh toán";
                hoadon.IdNhanvien = idnhanvien;
                hoadon.Phuongthucthanhtoan = cbb_PhuongThucThanhToan.Text;

                if (string.IsNullOrEmpty(txt_TongTienHang.Text) || string.IsNullOrEmpty(txt_TongThanhToan.Text))
                {
                    MessageBox.Show("Tổng Tiền Hàng hoặc Tổng Thanh Toán đã trống. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lấy mã khuyến mãi từ TextBox
                string idKhuyenMai = Cbb_MKM.Text.Trim();
                if (string.IsNullOrWhiteSpace(idKhuyenMai))
                {
                    hoadon.IdKhuyenmai = null;
                }
                else
                {
                    // Kiểm tra khuyến mại và xử lý tương ứng
                    string khuyenmaiStatus = KhuyenMaiService.CheckKhuyenMai(idKhachHang, idKhuyenMai);
                    if (khuyenmaiStatus == "Khách hàng đã sử dụng mã khuyến mại.")
                    {
                        MessageBox.Show(khuyenmaiStatus, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cbb_MKM.Text = "";
                        return; // Ngăn người dùng tiếp tục quá trình lưu hóa đơn
                    }
                    else
                    {
                        // Gọi phương thức UpdateSoLuongKhuyenMai từ KhuyenMaiService
                        string updateStatus = KhuyenMaiService.UpdateSoLuongKhuyenMai(idKhuyenMai);
                        // Kiểm tra kết quả trả về từ phương thức và xử lý tương ứng
                        if (updateStatus == "Áp dụng khuyến mại thành công.")
                        {
                            hoadon.IdKhuyenmai = idKhuyenMai;
                        }
                        else
                        {
                            // Hiển thị thông báo cho người dùng
                            MessageBox.Show(updateStatus, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Ngăn người dùng tiếp tục quá trình lưu hóa đơn
                        }
                    }
                }
                // Chuyển đổi giá trị từ string sang float cho tổng tiền
                if (!float.TryParse(txt_TongThanhToan.Text, out float tongThanhToan))
                {
                    MessageBox.Show("Giá trị tổng thanh toán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                hoadon.Tongtien = tongThanhToan;

                // Lấy id hóa đơn vừa thêm
                string idHoaDon = txtHoaDon.Text;
                bool isExistAndMatch = HoaDonRepos.CheckExistAndMatchIdHoadon(idHoaDon);
                // Kiểm tra xem hóa đơn đã tồn tại và trùng khớp chưa
                if (isExistAndMatch)
                {
                    // Nếu hóa đơn đã tồn tại và trùng khớp, thực hiện cập nhật
                    DialogResult confirmation2 = MessageBox.Show("Hóa Đơn Đã Tồn Tại, Bạn Có Muốn Cập Nhật Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirmation2 == DialogResult.Yes)
                    {
                        // Gọi phương thức cập nhật hóa đơn
                        bool result = HoaDonRepos.UpdateHoaDon(idHoaDon);
                        if (result)
                        {
                            // Thực hiện cập nhật dữ liệu sau khi kiểm tra và trùng khớp id hóa đơn
                            UpdateDataAfterChecking(idHoaDon);
                            MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật hóa đơn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Người dùng không muốn cập nhật, thoát khỏi phương thức
                        return;
                    }
                }
                else
                {
                    hoadon.IdHoadon = idHoaDon;
                    // Thêm hóa đơn vào danh sách
                    HoaDonRepos.AddHoaDon(hoadon);

                    // Kiểm tra xem ListView có mục nào không
                    if (listView1.Items.Count == 0)
                    {
                        MessageBox.Show("Danh sách sản phẩm trống. Vui lòng thêm ít nhất một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lưu thông tin cho từng sản phẩm trong ListView
                    foreach (ListViewItem lv in listView1.Items)
                    {
                        // Lấy thông tin từ ListView
                        string tenSanPham = lv.SubItems[1].Text;
                        int soLuong = int.Parse(lv.SubItems[4].Text);
                        float gia = float.Parse(lv.SubItems[5].Text);
                        string mau = lv.SubItems[2].Text;
                        int size = int.Parse(lv.SubItems[3].Text);

                        // Tìm ID của sản phẩm từ tên sản phẩm
                        int IdSanPham = SanPhamRepos.GetSanPhamId(tenSanPham);
                        if (IdSanPham == -1)
                        {
                            MessageBox.Show($"Không tìm thấy sản phẩm '{tenSanPham}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Tìm ID của màu từ tên màu
                        int IdMau = SanPhamChiTietRepos.GetMauId(mau);
                        if (IdMau == -1)
                        {
                            MessageBox.Show($"Không tìm thấy màu '{mau}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Tìm ID của kích thước từ tên kích thước
                        int IdKichThuoc = SanPhamChiTietRepos.GetSizeId(size);
                        if (IdKichThuoc == -1)
                        {
                            MessageBox.Show($"Không tìm thấy kích thước '{size}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Tìm idsanphamchitiet dựa trên IdSanPham, IdMau và IdKichThuoc
                        int idSanPhamCT = SanPhamChiTietRepos.GetIdSPCT(IdSanPham, IdMau, IdKichThuoc);
                        if (idSanPhamCT == -1)
                        {
                            MessageBox.Show($"Không tìm thấy sản phẩm chi tiết cho '{tenSanPham}', màu '{mau}' và kích thước '{size}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Kiểm tra và cập nhật số lượng tồn kho của sản phẩm chi tiết
                        int soLuongTonKho = SanPhamChiTietRepos.GetSoLuongTonKho(idSanPhamCT);
                        if (soLuongTonKho < soLuong)
                        {
                            MessageBox.Show($"Số lượng tồn kho không đủ cho sản phẩm '{tenSanPham}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // Trừ số lượng đã bán từ số lượng tồn kho
                        soLuongTonKho -= soLuong;

                        // Cập nhật số lượng tồn kho mới của sản phẩm chi tiết
                        SanPhamChiTietRepos.UpdateSoLuongTonKho(idSanPhamCT, soLuongTonKho);

                        // Thêm hóa đơn chi tiết cho mỗi sản phẩm
                        Hoadonct hoadonct = new Hoadonct
                        {
                            IdHoadon = idHoaDon,
                            IdSanphamct = idSanPhamCT,
                            Soluong = soLuong,
                            Giasp = gia,
                        };

                        HoaDonCTRepos.AddHoaDonCT(hoadonct);
                    }

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btn_ThanhToan.Enabled = true;
                cbb_PhuongThucThanhToan.Enabled = true;
                LoadData(hoaDonSer.Getview());
                cbb_SanPham.ResetText();
                foreach (var sanPhamChiTiet in SanPhamChiTietRepos.GetAllSPCT())
                {
                    // Kiểm tra nếu số lượng sản phẩm lớn hơn hoặc bằng 1
                    if (sanPhamChiTiet.Soluong >= 1)
                    {
                        int? idSanPhamNullable = sanPhamChiTiet.IdSanpham;
                        if (idSanPhamNullable.HasValue && !addedIds.Contains(idSanPhamNullable.Value))
                        {
                            int idSanPham = idSanPhamNullable.Value; // Ép kiểu từ int? sang int
                            string tenSanPham = SanPhamRepos.GetTenSanPhamById(idSanPham);
                            cbb_SanPham.Items.Add(tenSanPham);
                            addedIds.Add(idSanPham); // Thêm id đã thêm vào HashSet
                        }
                    }
                }
            }
        }
        private void UpdateDataAfterChecking(string idHoaDon)
        {
            // Lấy danh sách sản phẩm chi tiết mới từ ListView
            var danhSachChiTietMoi = new List<Hoadonct>();
            foreach (ListViewItem lv in listView1.Items)
            {
                // Lấy thông tin từ ListView
                string tenSanPham = lv.SubItems[1].Text;
                int soLuong = int.Parse(lv.SubItems[4].Text);
                double gia = double.Parse(lv.SubItems[5].Text);
                string mau = lv.SubItems[2].Text;
                int size = int.Parse(lv.SubItems[3].Text); // Sửa lại chỉ số cột

                // Tìm ID của sản phẩm từ tên sản phẩm
                int IdSanPham = SanPhamRepos.GetSanPhamId(tenSanPham);
                if (IdSanPham == -1)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm '{tenSanPham}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tìm ID của màu từ tên màu
                int IdMau = SanPhamChiTietRepos.GetMauId(mau);
                if (IdMau == -1)
                {
                    MessageBox.Show($"Không tìm thấy màu '{mau}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tìm ID của kích thước từ tên kích thước
                int IdKichThuoc = SanPhamChiTietRepos.GetSizeId(size);
                if (IdKichThuoc == -1)
                {
                    MessageBox.Show($"Không tìm thấy kích thước '{size}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo một đối tượng Hoadonct mới từ thông tin lấy được
                var hoadonct = new Hoadonct
                {
                    IdHoadon = idHoaDon,
                    IdSanphamct = SanPhamChiTietRepos.GetIdSPCT(IdSanPham, IdMau, IdKichThuoc),
                    Soluong = soLuong,
                    Giasp = gia
                };
                danhSachChiTietMoi.Add(hoadonct);
            }

            // Thực hiện cập nhật dữ liệu
            bool updateResult = HoaDonRepos.XoaVaCapNhatChiTietHoaDon(idHoaDon, danhSachChiTietMoi);
            if (updateResult)
            {
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ThemSP_Click(object sender, EventArgs e)
        {
            int stt = 1;
            int soLuongNhap = 0;
            int soLuongTrongKho = 0;
            if (cbb_SanPham.Text == "" || cbb_mauSP.Text == "" || cbb_SizeSP.Text == "" || txt_SoLuongSP.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txt_SoLuongSP.Text, out soLuongNhap) || !int.TryParse(txt_SoLuongConTrongKhoSP.Text, out soLuongTrongKho))
            {
                MessageBox.Show("Số lượng sản phẩm và số lượng trong kho phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuongNhap <= 0)
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuongNhap > soLuongTrongKho)
            {
                MessageBox.Show("Số lượng sản phẩm nhập vào vượt quá số lượng trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem sản phẩm đã tồn tại trong danh sách hay chưa
            foreach (ListViewItem item in listView1.Items)
            {
                string tenSanPham = item.SubItems[1].Text;
                string mauSanPham = item.SubItems[2].Text;
                string sizeSanPham = item.SubItems[3].Text;

                if (tenSanPham == cbb_SanPham.Text && mauSanPham == cbb_mauSP.Text && sizeSanPham == cbb_SizeSP.Text)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Tạo một ListViewItem mới
            ListViewItem lv1 = new ListViewItem(stt.ToString());

            // Thêm các SubItems vào ListViewItem
            lv1.SubItems.Add(cbb_SanPham.Text);
            lv1.SubItems.Add(cbb_mauSP.Text);
            lv1.SubItems.Add(cbb_SizeSP.Text);
            lv1.SubItems.Add(txt_SoLuongSP.Text);

            // Tính tổng tiền cho sản phẩm
            decimal giaSP = Convert.ToDecimal(txt_GiaSP.Text);
            int soLuongSP = Convert.ToInt32(txt_SoLuongSP.Text);
            decimal tongTien = giaSP * soLuongSP;
            lv1.SubItems.Add(tongTien.ToString()); // Thêm tổng tiền vào cột giá

            // Tăng biến STT lên 1 để sử dụng cho sản phẩm tiếp theo
            stt++;
            // Thêm ListViewItem vào ListView
            listView1.Items.Add(lv1);

            CapNhatGiaTriTongTien();
          
            ResetSP();
            btn_Luu.Enabled = true;
            txt_ThemSP .Enabled = false;
            txt_SoLuongSP.Enabled = false;
            cbb_SizeSP.Enabled = false;
            cbb_mauSP.Enabled = false;

        }
        public void ResetSP()
        {
            cbb_SanPham.ResetText();
            cbb_SizeSP.ResetText();
            cbb_mauSP.ResetText();
            txt_SoLuongSP.Text = "";
            txt_SoLuongConTrongKhoSP.Text = "";
            txt_GiaSP.Text = "";
        }
        private void CapNhatGiaTriTongTien()
        {
            decimal tongTienHang = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                decimal donGia;

                if (decimal.TryParse(item.SubItems[5].Text, out donGia))
                {
                    tongTienHang += donGia;
                }
            }

            decimal chietKhau;
            if (!decimal.TryParse(txt_ChietKhau.Text, out chietKhau))
            {
                chietKhau = 0;
            }

            decimal tongThanhToan = tongTienHang - chietKhau;

            txt_TongTienHang.Text = tongTienHang.ToString();
            txt_ChietKhau.Text = chietKhau.ToString(); // Cập nhật giá trị chiết khấu
            txt_TongThanhToan.Text = tongThanhToan.ToString();
        }
        private void txt_TongTienHang_TextChanged(object sender, EventArgs e)
        {
            FormatCurrencyTextBox(txt_TongTienHang);
        }

        private void txt_ChietKhau_TextChanged(object sender, EventArgs e)
        {
            CapNhatGiaTriTongTien();
        }

        private void txt_TongThanhToan_TextChanged(object sender, EventArgs e)
        {
            FormatCurrencyTextBox(txt_TongThanhToan);
        }

        private void txt_XoaSP_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn trong listView1 hay không
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy giá trị của mục được chọn để trừ đi từ tổng giá trị
                float giaCanTru = float.Parse(listView1.SelectedItems[0].SubItems[5].Text);

                // Xoá mục được chọn từ ListView
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);

                // Cập nhật lại tổng giá trị
                float tongTienHang = float.Parse(txt_TongTienHang.Text);
                tongTienHang -= giaCanTru;
                txt_TongTienHang.Text = tongTienHang.ToString();

                // Cập nhật lại giá trị chiết khấu và tổng thanh toán
                CapNhatGiaTriTongTien();

                // Kiểm tra số lượng nếu bằng 0 thì vô hiệu hóa nút Xoá
                if (listView1.Items.Count == 0)
                {
                    txt_XoaSP.Enabled = false;
                }

                //Kiểm tra nếu đã thêm sản phẩm mà thay đổi không muốn thêm nữa thì sẽ trả lại số lượng ban đầu
                int soLuongTrongKho = 0;
                if (int.TryParse(txt_SoLuongConTrongKhoSP.Text, out soLuongTrongKho))
                {
                    txt_SoLuongConTrongKhoSP.Text = (soLuongTrongKho + int.Parse(listView1.SelectedItems[0].SubItems[4].Text)).ToString();
                    if (soLuongTrongKho == 0)
                    {
                        MessageBox.Show("Vui lòng chọn một sản phẩm để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                // Hiển thị thông báo lỗi nếu không có mục nào được chọn trong listView1
                MessageBox.Show("Vui lòng chọn một sản phẩm để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_CheckKhuyenMai_Click(object sender, EventArgs e)
        {

        }

        private void txt_MaKhuyenMai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào là dấu cách hoặc ký tự đặc biệt
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                // Huỷ bỏ ký tự đó
                e.Handled = true;
            }
        }

        private void txt_MaKhuyenMai_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_KhachHangMoi_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_KhachHangMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự được nhập không phải là chữ cái, khoảng trắng hoặc phím Backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Chặn việc nhập ký tự và số bằng cách huỷ bỏ sự kiện KeyPress
                e.Handled = true;
            }
        }



        private void Cbb_MKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã khuyến mãi từ combobox
            string maKhuyenMai = Cbb_MKM.SelectedItem?.ToString();

            // Kiểm tra xem mã khuyến mãi có rỗng không
            if (string.IsNullOrEmpty(maKhuyenMai))
            {
                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Vui lòng chọn mã khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán mã khuyến mãi vào TextBox
            Cbb_MKM.Text = maKhuyenMai;

            // Gọi phương thức từ service để lấy thông tin chi tiết khuyến mãi
            Khuyenmai khuyenMai = KhuyenMaiService.GetById(maKhuyenMai);

            // Kiểm tra xem khuyến mãi có tồn tại không
            if (khuyenMai != null)
            {
                // Kiểm tra xem TextBox Tổng Tiền Hàng và Chiết Khấu có chứa giá trị hợp lệ không
                float tongTien;
                float chietKhau;
                if (!float.TryParse(txt_TongTienHang.Text, out tongTien) || !float.TryParse(txt_ChietKhau.Text, out chietKhau))
                {
                    MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho Tổng Tiền Hàng và Chiết Khấu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra hạn khuyến mại đã hết hạn chưa
                if (khuyenMai.Ngayhethan < DateTime.Today)
                {
                    // Nếu đã hết hạn, hiển thị thông báo và trả về -1 để chỉ ra rằng hạn khuyến mại đã hết
                    MessageBox.Show("Mã khuyến mại đã hết hạn sử dụng. Vui lòng chọn khuyến mại khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem số lượng khuyến mại còn lại
                if (khuyenMai.Soluong == 0)
                {
                    // Nếu số lượng khuyến mại là 0, hiển thị thông báo
                    MessageBox.Show("Số lượng trong khuyến mại này đã hết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // Tính toán số tiền khuyến mãi dựa trên phần trăm khuyến mãi và tổng số tiền
                    float tongTienHang = tongTien;
                    float tienKhuyenMai = tongTien * (float)(khuyenMai.Sophantramkhuyenmai / 100);

                    // Trừ số tiền khuyến mãi từ tổng số tiền để có tổng thanh toán
                    float tongThanhToan = tongTien - tienKhuyenMai;

                    // Hiển thị tổng thanh toán trong txt_TongThanhToan
                    txt_TongThanhToan.Text = tongThanhToan.ToString();
                    MessageBox.Show("Thêm Khuyến Mại Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                // Nếu không tồn tại, hiển thị thông báo cho người dùng
                MessageBox.Show("Khuyến mãi không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dtp_NgayTao_ValueChanged(object sender, EventArgs e)
        {
            // Gọi phương thức để cập nhật giá trị khi DateTimePicker thay đổi
            UpdateDateTimePickerValue();
        }


        private void FormatCurrencyTextBox(System.Windows.Forms.TextBox textBox)
        {
            // Kiểm tra xem TextBox có giá trị hay không
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Xóa tất cả các dấu chấm trong TextBox (nếu có)
                string value = textBox.Text.Replace(".", "");

                // Chuyển đổi giá trị thành số nguyên
                if (decimal.TryParse(value, out decimal number))
                {
                    // Định dạng số thành chuỗi có dấu phân cách hàng nghìn
                    textBox.Text = number.ToString("#,##0");
                }
            }
        }

        private void txt_GiaSP_TextChanged(object sender, EventArgs e)
        {
            FormatCurrencyTextBox(txt_GiaSP);
        }

        private void cbb_PhuongThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private static int indexer = 1;

        private void txtHoaDon_TextChanged(object sender, EventArgs e)
        {

        }
        public void ExportPDFfile()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument1_PrintPage;
            printDocument.Print();


        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            ExportPDFfile();
            MessageBox.Show("In Hoá Đơn Thành Công","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string GenerateInvoiceCode()
        {
            DateTime currentDate = DateTime.Now;
            string day = currentDate.Day < 10 ? currentDate.Day.ToString() : currentDate.Day.ToString("D2");
            string month = currentDate.Month.ToString("D2");
            string year = currentDate.Year.ToString();
            string gio = currentDate.Hour.ToString();
            string phut = currentDate.Minute.ToString();
            string giay = currentDate.Second.ToString();

            return $"{day}{month}{year}{gio}{phut}{giay}";
        }

        private void btn_lammoihd_Click(object sender, EventArgs e)
        {
            //khi tôi click vào nút làm mới hóa đơn thì tất cả các ô sẽ trở về giá trị ban đầu và các button sẽ trở về trạng thái ban đầu
            ResetSP();
            listView1.Items.Clear();
            ResetText();

            txtHoaDon.Text = GenerateInvoiceCode().ToString();

            txt_sdtKH.Text = "";
            txt_diachiKH.Text = "";
            cbb_PhuongThucThanhToan.Text = "";
            txt_TongTienHang.Text = "";
            txt_ChietKhau.Text = "";
            txt_TongThanhToan.Text = "";
            listView1.Items.Clear();
            txtHoaDon.Text = "";
            Cbb_MKM.Text = "";
            dtp_NgayTao.Value = DateTime.Now;
            txt_TongTienHang.Text = "";
            txt_ChietKhau.Text = "";
            txt_TongThanhToan.Text = "";
            txt_sdtKH.Text = "";
            txt_diachiKH.Text = "";
            cbb_PhuongThucThanhToan.Text = "";
            txt_GiaSP.Text = "";
            txt_SoLuongSP.Text = "";
            txt_SoLuongConTrongKhoSP.Text = "";
            cbb_KieuKH.Enabled = true;
            cbb_KieuKH.Text = "";



        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!groupBox7.Enabled)
            {
                // Nếu groupBox7 đang bị disable, enable dataGridView1 và groupBox7
                dataGridView1.Enabled = true;
                groupBox7.Enabled = true;
            }
            else
            {
                // Nếu groupBox7 đang được enable, disable dataGridView1 và groupBox7
                dataGridView1.Enabled = false;
                groupBox7.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                int index = e.RowIndex;
                var selectChild = dataGridView1.Rows[index];
                txtHoaDon.Text = selectChild.Cells[1].Value.ToString();
                //nếu cbb_mkm không có giá trị thì sẽ bo qua
                if (selectChild.Cells[2].Value == null)
                {
                    Cbb_MKM.Text = "";
                }
                cbb_KieuKH.Text = ("Thành Viên");
                dtp_NgayTao.Value = Convert.ToDateTime(selectChild.Cells[3].Value); // Đảm bảo hiển thị ngày tháng nếu dữ liệu là kiểu DateTime
                txt_TongThanhToan.Text = selectChild.Cells[4].Value.ToString();
                // Lấy số điện thoại từ cell 5
                string soDienThoai = selectChild.Cells[5].Value.ToString();
                // Hiển thị số điện thoại trong TextBox
                txt_sdtKH.Text = soDienThoai;


                // Chuyển số điện thoại thành ID khách hàng
                int idKhachHang = KhachHangRepository.GetIdSPCT1(soDienThoai);
                // Lấy tên khách hàng từ ID khách hàng
                string tenKhachHang = KhachHangRepository.GetTenKhachHang(idKhachHang);
                // Hiển thị tên khách hàng trong ComboBox

                string diachi = KhachHangRepository.GetDiaChiKhachHang(idKhachHang);
                // Hiển thị địa chỉ khách hàng
                txt_diachiKH.Text = diachi;
                txt_KhachHangMoi.Text = tenKhachHang;

                cbb_PhuongThucThanhToan.Text = selectChild.Cells[7].Value.ToString();

                // Xuất sản phẩm chi tiết vào ListView dựa vào ID hóa đơn đã chọn
                LoadChiTietHoaDon(txtHoaDon.Text);
                //Hiển thị thông tin liên quan đến lisview

                cbb_KieuKH.Enabled = false;

                txt_sdtKH.Enabled = false;
                txt_diachiKH.Enabled = false;
                Cbb_MKM.Enabled = false;
                btn_Luu.Enabled = true;
                cbb_PhuongThucThanhToan.Enabled = true;
                btn_ThanhToan.Enabled = true;
                btn_TimSDTKH.Enabled = false;
                txt_SDTTK.Enabled = false;
                LoadData(hoaDonSer.Getview());
            }
            else
            {
                // Nếu người dùng bấm vào bảng trống hoặc bảng tiêu đề, hiển thị một thông báo
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadChiTietHoaDon(string idHoaDon)
        {
            // Xóa dữ liệu cũ trong ListView
            listView1.Items.Clear();

            // Lấy danh sách ID sản phẩm chi tiết của hóa đơn có ID là idHoaDon
            int? idhoadonct = HoaDonRepos.GetIdHoaDonToHoaDonCT(idHoaDon);

            // Kiểm tra xem idhoadonct có giá trị hay không
            if (idhoadonct.HasValue)
            {
                // Lấy danh sách chi tiết hóa đơn từ ID sản phẩm chi tiết
                List<int?> danhSachChiTiet = HoaDonRepos.GetIdHoaDonCTToSanPhamCTList(idhoadonct.Value);

                if (danhSachChiTiet != null && danhSachChiTiet.Count > 0)
                {
                    // Duyệt qua danh sách chi tiết và thêm vào ListView
                    int STT = 1;
                    foreach (var sanphamctId in danhSachChiTiet)
                    {
                        // Lấy thông tin sản phẩm từ ID sản phẩm chi tiết
                        int? idsanpham = SanPhamChiTietRepos.GetIdSanPhamSPCT(sanphamctId);
                        int? idmau = SanPhamChiTietRepos.GetIdMauSPCT(sanphamctId);
                        int? idkichthuoc = SanPhamChiTietRepos.GetIdSizeSPCT(sanphamctId);

                        string tensanpham = SanPhamChiTietRepos.GetTenSanPhamById(idsanpham);
                        string tenmau = SanPhamChiTietRepos.GetMauById(idmau);
                        int? size = SanPhamChiTietRepos.GetSizeById(idkichthuoc);
                        int? soluong = HoaDonRepos.GetSoluongByIdHoaDonCT(idhoadonct);
                        double? gia = HoaDonRepos.GetGiaByIdHoaDonCT(idhoadonct);

                        // Tạo một ListViewItem mới
                        ListViewItem item = new ListViewItem(STT.ToString());
                        STT++;

                        // Thêm các sub-items vào ListViewItem
                        item.SubItems.Add(tensanpham);
                        item.SubItems.Add(tenmau);
                        item.SubItems.Add(size.ToString());
                        item.SubItems.Add(soluong.ToString());
                        item.SubItems.Add(gia.ToString());

                        // Thêm ListViewItem vào ListView
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    // Hiển thị thông báo nếu không có dữ liệu
                    MessageBox.Show("Không có dữ liệu chi tiết hóa đơn cho hóa đơn này.");
                }
            }
            else
            {
                // Xử lý trường hợp khi không tìm thấy ID sản phẩm chi tiết
                MessageBox.Show("Không tìm thấy ID sản phẩm chi tiết cho hóa đơn này.");
            }
        }
        private Bitmap GenerateQRCode(string data)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
            return qrCodeImage;



        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData(hoaDonSer.GetSearch1(textBox1.Text));
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Thiết lập font chữ và màu sắc
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);
            System.Drawing.Font contentFont = new System.Drawing.Font("Arial", 12);
            System.Drawing.Brush blackBrush = System.Drawing.Brushes.Black;

            // Thiết lập các khoảng cách và kích thước
            int margin = 50;
            int headerHeight = 30; // Giảm chiều cao tiêu đề để tạo không gian giữa các dòng nhỏ hơn
            int spacing = 10; // Giảm khoảng cách giữa các dòng để tạo không gian giữa chúng nhỏ hơn
            int yPos = margin;

            string maHoaDon = txtHoaDon.Text;
            string sdtKhachHang = txt_sdtKH.Text;
            string phuongThucThanhToan = cbb_PhuongThucThanhToan.Text;
            string maKhuyenMai = Cbb_MKM.Text;
            DateTime ngayTaoHoaDon = dtp_NgayTao.Value;
            string Tenkhachhang = txt_KhachHangMoi.Text;

            // Tiêu đề hóa đơn
            string title = "Hóa Đơn Bán Hàng";
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            e.Graphics.DrawString(title, titleFont, blackBrush, (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += (int)titleSize.Height + spacing;

            // Thông tin hóa đơn
            e.Graphics.DrawString($"Mã Hóa Đơn: {maHoaDon}", contentFont, blackBrush, margin, yPos);
            yPos += headerHeight + spacing; // Thêm khoảng cách giữa các dòng
            e.Graphics.DrawString($"Tên Khách Hàng: {Tenkhachhang}", contentFont, blackBrush, margin, yPos);
            yPos += headerHeight + spacing;
            e.Graphics.DrawString($"Số Điện Thoại Khách Hàng: {sdtKhachHang}", contentFont, blackBrush, margin, yPos);
            yPos += headerHeight + spacing;
            e.Graphics.DrawString($"Phương Thức Thanh Toán: {phuongThucThanhToan}", contentFont, blackBrush, margin, yPos);
            yPos += headerHeight + spacing;
            e.Graphics.DrawString($"Mã Khuyến Mãi: {maKhuyenMai}", contentFont, blackBrush, margin, yPos);
            yPos += headerHeight + spacing;
            e.Graphics.DrawString($"Ngày Tạo Hóa Đơn: {ngayTaoHoaDon.ToString("dd/MM/yyyy")}", contentFont, blackBrush, margin, yPos);
            yPos += headerHeight + spacing;

            // Tiêu đề danh sách sản phẩm
            string productListTitle = "Danh Sách Sản Phẩm";
            SizeF productListTitleSize = e.Graphics.MeasureString(productListTitle, titleFont);
            yPos += spacing;
            e.Graphics.DrawString(productListTitle, titleFont, blackBrush, (e.PageBounds.Width - productListTitleSize.Width) / 2, yPos);
            yPos += (int)productListTitleSize.Height + spacing;

            // Tạo các biến để lưu trữ vị trí của từng cột
            int col1Pos = margin; // Vị trí bắt đầu của cột Tên Sản Phẩm
            int col2Pos = col1Pos + 100; // Vị trí bắt đầu của cột Màu
            int col3Pos = col2Pos + 300; // Vị trí bắt đầu của cột Size
            int col4Pos = col3Pos + 300;  // Vị trí bắt đầu của cột Số Lượng
            int col5Pos = col4Pos + 400; // Vị trí bắt đầu của cột Giá Sản Phẩm
            int currentRow = 0;

            // Lặp qua danh sách sản phẩm và vẽ thông tin của từng sản phẩm
            // Tạo một biến để lưu trữ chiều cao của mỗi dòng
            int rowHeight = headerHeight + spacing;

            // Lặp qua danh sách sản phẩm và vẽ thông tin của từng sản phẩm
            foreach (ListViewItem item in listView1.Items)
            {
                // Lấy thông tin sản phẩm từ các subitems của mỗi item
                string tenSP = item.SubItems[1].Text;
                string mauSP = item.SubItems[2].Text;
                string sizeSP = item.SubItems[3].Text;
                string soLuongSP = item.SubItems[4].Text;
                string giaSP = item.SubItems[5].Text;

                // Vẽ thông tin sản phẩm tại vị trí hàng tương ứng
                e.Graphics.DrawString($"Tên Sản Phẩm {tenSP}", contentFont, blackBrush, margin, yPos + currentRow * rowHeight);
                e.Graphics.DrawString($"Màu {mauSP}", contentFont, blackBrush, col2Pos, yPos + currentRow * rowHeight);
                e.Graphics.DrawString($"Size {sizeSP}", contentFont, blackBrush, col3Pos, yPos + currentRow * rowHeight);
                e.Graphics.DrawString($"Số Lượng{soLuongSP}", contentFont, blackBrush, col4Pos, yPos + currentRow * rowHeight);
                e.Graphics.DrawString($"Giá Sản Phẩm {giaSP}", contentFont, blackBrush, col5Pos, yPos + currentRow * rowHeight);

                // Tăng vị trí hàng
                currentRow++;
            }

            // Tăng vị trí hàng
            yPos += currentRow * rowHeight;
            // Tăng vị trí hàng
            yPos += currentRow * (headerHeight + spacing);

            // Mã QR
            string qrData = txt_TongThanhToan.Text;
            Bitmap qrCodeImage = GenerateQRCode(qrData);
            e.Graphics.DrawImage(qrCodeImage, new PointF(margin, yPos + spacing));
        }

        private void txt_SDTTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
