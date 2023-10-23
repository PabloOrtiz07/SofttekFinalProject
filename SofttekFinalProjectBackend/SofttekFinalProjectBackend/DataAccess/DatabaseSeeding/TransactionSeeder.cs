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
                descriptionOperation = "Sale of bitcoin",
                UserId = 1,
                IsDeleted = false,
                DeletedTimeUtc = null,
                cryptoAccountOriginId = 1,
                Amount = 100.0
            },
            new Transaction
            {
                Id = 2,
                TypeOfOperation = TypeOfOperation.Buy,
                descriptionOperation = "Purchase of ethereum",
                UserId = 2,
                IsDeleted = false,
                DeletedTimeUtc = null,
                cryptoAccountOriginId = 2,
                Amount = 50.0 
            }
        );
    }
}
