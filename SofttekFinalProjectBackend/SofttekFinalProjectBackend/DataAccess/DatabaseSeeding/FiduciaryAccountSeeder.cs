using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.Entities;
using System;
using System.Collections.Generic;

namespace SofttekFinalProjectBackend.DataAccess.DatabaseSeeding
{
    public class FiduciaryAccountSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FiduciaryAccount>().HasData(
                new FiduciaryAccount
                {
                    Id = 1,
                    Amount = 500,
                    Status = SortOfAccount.Pesos,
                    Cbu = "CBU1",
                    Alias = "Alias1",
                    AccountNumber = "12345",
                    UserId = 1
                }
            );
        }
    }
}
