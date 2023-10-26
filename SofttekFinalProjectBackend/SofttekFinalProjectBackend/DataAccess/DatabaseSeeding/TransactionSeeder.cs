using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;

public class TransactionSeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().HasData(
            new Transaction
            {
                Id = 1,
                TypeOfOperation = TypeOfOperation.Sale,
                descriptionOperation = "Sale",
                UserId = 1,
                IsDeleted = false,
                DeletedTimeUtc = null,
                cryptoAccountOriginId = 1,
                Amount = 100.0,
                CreatedTimeUtc = DateTime.UtcNow
            },
            new Transaction
            {
                Id = 2,
                TypeOfOperation = TypeOfOperation.Buy,
                descriptionOperation = "Buy",
                UserId = 2,
                IsDeleted = false,
                DeletedTimeUtc = null,
                fiduciaryAccountOriginId = 1,
                fiduciaryAccountDestinationId = 2,
                Amount = 50.0,
                CreatedTimeUtc = DateTime.UtcNow
            }
        );
    }
}
