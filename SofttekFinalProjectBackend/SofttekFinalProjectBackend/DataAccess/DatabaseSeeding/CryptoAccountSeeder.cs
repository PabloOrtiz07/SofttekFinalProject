using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;

public class CryptoAccountSeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CryptoAccount>().HasData(
            new CryptoAccount
            {
                Id = 1,
                Amount = 1000,
                TypeOfAccount = TypeOfAccount.Crypto,
                Uuid = "CryptoUUID1",
                NameOfCrypto = "Bitcoin",
                UserId = 1
            },
            new CryptoAccount
            {
                Id = 2,
                Amount = 1500,
                TypeOfAccount = TypeOfAccount.Crypto,
                Uuid = "CryptoUUID2",
                NameOfCrypto = "Ethereum",
                UserId = 1
            },
            // Add two more crypto accounts for User 1
            new CryptoAccount
            {
                Id = 3,
                Amount = 800,
                TypeOfAccount = TypeOfAccount.Crypto,
                Uuid = "CryptoUUID3",
                NameOfCrypto = "Litecoin",
                UserId = 2
            },
            new CryptoAccount
            {
                Id = 4,
                Amount = 2000,
                TypeOfAccount = TypeOfAccount.Crypto,
                Uuid = "CryptoUUID4",
                NameOfCrypto = "Ripple",
                UserId = 2
            }
            // You can add more crypto accounts for other users as needed
        );
    }
}

