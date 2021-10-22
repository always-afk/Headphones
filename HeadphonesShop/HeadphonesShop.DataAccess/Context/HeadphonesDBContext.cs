using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HeadphonesShop.DataAccess.Models.DataModels;

#nullable disable

namespace HeadphonesShop.DataAccess.Context
{
    public partial class HeadphonesDBContext : DbContext
    {
        //public HeadphonesDBContext()
        //{
        //}

        public HeadphonesDBContext(DbContextOptions<HeadphonesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Design> Designs { get; set; }
        public virtual DbSet<FullHeadphone> FullHeadphones { get; set; }
        public virtual DbSet<Headphone> Headphones { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserHeadphone> UserHeadphones { get; set; }

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
                entity.HasIndex(e => e.Name, "UQ__Companie__737584F61CA2A4B6")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Design>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Designs__737584F629C8ABEE")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<FullHeadphone>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FullHeadphones");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Design)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Headphone>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Headphon__737584F6F5F7CF82")
                    .IsUnique();

                entity.HasIndex(e => e.Picture, "pic_index");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Picture).HasMaxLength(256);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Headphones)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Headphone__Compa__6521F869");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Headphones)
                    .HasForeignKey(d => d.DesignId)
                    .HasConstraintName("FK__Headphone__Desig__66161CA2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Roles__737584F6536C9287")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login, "UQ__Users__5E55825BDA2AA638")
                    .IsUnique();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleId__5B988E2F");
            });

            modelBuilder.Entity<UserHeadphone>(entity =>
            {
                entity.HasOne(d => d.Headphones)
                    .WithMany(p => p.UserHeadphones)
                    .HasForeignKey(d => d.HeadphonesId)
                    .HasConstraintName("FK__UserHeadp__Headp__68F2894D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHeadphones)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserHeadp__UserI__69E6AD86");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
