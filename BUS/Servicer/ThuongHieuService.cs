using DAL.Models;
using DAL.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Servicer
{
    public class ThuongHieuService
    {
        private ThuonghieuRepos _respo;

        public ThuongHieuService()
        {
            _respo = new ThuonghieuRepos();
        }

        public List<Thuonghieu> GetAll(string search)
        {
            return _respo.GetAll(search);
        }
        public string Add(Thuonghieu thuongHieu)
        {
            if (string.IsNullOrEmpty(thuongHieu.Tenthuonghieu))
            {
                return "Tên thương hiệu không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenthuonghieu == thuongHieu.Tenthuonghieu))
            {
                return "Tên thương hiệu đã tồn tại";
            }
            if (_respo.Add(thuongHieu))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string Update(Thuonghieu thuongHieu)
        {
            if (string.IsNullOrEmpty(thuongHieu.Tenthuonghieu))
            {
                return "Tên thương hiệu không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenthuonghieu == thuongHieu.Tenthuonghieu))
            {
                return "Tên thương hiệu đã tồn tại";
            }
            if (_respo.Update(thuongHieu))
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
