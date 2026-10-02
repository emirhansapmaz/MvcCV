using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcCV.Models;

public partial class DbCvContext : DbContext
{
    public DbCvContext()
    {
    }

    public DbCvContext(DbContextOptions<DbCvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblDeneyim> TblDeneyims { get; set; }

    public virtual DbSet<TblEgitim> TblEgitims { get; set; }

    public virtual DbSet<TblHakkindum> TblHakkinda { get; set; }

    public virtual DbSet<TblHobilerim> TblHobilerims { get; set; }

    public virtual DbSet<TblIletisim> TblIletisims { get; set; }

    public virtual DbSet<TblSertifikalar> TblSertifikalars { get; set; }

    public virtual DbSet<TblYetenekler> TblYeteneklers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=emirhan;Database=DbCV;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.ToTable("TblAdmin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sifre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblDeneyim>(entity =>
        {
            entity.ToTable("TblDeneyim");

            entity.Property(e => e.Aciklama)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AltBaslik)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Baslik)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tarih)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEgitim>(entity =>
        {
            entity.ToTable("TblEgitim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AltBaslik)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AltBaslik2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Baslik)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GNO");
            entity.Property(e => e.Tarih)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblHakkindum>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama).IsUnicode(false);
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Resim)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblHobilerim>(entity =>
        {
            entity.ToTable("TblHobilerim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Aciklama2)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblIletisim>(entity =>
        {
            entity.ToTable("TblIletisim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Kimden)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Konu)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mesaj)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSertifikalar>(entity =>
        {
            entity.ToTable("TblSertifikalar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Tarih)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblYetenekler>(entity =>
        {
            entity.ToTable("TblYetenekler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Yetenek)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
