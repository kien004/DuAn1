using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class KichthuocRepos
    {
        private DBContext _context;
        public KichthuocRepos()
        {
            _context = new DBContext();
        }
        public List<Kichthuoc> GetAllKT(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Kichthuocs.ToList();
            }
            //ở đây tôi muốn return list x.Size
            return _context.Kichthuocs.Where(x => x.Size.HasValue).ToList();


            
        }
        public bool Add(Kichthuoc kichthuoc)
        {
            try
            {
                _context.Kichthuocs.Add(kichthuoc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Kichthuoc kichthuoc)
        {
            try
            {
                var exist = _context.Kichthuocs.Find(kichthuoc.IdKichthuoc);
                exist.Size = kichthuoc.Size;
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
                var exist = _context.Kichthuocs.Find(id);
                _context.Kichthuocs.Remove(exist);
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
