using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("CHUCVU")]
public partial class Chucvu
{
    [Key]
    [Column("ID_CHUCVU")]
    public int IdChucvu { get; set; }

    [Column("TENCHUCVU")]
    [StringLength(50)]
    public string? Tenchucvu { get; set; }

    [InverseProperty("IdChucvuNavigation")]
    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
