using DAL.Models;
using DAL.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Servicer
{
    public class MauService
    {
        private MauRepos _respo;

        public MauService()
        {
            _respo = new MauRepos();
        }

        public List<Mau> GetAll(string search)
        {
            return _respo.GetAll(search);
        }
        public string Add(Mau mau)
        {
            if (string.IsNullOrEmpty(mau.Tenmau))
            {
                return "Tên màu không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenmau == mau.Tenmau))
            {
                return "Tên màu đã tồn tại";
            }
            if (_respo.Add(mau))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string Update(Mau mau)
        {
            if (string.IsNullOrEmpty(mau.Tenmau))
            {
                return "Tên màu không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenmau == mau.Tenmau))
            {
                return "Tên màu đã tồn tại";
            }
            if (_respo.Update(mau))
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
