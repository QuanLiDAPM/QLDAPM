using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LinquorStore.Models;

#nullable disable

namespace LinquorStore.Data
{
    public partial class LiquorStoresContext : DbContext
    {
        public LiquorStoresContext()
        {
        }

        public LiquorStoresContext(DbContextOptions<LiquorStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<DatHangChiTiet> DatHangChiTiets { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<NoiSanXuat> NoiSanXuats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-C2C1L4V4;Database=LiquorStores;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DatHang>(entity =>
            {
                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.DatHangs)
                    .HasForeignKey(d => d.KhachHangId)
                    .HasConstraintName("FK__DatHang__KhachHa__31EC6D26");

                entity.HasOne(d => d.TaiKhoan)
                    .WithMany(p => p.DatHangs)
                    .HasForeignKey(d => d.TaiKhoanId)
                    .HasConstraintName("FK__DatHang__TaiKhoa__32E0915F");
            });

            modelBuilder.Entity<DatHangChiTiet>(entity =>
            {
                entity.HasOne(d => d.DatHang)
                    .WithMany(p => p.DatHangChiTiets)
                    .HasForeignKey(d => d.DatHangId)
                    .HasConstraintName("FK__DatHang_C__DatHa__33D4B598");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DatHangChiTiets)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK__DatHang_C__SanPh__34C8D9D1");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasOne(d => d.Hang)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.HangId)
                    .HasConstraintName("FK__SanPham__Hang_ID__35BCFE0A");

                entity.HasOne(d => d.Loai)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.LoaiId)
                    .HasConstraintName("FK__SanPham__Loai_ID__36B12243");

                entity.HasOne(d => d.NoiSanXuat)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.NoiSanXuatId)
                    .HasConstraintName("FK__SanPham__NoiSanX__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
