using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface ICryptoAccountRepository : IRepository<CryptoAccount>
    {
        public Task<CryptoAccount> GetByUuid(string uuid);

        public Task<CryptoAccount> GetByNameOfCrypto(int userId, string name);


    }
}
