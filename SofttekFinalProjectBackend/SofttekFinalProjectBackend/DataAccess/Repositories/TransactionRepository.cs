using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly IMapper _mapper;

        public TransactionRepository(ContextDB contextDB, AutoMapper.IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        public virtual async Task<List<Transaction>> GetAllTransaction()
        {
            try
            {
                var transactions = await base.GetAll();

                transactions = await _contextDB.Transactions
                        .Include(transaction => transaction.fiduciaryAccountDestination)
                        .Include(transaction => transaction.fiduciaryAccountOrigin)
                        .Include(transaction => transaction.cryptoAccountDestination)
                        .Include(transaction => transaction.cryptoAccountOrigin)
                        .Where(transaction => transaction.IsDeleted != true)
                        .ToListAsync();

                return transactions;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
