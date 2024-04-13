using BUS.ViewModel;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
    public class TopKhachHangSer
    {
        TopSanPhamRepos _topSanPhamRepos = new TopSanPhamRepos();
     

        public TopKhachHangSer()
        {
        }

        public TopKhachHangSer(TopSanPhamRepos topSanPhamRepos)
        {
            _topSanPhamRepos = topSanPhamRepos;
        }

        public IEnumerable<TopKhachHangModel> GetTopCustomers(DateTime fromDate, DateTime toDate)
        {
            var hoadonList = _topSanPhamRepos.GetAllHoadon();
            var khachhangList = _topSanPhamRepos.GetAllKhachHang();
            var hoadonctList = _topSanPhamRepos.GetAllHoadonct();

            var topCustomers = (from hoadon in hoadonList
                                join khachhang in khachhangList on hoadon.IdKhachhang equals khachhang.IdKhachhang
                                join hoadonct in hoadonctList on hoadon.IdHoadon equals hoadonct.IdHoadon
                                where hoadon.Ngaytao >= fromDate && hoadon.Ngaytao <= toDate // Lọc dữ liệu theo ngày tạo hóa đơn
                                group hoadon by new { khachhang.IdKhachhang, khachhang.Hovaten } into g
                                select new TopKhachHangModel
                                {
                                    Id = g.Key.IdKhachhang,
                                    Name = g.Key.Hovaten,
                                    tongTien = g.Sum(x => x.Tongtien) ?? 0, // Tính tổng số tiền khách hàng đã mua
                                    soLuongMua = g.Count(),// Đếm số lần mua của khách hàng

                                }); // Sắp xếp và lấy top 10

            return topCustomers;
        }


    }
}
