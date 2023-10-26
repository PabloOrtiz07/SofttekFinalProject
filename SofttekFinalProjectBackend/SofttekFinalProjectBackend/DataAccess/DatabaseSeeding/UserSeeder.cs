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
                RoleId = 2
            },
            new User
            {
                Id = 2,
                Email = "user1@example.com",
                Password = PasswordEncryptHelper.EncryptPassword("password1", "user1@example.com"),
                IsDeleted = false,
                DeletedTimeUtc = null,
                RoleId = 2
            },
            new User
            {
                Id = 3,
                Email = "user2@example.com",
                Password = PasswordEncryptHelper.EncryptPassword("password2", "user2@example.com"),
                IsDeleted = false,
                DeletedTimeUtc = null,
                RoleId = 2
            },
            new User
            {
                Id = 4,
                Email = "user3@example.com",
                Password = PasswordEncryptHelper.EncryptPassword("password3", "user3@example.com"),
                IsDeleted = false,
                DeletedTimeUtc = null,
                RoleId = 2
            },
            new User
            {
                Id = 5,
                Email = "user4@example.com",
                Password = PasswordEncryptHelper.EncryptPassword("password4", "user4@example.com"),
                IsDeleted = false,
                DeletedTimeUtc = null,
                RoleId = 2
            },
            new User
            {
                Id = 6,
                Email = "user5@example.com",
                Password = PasswordEncryptHelper.EncryptPassword("password5", "user5@example.com"),
                IsDeleted = false,
                DeletedTimeUtc = null,
                RoleId = 2
            }
        );
    }
}

