using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopSanPhamRepos : ITopSanPhamRepos
    {
        DBContext _context = new DBContext();

        public TopSanPhamRepos()
        {
        }

        public TopSanPhamRepos(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Hoadon> GetAllHoadon()
        {
            return _context.Hoadons.ToList();
        }
        public IEnumerable<Khachhang> GetAllKhachHang()
        {
            return _context.Khachhangs.ToList();
        }

        public IEnumerable<Hoadonct> GetAllHoadonct()
        {
            return _context.Hoadoncts.ToList();
        }

        public IEnumerable<Sanpham> GetAllSanPham()
        {
           return _context.Sanphams.ToList();
        }

        public IEnumerable<Sanphamct> GetAllSanPhamct()
        {
            return _context.Sanphamcts.ToList();
        }
        public IEnumerable<Thuonghieu> GetAllThuonghieu()
        {
            return _context.Thuonghieus.ToList();
        }
    }
}
