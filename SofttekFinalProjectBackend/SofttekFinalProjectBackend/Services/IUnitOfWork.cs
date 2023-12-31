﻿using SofttekFinalProjectBackend.DataAccess.Repositories;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }

        public FiduciaryAccountRepository FiduciaryAccountRepository { get; }

        public CryptoAccountRepository CryptoAccountRepository { get; }

        public SaleRepository SaleRepository { get; }
        public TransactionRepository TransactionRepository { get; }
        public TransactionCryptoRepository TransactionCryptoRepository { get; }
        public TransactionFiduciaryRepository TransactionFiduciaryRepository { get; }

        public Task<int> Complete();

    }
}
