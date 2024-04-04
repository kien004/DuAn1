using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositori
{
    public class ChatlieuRepos
    {
        private DBContext _context;
public ChatlieuRepos()
        {
            _context = new DBContext();
        }
        public List<Chatlieu> GetAll(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Chatlieus.ToList();
            }
            return _context.Chatlieus.Where(x => x.Tenchatlieu.Contains(search)).ToList();
        }
        public bool Add(Chatlieu chatlieu)
        {
            try
            {
                _context.Chatlieus.Add(chatlieu);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Chatlieu chatlieu)
        {
            try
            {
                var exist = _context.Chatlieus.Find(chatlieu.IdChatlieu);
                exist.Tenchatlieu = chatlieu.Tenchatlieu;
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
                var exist = _context.Chatlieus.Find(id);
                _context.Chatlieus.Remove(exist);
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
