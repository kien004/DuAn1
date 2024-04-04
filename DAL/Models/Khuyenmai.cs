using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("KHUYENMAI")]
public partial class Khuyenmai
{
    [Key]
    [Column("ID_KHUYENMAI")]
    [StringLength(10)]
    [Unicode(false)]
    public string IdKhuyenmai { get; set; } = null!;

    [Column("TENKHUYENMAI")]
    [StringLength(50)]
    public string? Tenkhuyenmai { get; set; }

    [Column("NGAYTAO")]
    public DateOnly? Ngaytao { get; set; }

    [Column("NGAYHETHAN")]
    public DateOnly? Ngayhethan { get; set; }

    [Column("TRANGTHAI")]
    [StringLength(50)]
    public string? Trangthai { get; set; }

    [Column("SOPHANTRAMKHUYENMAI", TypeName = "decimal(18, 2)")]
    public decimal? Sophantramkhuyenmai { get; set; }

    [Column("SOLUONG")]
    public int? Soluong { get; set; }

    [Column("NGAYBATDAU")]
    public DateOnly? Ngaybatdau { get; set; }

    [Column("ID_KHACHHANG")]
    public int? IdKhachhang { get; set; }

    [InverseProperty("IdKhuyenmaiNavigation")]
    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    [ForeignKey("IdKhachhang")]
    [InverseProperty("Khuyenmais")]
    public virtual Khachhang? IdKhachhangNavigation { get; set; }
}
