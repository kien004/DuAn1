using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("HOADON")]
public partial class Hoadon
{
    [Key]
    [Column("ID_HOADON")]
    public int IdHoadon { get; set; }

    [Column("NGAYTAO")]
    public DateOnly? Ngaytao { get; set; }

    [Column("TONGTIEN")]
    public double? Tongtien { get; set; }

    [Column("ID_KHACHHANG")]
    public int? IdKhachhang { get; set; }

    [Column("ID_KHUYENMAI")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IdKhuyenmai { get; set; }

    [Column("TRANGTHAI")]
    [StringLength(50)]
    public string? Trangthai { get; set; }

    [Column("ID_NHANVIEN")]
    public int? IdNhanvien { get; set; }

    [Column("PHUONGTHUCTHANHTOAN")]
    [StringLength(50)]
    public string? Phuongthucthanhtoan { get; set; }

    [InverseProperty("IdHoadonNavigation")]
    public virtual ICollection<Hoadonct> Hoadoncts { get; set; } = new List<Hoadonct>();

    [ForeignKey("IdKhachhang")]
    [InverseProperty("Hoadons")]
    public virtual Khachhang? IdKhachhangNavigation { get; set; }

    [ForeignKey("IdKhuyenmai")]
    [InverseProperty("Hoadons")]
    public virtual Khuyenmai? IdKhuyenmaiNavigation { get; set; }

    [ForeignKey("IdNhanvien")]
    [InverseProperty("Hoadons")]
    public virtual Nhanvien? IdNhanvienNavigation { get; set; }
}
