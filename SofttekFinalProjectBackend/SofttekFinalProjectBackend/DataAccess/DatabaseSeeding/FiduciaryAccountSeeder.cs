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
                    Mount = 500,  
                    TypeOfAccount = TypeOfAccount.Pesos,
                    Cbu = "CBU1",
                    Alias = "Alias1",
                    AccountNumber = "12345",
                    UserId = 1
                },
                new FiduciaryAccount
                {
                    Id = 2,
                    Mount = 1000, 
                    TypeOfAccount = TypeOfAccount.Dollar,
                    Cbu = "CBU2",
                    Alias = "Alias2",
                    AccountNumber = "54321",
                    UserId = 1
                }
            );
        }
    }
}

