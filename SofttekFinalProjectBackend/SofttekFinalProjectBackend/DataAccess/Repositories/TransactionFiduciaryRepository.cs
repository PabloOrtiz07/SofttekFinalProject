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
                cbu = cbu.ToLower();
                alias = alias.ToLower(); 
                accountNumber = accountNumber.ToLower(); 

                var entity = await _contextDB.Set<TransactionFiduciary>()
                    .FirstOrDefaultAsync(transaction =>
                        transaction.Cbu.ToLower() == cbu ||
                        transaction.Alias.ToLower() == alias ||
                        transaction.AccountNumber.ToLower() == accountNumber);

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
                cbu = cbu.ToLower(); 

                TransactionFiduciary entity = await _contextDB.Set<TransactionFiduciary>()
                    .FirstOrDefaultAsync(transaction => transaction.Cbu.ToLower() == cbu);

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
