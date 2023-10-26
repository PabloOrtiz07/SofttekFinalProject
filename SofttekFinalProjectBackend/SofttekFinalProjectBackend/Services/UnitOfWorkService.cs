using AutoMapper;
using SofttekFinalProjectBackend.DataAccess;
using SofttekFinalProjectBackend.DataAccess.Repositories;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;

        private readonly IMapper _mapper;

        public UserRepository UserRepository { get; set; }

        public FiduciaryAccountRepository FiduciaryAccountRepository { get; set; }

        public CryptoAccountRepository CryptoAccountRepository { get; set; }

        public SaleRepository SaleRepository { get; set; }

        public TransactionRepository TransactionRepository { get; set; }
        public TransactionCryptoRepository TransactionCryptoRepository { get; set; }
        public TransactionFiduciaryRepository TransactionFiduciaryRepository { get; set; }


        public UnitOfWorkService(ContextDB contextDB, IMapper mapper)
        {
            _mapper = mapper;
            _contextDB = contextDB;
            UserRepository = new UserRepository(_contextDB, _mapper);
            FiduciaryAccountRepository = new FiduciaryAccountRepository(_contextDB, _mapper);
            CryptoAccountRepository = new CryptoAccountRepository(_contextDB, _mapper);
            SaleRepository = new SaleRepository(_contextDB, _mapper);
            TransactionRepository = new TransactionRepository(_contextDB, _mapper);
            TransactionCryptoRepository = new TransactionCryptoRepository(_contextDB, _mapper);
            TransactionFiduciaryRepository = new TransactionFiduciaryRepository(_contextDB, _mapper);



        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}
