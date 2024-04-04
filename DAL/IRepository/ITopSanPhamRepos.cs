using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface ITopSanPhamRepos
    {
        public IEnumerable<Khachhang> GetAllKhachHang();
        public IEnumerable<Sanpham> GetAllSanPham();
        public IEnumerable<Sanphamct> GetAllSanPhamct();
        public IEnumerable<Hoadon> GetAllHoadon();
        public IEnumerable<Hoadonct> GetAllHoadonct();
        public IEnumerable<Thuonghieu> GetAllThuonghieu();
    }
}
