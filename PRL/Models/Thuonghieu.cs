using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("THUONGHIEU")]
public partial class Thuonghieu
{
    [Key]
    [Column("ID_THUONGHIEU")]
    public int IdThuonghieu { get; set; }

    [Column("TENTHUONGHIEU")]
    [StringLength(50)]
    public string? Tenthuonghieu { get; set; }

    [InverseProperty("IdThuonghieuNavigation")]
    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
