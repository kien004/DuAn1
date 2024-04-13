using BUS.Viewmoder;
using DAL.Models;
using DAL.Repositori;
using Project_SHOE.Controller.Repositori;
using Project_SHOE.Controller.Servicer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public class HoaDonSer
    {
        KhuyenMaiService khuyenMaiService = new KhuyenMaiService();
        KhachHangService khachHangService =  new KhachHangService();
        HoaDonRepos _repos = new HoaDonRepos();
        public HoaDonSer()
        {

        }
        public HoaDonSer(HoaDonRepos repos)
        {
            _repos = repos;
        }
        public bool AddHoaDon(Hoadon hoadon)
        {
            return _repos.AddHoaDon(hoadon);
        }
        public bool CheckExistAndMatchIdHoadon(string idHoaDon)
        {
            return _repos.CheckExistAndMatchIdHoadon(idHoaDon);
        }

        public bool DeleteHoaDon(int id)
        {
            return _repos.DeleteHoaDon(id);
        }
        public bool UpdateHoaDon(string id)
        {
            return _repos.UpdateHoaDon(id);
        }
        public IEnumerable<Hoadon> GetALLHoadons()
        {
            return _repos.GetALLHoadons().ToList();
        }
        public List<HoaDon> Getview()
        {
            var joinData = from hoadon in _repos.GetALLHoadons()
                           join khachhang in khachHangService.GetAllKH() on hoadon.IdKhachhang equals khachhang.IdKhachhang
                           select new HoaDon
                           {
                               IdHoaDon = hoadon.IdHoadon,
                               IdKhuyenMai = hoadon.IdKhuyenmai,
                               NgayTao = hoadon.Ngaytao.Value.Date,
                               TongTien = hoadon.Tongtien.Value,
                               SoDienThoai = khachhang.Sdt,
                               idnhanvien = hoadon.IdNhanvien.Value,
                               PhuongThucThanhToan = hoadon.Phuongthucthanhtoan,
                               TrangThai = hoadon.Trangthai,
                           };
            return joinData.ToList();
        }
        public List<HoaDon> GetSearch1(string searchText)
        {
            var joinData = from hoadon in _repos.GetALLHoadons()
                           join khachhang in khachHangService.GetAllKH() on hoadon.IdKhachhang equals khachhang.IdKhachhang
                           select new HoaDon
                           {
                               IdHoaDon = hoadon.IdHoadon,
                               IdKhuyenMai = hoadon.IdKhuyenmai,
                               NgayTao = hoadon.Ngaytao.Value.Date,
                               TongTien = hoadon.Tongtien.Value,
                               SoDienThoai = khachhang.Sdt,
                               idnhanvien = hoadon.IdNhanvien.Value,
                               PhuongThucThanhToan = hoadon.Phuongthucthanhtoan,
                               TrangThai = hoadon.Trangthai,
                           };
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return joinData.ToList();
            }
            return joinData.Where(c => c.SoDienThoai.Contains(searchText)).ToList();
        }
    }
}
