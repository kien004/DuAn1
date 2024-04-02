using DAL.Context;
using DAL.Models;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class SanPhamRepos /*: ISanPhamRepos*/
    {
        DBContext _Contex = new DBContext();

        public SanPhamRepos(DBContext contex)
        {
            _Contex = contex;
        }

        public SanPhamRepos()
        {
        }
        public bool CheckDuplicate(string tenSanPham)
        {
            // Kiểm tra xem có sản phẩm nào trong cơ sở dữ liệu có cùng tên sản phẩm không
            var existingProduct = _Contex.Sanphams.FirstOrDefault(p => p.Tensanpham == tenSanPham);

            // Nếu sản phẩm đã tồn tại, trả về true
            // Ngược lại, trả về false
            return existingProduct != null;
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

        public bool CheckDuplicateForUpdate(string tenSanPham, int maSanPham)
        {
            // Kiểm tra xem tên sản phẩm có tồn tại và không trùng với sản phẩm khác (trừ sản phẩm đang cập nhật) không
            return _Contex.Sanphams.Any(sp => sp.Tensanpham == tenSanPham && sp.IdSanpham != maSanPham);
        }


        public int GetSanPhamId(string tenSanPham)
        {
            // Lấy ID của sản phẩm từ tên sản phẩm
            var sanPham = _Contex.Sanphams.FirstOrDefault(sp => sp.Tensanpham == tenSanPham);
            if (sanPham != null)
            {
                // Nếu tìm thấy, trả về IdSanphamct
                return sanPham.IdSanpham;
            }
            else
            {
                // Nếu không tìm thấy, trả về giá trị mặc định hoặc thực hiện xử lý phù hợp
                // Ở đây, ta có thể trả về giá trị mặc định là -1 hoặc một giá trị thích hợp khác
                return -1;
            }
        }
        public int AddSP(Sanpham sp)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sp.Tensanpham))
                {
                    return 1;
                }
                else
                {
                    _Contex.Sanphams.Add(sp);
                    _Contex.SaveChanges();
                    return 2;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }


        public IEnumerable<Sanpham> GetAllSP()
        {
            return _Contex.Sanphams.ToList();
        }
        public Sanpham GetById(int id)
        {
            return _Contex.Sanphams.FirstOrDefault(x => x.IdSanpham == id);
        }
        public List<Sanpham> GetSearch(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _Contex.Sanphams.ToList();
            }
            return _Contex.Sanphams.Where(c => c.Tensanpham.Contains(searchText)).ToList();
        }
        public IEnumerable<Thuonghieu> GetAllTH()
        {
            return _Contex.Thuonghieus.ToList();
        }
        public bool DeleteSP(int id)
        {
            try
            {
                var exist = _Contex.Sanphams.Find(id);
                _Contex.Sanphams.Remove(exist);
                _Contex.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteKH(int id)
        {
            try
            {
                var exist = _Contex.Sanphams.Find(id);
                _Contex.Sanphams.Remove(exist);
                _Contex.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public int UpdateSP(int id, Sanpham sp)
        {
            try
            {
                var exist = _Contex.Sanphams.Find(id);
                if (exist == null)
                {
                    return 1;
                }
                else if (string.IsNullOrWhiteSpace(sp.Tensanpham))
                {
                    return 2;
                }
                else
                {
                    exist.Tensanpham = sp.Tensanpham;
                    exist.IdThuonghieu = sp.IdThuonghieu;
                    _Contex.Sanphams.Update(exist);
                    _Contex.SaveChanges();
                    return 3;
                }

            }
            catch
            {
                return 1;
            }
        }
    }
}
