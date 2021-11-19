using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Neusta.CompanyService.Database.Contexts;
using NUnit.Framework;

namespace Neusta.CompanyService.Database.Api.Repositories
{
    public abstract class TestBaseRepository
    {
        protected CompanyServiceDbContext context;
        private DbConnection connection;

        [SetUp]
        public void BaseSetUp()
        {
            DbContextOptions<CompanyServiceDbContext> options = new DbContextOptionsBuilder<CompanyServiceDbContext>()
                .UseSqlite(this.CreateInMemoryDatabase())
                .Options;

            context = new CompanyServiceDbContext(options);
            BaseTearDown();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [TearDown]
        public void BaseTearDown()
        {
            this.connection?.Dispose();
        }

        private DbConnection CreateInMemoryDatabase()
        {
            this.connection = new SqliteConnection("Filename=:memory:");
            this.connection.Open();
            return this.connection;
        }
    }
}