using legal_persons_lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace bureau_web_ui_lib
{
    public class BureauWebUIContext : DbContext
    {
        public BureauWebUIContext(DbContextOptions<BureauWebUIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBUpload>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("keyId");
                entity.Property(e => e.UploadId).HasColumnName("id");
                entity.Property(e => e.InProcess).HasColumnName("inProcess");
                entity.Property(e => e.Inserted).HasColumnName("created");
                entity.Property(e => e.OrganizationId).HasColumnName("legalPersonId");
                entity.Property(e => e.Priority).HasColumnName("priorityLoad");
                entity.Property(e => e.RegResultXml).HasColumnName("regResultXML");
                entity.Property(e => e.Status).HasColumnName("statusId");
                entity.Property(e => e.Updated).HasColumnName("lastUpdated");
                entity.Property(e => e.UploadId).HasColumnName("id");
                entity.Property(e => e.UploadResultXml).HasColumnName("uploadResultXML");
                entity.Property(e => e.UploadXML).HasColumnName("uploadingXML");
                entity.Property(e => e.UserId).HasColumnName("naturalPersonId");
                entity.ToTable("te_requestsOfUploadPostgresNew");
            });

            // Projection of a SQL function result, not a physical table.
            modelBuilder.Entity<UploadResult>().HasNoKey()
                .ToTable("UploadResults", table => table.ExcludeFromMigrations());

        }
        public virtual DbSet<DBUpload> TeRequestsOfUpload { get; set; } = null!;

        public virtual DbSet<UploadResult> UploadResults { get; set; } = null!;
    
    }

    public class UploadResult
    {
        public string? Xml { get; set; }
    }
}
