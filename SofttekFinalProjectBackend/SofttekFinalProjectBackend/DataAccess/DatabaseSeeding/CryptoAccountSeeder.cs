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
                    Mount = 1000,
                    TypeOfAccount = TypeOfAccount.Crypto,
                    Uuid = "CryptoUUID1",
                    NameOfCrypto = "Bitcoin",
                    UserId = 1
                },
                new CryptoAccount
                {
                    Id = 2,
                    Mount = 1500,
                    TypeOfAccount = TypeOfAccount.Crypto,
                    Uuid = "CryptoUUID2",
                    NameOfCrypto = "Ethereum",
                    UserId = 1
                }
            );
        }
    }
}
