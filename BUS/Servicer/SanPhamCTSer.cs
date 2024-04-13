using DAL.Models;
using BUS.Viewmoder;
using DAL.Models;
using DAL.Repositori;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SHOE.Controller.Repositori;

namespace BUS.Services
{
    public class SanPhamCTSer
    {
        SanPhamChiTietRepos _repos = new SanPhamChiTietRepos();
        SanPhamRepos _sprepos = new SanPhamRepos();
        NhanvienRepository _nhanvien = new NhanvienRepository();

        public SanPhamCTSer(SanPhamChiTietRepos repos, SanPhamRepos sprepos)
        {
            _sprepos = sprepos;
            _repos = repos;
        }

        public SanPhamCTSer()
        {
        }
        public List<Sanphamct> GetSizeBySanPhamId(int idSanPham, int idMau)
        {
            return _repos.GetSizeBySanPhamId(idSanPham, idMau);
        }
        public List<Sanphamct> GetMauBySanPhamId(int idSanPham)
        {
            return _repos.GetMauBySanPhamId(idSanPham);
        }
        public Sanphamct GetById(int id)
        {
            return _repos.GetById(id);
        }
        public int GetIdSPCT(int idsp, int idmau, int idkichthuoc)
        {
            return _repos.GetIdSPCT(idsp, idmau, idkichthuoc);
        }

        public int GetMauId(string mau1)
        {
            return _repos.GetMauId(mau1);
        }
        public int GetSizeId(int size)
        {
            return _repos.GetSizeId(size);
        }
        public bool CheckTrum(Sanphamct newProduct)
        {
            // Kiểm tra xem có sản phẩm chi tiết nào trong cơ sở dữ liệu có các thuộc tính giống với sản phẩm chi tiết mới không
            bool isDuplicate = _repos.GetAllSPCT().Any(p =>
                p.IdSanpham == newProduct.IdSanpham &&
                p.IdLoaisanpham == newProduct.IdLoaisanpham &&
                p.IdChatlieu == newProduct.IdChatlieu &&
                p.IdMau == newProduct.IdMau &&
                p.IdKichthuoc == newProduct.IdKichthuoc);


            return isDuplicate;
        }
        public int GetSoLuongTonKho(int idSanPhamCT)
        {
            return _repos.GetSoLuongTonKho(idSanPhamCT);
        }
        public int UpdateSoLuongTonKho(int idSanPhamCT, int soLuongMoi)
        {
            return _repos.UpdateSoLuongTonKho(idSanPhamCT, soLuongMoi);
        }

        public bool CheckTrumSua(int maSPCT, Sanphamct updatedProduct)
        {
            // Lấy danh sách sản phẩm chi tiết trừ sản phẩm chi tiết đang được cập nhật
            var existingProducts = _repos.GetAllSPCT().Where(spct => spct.IdSanphamct != maSPCT);

            // Kiểm tra xem có sản phẩm chi tiết nào khác có thông tin giống với sản phẩm chi tiết đang được cập nhật không
            return existingProducts.Any(spct =>
                spct.IdSanpham == updatedProduct.IdSanpham &&
                spct.IdLoaisanpham == updatedProduct.IdLoaisanpham &&
                spct.IdMau == updatedProduct.IdMau &&
                spct.IdChatlieu == updatedProduct.IdChatlieu &&
                spct.IdKichthuoc == updatedProduct.IdKichthuoc);

        }

