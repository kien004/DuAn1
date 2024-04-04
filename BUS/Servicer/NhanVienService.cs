using DAL.Models;
using Project_SHOE.Controller.IService;
using Project_SHOE.Controller.Repositori;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SHOE.Controller.Servicer
{
    public class NhanVienService : INhanvienService

    {
        private NhanvienRepository _repos;

        public NhanVienService()
        {
            _repos = new NhanvienRepository();
        }
        public int GetIdNhanVien(int sdt)
        {
            return _repos.GetIdNhanVien(sdt);
        }
        public string Add(Nhanvien nv)
        {
            if (_repos.AddNV(nv) == true)
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }



        public List<Nhanvien> GetAll(string search)
        {
            if (search == null)
            {
                return _repos.GetAllNV();
            }
            else
            {
                return _repos.GetAllNV().Where(x => x.Hovaten.Contains(search)).ToList();
            }
        }
        public List<Chucvu> GetChucvus()
        {
            return _repos.GetChucvus();
        }


        public string Remove(Nhanvien nv)
        {
            var clone = _repos.GetAllNV().FirstOrDefault(x => x.IdNhanvien == nv.IdNhanvien);

            if (_repos.RemoveNV(clone) == true)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

        public string Update(Nhanvien nv)
        {

            var clone = _repos.GetAllNV().FirstOrDefault(x => x.IdNhanvien == nv.IdNhanvien);
            clone.IdNhanvien = nv.IdNhanvien;
            clone.Sdt = nv.Sdt;
            clone.Hovaten = nv.Hovaten;
            clone.Matkhau = nv.Matkhau;
            clone.Ngaysinh = nv.Ngaysinh;
            clone.IdChucvu = nv.IdChucvu;
            clone.Diachi = nv.Diachi;
            clone.Gioitinh = nv.Gioitinh;

            clone.Diachi = nv.Diachi;
            if (_repos.UpdateNV(clone) == true)
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
    }
}
