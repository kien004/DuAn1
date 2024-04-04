using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("MAU")]
public partial class Mau
{
    [Key]
    [Column("ID_MAU")]
    public int IdMau { get; set; }

    [Column("TENMAU")]
    [StringLength(50)]
    public string? Tenmau { get; set; }

    [InverseProperty("IdMauNavigation")]
    public virtual ICollection<Sanphamct> Sanphamcts { get; set; } = new List<Sanphamct>();
}
