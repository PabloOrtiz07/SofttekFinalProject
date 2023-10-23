using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;

public class TransactionFiduciarySeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransactionFiduciary>().HasData(
            new TransactionFiduciary
            {
                Id = 1,
                Cbu = "CBU1",
                Alias = "Alias1",
                AccountNumber = "12345"
            },
            new TransactionFiduciary
            {
                Id = 2,
                Cbu = "CBU2",
                Alias = "Alias2",
                AccountNumber = "54321"
            }
        ) ;
    }
}