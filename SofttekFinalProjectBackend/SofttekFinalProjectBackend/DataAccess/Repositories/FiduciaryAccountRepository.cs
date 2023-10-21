using AutoMapper;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class FiduciaryAccountRepository : Repository<FiduciaryAccount>, IFiduciaryAccountRepository
    {
        private readonly IMapper _mapper;

        public FiduciaryAccountRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;

        }

    }
}
