using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Viewmoder
{
    public class SanPhamCT
    {
        public int IdSanphamct { get; set; }
        public int? KichThuoc { get; set; }
        public string? Mau { get; set; }
        public int? Soluong { get; set; }
        public string? ChatLieu { get; set; }
        public string? TenSanPham { get; set; }
        public double? Dongia { get; set; }
        public string? LoaiSanPham { get; set; }
        public int? IdNhanvien { get; set; }
        public string? TrangThai { get; set; }
    }
}
