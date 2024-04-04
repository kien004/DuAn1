using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class LoaisanphamRepos
    {
        private DBContext _context;
        public LoaisanphamRepos()
        {
            _context = new DBContext();
        }
        public List<Loaisanpham> GetAll(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Loaisanphams.ToList();
            }
            return _context.Loaisanphams.Where(x => x.Tenloaisanpham.Contains(search)).ToList();
        }
        public bool Add(Loaisanpham loaisanpham)
        {
            try
            {
                _context.Loaisanphams.Add(loaisanpham);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Loaisanpham loaisanpham)
        {
            try
            {
                var exist = _context.Loaisanphams.Find(loaisanpham.IdLoaisanpham);
                exist.Tenloaisanpham = loaisanpham.Tenloaisanpham;
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
                var exist = _context.Loaisanphams.Find(id);
                _context.Loaisanphams.Remove(exist);
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
