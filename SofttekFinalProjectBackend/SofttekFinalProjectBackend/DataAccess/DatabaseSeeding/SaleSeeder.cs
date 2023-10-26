using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;

public class SaleSeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>().HasData(
            new Sale
            {
                Id = 1,
                Amount = 100.0,
                NameOfCrypto = "bitcoin",
                IsDeleted = false,
                DeletedTimeUtc = null,
                CbuAccountPesos = "CBU1"            },
            new Sale
            {
                Id = 2,
                Amount = 50.0,
                NameOfCrypto = "ethereum",
                IsDeleted = false,
                DeletedTimeUtc = null,
                CbuAccountPesos = "CBU1"            },
            new Sale
            {
                Id = 3,
                Amount = 75.0,
                NameOfCrypto = "bitcoin",
                IsDeleted = false,
                DeletedTimeUtc = null,
                CbuAccountPesos = "CBU3"            },
            new Sale
            {
                Id = 4,
                Amount = 60.0,
                NameOfCrypto = "ethereum",
                IsDeleted = false,
                DeletedTimeUtc = null,
                CbuAccountPesos = "CBU3"            },
            new Sale
            {
                Id = 5,
                Amount = 1,
                NameOfCrypto = "bitcoin",
                IsDeleted = false,
                DeletedTimeUtc = null,
                CbuAccountPesos = "CBU3"            }
        );
    }
}
