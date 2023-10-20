using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;


namespace SofttekFinalProjectBackend.DataAccess
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<CryptoAccount> CryptoAccount { get; set; }
        public DbSet<FiduciaryAccount> FiduciaryAccount { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new CryptoAccountSeeder(),
                new FiduciaryAccountSeeder()


            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
