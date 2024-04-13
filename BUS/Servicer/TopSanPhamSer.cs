using System;
using System.Collections.Generic;
using System.Linq;
using DAL.IRepositories;
using BUS.ViewModel;
using DAL.Repositories;
using DAL.Models;

namespace BUS.Services
{
    public class TopSanPhamService
    {
        TopSanPhamRepos _topSanPhamRepos = new TopSanPhamRepos();
        public TopSanPhamService()
        {
        }
        public TopSanPhamService(TopSanPhamRepos topSanPhamRepos)
        {
            _topSanPhamRepos = topSanPhamRepos;
        }

        public IEnumerable<TopSanPhamModel> GetTopSellingProducts(DateTime fromDate, DateTime toDate)
        {
            var hoadonctList = _topSanPhamRepos.GetAllHoadonct();
            var sanphamctList = _topSanPhamRepos.GetAllSanPhamct();
            var sanphamList = _topSanPhamRepos.GetAllSanPham();
            var thuonghieuList = _topSanPhamRepos.GetAllThuonghieu(); // Lấy danh sách các thương hiệu

            var topProducts = (from sanphamct in sanphamctList
                              join sanpham in sanphamList on sanphamct.IdSanpham equals sanpham.IdSanpham
                              join thuonghieu in thuonghieuList on sanpham.IdThuonghieu equals thuonghieu.IdThuonghieu // Thêm join với bảng THUONGHIEU
                              join hoadonct in hoadonctList on sanphamct.IdSanphamct equals hoadonct.IdSanphamct
                              join hoadon in _topSanPhamRepos.GetAllHoadon() on hoadonct.IdHoadon equals hoadon.IdHoadon
                              where hoadon.Ngaytao >= fromDate && hoadon.Ngaytao <= toDate // Lọc dữ liệu theo ngày tạo hóa đơn
                              group new { sanphamct, sanpham, hoadonct, thuonghieu } by new { sanpham.IdSanpham, sanpham.Tensanpham, thuonghieu.Tenthuonghieu } into g
                              select new TopSanPhamModel
                              {
                                  idSP = g.Key.IdSanpham,
                                  nameSP = g.Key.Tensanpham,
                                  soLuong = g.Sum(x => x.hoadonct.Soluong ?? 0),
                                  tongTien = g.Sum(x => x.hoadonct.Giasp * (x.hoadonct.Soluong ?? 0)), // Tính tổng doanh thu từ tất cả sản phẩm chi tiết
                                  TrangThai = GetProductStatus(g.Sum(x => x.sanphamct.Soluong ?? 0)), // Sử dụng số lượng tồn kho để xác định trạng thái
                                  TenThuongHieu = g.Key.Tenthuonghieu // Thiết lập tên thương hiệu
                              }) ;

            return topProducts;
        }



        private string GetProductStatus(int quantity)
        {
            if (quantity > 0)
            {
                return "Còn hàng";
            }
            else
            {
                return "Hết hàng";
            }
        }
        
    }
}
