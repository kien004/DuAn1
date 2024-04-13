
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
    public class KhuyenMaiRepository : IKhuyenMaiRepository
    {
        private DBContext _dbContext;
        public KhuyenMaiRepository()
        {
            _dbContext = new DBContext();
        }
        public Khuyenmai GetById(string id)
        {
            return _dbContext.Khuyenmais.FirstOrDefault(x => x.IdKhuyenmai == id);
        }
        public bool AddKM(Khuyenmai khuyenmai)
        {
            _dbContext.Add(khuyenmai);
            _dbContext.SaveChanges();
            return true;
        }
        public string CheckKhuyenMai(int idKhachHang, string idKhuyenMai)
        {
            var khuyenMai = _dbContext.Khuyenmais.FirstOrDefault(km => km.IdKhuyenmai == idKhuyenMai);

            if (khuyenMai != null)
            {
                // Kiểm tra xem mã khuyến mại đã được sử dụng trong hóa đơn của khách hàng chưa
                var existingKhuyenMai = _dbContext.Hoadons.FirstOrDefault(hd => hd.IdKhachhang == idKhachHang && hd.IdKhuyenmai == idKhuyenMai);

                if (existingKhuyenMai != null)
                {
                    return "Khách hàng đã sử dụng mã khuyến mại.";
                }
                else
                {
                    return "Khách hàng chưa sử dụng mã khuyến mại.";
                }
            }
            else
            {
                return "Mã khuyến mại không tồn tại.";
            }
        }
        public string UpdateSoLuongKhuyenMai(string idKhuyenMai)
        {
            var khuyenMai = _dbContext.Khuyenmais.FirstOrDefault(km => km.IdKhuyenmai == idKhuyenMai);

            if (khuyenMai != null)
            {
                // Kiểm tra xem còn số lượng khuyến mại không
                if (khuyenMai.Soluong > 0)
                {
                    // Giảm số lượng khuyến mại đi 1
                    khuyenMai.Soluong--;

                    // Kiểm tra hạn khuyến mại đã hết hạn chưa
                    if (khuyenMai.Ngayhethan < DateTime.Today)
                    {
                        // Nếu đã hết hạn, hiển thị thông báo và trả về -1 để chỉ ra rằng hạn khuyến mại đã hết
                        return "Mã khuyến mại đã hết hạn sử dụng. Vui lòng chọn khuyến mại khác.";
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _dbContext.SaveChanges();

                    // Kiểm tra xem số lượng khuyến mại còn lại
                    if (khuyenMai.Soluong == 0)
                    {
                        // Nếu số lượng khuyến mại là 0, hiển thị thông báo
                        return "Số lượng trong khuyến mại này đã hết.";
                    }

                    // Trả về thông báo thành công
                    return "Áp dụng khuyến mại thành công.";
                }
                else
                {
                    // Nếu số lượng khuyến mại đã hết, hiển thị thông báo
                    return "Số lượng trong khuyến mại này đã hết.";
                }
            }
            else
            {
                // Xử lý trường hợp không tìm thấy mã khuyến mại
                return $"Không tìm thấy mã khuyến mại {idKhuyenMai}.";
            }
        }



        public List<Khuyenmai> GetAllKM()
        {
            return _dbContext.Khuyenmais.ToList();
        }
        public IEnumerable<Khuyenmai> GetAllKM1()
        {
            return _dbContext.Khuyenmais.ToList();
        }

        public bool RemoveKM(Khuyenmai khuyenmai)
        {
            _dbContext.Remove(khuyenmai);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateKM(Khuyenmai khuyenmai)
        {
            _dbContext.Update(khuyenmai);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
