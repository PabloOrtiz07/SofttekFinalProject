using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.DatabaseSeeding;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Helper;

public class UserSeeder : IEntitySeeder
{
    public void SeedDatabase(ModelBuilder modelBuilder)
    {
     
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Email = "test@gmail.com",
                Password = PasswordEncryptHelper.EncryptPassword("123", "test@gmail.com"),
                IsDeleted = false,
                DeletedTimeUtc = null,
            }
        );

      
    }
}

