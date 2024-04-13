using BUS.Viewmoder;
using DAL.Models;
using DAL.Repositori;
using Project_SHOE.Controller.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public class SanPhamSer
    {
        SanPhamRepos _repos = new SanPhamRepos();
        Thuonghieu _thuonghieu = new Thuonghieu();
        NhanvienRepository _nhanvien = new NhanvienRepository();

        public SanPhamSer(SanPhamRepos repos)
        {
            _repos = repos;
        }

        public SanPhamSer()
        {
        }
        public bool CheckDuplicate(string tenSanPham)
        {
            return _repos.CheckDuplicate(tenSanPham);
        }
        public string GetTenSanPhamById(int idSanPham)
        {
            return _repos.GetTenSanPhamById(idSanPham);
        }
        public bool CheckDuplicateForUpdate(string tenSanPham, int maSanPham)
        {
            // Kiểm tra xem tên sản phẩm có tồn tại và không trùng với sản phẩm khác (trừ sản phẩm đang cập nhật) không
            return _repos.CheckDuplicateForUpdate(tenSanPham, maSanPham);
        }
        public int GetSanPhamId(string tenSanPham)
        {
            return _repos.GetSanPhamId(tenSanPham);
        }


        public string AddSP(Sanpham sp)
        {
            if (_repos.AddSP(sp) == 2)
            {
                return "Thêm thành công";
            }
            else if (_repos.AddSP(sp) == 1)
            {
                return "Tên Giày không được để trống";
            }
            else
            {
                return "Thêm thất bại";
            }
        }

        public IEnumerable<Sanpham> GetAllSP()
        {
            return _repos.GetAllSP().ToList();
        }
        public IEnumerable<Thuonghieu> GetAllTH()
        {
            return _repos.GetAllTH().ToList();
        }
        public bool DeleteSP(int id)
        {
            return _repos.DeleteSP(id);
        }
        public Sanpham GetById(int id)
        {
            return _repos.GetById(id);
        }
        public List<Sanpham> GetSearch(string searchText)
        {
            return _repos.GetSearch(searchText);
        }
        public int UpdateSP(int id, Sanpham sp)
        {
            return _repos.UpdateSP(id, sp);
        }
        public List<ThuongHieuSP> Getview()
        {
            var joinData = from SanPham in _repos.GetAllSP()
                           join Thuonghieu in _repos.GetAllTH() on SanPham.IdThuonghieu equals Thuonghieu.IdThuonghieu
                           join nhanvien in _nhanvien.GetAllNV() on SanPham.IdNhanvien equals nhanvien.IdNhanvien
                           select new ThuongHieuSP
                           {
                               IdSanpham = SanPham.IdSanpham,
                               TenSanPham = SanPham.Tensanpham,
                               TenThuongHieu = Thuonghieu.Tenthuonghieu,
                               IdNhanvien = nhanvien.IdNhanvien,
                           };
            return joinData.ToList();
        }
        public List<ThuongHieuSP> GetSearch1(string searchText)
        {
            var joinData = from SanPham in _repos.GetAllSP()
                           join Thuonghieu in _repos.GetAllTH() on SanPham.IdThuonghieu equals Thuonghieu.IdThuonghieu
                           join nhanvien in _nhanvien.GetAllNV() on SanPham.IdNhanvien equals nhanvien.IdNhanvien
                           select new ThuongHieuSP
                           {
                               IdSanpham = SanPham.IdSanpham,
                               TenSanPham = SanPham.Tensanpham,
                               TenThuongHieu = Thuonghieu.Tenthuonghieu,
                               IdNhanvien = nhanvien.IdNhanvien,
                           };
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return joinData.ToList();
            }
            return joinData.Where(c => c.TenSanPham.Contains(searchText)).ToList();
        }
    }
}
