using Microsoft.EntityFrameworkCore;

namespace private_lib
{
    public class BureauUsersContext : DbContext
    {
        public BureauUsersContext(DbContextOptions<BureauUsersContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LegalPerson>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("td_legalPersons");
            });
               
            modelBuilder.Entity<NaturalPerson>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("td_naturalPersons");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("td_certificates");
            });

        }
        public virtual DbSet<LegalPerson> TdLegalPersons { get; set; } = null!;
        public virtual DbSet<NaturalPerson> TdNaturalPersons { get; set; } = null!;
        public virtual DbSet<Certificate> TdCertificates { get; set; } = null!;
    }


    public class BureauWebUIContext : DbContext
    {
        public BureauWebUIContext(DbContextOptions<BureauWebUIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestOfCertificate>(entity =>
            {
                entity.HasKey(e => e.KeyId);
                entity.ToTable("te_requestsOfCertificates");
            });

        }
        public virtual DbSet<RequestOfCertificate> TeRequestsOfCertificates { get; set; } = null!;
    }

    public class LegalPerson
    {
        public long KeyId { get; set; }
        public DateTime? Created { get; set; }
        public string? ITN { get; set; }
        public string? Caption { get; set; } = null!;
        public string? TaxServiceData { get; set; } = null!;
        public string? Settings { get; set; }
        public bool Active { get; set; } = false;
    }

    public class NaturalPerson
    {
        public long KeyId { get; set; }
        public DateTime? Created { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long? LegalPersonId { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Caption { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? Settings { get; set; }
        public string? IpMasks { get; set; }
        public int AccessLevel { get; set; } = 1;
    }

    public class Certificate
    {
        public long KeyId { get; set; }
        public long? RequestId { get; set; }
        public long? LegalPersonId { get; set; }
        public long? NaturalPersonId { get; set; }
        public string SerialNumber { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? Data { get; set; }
        public string? IpMasks { get; set; }
        public bool Active { get; set; }
        public bool? TestOnly { get; set; }
    }

    public class RequestOfCertificate
    {
        public long KeyId { get; set; }
        public DateTime? Inserted { get; set; }
        public long NaturalPersonId { get; set; }
        public string Data { get; set; } = null!;
        public int? Status { get; set; }
        public string? Certificate { get; set; }
        public DateTime? Issued { get; set; }
        public DateTime? Expire { get; set; }
    }



}
