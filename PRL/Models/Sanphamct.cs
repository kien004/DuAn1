using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("SANPHAMCT")]
public partial class Sanphamct
{
    [Key]
    [Column("ID_SANPHAMCT")]
    public int IdSanphamct { get; set; }

    [Column("ID_KICHTHUOC")]
    public int? IdKichthuoc { get; set; }

    [Column("ID_MAU")]
    public int? IdMau { get; set; }

    [Column("SOLUONG")]
    public int? Soluong { get; set; }

    [Column("ID_CHATLIEU")]
    public int? IdChatlieu { get; set; }

    [Column("ID_SANPHAM")]
    public int? IdSanpham { get; set; }

    [Column("DONGIA")]
    public double? Dongia { get; set; }

    [Column("ID_LOAISANPHAM")]
    public int? IdLoaisanpham { get; set; }

    [Column("ID_NHANVIEN")]
    public int? IdNhanvien { get; set; }

    [InverseProperty("IdSanphamctNavigation")]
    public virtual ICollection<Hoadonct> Hoadoncts { get; set; } = new List<Hoadonct>();

    [ForeignKey("IdChatlieu")]
    [InverseProperty("Sanphamcts")]
    public virtual Chatlieu? IdChatlieuNavigation { get; set; }

    [ForeignKey("IdKichthuoc")]
    [InverseProperty("Sanphamcts")]
    public virtual Kichthuoc? IdKichthuocNavigation { get; set; }

    [ForeignKey("IdLoaisanpham")]
    [InverseProperty("Sanphamcts")]
    public virtual Loaisanpham? IdLoaisanphamNavigation { get; set; }

    [ForeignKey("IdMau")]
    [InverseProperty("Sanphamcts")]
    public virtual Mau? IdMauNavigation { get; set; }

    [ForeignKey("IdNhanvien")]
    [InverseProperty("Sanphamcts")]
    public virtual Nhanvien? IdNhanvienNavigation { get; set; }

    [ForeignKey("IdSanpham")]
    [InverseProperty("Sanphamcts")]
    public virtual Sanpham? IdSanphamNavigation { get; set; }
}
