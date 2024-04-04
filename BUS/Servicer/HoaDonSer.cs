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
        public bool DeleteHoaDon(int id)
        {
            return _repos.DeleteHoaDon(id);
        }
        public bool UpdateHoaDon(int id)
        {
            return _repos.UpdateHoaDon(id);
        }
        public IEnumerable<Hoadon> GetALLHoadons()
        {
            return _repos.GetALLHoadons().ToList();
        }
        public List<HoaDon> Getview()
        {
            var joinData = from Khachhang in khachHangService.GetAllKH()
                           join HoaDon1 in _repos.GetALLHoadons() on Khachhang.IdKhachhang equals HoaDon1.IdKhachhang
                           join Khuyenmai in khuyenMaiService.GetALLKhuyenMai() on HoaDon1.IdKhuyenmai equals Khuyenmai.IdKhuyenmai
                           select new HoaDon
                           {
                               IdHoaDon = HoaDon1.IdHoadon,
                               NgayTao = HoaDon1.Ngaytao,
                               TongTien = HoaDon1.Tongtien,
                               TenKhachHang = Khachhang.Hovaten,
                               SoDienThoai = Khachhang.Sdt,
                               DiaChi = Khachhang.Diachi,
                               IdKhuyenMai = Khuyenmai.IdKhuyenmai,
                               TrangThai = HoaDon1.Trangthai,
                           };
            return joinData.ToList();
        }
    }
}
