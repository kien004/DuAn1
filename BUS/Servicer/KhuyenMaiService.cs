using BUS.Viewmoder;
using DAL.Models;
using Project_SHOE.Controller.IService;
using Project_SHOE.Controller.Repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_SHOE.Controller.Servicer
{
    public class KhuyenMaiService : IKhuyenMaiService
    {
        private KhuyenMaiRepository _repos;
        public KhuyenMaiService()
        {
            _repos = new KhuyenMaiRepository();
        }
        public Khuyenmai GetById(string id)
        {
            return _repos.GetById(id);
        }
        public string Add(Khuyenmai km)
        {
            if (_repos.AddKM(km) == true)
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public string CheckKhuyenMai(int idkhachang, string idkhuyenmai)
        {
            return _repos.CheckKhuyenMai(idkhachang, idkhuyenmai);
        }

        public string UpdateSoLuongKhuyenMai(string idKhuyenMai)
        {
            return _repos.UpdateSoLuongKhuyenMai(idKhuyenMai);
        }
            public bool IsKhuyenMaiValid(string maKhuyenMai)
        {
            // Kiểm tra xem mã khuyến mãi có tồn tại trong cơ sở dữ liệu không
            return _repos.GetAllKM().Any(km => km.IdKhuyenmai == maKhuyenMai);
        }
        public string Delete(Khuyenmai km)
        {
            var clone = _repos.GetAllKM().FirstOrDefault(x => x.Tenkhuyenmai == km.Tenkhuyenmai);

            if (_repos.RemoveKM(clone) == true)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

        public List<Khuyenmai> GetAll(string search)
        {
            if (search == null)
            {
                return _repos.GetAllKM();
            }
            else
            {
                return _repos.GetAllKM().Where(x => x.Tenkhuyenmai.Contains(search)).ToList();
            }
        }
        public IEnumerable<Khuyenmai> GetALLKhuyenMai()
        {
            return _repos.GetAllKM1().ToList();
        }
        public string Update(Khuyenmai km)
        {
            var clone = _repos.GetAllKM().FirstOrDefault(x => x.Tenkhuyenmai == km.Tenkhuyenmai);
            clone.Ngayhethan = km.Ngayhethan;
            clone.Tenkhuyenmai = km.Tenkhuyenmai;
            clone.Trangthai = km.Trangthai;
            clone.Sophantramkhuyenmai = km.Sophantramkhuyenmai;
            clone.Ngaybatdau = km.Ngaybatdau;
            clone.Ngaytao = km.Ngaytao;


            if (_repos.UpdateKM(clone) == true)
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
    }
}
