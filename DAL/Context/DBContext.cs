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
            entity.HasKey(e => e.IdChatlieu).HasName("PK__CHATLIEU__3912AF28B69139E9");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.IdChucvu).HasName("PK__CHUCVU__ACDE8E29964ECADA");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.IdHoadon).HasName("PK__HOADON__018FF0B54B7EE138");

            entity.HasOne(d => d.IdKhachhangNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_KHACH__02FC7413");

            entity.HasOne(d => d.IdKhuyenmaiNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_KHUYE__03F0984C");

            entity.HasOne(d => d.IdNhanvienNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK__HOADON__ID_NHANV__2739D489");
        });

        modelBuilder.Entity<Hoadonct>(entity =>
        {
            entity.HasKey(e => e.IdHoadonct).HasName("PK__HOADONCT__CB5C3B206FE879AD");

            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK__HOADONCT__ID_HOA__2645B050");

            entity.HasOne(d => d.IdSanphamctNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK__HOADONCT__ID_SAN__25518C17");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKhachhang).HasName("PK__KHACHHAN__769C0DEBB64A613B");
        });

        modelBuilder.Entity<Khuyenmai>(entity =>
        {
            entity.HasKey(e => e.IdKhuyenmai).HasName("PK__KHUYENMA__C2E0A21052FF9964");
        });

        modelBuilder.Entity<Kichthuoc>(entity =>
        {
            entity.HasKey(e => e.IdKichthuoc).HasName("PK__KICHTHUO__854A5CB768D71888");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.IdLoaisanpham).HasName("PK__LOAISANP__D4D52375F0E94591");
        });

        modelBuilder.Entity<Mau>(entity =>
        {
            entity.HasKey(e => e.IdMau).HasName("PK__MAU__276D397D8F289BC7");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.IdNhanvien).HasName("PK__NHANVIEN__DE90FCA300A7442F");

            entity.HasOne(d => d.IdChucvuNavigation).WithMany(p => p.Nhanviens).HasConstraintName("FK__NHANVIEN__ID_CHU__45F365D3");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.IdSanpham).HasName("PK__SANPHAM__216A05532DD142E4");

            entity.HasOne(d => d.IdNhanvienNavigation).WithMany(p => p.Sanphams).HasConstraintName("FK__SANPHAM__ID_NHAN__49C3F6B7");

            entity.HasOne(d => d.IdThuonghieuNavigation).WithMany(p => p.Sanphams).HasConstraintName("FK__SANPHAM__ID_THUO__48CFD27E");
        });

        modelBuilder.Entity<Sanphamct>(entity =>
        {
            entity.HasKey(e => e.IdSanphamct).HasName("PK__SANPHAMC__99B856112928B6C3");

            entity.HasOne(d => d.IdChatlieuNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_CH__4E88ABD4");

            entity.HasOne(d => d.IdKichthuocNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_KI__4CA06362");

            entity.HasOne(d => d.IdLoaisanphamNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_LO__5070F446");

            entity.HasOne(d => d.IdMauNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_MA__4D94879B");

            entity.HasOne(d => d.IdNhanvienNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_NH__5165187F");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.Sanphamcts).HasConstraintName("FK__SANPHAMCT__ID_SA__4F7CD00D");
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.IdThuonghieu).HasName("PK__THUONGHI__1A06707097965DAD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
