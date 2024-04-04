using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("SANPHAM")]
public partial class Sanpham
{
    [Key]
    [Column("ID_SANPHAM")]
    public int IdSanpham { get; set; }

    [Column("ID_THUONGHIEU")]
    public int? IdThuonghieu { get; set; }

    [Column("TENSANPHAM")]
    [StringLength(50)]
    public string? Tensanpham { get; set; }

    [Column("MOTA", TypeName = "text")]
    public string? Mota { get; set; }

    [Column("ID_NHANVIEN")]
    public int? IdNhanvien { get; set; }

    [ForeignKey("IdNhanvien")]
    [InverseProperty("Sanphams")]
    public virtual Nhanvien? IdNhanvienNavigation { get; set; }

    [ForeignKey("IdThuonghieu")]
    [InverseProperty("Sanphams")]
    public virtual Thuonghieu? IdThuonghieuNavigation { get; set; }

    [InverseProperty("IdSanphamNavigation")]
    public virtual ICollection<Sanphamct> Sanphamcts { get; set; } = new List<Sanphamct>();
}
