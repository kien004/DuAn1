using DAL.Models;
using DAL.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Servicer
{
    public class LoaiSanPhamService
    {
        private LoaisanphamRepos _respo;

        public LoaiSanPhamService()
        {
            _respo = new LoaisanphamRepos();
        }

        public List<Loaisanpham> GetAll(string search)
        {
            return _respo.GetAll(search);
        }
        public string Add(Loaisanpham loaiSanPham)
        {
            if (string.IsNullOrEmpty(loaiSanPham.Tenloaisanpham))
            {
                return "Tên loại sản phẩm không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenloaisanpham == loaiSanPham.Tenloaisanpham))
            {
                return "Tên loại sản phẩm đã tồn tại";
            }
            if (_respo.Add(loaiSanPham))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string Update(Loaisanpham loaiSanPham)
        {
            if (string.IsNullOrEmpty(loaiSanPham.Tenloaisanpham))
            {
                return "Tên loại sản phẩm không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenloaisanpham == loaiSanPham.Tenloaisanpham))
            {
                return "Tên loại sản phẩm đã tồn tại";
            }
            if (_respo.Update(loaiSanPham))
            {
                return "Sửa thành công";
            }
            return "Sửa thất bại";
        }
        public string Delete(int id)
        {
            if (_respo.Delete(id))
            {
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }
    }
}
