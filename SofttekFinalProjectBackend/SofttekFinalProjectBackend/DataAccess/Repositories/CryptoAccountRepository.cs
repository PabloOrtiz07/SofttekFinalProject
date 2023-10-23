using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class CryptoAccountRepository : Repository<CryptoAccount>, ICryptoAccountRepository
    {
        private readonly IMapper _mapper;

        public CryptoAccountRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        public virtual async Task<CryptoAccount> GetByUuid(string uuid)
        {
            try
            {
                var entity = await _contextDB.Set<CryptoAccount>()
                    .FirstOrDefaultAsync(account => account.Uuid == uuid);
                if (entity != null)
                {
                    return entity;
                }

                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual async Task<CryptoAccount> GetByNameOfCrypto(int userId, string name)
        {
            try
            {
                var entity = await _contextDB.Set<CryptoAccount>()
                    .FirstOrDefaultAsync(account => account.NameOfCrypto == name && account.UserId == userId);

                if (entity != null)
                {
                    return entity;
                }

                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
