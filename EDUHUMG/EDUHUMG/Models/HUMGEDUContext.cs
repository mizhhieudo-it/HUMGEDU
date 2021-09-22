using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class HUMGEDUContext : DbContext
    {
        public HUMGEDUContext()
        {
        }

        public HUMGEDUContext(DbContextOptions<HUMGEDUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baihoc> Baihocs { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Khoahoc> Khoahocs { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Thongbao> Thongbaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MINHHIEUPC\\SQLEXPRESS;Database=HUMGEDU;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Baihoc>(entity =>
            {
                entity.HasKey(e => e.Idbaihoc)
                    .HasName("PK_chitietbaihoc");

                entity.ToTable("baihoc");

                entity.Property(e => e.Idbaihoc).HasColumnName("idbaihoc");

                entity.Property(e => e.Idkhoahoc).HasColumnName("idkhoahoc");

                entity.Property(e => e.Linkbaihoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("linkbaihoc");

                entity.Property(e => e.Linkvideobaihoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("linkvideobaihoc");

                entity.Property(e => e.Motabaihoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("motabaihoc");

                entity.Property(e => e.Nguoisuabaihoc)
                    .HasMaxLength(50)
                    .HasColumnName("nguoisuabaihoc");

                entity.Property(e => e.Nguoitaobaihoc)
                    .HasMaxLength(50)
                    .HasColumnName("nguoitaobaihoc");

                entity.Property(e => e.Thoigiansuabaihoc)
                    .HasColumnType("date")
                    .HasColumnName("thoigiansuabaihoc");

                entity.Property(e => e.Thoigiantaobaihoc)
                    .HasColumnType("date")
                    .HasColumnName("thoigiantaobaihoc");

                entity.Property(e => e.Tieudebaihoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("tieudebaihoc");

                entity.Property(e => e.Trangthaibaihoc).HasColumnName("trangthaibaihoc");

                entity.HasOne(d => d.IdkhoahocNavigation)
                    .WithMany(p => p.Baihocs)
                    .HasForeignKey(d => d.Idkhoahoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_baihoc_khoahoc");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.Iddanhmuc);

                entity.ToTable("danhmuc");

                entity.Property(e => e.Iddanhmuc).HasColumnName("iddanhmuc");

                entity.Property(e => e.Linkdanhmuc)
                    .IsRequired()
                    .HasColumnName("linkdanhmuc");

                entity.Property(e => e.Tendanhmuc)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("tendanhmuc");
            });

            modelBuilder.Entity<Khoahoc>(entity =>
            {
                entity.HasKey(e => e.Idkhoahoc);

                entity.ToTable("khoahoc");

                entity.Property(e => e.Idkhoahoc).HasColumnName("idkhoahoc");

                entity.Property(e => e.Anhkhoahoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("anhkhoahoc");

                entity.Property(e => e.Iddanhmuc).HasColumnName("iddanhmuc");

                entity.Property(e => e.Linkkhoahoc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("linkkhoahoc");

                entity.Property(e => e.Motakhoahoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("motakhoahoc");

                entity.Property(e => e.Nguoisuakhoahoc)
                    .HasMaxLength(50)
                    .HasColumnName("nguoisuakhoahoc");

                entity.Property(e => e.Nguoitaokhoahoc)
                    .HasMaxLength(50)
                    .HasColumnName("nguoitaokhoahoc");

                entity.Property(e => e.Tenkhoahoc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tenkhoahoc");

                entity.Property(e => e.Thoigiansuakhoahoc)
                    .HasColumnType("date")
                    .HasColumnName("thoigiansuakhoahoc");

                entity.Property(e => e.Thoigiantaokhoahoc)
                    .HasColumnType("date")
                    .HasColumnName("thoigiantaokhoahoc");

                entity.Property(e => e.Trangthaikhoahoc).HasColumnName("trangthaikhoahoc");

                entity.HasOne(d => d.IddanhmucNavigation)
                    .WithMany(p => p.Khoahocs)
                    .HasForeignKey(d => d.Iddanhmuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_khoahoc_danhmuc");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("taikhoan");

                entity.Property(e => e.Iduser)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("iduser");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Thongbao>(entity =>
            {
                entity.HasKey(e => e.Idthongbao);

                entity.ToTable("thongbao");

                entity.Property(e => e.Idthongbao).HasColumnName("idthongbao");

                entity.Property(e => e.Linkthongbao)
                    .HasColumnType("text")
                    .HasColumnName("linkthongbao");

                entity.Property(e => e.Motathongbao)
                    .HasColumnType("text")
                    .HasColumnName("motathongbao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
