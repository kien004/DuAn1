using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class MauRepos
    {
        private DBContext _context;
        public MauRepos()
        {
            _context = new DBContext();
        }
        public List<Mau> GetAll(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Maus.ToList();
            }
            return _context.Maus.Where(x => x.Tenmau.Contains(search)).ToList();
        }
        public bool Add(Mau mau)
        {
            try
            {
                _context.Maus.Add(mau);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Mau mau)
        {
            try
            {
                var exist = _context.Maus.Find(mau.IdMau);
                exist.Tenmau = mau.Tenmau;
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
                var exist = _context.Maus.Find(id);
                _context.Maus.Remove(exist);
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
