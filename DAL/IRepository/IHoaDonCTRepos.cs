using DAL.Context;
using DAL.Models;
using DAL.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public class IHoaDonCTRepos : HoaDonRepos
    {
        DBContext dbContext = new DBContext();
        public int AddHoaDonCT(Hoadonct hoadonct)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hoadonct.IdSanphamct.ToString()) || string.IsNullOrWhiteSpace(hoadonct.IdHoadon.ToString()))
                {
                    return 1;
                }
                else
                {
                    dbContext.Hoadoncts.Add(hoadonct);
                    dbContext.SaveChanges();
                    return 2;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var exist = dbContext.Hoadoncts.Find(id);
                dbContext.Hoadoncts.Remove(exist);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete1(int id)
        {
            try
            {
                var exist = dbContext.Hoadoncts.Where(c => c.IdSanphamct == id).ToList();
                foreach (var item in exist)
                {
                    dbContext.Hoadoncts.Remove(item);
                }
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Hoadonct> GetRepos()
        {
            return dbContext.Hoadoncts.ToList();
        }
        public int UpdateHoaDonCT(int id, Hoadonct hoadonct)
        {
            try
            {
                var exist = dbContext.Hoadoncts.Find(id);
                if (exist == null)
                {
                    return 1;
                }
                else if (string.IsNullOrWhiteSpace(hoadonct.IdSanphamct.ToString()) || string.IsNullOrWhiteSpace(hoadonct.IdHoadon.ToString()))
                {
                    return 2;
                }
                else
                {
                    exist.IdSanphamct = hoadonct.IdSanphamct;
                    exist.IdHoadonct = hoadonct.IdHoadonct;
                    dbContext.Hoadoncts.Update(exist);
                    dbContext.SaveChanges();
                    return 3;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }
        public bool UpdateHoaDonCT1(int id, string trangthai)
        {
            try
            {
                var exist = dbContext.Hoadoncts.Find(id);
                exist.Trangthai = trangthai;
                dbContext.Hoadoncts.Update(exist);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
