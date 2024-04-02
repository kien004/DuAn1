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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml;
using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;

namespace PRL.Views
{
    public partial class HoaDon : Form
    {
        HashSet<string> addedColors = new HashSet<string>();
        HashSet<int?> addedSizes = new HashSet<int?>();
        HashSet<int> addedIds = new HashSet<int>();
        IHoaDonCTRepos HoaDonCTRepos = new IHoaDonCTRepos();
        HoaDonRepos HoaDonRepos = new HoaDonRepos();
        SanPhamCTSer SanPhamChiTietRepos = new SanPhamCTSer();
        SanPhamSer SanPhamRepos = new SanPhamSer();
        KhachHangRepository KhachHangRepository = new KhachHangRepository();
        KhuyenMaiService KhuyenMaiService = new KhuyenMaiService();

        public HoaDon()
        {
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
            cbb_KieuKH.Items.Add("Khách Lẻ");
            cbb_KieuKH.Items.Add("Thành Viên");
            foreach (var sanPhamChiTiet in SanPhamChiTietRepos.GetAllSPCT())
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
            foreach (var i in KhachHangRepository.GetAllKH())
            {
                cbb_KhachHang.Items.Add(i.Hovaten);
            }
            foreach (var i in KhuyenMaiService.GetALLKhuyenMai())
            {
                Cbb_MKM.Items.Add(i.IdKhuyenmai);
            }
            txt_KhachHangMoi.Enabled = false;
            cbb_KhachHang.Enabled = false;
            txt_sdtKH.Enabled = false;
            btn_TimSDTKH.Enabled = false;
            dtp_NgayTao.Enabled = false;
            txt_GiaSP.Enabled = false;
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
            txt_MaKhuyenMai.Enabled = false;
            Cbb_MKM.Enabled = false;
            txt_KhachHangMoi.KeyPress += txt_KhachHangMoi_KeyPress;
            txt_sdtKH.KeyPress += txt_sdtKH_KeyPress;
            txt_SoLuongSP.KeyPress += txt_sdtKH_KeyPress;
            txt_MaKhuyenMai.KeyPress += txt_MaKhuyenMai_KeyPress;
            cbb_KhachHang.KeyDown += comboBox1_KeyDown;
            cbb_KhachHang.KeyPress += comboBox1_KeyPress;
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


        private void cbb_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem combobox có dữ liệu nào hay không
            if (cbb_KhachHang.SelectedIndex >= 0 && cbb_KhachHang.SelectedIndex < KhachHangRepository.GetAllKH().Count)
            {
                txt_sdtKH.Text = KhachHangRepository.GetAllKH().ElementAt(cbb_KhachHang.SelectedIndex).Sdt;
                txt_diachiKH.Text = KhachHangRepository.GetAllKH().ElementAt(cbb_KhachHang.SelectedIndex).Diachi;
            }
            else
            {
                // Hiển thị thông báo hoặc xử lý theo ý của bạn khi không có dữ liệu trong combobox
                MessageBox.Show("Không có dữ liệu khách hàng để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cbb_KieuKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_KieuKH.Text == "Khách Lẻ")
            {
                // Các thay đổi khi chọn Khách Lẻ
                txt_sdtKH.Enabled = true;
                txt_diachiKH.Enabled = true;
                cbb_KhachHang.Enabled = false;
                txt_KhachHangMoi.Enabled = true;
                btn_TimSDTKH.Enabled = false;
                txt_MaKhuyenMai.Enabled = false;
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
                cbb_KhachHang.Enabled = true;
                btn_TimSDTKH.Enabled = true;
                txt_KhachHangMoi.Enabled = false;
                txt_MaKhuyenMai.Enabled = false;
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
            cbb_KhachHang.Enabled = false;
            btn_TimSDTKH.Enabled = false;
            txt_KhachHangMoi.Enabled = false;
            txt_MaKhuyenMai.Enabled = false;
            txt_SDTTK.Enabled = false;
            cbb_SanPham.Enabled = false;
        }

        // Phương thức để xoá dữ liệu trong các TextBox và ComboBox
        private void ResetCustomerData()
        {
            txt_sdtKH.Text = "";
            txt_diachiKH.Text = "";
            cbb_KhachHang.SelectedIndex = -1;
            txt_KhachHangMoi.Text = "";
            txt_MaKhuyenMai.Text = "";
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

            // Hiển thị hộp thoại xác nhận
            DialogResult confirmation = MessageBox.Show("Bạn có chắc muốn thêm khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng xác nhận muốn thêm
            if (confirmation == DialogResult.Yes)
            {
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
                // Thêm khách hàng vào danh sách và cập nhật combobox
                if (result)
                {
                    MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sau khi thêm thành công, làm mới các TextBox và cập nhật danh sách khách hàng
                    ClearTextBoxes();
                    cbb_KhachHang.Items.Clear(); // Xoá tất cả các mục trong combobox trước khi cập nhật
                    foreach (var i in KhachHangRepository.GetAllKH())
                    {
                        cbb_KhachHang.Items.Add(i.Hovaten);
                    }
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            cbb_KhachHang.ResetText();
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
            cbb_KhachHang.Text = customer.Hovaten;
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

                // Lấy tên sản phẩm từ ComboBox sản phẩm
                string tenSanPham = cbb_SanPham.SelectedItem?.ToString();

                // Lấy ID sản phẩm và ID màu từ tên sản phẩm và tên màu
                int? idSanPham = null;
                int? idMau = null;
                if (!string.IsNullOrWhiteSpace(selectedMau) && !string.IsNullOrWhiteSpace(tenSanPham))
                {
                    idSanPham = SanPhamChiTietRepos.GetSanPhamId(tenSanPham);
                    idMau = SanPhamChiTietRepos.GetMauId(selectedMau);
                }

                // Kiểm tra nếu cả idSanPham và idMau có giá trị
                if (idSanPham.HasValue && idMau.HasValue)
                {
                    // Lọc và thêm các kích thước có trong sản phẩm và màu đã chọn
                    foreach (var sanPhamChiTiet in SanPhamChiTietRepos.GetSizeBySanPhamId(idSanPham.Value, idMau.Value))
                    {
                        int idSize = sanPhamChiTiet.IdKichthuoc.Value;
                        int? size = SanPhamChiTietRepos.GetSizeById(idSize);
                        if (size.HasValue)
                        {
                            cbb_SizeSP.Items.Add(size.Value);
                        }
                    }
                }

                // Lưu lại màu được chọn mới vào biến previousSelectedMau
                previousSelectedMau = selectedMau;
            }

            // Ẩn ComboBox kích thước nếu không có sản phẩm nào hoặc không có màu nào được chọn
            cbb_SizeSP.Enabled = cbb_SizeSP.Items.Count > 0;
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

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thêm hóa đơn
            DialogResult confirmation = MessageBox.Show("Bạn có chắc muốn thêm hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng xác nhận muốn thêm
            if (confirmation == DialogResult.Yes)
            {
                var hoadon = new Hoadon();

                // Lấy thông tin khách hàng từ ComboBox và TextBox
                string tenKhachHang = cbb_KhachHang.Text;
                string sdtKhachHang = txt_sdtKH.Text;

                // Kiểm tra xem loại khách hàng là Khách Lẻ hay Thành Viên
                if (cbb_KieuKH.Text == "Khách Lẻ")
                {
                    // Nếu là Khách Lẻ, tự động thêm mới khách hàng
                    btn_ThemKH_Click();
                    return;
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

                // Lấy ngày tạo từ DateTimePicker
                DateOnly ngayTao = DateOnly.FromDateTime(dtp_NgayTao.Value);

                // Gán giá trị cho hóa đơn
                hoadon.IdKhachhang = idKhachHang;
                hoadon.NgayTao = ngayTao;

                if (string.IsNullOrEmpty(txt_TongTienHang.Text) || string.IsNullOrEmpty(txt_TongThanhToan.Text))
                {
                    MessageBox.Show("Tổng Tiền Hàng hoặc Tổng Thanh Toán đã trống. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lấy mã khuyến mãi từ TextBox
                string idKhuyenMai = txt_MaKhuyenMai.Text.Trim();
                if (string.IsNullOrWhiteSpace(idKhuyenMai))
                {
                    hoadon.IdKhuyenmai = null;
                }
                else
                {
                    // Gọi phương thức UpdateSoLuongKhuyenMai từ KhuyenMaiService
                    string khuyenmaiStatus = KhuyenMaiService.UpdateSoLuongKhuyenMai(idKhuyenMai);
                    // Kiểm tra kết quả trả về từ phương thức và xử lý tương ứng
                    if (khuyenmaiStatus == "Áp Dụng Khuyến Mại Thành Công")
                    {
                        hoadon.IdKhuyenmai = idKhuyenMai;
                    }
                    else
                    {
                        // Hiển thị thông báo cho người dùng
                        MessageBox.Show(khuyenmaiStatus, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Để ngăn người dùng tiếp tục quá trình lưu hóa đơn
                    }
                }
                // Chuyển đổi giá trị từ string sang float cho tổng tiền
                if (!float.TryParse(txt_TongThanhToan.Text, out float tongThanhToan))
                {
                    MessageBox.Show("Giá trị tổng thanh toán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                hoadon.Tongtien = tongThanhToan;

                // Thêm hóa đơn vào danh sách
                HoaDonRepos.AddHoaDon(hoadon);

                // Lấy id hóa đơn vừa thêm
                int idHoaDon = hoadon.IdHoadon;

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
                btn_InHoaDon.Enabled = true;
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

            //Thêm sản phẩm vào danh sách
            ListViewItem lv1 = new ListViewItem(stt.ToString());
            lv1.SubItems.Add(cbb_SanPham.Text);
            lv1.SubItems.Add(cbb_mauSP.Text);
            lv1.SubItems.Add(cbb_SizeSP.Text);
            lv1.SubItems.Add(txt_SoLuongSP.Text);
            lv1.SubItems.Add(txt_GiaSP.Text);
            listView1.Items.Add(lv1);

            // Tăng biến STT lên 1 để sử dụng cho sản phẩm tiếp theo
            stt++;
            CapNhatGiaTriTongTien();
            btn_Luu.Enabled = true;
            ResetSP();
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
                int soLuong;

                if (decimal.TryParse(item.SubItems[5].Text, out donGia) && int.TryParse(item.SubItems[4].Text, out soLuong))
                {
                    tongTienHang += donGia * soLuong;
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
        private void capnhattienkhachphaitra()
        {
            decimal tienkhachtra;

            decimal tienkhachphaitra = decimal.Parse( txt_TongThanhToan.Text);
            if (!decimal.TryParse(textBox1.Text, out tienkhachtra))
            {
                tienkhachphaitra = 0;
            }

            decimal tongThanhToan =  tienkhachphaitra - tienkhachtra;

            textBox1.Text = tienkhachtra.ToString();
            textBox2.Text = tongThanhToan.ToString();
        }
        private void txt_TongTienHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ChietKhau_TextChanged(object sender, EventArgs e)
        {
            CapNhatGiaTriTongTien();
        }

        private void txt_TongThanhToan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_XoaSP_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy giá trị của mục được chọn để trừ đi từ tổng giá trị
                float giaCanTru = float.Parse(listView1.SelectedItems[0].SubItems[5].Text);

                // Xoá mục được chọn từ ListView
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);

                // Cập nhật lại tổng giá trị
                float tongGia = 0;
                foreach (ListViewItem item in listView1.Items)
                {
                    tongGia += float.Parse(item.SubItems[5].Text);
                }
                txt_TongTienHang.Text = tongGia.ToString();
                CapNhatGiaTriTongTien();
                // Vô hiệu hóa nút Xoá nếu không còn mục được chọn
                txt_XoaSP.Enabled = false;
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

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
          



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
            txt_MaKhuyenMai.Text = maKhuyenMai;

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
                if (khuyenMai.Ngayhethan < DateOnly.FromDateTime(DateTime.Today))
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
                    txt_MaKhuyenMai.Enabled = false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            capnhattienkhachphaitra();
        }
    }
}
