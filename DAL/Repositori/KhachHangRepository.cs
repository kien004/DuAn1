using DAL.Context;
using DAL.Models;
using Project_SHOE.Controller.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_SHOE.Controller.Repositori
{
    public class KhachHangRepository /*: IKhachHangRepository*/
    {
        private DBContext _dbContext;
        public KhachHangRepository()
        {
            _dbContext = new DBContext();
        }
        public bool AddKH(Khachhang kh)
        {
            _dbContext.Add(kh);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Khachhang> GetAllKH()
        {
            return _dbContext.Khachhangs.ToList();
        }
        public bool IsSDTExist(string? sdt)
        {
            
            // Kiểm tra xem sdt có null không
            if (string.IsNullOrEmpty(sdt))
            {
                return false;
            }
            // Kiểm tra xem sdt đã tồn tại trong cơ sở dữ liệu hay chưa
            var khachhang = _dbContext.Khachhangs.FirstOrDefault(kh => kh.Sdt == sdt);
            if (khachhang != null)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }

        public IEnumerable<Khachhang> GetAllKH1()
        {
            return _dbContext.Khachhangs.ToList();
        }

        public int GetIdSPCT(string hovaten, string sdt)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _dbContext.Khachhangs.FirstOrDefault(kh => kh.Hovaten == hovaten && kh.Sdt == sdt);

            if (khachhang != null)
            {
                return khachhang.IdKhachhang;
            }
            else
            {
                return -1;
            }
        }
        public int GetIdSPCT1( string sdt)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _dbContext.Khachhangs.FirstOrDefault(kh => kh.Sdt == sdt);

            if (khachhang != null)
            {
                return khachhang.IdKhachhang;
            }
            else
            {
                return -1;
            }
        }
        public string GetTenKhachHang(int id)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _dbContext.Khachhangs.FirstOrDefault(kh => kh.IdKhachhang == id);

            if (khachhang != null)
            {
                return khachhang.Hovaten;
            }
            else
            {
                return "Fail";
            }
        }
        public string GetDiaChiKhachHang(int id)
        {
            // Tìm kiếm IdKhachhang dựa trên họ và tên và số điện thoại
            var khachhang = _dbContext.Khachhangs.FirstOrDefault(kh => kh.IdKhachhang == id);

            if (khachhang != null)
            {
                return khachhang.Diachi;
            }
            else
            {
                return "Fail";
            }
        }

        public IEnumerable<Khachhang> GetAllKH2()
        {
            return _dbContext.Khachhangs.ToList();
        }

        public bool RemoveKH(Khachhang kh)
        {
            _dbContext.Remove(kh);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateKH(Khachhang kh)
        {
            _dbContext.Update(kh);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
