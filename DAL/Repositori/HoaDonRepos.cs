using DAL.Context;
using DAL.IRepository;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class HoaDonRepos : IHoaDonRepos
    {
        DBContext _Context = new DBContext();
        SanPhamChiTietRepos SanPhamChiTietRepos = new SanPhamChiTietRepos();
        public HoaDonRepos()
        {

        }
        public HoaDonRepos(DBContext context)
        {
            _Context = context;
        }
        public bool AddHoaDon(Hoadon hoadon)
        {
            _Context.Hoadons.Add(hoadon);
            _Context.SaveChanges();
            return true;
        }
        public Hoadon GetHoadonchuathanhtoan()
        {
            return _Context.Hoadons.FirstOrDefault(x => x.Trangthai == "Chưa Thanh Toán");
        }
        public IEnumerable<Hoadon> GetALLHoadons()
        {
            return _Context.Hoadons.ToList();
        }
        // Phương thức để cập nhật trạng thái của hóa đơn thành "Đã Thanh Toán"
        public bool CapNhatTrangThaiHoaDon(string idHoaDon, string pttt, string trangThaiMoi)
        {
            var hoaDon = _Context.Hoadons.FirstOrDefault(x => x.IdHoadon == idHoaDon);

            if (hoaDon != null)
            {
                hoaDon.Phuongthucthanhtoan = pttt;
                hoaDon.Trangthai = trangThaiMoi;
                _Context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true; // Trả về true nếu cập nhật thành công
            }
            else
            {
                return false; // Trả về false nếu hóa đơn không tồn tại
            }
        }
        public int GetIdHoaDonToHoaDonCT(string id)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _Context.Hoadoncts.FirstOrDefault(kh => kh.IdHoadon == id);

            if (khachhang != null)
            {
                return khachhang.IdHoadonct;
            }
            else
            {
                return -1;
            }
        }
        public int? GetIdHoaDonCTToSanPhamCT(int? id)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _Context.Hoadoncts.FirstOrDefault(kh => kh.IdHoadonct == id);

            if (khachhang != null)
            {
                return khachhang.IdSanphamct;
            }
            else
            {
                return -1;
            }
        }
        public List<int?> GetIdHoaDonCTToSanPhamCTList(int id)
        {
            // Tìm kiếm chi tiết hóa đơn dựa trên ID
            var hoadonct = _Context.Hoadoncts.FirstOrDefault(h => h.IdHoadonct == id);

            if (hoadonct != null)
            {
                // Trả về một danh sách chứa ID sản phẩm chi tiết
                return new List<int?> { hoadonct.IdSanphamct };
            }
            else
            {
                // Trả về danh sách rỗng nếu không tìm thấy chi tiết hóa đơn
                return new List<int?>();
            }
        }

        public int? GetSoluongByIdHoaDonCT(int? id)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _Context.Hoadoncts.FirstOrDefault(kh => kh.IdHoadonct == id);

            if (khachhang != null)
            {
                return khachhang.Soluong;
            }
            else
            {
                return -1;
            }
        }
        public double? GetGiaByIdHoaDonCT(int? id)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _Context.Hoadoncts.FirstOrDefault(kh => kh.IdHoadonct == id);

            if (khachhang != null)
            {
                return khachhang.Giasp;
            }
            else
            {
                return -1;
            }
        }
        public bool CheckExistAndMatchIdHoadon(string idHoaDon)
        {
            var hoaDon = _Context.Hoadons.FirstOrDefault(x => x.IdHoadon == idHoaDon);
            if (hoaDon != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool XoaVaCapNhatChiTietHoaDon(string idHoaDon, List<Hoadonct> danhSachChiTietMoi)
        {
            // Bắt đầu transaction
            using (var transaction = _Context.Database.BeginTransaction())
            {
                try
                {
                    // Lấy danh sách sản phẩm chi tiết cũ của hóa đơn
                    var chiTietHoaDonCu = _Context.Hoadoncts.Where(ct => ct.IdHoadon == idHoaDon).ToList();
                    if (chiTietHoaDonCu.Any())
                    {
                        // Cập nhật lại số lượng sản phẩm chi tiết cũ
                        foreach (var chiTiet in chiTietHoaDonCu)
                        {
                            var chiTietMoi = _Context.Sanphamcts.FirstOrDefault(ct => ct.IdSanphamct == chiTiet.IdSanphamct);
                            if (chiTietMoi != null)
                            {
                                chiTietMoi.Soluong += chiTiet.Soluong; // Cập nhật số lượng mới
                            }
                        }
                    }

                    // Xóa các sản phẩm chi tiết của hóa đơn hiện tại
                    _Context.Hoadoncts.RemoveRange(chiTietHoaDonCu);

                    // Thêm mới các sản phẩm chi tiết vào hóa đơn
                    foreach (var chiTiet in danhSachChiTietMoi)
                    {
                        _Context.Hoadoncts.Add(chiTiet);
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _Context.SaveChanges();

                    transaction.Commit(); // Commit transaction nếu không có lỗi xảy ra
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback(); // Rollback transaction nếu có lỗi xảy ra
                    return false;
                }
            }
        }

        public bool UpdateHoaDon(string id)
        {
            try
            {
                var exist = _Context.Hoadons.Find(id);
                exist.Trangthai = "hoá Đơn Chưa Có Sản Phẩm";
                _Context.Hoadons.Update(exist);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteHoaDon(int id)
        {
            try
            {
                var exist = _Context.Hoadons.Find(id);

                _Context.Hoadons.Remove(exist);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Hoadon> GetHoadonsChuaThanhToanNgayHienTai()
        {
            DateTime homNay = DateTime.Today;
            return _Context.Hoadons.Where(x => x.Trangthai == "Chưa Thanh Toán" && x.Ngaytao.Value.Date == homNay.Date).ToList();
        }

        public IEnumerable<Hoadon> TimKiemHoaDonTheoIdKhachHang(int idKhachHang)
        {
            return _Context.Hoadons.Where(x => x.IdKhachhang == idKhachHang).ToList();
        }

    }
}
