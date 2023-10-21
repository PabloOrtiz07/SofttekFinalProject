using AutoMapper;
using SofttekFinalProjectBackend.DataAccess;
using SofttekFinalProjectBackend.DataAccess.Repositories;

namespace SofttekFinalProjectBackend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;

        private readonly IMapper _mapper;

        public UserRepository UserRepository { get; set; }

        public FiduciaryAccountRepository FiduciaryAccountRepository { get; set; }

        public CryptoAccountRepository CryptoAccountRepository { get; set; }


        public UnitOfWorkService(ContextDB contextDB, IMapper mapper)
        {
            _mapper = mapper;
            _contextDB = contextDB;
            UserRepository = new UserRepository(_contextDB, _mapper);
            FiduciaryAccountRepository = new FiduciaryAccountRepository(_contextDB, _mapper);
            CryptoAccountRepository = new CryptoAccountRepository(_contextDB, _mapper);

        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}
