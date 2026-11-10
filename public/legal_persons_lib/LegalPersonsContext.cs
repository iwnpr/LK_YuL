using legal_persons_lib.Entities;
using legal_persons_lib.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace legal_persons_lib
{
    public class LegalPersonsContext : DbContext
    {
        [Obsolete]
        static LegalPersonsContext()
                => NpgsqlConnection.GlobalTypeMapper
                    .MapEnum<DBCertificateStatus>("personal_account.cert_status");

        public LegalPersonsContext(DbContextOptions<LegalPersonsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("personal_account");

            modelBuilder.Entity<DBCertificate>(entity =>
            {
                entity.ToTable("certificates");

                entity.Property(e => e.RequestData)
                    .HasColumnType("xml")
                    .HasColumnName("request_data");

                entity.Property(e => e.Сertificate)
                    .HasColumnType("xml")
                    .HasColumnName("certificate");

                entity.Property(e => e.CertificateDateFrom)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("certificate_date_from");

                entity.Property(e => e.CertificateDateTo)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("certificate_date_to");

                entity.Property(e => e.CertificateSerialNumber).HasColumnName("certificate_serial_number");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.OrganizationId).HasColumnName("organizations_id");

                entity.Property(e => e.RequestData)
                    .HasColumnType("xml")
                    .HasColumnName("request_data");

                entity.Property(e => e.UserId).HasColumnName("users_id");

            });

            modelBuilder.Entity<DBUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("td_users");
            });

            modelBuilder.Entity<DBOrganization>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("organizations");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBLogon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("te_logon");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });
            
            modelBuilder.Entity<DBRegistrationCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("te_registration_codes");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });
            
            modelBuilder.Entity<DBTemporaryCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("te_temporary_codes");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.UserId).HasColumnName("users_id");
            });

            modelBuilder.Entity<DBUserAccess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("user_access");
            });

            modelBuilder.Entity<DBOrganizationType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tr_organization_type");
            });

            modelBuilder.Entity<DBService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tr_services");
            });

            modelBuilder.Entity<DBOrganizationAccess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("organization_access");
            });

            modelBuilder.Entity<DBRequestParameter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("td_request_parameters");

                entity.Property(e => e.RequestParameters)
                    .HasColumnType("xml");
            });

        }

        public virtual DbSet<DBUser> Users { get; set; } = null!;
        public virtual DbSet<DBLogon> Logons { get; set; } = null!;
        public virtual DbSet<DBCertificate> Certificates { get; set; } = null!;
        public virtual DbSet<DBOrganization> Organizations { get; set; } = null!;
        public virtual DbSet<DBRegistrationCode> RegistrationCodes { get; set; } = null!;
        public virtual DbSet<DBTemporaryCode> TemporaryCodes { get; set; } = null!;

        public virtual DbSet<DBRequestParameter> RequestParameters { get; set; } = null!;

        public virtual DbSet<DBUserAccess> UserAccesses { get; set; } = null!;
        public virtual DbSet<DBOrganizationType> OrganizationTypes { get; set; } = null!;
        public virtual DbSet<DBOrganizationAccess> OrganizationAccess { get; set; } = null!;
        public virtual DbSet<DBService> Services { get; set; } = null!;
       

    }
}