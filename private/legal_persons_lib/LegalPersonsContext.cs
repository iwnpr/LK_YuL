using legal_persons_lib.Entities;
using legal_persons_lib.Entities.Requests;
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
                    .MapEnum<DBCertificateStatus>("personal_account.cert_status")
                    .MapEnum<DBGovernment>("personal_account.governments")
                    .MapEnum<DBExampleType>("personal_account.examples_type");

        public LegalPersonsContext(DbContextOptions<LegalPersonsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("personal_account");

            modelBuilder.Entity<DBCertificate>(entity =>
            {
                entity.ToTable("certificates", "personal_account");

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
                entity.ToTable("td_users", "personal_account");
            });

            modelBuilder.Entity<DBUserAccess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("user_access", "personal_account");
            });

            modelBuilder.Entity<DBOrganization>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("organizations", "personal_account");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBLogon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("te_logon", "personal_account");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBRegistrationCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("te_registration_codes", "personal_account");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");
            });

            modelBuilder.Entity<DBTemporaryCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("te_temporary_codes", "personal_account");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.UserId).HasColumnName("users_id");
            });

            modelBuilder.Entity<DBOrganizationType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tr_organization_type", "personal_account");
            });

            modelBuilder.Entity<DBService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tr_services", "personal_account");
            });

            modelBuilder.Entity<DBOrganizationAccess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("organization_access", "personal_account");
            });

            modelBuilder.Entity<DBRequestParameter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("td_request_parameters", "personal_account");

                entity.Property(e => e.RequestParameters)
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<DBRequestCheckContractsByUser>(entity =>
            {
                entity.ToTable("te_requests_check_contracts_by_user", "personal_account");

                entity.Property(e => e.Request)
                    .HasColumnType("xml")
                    .HasColumnName("request");

                entity.Property(e => e.Response)
                    .HasColumnType("xml")
                    .HasColumnName("response");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrganizationId).HasColumnName("organizations_id");

                entity.Property(e => e.UserId).HasColumnName("users_id");
            });

            modelBuilder.Entity<DBRequestForGovernmentByUser>(entity =>
            {
                entity.ToTable("te_requests_for_government_by_user", "personal_account");

                entity.Property(e => e.Request)
                    .HasColumnType("xml")
                    .HasColumnName("request");

                entity.Property(e => e.Response)
                    .HasColumnType("xml")
                    .HasColumnName("response");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("date")
                    .HasColumnName("request_date");

                entity.Property(e => e.ResponseDate)
                    .HasColumnType("date")
                    .HasColumnName("response_date");

                entity.Property(e => e.IncomingRequestId)
                    .HasColumnName("incoming_request_id");

                entity.Property(e => e.OutgoingResponseId)
                    .HasColumnName("outgoing_response_id");

                entity.Property(e => e.GovernmentId)
                    .HasColumnName("government_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrganizationId).HasColumnName("organizations_id");

                entity.Property(e => e.UserId).HasColumnName("users_id");
            });

            modelBuilder.Entity<DBRequestOfBureau>(entity =>
            {
                entity.ToTable("te_requests_of_bureau", "personal_account");

                entity.Property(e => e.Request)
                    .HasColumnType("xml")
                    .HasColumnName("request");

                entity.Property(e => e.Response)
                    .HasColumnType("xml")
                    .HasColumnName("response");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated");

                entity.Property(e => e.ResponseId)
                    .HasColumnName("response_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrganizationId).HasColumnName("organizations_id");

                entity.Property(e => e.UserId).HasColumnName("users_id");
            });

            modelBuilder.Entity<DBRequestOfQBCH>(entity =>
            {
                entity.ToTable("te_requests_of_qbch", "personal_account");

                entity.Property(e => e.Request)
                    .HasColumnType("xml")
                    .HasColumnName("request");

                entity.Property(e => e.Response)
                    .HasColumnType("xml")
                    .HasColumnName("response");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated");

                 entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<DBUpload>(entity =>
            {
                entity.ToTable("te_requests_of_uploads", "personal_account");

                entity.Property(e => e.UploadXML)
                    .HasColumnType("xml")
                    .HasColumnName("upload_xml");

                entity.Property(e => e.RegResultXml)
                    .HasColumnType("xml")
                    .HasColumnName("reg_result_xml");

                entity.Property(e => e.UploadResultXml)
                    .HasColumnType("xml")
                    .HasColumnName("upload_result_xml");

                entity.Property(e => e.Inserted)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("inserted");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrganizationId).HasColumnName("organizations_id");

                entity.Property(e => e.UserId).HasColumnName("users_id");
            });

        }

        public virtual DbSet<DBUser> Users { get; set; } = null!;
        public virtual DbSet<DBUserAccess> UserAccesses { get; set; } = null!;
        public virtual DbSet<DBLogon> Logons { get; set; } = null!;
        public virtual DbSet<DBCertificate> Certificates { get; set; } = null!;
        public virtual DbSet<DBOrganization> Organizations { get; set; } = null!;
        public virtual DbSet<DBOrganizationType> OrganizationTypes { get; set; } = null!;
        public virtual DbSet<DBOrganizationAccess> OrganizationAccess { get; set; } = null!;
        public virtual DbSet<DBRegistrationCode> RegistartionCodes { get; set; } = null!;
        public virtual DbSet<DBTemporaryCode> TemporaryCodes { get; set; } = null!;
        public virtual DbSet<DBRequestParameter> RequestParameters { get; set; } = null!;
        public virtual DbSet<DBService> Services { get; set; } = null!;
        public virtual DbSet<DBRequestCheckContractsByUser> RequestsCheckContractsByUsers { get; set; } = null!;
        public virtual DbSet<DBRequestForGovernmentByUser> RequestsForGovernmentByUsers { get; set; } = null!;
        public virtual DbSet<DBRequestOfQBCH> RequestsOfQBCH { get; set; } = null!;
        public virtual DbSet<DBRequestOfBureau> RequestsOfBureau { get; set; } = null!;
        public virtual DbSet<DBUpload> Uploads { get; set; } = null!;
    }
}