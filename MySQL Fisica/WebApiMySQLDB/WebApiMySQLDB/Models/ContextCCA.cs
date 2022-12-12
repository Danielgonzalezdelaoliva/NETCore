using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApiMySQLDB.Models
{
    public partial class ContextCCA : DbContext
    {
        public ContextCCA()
        {
        }

        public ContextCCA(DbContextOptions<ContextCCA> options)
            : base(options)
        {
        }

       
        public virtual DbSet<CcaRol> CcaRol { get; set; }
        public virtual DbSet<CcaSite> CcaSite { get; set; }
       
        public virtual DbSet<CcaUser> CcaUser { get; set; }



//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=intbdmisc01;user id=cca_adm;port=3301;password=)XI6YOBdfQ;database=cca;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CcaRol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("cca_rol");

                entity.Property(e => e.Name).HasMaxLength(40);
            });
            modelBuilder.Entity<CcaSite>(entity =>
            {
                entity.HasKey(e => e.IdSite)
                    .HasName("PRIMARY");

                entity.ToTable("cca_site");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CcaUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("cca_user");

                entity.HasIndex(e => e.IdRol)
                    .HasName("fk_cca_user_as_cca_user_idx");

                entity.HasIndex(e => e.IdSite)
                    .HasName("fk_cca_user_as_cca_site_idx");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.CcaUser)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cca_user_as_cca_user");

                entity.HasOne(d => d.IdSiteNavigation)
                    .WithMany(p => p.CcaUser)
                    .HasForeignKey(d => d.IdSite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cca_user_as_cca_site");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
