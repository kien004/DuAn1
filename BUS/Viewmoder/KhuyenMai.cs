using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Viewmoder
{
    public class KhuyenMai
    {
        public string IdKhuyenmai { get; set; }
        public DateOnly? Ngaytao { get; set; }
        public DateOnly? Ngayhethan { get; set; }
        public DateOnly? NgayBatDau { get; set; }
        public string Tenkhuyenmai { get; set; }
        public int IdKhachHang { get; set; }
        public string Trangthai { get; set; }
        public decimal Sophantramkhuyenmai { get; set; }
        public int Soluong { get; set; }
        public virtual Khachhang IdKhachHangNavigation { get; set; } = null!;
    }
}
