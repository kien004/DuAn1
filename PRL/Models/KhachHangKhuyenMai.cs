using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRL.Models;

[Keyless]
[Table("KhachHangKhuyenMai")]
public partial class KhachHangKhuyenMai
{
    public int? IdKhachHang { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKhuyenMai { get; set; }

    [ForeignKey("IdKhachHang")]
    public virtual Khachhang? IdKhachHangNavigation { get; set; }

    [ForeignKey("IdKhuyenMai")]
    public virtual Khuyenmai? IdKhuyenMaiNavigation { get; set; }
}
