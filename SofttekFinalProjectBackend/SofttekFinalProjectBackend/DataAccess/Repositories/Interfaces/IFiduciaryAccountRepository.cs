using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface IFiduciaryAccountRepository : IRepository<FiduciaryAccount>
    {
        public Task<List<FiduciaryAccount>> GetAllAccountInPesos();
        public Task<FiduciaryAccount> GetAccount(string cbu, string alias, string accountNumber);

        public Task<FiduciaryAccount> GetAccountInPesos(int userId);


    }
}
