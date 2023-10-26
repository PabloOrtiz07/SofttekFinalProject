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
                uuid = uuid.ToLower(); 

                var entity = await _contextDB.Set<CryptoAccount>()
                    .FirstOrDefaultAsync(account => account.Uuid.ToLower() == uuid);

                return entity; 
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
                name = name.ToLower();

                var entity = await _contextDB.Set<CryptoAccount>()
                    .FirstOrDefaultAsync(account => account.NameOfCrypto.ToLower() == name && account.UserId == userId);

                return entity; 
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
