using BUS.Viewmoder;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Project_SHOE.Controller.IService;
using Project_SHOE.Controller.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SHOE.Controller.Servicer
{
    public class KhachHangService : IKhachHangService
    {
        private KhachHangRepository _repos;
        public KhachHangService()
        {
            _repos = new KhachHangRepository();
        }
        public string Add(Khachhang kh)
        {
            if (_repos.AddKH(kh) == true)
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";

            }
        }
        public List<Khachhang> GetAll(string search)
        {
            if (search == null)
            {
                return _repos.GetAllKH();

            }
            else
            {
                return _repos.GetAllKH().Where(x => x.Sdt.Contains(search)).ToList();
            }
        }
        public IEnumerable<Khachhang> GetAllKH()
        {
            return _repos.GetAllKH1().ToList();
        }

        public string Remove(Khachhang kh)
        {
            var clone = _repos.GetAllKH().FirstOrDefault(x => x.IdKhachhang == kh.IdKhachhang);
            if (_repos.RemoveKH(clone) == true)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

        public string Update(Khachhang kh)
        {
            var clone = _repos.GetAllKH().FirstOrDefault(x => x.IdKhachhang == kh.IdKhachhang);
            clone.IdKhachhang = kh.IdKhachhang;
            clone.Sdt = kh.Sdt;
            clone.Diachi = kh.Diachi;
            clone.Hovaten = kh.Hovaten;
            if (_repos.UpdateKH(clone) == true)
            {
                return "Sửa Thành Công";
            }
            else { return "Sửa Thất Bại"; }

        }
        public List<Khachhang> GetSearch1(string searchText)
        {
            var searchTextLower = searchText.ToLower(); // Chuyển đổi chuỗi tìm kiếm về chữ thường

            var joinData = from kh in _repos.GetAllKH()
                           select new Khachhang
                           {
                               IdKhachhang = kh.IdKhachhang,
                               Hovaten = kh.Hovaten,
                               Sdt = kh.Sdt,
                               Diachi = kh.Diachi,
                           };

            if (string.IsNullOrWhiteSpace(searchText))
            {
                return joinData.ToList();
            }

            // Chuyển đổi dữ liệu trong cơ sở dữ liệu về chữ thường và thực hiện tìm kiếm
            return joinData.Where(c => c.Hovaten.ToLower().Contains(searchTextLower)).ToList();
        }
        public List<Khachhang> Getview()
        {
            var joinData = from Khachhang in _repos.GetAllKH()
                           select new Khachhang
                           {
                               IdKhachhang = Khachhang.IdKhachhang,
                               Hovaten = Khachhang.Hovaten,
                               Sdt = Khachhang.Sdt,
                               Diachi = Khachhang.Diachi,
                           };
            return joinData.ToList();
        }
    }
}
