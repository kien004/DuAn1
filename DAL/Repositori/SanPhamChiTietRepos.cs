using DAL.Context;
using DAL.IRepository;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class SanPhamChiTietRepos
    {
        DBContext _Contex = new DBContext();

        public SanPhamChiTietRepos(DBContext contex)
        {
            _Contex = contex;
        }

        public SanPhamChiTietRepos()
        {
        }

        public List<Sanphamct> GetMauBySanPhamId(int idSanPham)
        {
            return _Contex.Sanphamcts.Where(spct => spct.IdSanpham == idSanPham).ToList();
        }
        public List<Sanphamct> GetSizeBySanPhamId(int idSanPham, int idMau)
        {
            return _Contex.Sanphamcts.Where(spct => spct.IdSanpham == idSanPham && spct.IdMau == idMau).ToList();
        }

        public int AddSPCT(Sanphamct spct)
        {
            try
            {
                if (Convert.ToString(spct.IdLoaisanpham) == "" || Convert.ToString(spct.IdMau) == "" || Convert.ToString(spct.IdKichthuoc) == "" || Convert.ToString(spct.IdLoaisanpham) == "")
                {
                    return 1;
                }
                else
                {
                    _Contex.Sanphamcts.Add(spct);
                    _Contex.SaveChanges();
                    return 2;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public bool AddSPCT_ChatLieu(Chatlieu sp)
        {
            try
            {

                _Contex.Chatlieus.Add(sp);
                _Contex.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public int GetIdSPCT(int idsp, int idmau, int idkichthuoc)
        {
            // Tìm kiếm IdSanphamct dựa trên id của sản phẩm, màu và kích thước
            var sanPhamCT = _Contex.Sanphamcts.FirstOrDefault(spct => spct.IdSanpham == idsp && spct.IdMau == idmau && spct.IdKichthuoc == idkichthuoc);

            if (sanPhamCT != null)
            {
                // Nếu tìm thấy, trả về IdSanphamct
                return sanPhamCT.IdSanphamct;
            }
            else
            {
                // Nếu không tìm thấy, trả về giá trị mặc định hoặc thực hiện xử lý phù hợp
                // Ở đây, ta có thể trả về giá trị mặc định là -1 hoặc một giá trị thích hợp khác
                return -1;
            }
        }
        public int GetSoLuongTonKho(int idSanPhamCT)
        {
            var mau = _Contex.Sanphamcts.FirstOrDefault(sp => sp.IdSanphamct == idSanPhamCT);
            if (mau != null)
            {
                // Nếu tìm thấy, kiểm tra xem Soluong có giá trị null hay không
                if (mau.Soluong.HasValue)
                {
                    // Nếu có giá trị, trả về giá trị đó
                    return mau.Soluong.Value;
                }
                else
                {
                    // Nếu Soluong là null, xử lý phù hợp ở đây
                    // Ví dụ: trả về một giá trị mặc định hoặc thông báo lỗi
                    return -1; // hoặc ném ra một Exception, tùy theo yêu cầu của ứng dụng
                }
            }
            else
            {
                // Nếu không tìm thấy, trả về giá trị mặc định hoặc thực hiện xử lý phù hợp
                // Ở đây, ta có thể trả về giá trị mặc định là -1 hoặc một giá trị thích hợp khác
                return -1;
            }
        }
        public int UpdateSoLuongTonKho(int idSanPhamCT, int soLuongMoi)
        {
            var spct = _Contex.Sanphamcts.FirstOrDefault(sp => sp.IdSanphamct == idSanPhamCT);
            if (spct != null)
            {
                // Cập nhật số lượng tồn kho mới
                spct.Soluong = soLuongMoi;

                // Lưu thay đổi vào cơ sở dữ liệu
                _Contex.SaveChanges();

                // Trả về 1 để chỉ ra rằng cập nhật đã thành công
                return 1;
            }
            else
            {
                // Xử lý trường hợp không tìm thấy sản phẩm chi tiết
                throw new InvalidOperationException($"Không tìm thấy sản phẩm chi tiết có IdSanPhamCT = {idSanPhamCT}");
            }
        }
        public int GetByIdSanPham(int idSanPhamCT, int idSanPham)
        {
            var spct = _Contex.Sanphamcts.FirstOrDefault(sp => sp.IdSanphamct == idSanPhamCT);
            if (spct != null)
            {
                spct.IdSanpham = idSanPham;
                _Contex.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return 1;
            }
            return -1; // Trả về -1 nếu không tìm thấy sản phẩm chi tiết
        }
        public string GetTenSanPhamById(int idSanPham)
        {
            var sanPham = _Contex.Sanphams.FirstOrDefault(sp => sp.IdSanpham == idSanPham);
            if (sanPham != null)
            {
                return sanPham.Tensanpham;
            }
            return null; // Trả về null nếu không tìm thấy sản phẩm
        }
        public string GetMauById(int idSanPham)
        {
            var sanPham = _Contex.Maus.FirstOrDefault(sp => sp.IdMau == idSanPham);
            if (sanPham != null)
            {
                return sanPham.Tenmau;
            }
            return null; // Trả về null nếu không tìm thấy sản phẩm
        }
        public int? GetSizeById(int idKichThuoc)
        {
            var kichThuoc = _Contex.Kichthuocs.FirstOrDefault(kt => kt.IdKichthuoc == idKichThuoc);
            if (kichThuoc != null)
            {
                return kichThuoc.Size;
            }
            return null; // Trả về null nếu không tìm thấy kích thước
        }

        public int GetMauId(string mau1)
        {
            // Lấy ID của sản phẩm từ tên sản phẩm
            var mau = _Contex.Maus.FirstOrDefault(sp => sp.Tenmau == mau1);
            if (mau != null)
            {
                // Nếu tìm thấy, trả về IdSanphamct
                return mau.IdMau;
            }
            else
            {
                // Nếu không tìm thấy, trả về giá trị mặc định hoặc thực hiện xử lý phù hợp
                // Ở đây, ta có thể trả về giá trị mặc định là -1 hoặc một giá trị thích hợp khác
                return -1;
            }
        }
        public int GetSanPhamId(string mau1)
        {
            // Lấy ID của sản phẩm từ tên sản phẩm
            var mau = _Contex.Sanphams.FirstOrDefault(sp => sp.Tensanpham == mau1);
            if (mau != null)
            {
                // Nếu tìm thấy, trả về IdSanphamct
                return mau.IdSanpham;
            }
            else
            {
                // Nếu không tìm thấy, trả về giá trị mặc định hoặc thực hiện xử lý phù hợp
                // Ở đây, ta có thể trả về giá trị mặc định là -1 hoặc một giá trị thích hợp khác
                return -1;
            }
        }
        public int GetSizeId(int size)
        {
            // Lấy ID của sản phẩm từ tên sản phẩm
            var siz1 = _Contex.Kichthuocs.FirstOrDefault(sp => sp.Size == size);
            if (siz1 != null)
            {
                // Nếu tìm thấy, trả về IdSanphamct
                return siz1.IdKichthuoc;
            }
            else
            {
                // Nếu không tìm thấy, trả về giá trị mặc định hoặc thực hiện xử lý phù hợp
                // Ở đây, ta có thể trả về giá trị mặc định là -1 hoặc một giá trị thích hợp khác
                return -1;
            }
        }
        public bool AddSPCT_Mau(Mau sp)
        {
            try
            {

                _Contex.Maus.Add(sp);
                _Contex.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool AddSPCT_Size(Kichthuoc sp)
        {
            try
            {

                _Contex.Kichthuocs.Add(sp);
                _Contex.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Sanphamct> GetAllSPCT()
        {
            return _Contex.Sanphamcts.ToList();
        }
        public IEnumerable<Mau> GetAllSPCT_Mau()
        {
            return _Contex.Maus.ToList();
        }
        public IEnumerable<Kichthuoc> GetAllSPCT_KichThuoc()
        {
            return _Contex.Kichthuocs.ToList();
        }
        public IEnumerable<Chatlieu> GetAllSPCT_ChatLieu()
        {
            return _Contex.Chatlieus.ToList();
        }
        public IEnumerable<Loaisanpham> GetAllSPCT_LSP()
        {
            return _Contex.Loaisanphams.ToList();
        }
        public Sanphamct GetById(int id)
        {
            return _Contex.Sanphamcts.FirstOrDefault(x => x.IdSanphamct == id);
        }

        public List<Sanphamct> GetByProductId(int productId)
        {
            // Truy vấn cơ sở dữ liệu để lấy danh sách sản phẩm chi tiết dựa trên IdSanpham
            return _Contex.Sanphamcts.Where(p => p.IdSanpham == productId).ToList();
        }
        public IEnumerable<Thuonghieu> GetAllTH()
        {
            return _Contex.Thuonghieus.ToList();
        }
        public bool DeleteSPCT(int id)
        {
            try
            {
                var exist = _Contex.Sanphamcts.Find(id);
                _Contex.Sanphamcts.Remove(exist);
                _Contex.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    
        public int UpdateSPCT(int id, Sanphamct spct)
        {
            try
            {
                var exist = _Contex.Sanphamcts.Find(id);
                if (exist == null)
                {
                    return 1;
                }
                if (Convert.ToString(spct.IdLoaisanpham) == "" || Convert.ToString(spct.IdMau) == "" || Convert.ToString(spct.IdKichthuoc) == "" || Convert.ToString(spct.IdLoaisanpham) == "")
                {
                    return 2;
                }
                else
                {
                    exist.IdSanpham = spct.IdSanpham;
                    exist.IdLoaisanpham = spct.IdLoaisanpham;
                    exist.IdMau = spct.IdMau;
                    exist.IdKichthuoc = spct.IdKichthuoc;
                    exist.IdChatlieu = spct.IdChatlieu;
                    exist.Soluong = spct.Soluong;
                    exist.Dongia = spct.Dongia;
                    _Contex.Sanphamcts.Update(exist);
                    _Contex.SaveChanges();
                    return 3;
                }

            }
            catch
            {
                return 1;
            }
        }
        public Chatlieu GetById_ChatLieu(string chatlieu)
        {
            return _Contex.Chatlieus.FirstOrDefault(c => c.Tenchatlieu == chatlieu);
        }
        public Mau GetById_Mau(string mau)
        {
            return _Contex.Maus.FirstOrDefault(c => c.Tenmau == mau);
        }
        public Kichthuoc GetById_Size(int size)
        {
            return _Contex.Kichthuocs.FirstOrDefault(c => c.Size == size);
        }
    }
}
