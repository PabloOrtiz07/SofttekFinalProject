using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace SofttekFinalProjectBackend.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);

    }
}
