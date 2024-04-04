using DAL.Models;
using DAL.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Servicer
{
    public class ChatlieuService
    {
        private ChatlieuRepos _respo;

        public ChatlieuService()
        {
            _respo = new ChatlieuRepos();
        }

        public List<Chatlieu> GetAll(string search)
        {
            return _respo.GetAll(search);
        }
        public string Add(Chatlieu chatlieu)
        {
            if (string.IsNullOrEmpty(chatlieu.Tenchatlieu))
            {
                return "Tên chất liệu không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenchatlieu == chatlieu.Tenchatlieu))
            {
                return "Tên chất liệu đã tồn tại";
            }
            if (_respo.Add(chatlieu))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string Update(Chatlieu chatlieu)
        {
            if (string.IsNullOrEmpty(chatlieu.Tenchatlieu))
            {
                return "Tên chất liệu không được để trống";
            }
            if (_respo.GetAll(null).Any(x => x.Tenchatlieu == chatlieu.Tenchatlieu))
            {
                return "Tên chất liệu đã tồn tại";
            }
            if (_respo.Update(chatlieu))
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
