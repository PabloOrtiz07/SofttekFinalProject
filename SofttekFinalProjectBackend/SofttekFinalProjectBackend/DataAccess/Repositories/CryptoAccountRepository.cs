using AutoMapper;
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
    }
}
