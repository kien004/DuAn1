using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("HOADONCT")]
public partial class Hoadonct
{
    [Key]
    [Column("ID_HOADONCT")]
    public int IdHoadonct { get; set; }

    [Column("SOLUONG")]
    public int? Soluong { get; set; }

    [Column("GIASP")]
    public double? Giasp { get; set; }

    [Column("TRANGTHAI")]
    [StringLength(30)]
    public string? Trangthai { get; set; }

    [Column("ID_SANPHAMCT")]
    public int? IdSanphamct { get; set; }

    [Column("ID_HOADON")]
    [StringLength(50)]
    [Unicode(false)]
    public string? IdHoadon { get; set; }

    [ForeignKey("IdHoadon")]
    [InverseProperty("Hoadoncts")]
    public virtual Hoadon? IdHoadonNavigation { get; set; }

    [ForeignKey("IdSanphamct")]
    [InverseProperty("Hoadoncts")]
    public virtual Sanphamct? IdSanphamctNavigation { get; set; }
}
