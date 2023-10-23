using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class TransactionFiduciaryRepository : Repository<TransactionFiduciary>, ITransactionFiduciaryRepository
    {
        private readonly IMapper _mapper;

        public TransactionFiduciaryRepository(ContextDB contextDB, AutoMapper.IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }
        public virtual async Task<TransactionFiduciary> GetAccount(string cbu, string alias, string accountNumber)
        {
            try
            {
                var entity = await _contextDB.Set<TransactionFiduciary>()
                    .FirstOrDefaultAsync(transaction =>
                        transaction.Cbu == cbu &&
                        transaction.Alias == alias &&
                        transaction.AccountNumber == accountNumber);

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public virtual async Task<int> GetIdAccount(string cbu)
        {
            try
            {
                TransactionFiduciary entity = await _contextDB.Set<TransactionFiduciary>()
                    .FirstOrDefaultAsync(transaction => transaction.Cbu == cbu);
                if (entity != null)
                {
                    return entity.Id;
                }

                return -1;

            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
