using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrator",
                    Description = "Administrator",
                    IsDeleted = false,
                    DeletedTimeUtc = null,

                },
                 new Role
                 {
                     Id = 2,
                     Name = "User",
                     Description = "User",
                     IsDeleted = false,
                     DeletedTimeUtc = null,
                 });
        }
    }
}
