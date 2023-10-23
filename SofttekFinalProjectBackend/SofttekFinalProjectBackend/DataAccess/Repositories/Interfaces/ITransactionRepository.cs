using System.Transactions;
using SofttekFinalProjectBackend.Entities;
using Transaction = SofttekFinalProjectBackend.Entities.Transaction;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public Task<List<Transaction>> GetAllTransaction();

    }
}
