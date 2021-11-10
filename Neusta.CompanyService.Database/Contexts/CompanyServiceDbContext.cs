using Microsoft.EntityFrameworkCore;
using Neusta.CompanyService.Database.Entities;

namespace Neusta.CompanyService.Database.Contexts
{
    public class CompanyServiceDbContext : DbContext
    {
        public CompanyServiceDbContext(DbContextOptions options) : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=CompanyServiceDatabase.db");
        }

        public DbSet<Company> Company { set; get; }
        public DbSet<CompanyAttribute> CompanyAttribute { set; get; }
        public DbSet<CompanyAttributeValue> CompanyAttributeValue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyAttributeValue>().HasKey(companyAttributeValue =>
                new {companyAttributeValue.CompanyAttributeId, companyAttributeValue.CompanyId});
        }
    }
}