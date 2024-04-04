using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("KICHTHUOC")]
public partial class Kichthuoc
{
    [Key]
    [Column("ID_KICHTHUOC")]
    public int IdKichthuoc { get; set; }

    [Column("SIZE")]
    public int? Size { get; set; }

    [InverseProperty("IdKichthuocNavigation")]
    public virtual ICollection<Sanphamct> Sanphamcts { get; set; } = new List<Sanphamct>();
}
