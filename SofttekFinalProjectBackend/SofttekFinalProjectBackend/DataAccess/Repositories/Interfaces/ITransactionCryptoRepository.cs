using AutoMapper;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface ITransactionCryptoRepository : IRepository<TransactionCrypto>
    {
        public Task<TransactionCrypto> GetByUuid(string uuid);
        public Task<int> GetIdAccount(string uuid);


    }
}
