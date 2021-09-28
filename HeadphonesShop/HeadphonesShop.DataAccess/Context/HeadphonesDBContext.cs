using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HeadphonesShop.DataAccess.Models;

#nullable disable

namespace HeadphonesShop.DataAccess.Context
{
    public partial class HeadphonesDBContext : DbContext
    {
        public HeadphonesDBContext()
        {
        }

        //public HeadphonesDBContext(DbContextOptions<HeadphonesDBContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Design> Designs { get; set; }
        public virtual DbSet<Headphone> Headphones { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HeadphonesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Companie__737584F622AF138A")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Design>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Designs__737584F621E34017")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Headphone>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Headphon__737584F636E93A10")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Picture).HasMaxLength(256);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Headphones)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Headphone__Compa__4C0144E4");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Headphones)
                    .HasForeignKey(d => d.DesignId)
                    .HasConstraintName("FK__Headphone__Desig__4CF5691D");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Roles__737584F6CD634B29")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login, "UQ__Users__5E55825BDB4374DF")
                    .IsUnique();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleId__4277DAAA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
