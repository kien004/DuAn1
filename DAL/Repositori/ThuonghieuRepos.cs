using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class ThuonghieuRepos
    {
        private DBContext _context;
        public ThuonghieuRepos()
        {
            _context = new DBContext();
        }
        public List<Thuonghieu> GetAll(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Thuonghieus.ToList();
            }
            return _context.Thuonghieus.Where(x => x.Tenthuonghieu.Contains(search)).ToList();
        }
        public bool Add(Thuonghieu thuonghieu)
        {
            try
            {
                _context.Thuonghieus.Add(thuonghieu);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Thuonghieu thuonghieu)
        {
            try
            {
                var exist = _context.Thuonghieus.Find(thuonghieu.IdThuonghieu);
                exist.Tenthuonghieu = thuonghieu.Tenthuonghieu;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var exist = _context.Thuonghieus.Find(id);
                _context.Thuonghieus.Remove(exist);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
