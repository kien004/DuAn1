using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("LOAISANPHAM")]
public partial class Loaisanpham
{
    [Key]
    [Column("ID_LOAISANPHAM")]
    public int IdLoaisanpham { get; set; }

    [Column("TENLOAISANPHAM")]
    [StringLength(50)]
    public string? Tenloaisanpham { get; set; }

    [InverseProperty("IdLoaisanphamNavigation")]
    public virtual ICollection<Sanphamct> Sanphamcts { get; set; } = new List<Sanphamct>();
}
