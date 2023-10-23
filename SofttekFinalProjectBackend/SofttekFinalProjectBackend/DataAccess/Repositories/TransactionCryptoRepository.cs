using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.Entities;
using System;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class TransactionCryptoRepository : Repository<TransactionCrypto>, ITransactionCryptoRepository
    {
        private readonly IMapper _mapper;

        public TransactionCryptoRepository(ContextDB contextDB, AutoMapper.IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }
        public virtual async Task<TransactionCrypto> GetByUuid(string uuid)
        {
            try
            {
                uuid = uuid.ToLower();

                var entity = await _contextDB.Set<TransactionCrypto>()
                    .FirstOrDefaultAsync(transaction => transaction.Uuid.ToLower() == uuid);

                return entity; 
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<int> GetIdAccount(string uuid)
        {
            try
            {
                uuid = uuid.ToLower(); 

                TransactionCrypto entity = await _contextDB.Set<TransactionCrypto>()
                    .FirstOrDefaultAsync(transaction => transaction.Uuid.ToLower() == uuid);

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
