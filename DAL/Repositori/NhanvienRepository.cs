
using Project_SHOE.Controller.IRepository;
using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SHOE.Controller.Repositori
{
    public class NhanvienRepository /*: INhanvienRepository*/
    {
        private DBContext _dbContext;
        public NhanvienRepository()
        {
            _dbContext = new DBContext();
        }
        public bool AddNV(Nhanvien nv)
        {
            _dbContext.Add(nv);
            _dbContext.SaveChanges();
            return true;
        }
        public int GetIdNhanVien(string sdt)
        {
            var khanhhang = _dbContext.Nhanviens.FirstOrDefault(x => x.Sdt == sdt);

            if (khanhhang != null)
            {
                return khanhhang.IdNhanvien;
            }
            else
            {
                return -1;
            }
        }
        public List<Nhanvien> GetAllNV()
        {
            return _dbContext.Nhanviens.ToList();
        }

        public bool RemoveNV(Nhanvien nv)
        {
            _dbContext.Remove(nv);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateNV(Nhanvien nv)
        {
            _dbContext.Update(nv);
            _dbContext.SaveChanges();
            return true;
        }
        public List<Chucvu> GetChucvus()
        {
            return _dbContext.Chucvus.ToList();
        }
    }
}
