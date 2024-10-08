using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace iStore.Models
{
    public partial class iStoreDB : DbContext
    {
        public iStoreDB()
            : base("name=iStoreDB")
        {
        }

        public virtual DbSet<CauHinh> CauHinhs { get; set; }
        public virtual DbSet<Chitiet_Cauhinh> Chitiet_Cauhinh { get; set; }
        public virtual DbSet<Chitiet_Donhang> Chitiet_Donhang { get; set; }
        public virtual DbSet<Chitiet_Giohang> Chitiet_Giohang { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; }
        public virtual DbSet<MaGiamGia> MaGiamGias { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieux { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHinh>()
                .Property(e => e.mota)
                .IsUnicode(false);

            modelBuilder.Entity<Chitiet_Donhang>()
                .Property(e => e.gia)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Chitiet_Giohang>()
                .Property(e => e.gia)
                .HasPrecision(10, 0);

            modelBuilder.Entity<DanhGia>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.trangthai)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.tongtien)
                .HasPrecision(10, 0);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.tongtien)
                .HasPrecision(10, 0);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.ma_giamgia)
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnh>()
                .Property(e => e.url_hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<MaGiamGia>()
                .Property(e => e.ma_giamgia)
                .IsUnicode(false);

            modelBuilder.Entity<MaGiamGia>()
                .Property(e => e.giatri_giam)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MaGiamGia>()
                .Property(e => e.loai_giam)
                .IsUnicode(false);

            modelBuilder.Entity<MaGiamGia>()
                .Property(e => e.dieukien)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.ten_nguoidung)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.matkhau_kiemtra)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.diachi)
                .IsUnicode(false);

            modelBuilder.Entity<PhuongThucThanhToan>()
                .Property(e => e.ten_phuongthuc)
                .IsUnicode(false);

            modelBuilder.Entity<PhuongThucThanhToan>()
                .Property(e => e.sotaikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<PhuongThucThanhToan>()
                .Property(e => e.nganhang)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.gia_sanpham)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.mota)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhToan>()
                .Property(e => e.sotien)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ThanhToan>()
                .Property(e => e.magiadich)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhToan>()
                .Property(e => e.trangthai)
                .IsUnicode(false);
        }
    }
}
