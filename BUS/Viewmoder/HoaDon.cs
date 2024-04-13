using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Viewmoder
{
    public class HoaDon
    {
        public string IdHoaDon {  get; set; }
        public DateTime NgayTao {  get; set; }
        public double? TongTien {  get; set; }
        public string SoDienThoai { get; set; }
        public int idnhanvien {  get; set; }
        public string PhuongThucThanhToan {  get; set; }
        public string IdKhuyenMai { get; set; }
        public string TrangThai { get; set; }
        public virtual Khuyenmai IdKhuyenMaiNavigation { get; set; } = null!;
        public virtual Khachhang IdKhachHangNavigation { get; set; } = null!;
        public virtual Nhanvien IdNhanVienNavigation { get; set; } = null!;
    }
}
