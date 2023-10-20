using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.DatabaseSeeding
{
    public class CryptoAccountSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CryptoAccount>().HasData(
                new CryptoAccount
                {
                    Id = 1,
                    Amount = 1000,
                    Status = SortOfAccount.Crypto,
                    Uuid = "CryptoUUID1",
                    Description = "Bitcoin",
                    UserId = 1
                },
                new CryptoAccount
                {
                    Id = 2,
                    Amount = 1500,
                    Status = SortOfAccount.Crypto,
                    Uuid = "CryptoUUID2",
                    Description = "Ethereum",
                    UserId = 1
                }
            );
        }
    }
}
