using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;

public class TransactionCryptoSeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransactionCrypto>().HasData(
            new TransactionCrypto
            {
                Id = 1,
                Uuid = "CryptoUUID1"
            },
            new TransactionCrypto
            {
                Id = 2,
                Uuid = "CryptoUUID2"
            }
        );
    }
}






