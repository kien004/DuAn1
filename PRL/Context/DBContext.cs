using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PRL.Models;

namespace PRL.Context;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chatlieu> Chatlieus { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Hoadonct> Hoadoncts { get; set; }

    public virtual DbSet<KhachHangKhuyenMai> KhachHangKhuyenMais { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }

    public virtual DbSet<Kichthuoc> Kichthuocs { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Mau> Maus { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Sanphamct> Sanphamcts { get; set; }

    public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HHUNGDZ\\SQLEXPRESS;Initial Catalog=CuaHangBanHang_1;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chatlieu>(entity =>
        {
            entity.HasKey(e => e.IdChatlieu).HasName("PK__CHATLIEU__3912AF2857494BEC");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.IdChucvu).HasName("PK__CHUCVU__ACDE8E29665B8532");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.IdHoadon).HasName("PK__HOADON__018FF0B5C92EDE58");

            entity.HasOne(d => d.IdKhachhangNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_KHACH__60A75C0F");

            entity.HasOne(d => d.IdKhuyenmaiNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_KHUYE__619B8048");

            entity.HasOne(d => d.IdNhanvienNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_NHANV__628FA481");
        });

        modelBuilder.Entity<Hoadonct>(entity =>
        {
            entity.HasKey(e => e.IdHoadonct).HasName("PK__HOADONCT__CB5C3B20CBDE225E");

            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK__HOADONCT__ID_HOA__66603565");

            entity.HasOne(d => d.IdSanphamctNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK__HOADONCT__ID_SAN__656C112C");
        });

        modelBuilder.Entity<KhachHangKhuyenMai>(entity =>
        {
            entity.HasOne(d => d.IdKhachHangNavigation).WithMany().HasConstraintName("FK__KhachHang__IdKha__5CD6CB2B");

            entity.HasOne(d => d.IdKhuyenMaiNavigation).WithMany().HasConstraintName("FK__KhachHang__IdKhu__5DCAEF64");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKhachhang).HasName("PK__KHACHHAN__769C0DEB4E7C3056");
        });

        modelBuilder.Entity<Khuyenmai>(entity =>
        {
            entity.HasKey(e => e.IdKhuyenmai).HasName("PK__KHUYENMA__C2E0A2103BC12B69");

            entity.HasOne(d => d.IdKhachhangNavigation).WithMany(p => p.Khuyenmais).HasConstraintName("FK__KHUYENMAI__ID_KH__5AEE82B9");
        });

        modelBuilder.Entity<Kichthuoc>(entity =>
        {
            entity.HasKey(e => e.IdKichthuoc).HasName("PK__KICHTHUO__854A5CB7226D930F");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.IdLoaisanpham).HasName("PK__LOAISANP__D4D523758FFB08B7");
        });

        modelBuilder.Entity<Mau>(entity =>
        {
            entity.HasKey(e => e.IdMau).HasName("PK__MAU__276D397D24D0EFDF");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.IdNhanvien).HasName("PK__NHANVIEN__DE90FCA3C4C213A6");

            entity.HasOne(d => d.IdChucvuNavigation).WithMany(p => p.Nhanviens).HasConstraintName("FK__NHANVIEN__ID_CHU__45F365D3");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.IdSanpham).HasName("PK__SANPHAM__216A055354C5C1A6");

            entity.HasOne(d => d.IdNhanvienNavigation).WithMany(p => p.Sanphams).HasConstraintName("FK__SANPHAM__ID_NHAN__5070F446");

            entity.HasOne(d => d.IdThuonghieuNavigation).WithMany(p => p.Sanphams).HasConstraintName("FK__SANPHAM__ID_THUO__4F7CD00D");
        });

        modelBuilder.Entity<Sanphamct>(entity =>
        {
            entity.HasKey(e => e.IdSanphamct).HasName("PK__SANPHAMC__99B85611BAC612A1");

            entity.HasOne(d => d.IdChatlieuNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_CH__5535A963");

            entity.HasOne(d => d.IdKichthuocNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_KI__534D60F1");

            entity.HasOne(d => d.IdLoaisanphamNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_LO__571DF1D5");

            entity.HasOne(d => d.IdMauNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_MA__5441852A");

            entity.HasOne(d => d.IdNhanvienNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_NH__5812160E");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_SA__5629CD9C");
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.IdThuonghieu).HasName("PK__THUONGHI__1A0670706A0CEDEB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