        public string AddSPCT(Sanphamct sp)
        {
            if (_repos.AddSPCT(sp) == 2)
            {
                return "Thêm thành công";
            }
            else if (_repos.AddSPCT(sp) == 1)
            {
                return "Thêm thất bại";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public bool AddSPCT_ChatLieu(Chatlieu sp)
        {
            return _repos.AddSPCT_ChatLieu(sp);
        }
        public bool AddSPCT_Mau(Mau sp)
        {
            return _repos.AddSPCT_Mau(sp);
        }
        public bool AddSPCT_Size(Kichthuoc sp)
        {
            return _repos.AddSPCT_Size(sp);
        }
        public List<Sanphamct> GetAllSPCT()
        {
            return _repos.GetAllSPCT().ToList();
        }
        public string GetMauById(int? idSanPham)
        {
            return _repos.GetMauById(idSanPham);
        }
        public int? GetSizeById(int? idKichThuoc)
        {
            return _repos.GetSizeById(idKichThuoc);
        }
        public List<Mau> GetAllSPCT_Mau()
        {
            return _repos.GetAllSPCT_Mau().ToList();
        }
        public List<Loaisanpham> GetAllSPCT_LSP()
        {
            return _repos.GetAllSPCT_LSP().ToList();
        }
        public List<Kichthuoc> GetAllSPCT_KichThuoc()
        {
            return _repos.GetAllSPCT_KichThuoc().ToList();
        }
        public int GetByIdSanPham(int idSanPhamCT, int idSanPham)
        {
            return _repos.GetByIdSanPham(idSanPhamCT, idSanPham);
        }
        public string GetTenSanPhamById(int? idSanPham)
        {
            return _repos.GetTenSanPhamById(idSanPham);
        }
        public int? GetIdSanPhamSPCT(int? id)
        {
            return _repos.GetIdSanPhamSPCT(id);
        }
        public int? GetIdMauSPCT(int? id)
        {
            return _repos.GetIdSanPhamSPCT(id);
        }
        public int? GetIdSizeSPCT(int? id)
        {
            return _repos.GetIdSanPhamSPCT(id);
        }
        public int GetSanPhamId(string mau1)
        {
            return _repos.GetSanPhamId(mau1);
        }
        public List<Chatlieu> GetAllSPCT_ChatLieu()
        {
            return _repos.GetAllSPCT_ChatLieu().ToList();
        }
        public bool DeleteSPCT(int id)
        {
            return (_repos.DeleteSPCT(id));
        }
        public int checkspctcotronghoadon(int id)
        {
            return _repos.checkspctcotronghoadon(id);
        }   

        public int UpdateSPCT(int id, Sanphamct kh)
        {
            return (_repos.UpdateSPCT(id, kh));
        }
        public List<SanPhamCT> Getview()
        {
            var joinData = from sp in _sprepos.GetAllSP()
                           join spct in _repos.GetAllSPCT() on sp.IdSanpham equals spct.IdSanpham
                           join kichthuoc in _repos.GetAllSPCT_KichThuoc() on spct.IdKichthuoc equals kichthuoc.IdKichthuoc
                           join mau in _repos.GetAllSPCT_Mau() on spct.IdMau equals mau.IdMau
                           join lsp in _repos.GetAllSPCT_LSP() on spct.IdLoaisanpham equals lsp.IdLoaisanpham
                           join chatlieu in _repos.GetAllSPCT_ChatLieu() on spct.IdChatlieu equals chatlieu.IdChatlieu
                           join nhanvien in _nhanvien.GetAllNV() on sp.IdNhanvien equals nhanvien.IdNhanvien
                           select new SanPhamCT
                           {
                               IdSanphamct = spct.IdSanphamct,
                               TenSanPham = sp.Tensanpham,
                               LoaiSanPham = lsp.Tenloaisanpham,
                               Mau = mau.Tenmau,
                               KichThuoc = kichthuoc.Size,
                               ChatLieu = chatlieu.Tenchatlieu,
                               Soluong = spct.Soluong,
                               Dongia = spct.Dongia,
                               IdNhanvien = spct.IdNhanvien,
                               TrangThai = spct.Trangthai,
                           };
            return joinData.ToList();
        }
        public List<SanPhamCT> GetSearch(int searchCombobox)
        {
            var joinData = from sp in _sprepos.GetAllSP()
                           join spct in _repos.GetAllSPCT() on sp.IdSanpham equals spct.IdSanpham
                           join kichthuoc in _repos.GetAllSPCT_KichThuoc() on spct.IdKichthuoc equals kichthuoc.IdKichthuoc
                           join mau in _repos.GetAllSPCT_Mau() on spct.IdMau equals mau.IdMau
                           join lsp in _repos.GetAllSPCT_LSP() on spct.IdLoaisanpham equals lsp.IdLoaisanpham
                           join chatlieu in _repos.GetAllSPCT_ChatLieu() on spct.IdChatlieu equals chatlieu.IdChatlieu
                           join nhanvien in _nhanvien.GetAllNV() on sp.IdNhanvien equals nhanvien.IdNhanvien
                           select new SanPhamCT
                           {
                               IdSanphamct = spct.IdSanphamct,
                               TenSanPham = sp.Tensanpham,
                               LoaiSanPham = lsp.Tenloaisanpham,
                               Mau = mau.Tenmau,
                               KichThuoc = kichthuoc.Size,
                               ChatLieu = chatlieu.Tenchatlieu,
                               Soluong = spct.Soluong,
                               Dongia = spct.Dongia,
                               IdNhanvien = spct.IdNhanvien,
                               TrangThai = spct.Trangthai,
                           };

            if (searchCombobox != 0)
            {
                // Chỉ trả về danh sách sản phẩm có kích thước trùng khớp với searchCombobox
                joinData = joinData.Where(c => c.KichThuoc.Equals(searchCombobox));
            }

            // Chuyển đổi và trả về danh sách sản phẩm
            return joinData.ToList();
        }

        public Chatlieu GetById_ChatLieu(string chatlieu)
        {
            return _repos.GetById_ChatLieu(chatlieu);
        }
        public Mau GetById_Mau(string mau)
        {
            return _repos.GetById_Mau(mau);
        }
        public Kichthuoc GetById_Size(int size)
        {
            return _repos.GetById_Size(size);
        }
    }
}
