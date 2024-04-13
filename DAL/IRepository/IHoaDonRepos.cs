using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IHoaDonRepos
    {
        IEnumerable<Hoadon> GetALLHoadons();
        bool AddHoaDon(Hoadon hoadon);
        bool UpdateHoaDon(string id);
        bool DeleteHoaDon(int id);
    }
}
