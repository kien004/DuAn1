using DAL.Models;
using DAL.Repositori;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Servicer
{
    public class KichThuocService
    {
        private KichthuocRepos _respo;

        public KichThuocService()
        {
            _respo = new KichthuocRepos();
        }
        public List<Kichthuoc> GetAll(string search)
        {
            return _respo.GetAllKT(search);
        }
        public string Add(Kichthuoc kichthuoc)
        {
            if (_respo.Add(kichthuoc) == true)
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";

            }

        }
        public string Update(Kichthuoc kichthuoc)
        {
            if (_respo.Update(kichthuoc) == true)
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public string Delete(int id)
        {
            if (_respo.Delete(id) == true)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }


    }
}
