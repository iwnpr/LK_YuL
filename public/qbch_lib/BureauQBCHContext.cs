using Microsoft.EntityFrameworkCore;
using qbch_lib.Entities;

namespace qbch_lib
{
    public class BureauQBCHContext : DbContext
    {
        public BureauQBCHContext(DbContextOptions<BureauQBCHContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("qbchv3");

            modelBuilder.Entity<DBAbonentCertificate>(entity =>
            {
                entity.ToTable("tr_abonent_certificates");
                entity.HasKey(e => e.KeyId);

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBAbonent>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("tr_abonents");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBUserType>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("tr_user_types");
            });

            modelBuilder.Entity<DBPermission>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("td_permissions");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBMethod>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("tr_services");
            });
        }

        public virtual DbSet<DBAbonent> Abonents { get; set; } = null!;
        public virtual DbSet<DBAbonentCertificate> Certificates { get; set; } = null!;
        public virtual DbSet<DBPermission> Permissions { get; set; } = null!;
        public virtual DbSet<DBMethod> Methods { get; set; } = null!;
        public virtual DbSet<DBUserType> UserTypes { get; set; } = null!;
    }
}
