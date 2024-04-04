using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Table("CHATLIEU")]
public partial class Chatlieu
{
    [Key]
    [Column("ID_CHATLIEU")]
    public int IdChatlieu { get; set; }

    [Column("TENCHATLIEU")]
    [StringLength(50)]
    public string? Tenchatlieu { get; set; }

    [InverseProperty("IdChatlieuNavigation")]
    public virtual ICollection<Sanphamct> Sanphamcts { get; set; } = new List<Sanphamct>();
}
