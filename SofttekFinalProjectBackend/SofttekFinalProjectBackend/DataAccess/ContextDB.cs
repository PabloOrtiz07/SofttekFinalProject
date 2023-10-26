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
        public DbSet<CryptoAccount> CryptoAccounts { get; set; }
        public DbSet<FiduciaryAccount> FiduciaryAccounts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var seeders = new List<IEntitySeeder>

            {   new RoleSeeder(),
                new UserSeeder(),
                new CryptoAccountSeeder(),
                new FiduciaryAccountSeeder(),
                new SaleSeeder(),
                new TransactionCryptoSeeder(),
                new TransactionFiduciarySeeder(),
                new TransactionSeeder()





            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
