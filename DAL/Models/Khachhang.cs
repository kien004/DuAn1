using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("KHACHHANG")]
public partial class Khachhang
{
    [Key]
    [Column("ID_KHACHHANG")]
    public int IdKhachhang { get; set; }

    [Column("HOVATEN")]
    [StringLength(50)]
    public string? Hovaten { get; set; }

    [Column("SDT")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Sdt { get; set; }

    [Column("DIACHI")]
    [StringLength(50)]
    public string? Diachi { get; set; }

    [InverseProperty("IdKhachhangNavigation")]
    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
}
