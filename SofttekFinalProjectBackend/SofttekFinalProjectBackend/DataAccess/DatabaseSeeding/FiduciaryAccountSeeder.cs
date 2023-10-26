using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;

public class FiduciaryAccountSeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FiduciaryAccount>().HasData(
            new FiduciaryAccount
            {
                Id = 1,
                Amount = 500000000,
                TypeOfAccount = TypeOfAccount.Pesos,
                Cbu = "CBU1",
                Alias = "Alias1",
                AccountNumber = "12345",
                UserId = 1
            },
            new FiduciaryAccount
            {
                Id = 2,
                Amount = 1000,
                TypeOfAccount = TypeOfAccount.Dollar,
                Cbu = "CBU2",
                Alias = "Alias2",
                AccountNumber = "54321",
                UserId = 1
            },
            // Add two more fiduciary accounts for User 1
            new FiduciaryAccount
            {
                Id = 3,
                Amount = 800,
                TypeOfAccount = TypeOfAccount.Pesos,
                Cbu = "CBU3",
                Alias = "Alias3",
                AccountNumber = "67890",
                UserId = 2
            },
            new FiduciaryAccount
            {
                Id = 4,
                Amount = 1500,
                TypeOfAccount = TypeOfAccount.Dollar,
                Cbu = "CBU4",
                Alias = "Alias4",
                AccountNumber = "98765",
                UserId = 2
            }
        );
    }
}

