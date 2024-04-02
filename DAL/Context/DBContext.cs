using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

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
        => optionsBuilder.UseSqlServer("Data Source=HHUNGDZ\\SQLEXPRESS;Initial Catalog=CuaHangBanHang_1;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chatlieu>(entity =>
        {
            entity.HasKey(e => e.IdChatlieu).HasName("PK__CHATLIEU__3912AF289F0644BF");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.IdChucvu).HasName("PK__CHUCVU__ACDE8E29231C707F");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.IdHoadon).HasName("PK__HOADON__018FF0B57137B976");

            entity.HasOne(d => d.IdKhachhangNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_KHACH__403A8C7D");

            entity.HasOne(d => d.IdKhuyenmaiNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_KHUYE__412EB0B6");
        });

        modelBuilder.Entity<Hoadonct>(entity =>
        {
            entity.HasKey(e => e.IdHoadonct).HasName("PK__HOADONCT__CB5C3B207A9A076B");

            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK__HOADONCT__ID_HOA__5CD6CB2B");

            entity.HasOne(d => d.IdSanphamctNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK__HOADONCT__ID_SAN__5BE2A6F2");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKhachhang).HasName("PK__KHACHHAN__769C0DEB06885947");
        });

        modelBuilder.Entity<Khuyenmai>(entity =>
        {
            entity.HasKey(e => e.IdKhuyenmai).HasName("PK__KHUYENMA__C2E0A21097623CEC");
        });

        modelBuilder.Entity<Kichthuoc>(entity =>
        {
            entity.HasKey(e => e.IdKichthuoc).HasName("PK__KICHTHUO__854A5CB7E88DA72D");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.IdLoaisanpham).HasName("PK__LOAISANP__D4D52375024DF897");
        });

        modelBuilder.Entity<Mau>(entity =>
        {
            entity.HasKey(e => e.IdMau).HasName("PK__MAU__276D397D5D626397");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.IdNhanvien).HasName("PK__NHANVIEN__DE90FCA31084BD1E");

            entity.HasOne(d => d.IdChucvuNavigation).WithMany(p => p.Nhanviens).HasConstraintName("FK__NHANVIEN__ID_CHU__33D4B598");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.IdSanpham).HasName("PK__SANPHAM__216A05531AAF96E4");

            entity.HasOne(d => d.IdThuonghieuNavigation).WithMany(p => p.Sanphams).HasConstraintName("FK__SANPHAM__ID_THUO__36B12243");
        });

        modelBuilder.Entity<Sanphamct>(entity =>
        {
            entity.HasKey(e => e.IdSanphamct).HasName("PK__SANPHAMC__99B856117AD9B018");

            entity.HasOne(d => d.IdChatlieuNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_CH__3B75D760");

            entity.HasOne(d => d.IdKichthuocNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_KI__398D8EEE");

            entity.HasOne(d => d.IdLoaisanphamNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_LO__3D5E1FD2");

            entity.HasOne(d => d.IdMauNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_MA__3A81B327");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_SA__3C69FB99");
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.IdThuonghieu).HasName("PK__THUONGHI__1A0670700CC3CDDC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
