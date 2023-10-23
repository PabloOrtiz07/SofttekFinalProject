using AutoMapper;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface ITransactionFiduciaryRepository : IRepository<TransactionFiduciary>
    {
        public Task<TransactionFiduciary> GetAccount(string cbu, string alias, string accountNumber);

        public Task<int> GetIdAccount(string cbu);


    }
}
