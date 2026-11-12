using Microsoft.EntityFrameworkCore;

namespace bureau_data_lib
{
    public class BureauDataContext : DbContext
    {
        public BureauDataContext(DbContextOptions<BureauDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Projection of a SQL function result, not a physical table.
            modelBuilder.Entity<CreditRecord>().HasNoKey()
                .ToTable("Results", table => table.ExcludeFromMigrations());
        }

        public virtual DbSet<CreditRecord> Results { get; set; } = null!;

    }

    public class CreditRecord
    {
        public string? Xml { get; set; }
    }
}
