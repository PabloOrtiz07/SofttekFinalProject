using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Services;
using System.Security.Principal;

namespace SofttekFinalProjectBackend.Logic
{
    public class SaveTransactionManager
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;
        private readonly IUnitOfWork _unitOfWork;

        public SaveTransactionManager(AccountFinder accountFinder, GestorOfOperation gestorOfOperation, IUnitOfWork unitOfWork)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SaveTransactionWithDraw(int idUser,WithDrawMoneyFiduciary withDrawMoneyFiduciary)
        {
            try
            {
                TransactionFiduciary result 
                    = await _unitOfWork.TransactionFiduciaryRepository.GetAccount(withDrawMoneyFiduciary.Cbu, withDrawMoneyFiduciary.Alias, withDrawMoneyFiduciary.AccountNumber);
                if (result == null)
                {
                    FiduciaryAccount accountFinding 
                        = await _unitOfWork.FiduciaryAccountRepository.GetAccount(withDrawMoneyFiduciary.Cbu, withDrawMoneyFiduciary.Alias, withDrawMoneyFiduciary.AccountNumber);

                    result = new TransactionFiduciary
                    {
                        Cbu = accountFinding.Cbu,
                        Alias = accountFinding.Alias,
                        AccountNumber = accountFinding.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(result);
                }

                int idAccount = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(result.Cbu);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.WithDraw,
                    descriptionOperation = "WithDraw",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    fiduciaryAccountOriginId = idAccount,
                    Amount = withDrawMoneyFiduciary.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> SaveTransactionWithDraw(int idUser, WithDrawMoneyCrypto withDrawMoneyCrypto)
        {
            try
            {
                TransactionCrypto result = await _unitOfWork.TransactionCryptoRepository.GetByUuid(withDrawMoneyCrypto.Uuid);
                if (result == null)
                {
                    CryptoAccount accountFinding = await _unitOfWork.CryptoAccountRepository.GetByUuid(withDrawMoneyCrypto.Uuid);

                    result = new TransactionCrypto
                    {
                        Uuid = accountFinding.Uuid
                    };

                    await _unitOfWork.TransactionCryptoRepository.Insert(result);
                }

                int idAccount = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(result.Uuid);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.WithDraw,
                    descriptionOperation = "WithDraw",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    cryptoAccountOriginId = idAccount,
                    Amount = withDrawMoneyCrypto.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionDeposit(int idUser, DepositFiduciary depositFiduciary)
        {
            try
            {
                TransactionFiduciary result 
                    = await _unitOfWork.TransactionFiduciaryRepository.GetAccount(depositFiduciary.Cbu, depositFiduciary.Alias, depositFiduciary.AccountNumber);
                if (result == null)
                {
                    FiduciaryAccount accountFinding
                        = await _unitOfWork.FiduciaryAccountRepository.GetAccount(depositFiduciary.Cbu, depositFiduciary.Alias, depositFiduciary.AccountNumber);

                    result = new TransactionFiduciary
                    {
                        Cbu = accountFinding.Cbu,
                        Alias = accountFinding.Alias,
                        AccountNumber = accountFinding.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(result);
                }

                int idAccount = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(result.Cbu);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Deposit,
                    descriptionOperation = "Deposit",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    fiduciaryAccountOriginId = idAccount,
                    Amount = depositFiduciary.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionDeposit(int idUser, DepositCrypto depositCrypto)
        {
            try
            {
                TransactionCrypto result = await _unitOfWork.TransactionCryptoRepository.GetByUuid(depositCrypto.Uuid);
                if (result == null)
                {
                    CryptoAccount accountFinding = await _unitOfWork.CryptoAccountRepository.GetByUuid(depositCrypto.Uuid);

                    result = new TransactionCrypto
                    {
                        Uuid = accountFinding.Uuid
                    };

                    await _unitOfWork.TransactionCryptoRepository.Insert(result);
                }

                int idAccount = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(result.Uuid);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Deposit,
                    descriptionOperation = "Deposit",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    cryptoAccountOriginId = idAccount,
                    Amount = depositCrypto.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionSale(int idUser, SaleRequestDTO saleRequest)
        {
            try
            {
                CryptoAccount accountFinding = await _unitOfWork.CryptoAccountRepository.GetByNameOfCrypto(idUser,saleRequest.NameOfCrypto);

                TransactionCrypto result = await _unitOfWork.TransactionCryptoRepository.GetByUuid(accountFinding.Uuid);
                if (result == null)
                {

                    result = new TransactionCrypto
                    {
                        Uuid = accountFinding.Uuid
                    };

                    await _unitOfWork.TransactionCryptoRepository.Insert(result);
                }

                int idAccount = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(result.Uuid);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Sale,
                    descriptionOperation = "Sale",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    cryptoAccountOriginId = idAccount,
                    Amount = saleRequest.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> SaveTransactionBuy(int idUser, int saleId)
        {
            try
            {
                Sale saleFinding = await _unitOfWork.SaleRepository.GetById(saleId);
                FiduciaryAccount saleAccount = await _unitOfWork.FiduciaryAccountRepository.GetAccount(saleFinding.CbuAccountPesos,"","");
                FiduciaryAccount userAccount = await _unitOfWork.FiduciaryAccountRepository.GetAccountInPesos(idUser);

                TransactionFiduciary resultSale
                    = await _unitOfWork.TransactionFiduciaryRepository.GetAccount(saleAccount.Cbu, saleAccount.Alias, saleAccount.AccountNumber);
                TransactionFiduciary resultBuy
                   = await _unitOfWork.TransactionFiduciaryRepository.GetAccount(saleAccount.Cbu, saleAccount.Alias, saleAccount.AccountNumber);
                if (resultSale == null)
                {

                    resultSale = new TransactionFiduciary
                    {
                        Cbu = saleAccount.Cbu,
                        Alias = saleAccount.Alias,
                        AccountNumber = saleAccount.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(resultSale);
                }
                if (resultBuy == null)
                {

                    resultBuy = new TransactionFiduciary
                    {
                        Cbu = userAccount.Cbu,
                        Alias = userAccount.Alias,
                        AccountNumber = userAccount.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(resultBuy);
                }

                int idAccountSeller = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(resultSale.Cbu);
                int idAccountBuyer = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(resultBuy.Cbu);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Buy,
                    descriptionOperation = "Buy",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    fiduciaryAccountOriginId = idAccountBuyer,
                    fiduciaryAccountDestinationId = idAccountSeller,
                    Amount = saleFinding.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionTransfers(int idUser, DepositFiduciary fiduciaryOrigin, TransfersFiduciary fiduciaryDestination)
        {
            try
            {
                TransactionFiduciary resultOrigin =
                    await _unitOfWork.TransactionFiduciaryRepository.GetAccount(fiduciaryOrigin.Cbu, fiduciaryOrigin.Alias, fiduciaryOrigin.AccountNumber);

                if (resultOrigin == null)
                {
                    FiduciaryAccount accountFindingOrigin
                        = await _unitOfWork.FiduciaryAccountRepository.GetAccount(fiduciaryOrigin.Cbu, fiduciaryOrigin.Alias, fiduciaryOrigin.AccountNumber);

                    resultOrigin = new TransactionFiduciary
                    {
                        Cbu = accountFindingOrigin.Cbu,
                        Alias = accountFindingOrigin.Alias,
                        AccountNumber = accountFindingOrigin.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(resultOrigin);
                }
                TransactionFiduciary resultDestination =
                        await _unitOfWork.TransactionFiduciaryRepository.GetAccount(fiduciaryDestination.Cbu, fiduciaryDestination.Alias, fiduciaryDestination.AccountNumber);

                if (resultDestination == null)
                {
                    FiduciaryAccount accountFindingDestination
                        = await _unitOfWork.FiduciaryAccountRepository.GetAccount(fiduciaryDestination.Cbu, fiduciaryDestination.Alias, fiduciaryDestination.AccountNumber);

                    resultDestination = new TransactionFiduciary
                    {
                        Cbu = accountFindingDestination.Cbu,
                        Alias = accountFindingDestination.Alias,
                        AccountNumber = accountFindingDestination.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(resultDestination);
                }

                int idAccountOrigin = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(resultOrigin.Cbu);
                int idAccountDestination = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(resultDestination.Cbu);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Transfers,
                    descriptionOperation = "Transfers",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    fiduciaryAccountOriginId= idAccountOrigin,
                    fiduciaryAccountDestinationId = idAccountDestination,
                    Amount = fiduciaryOrigin.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionTransfers(int idUser, DepositFiduciary fiduciaryOrigin, TransfersCrypto cryptoDestination)
        {
            try
            {
                TransactionFiduciary resultOrigin =
                    await _unitOfWork.TransactionFiduciaryRepository.GetAccount(fiduciaryOrigin.Cbu, fiduciaryOrigin.Alias, fiduciaryOrigin.AccountNumber);

                if (resultOrigin == null)
                {
                    FiduciaryAccount accountFindingOrigin
                        = await _unitOfWork.FiduciaryAccountRepository.GetAccount(fiduciaryOrigin.Cbu, fiduciaryOrigin.Alias, fiduciaryOrigin.AccountNumber);

                    resultOrigin = new TransactionFiduciary
                    {
                        Cbu = accountFindingOrigin.Cbu,
                        Alias = accountFindingOrigin.Alias,
                        AccountNumber = accountFindingOrigin.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(resultOrigin);
                }


                TransactionCrypto resultDestination =
                        await _unitOfWork.TransactionCryptoRepository.GetByUuid(cryptoDestination.Uuid);

                if (resultDestination == null)
                {
                    CryptoAccount accountFindingDestination = await _unitOfWork.CryptoAccountRepository.GetByUuid(cryptoDestination.Uuid);

                    resultDestination = new TransactionCrypto
                    {
                        Uuid = accountFindingDestination.Uuid
                    };
                    await _unitOfWork.TransactionCryptoRepository.Insert(resultDestination);

                }



                int idAccountOrigin = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(resultOrigin.Cbu);
                int idAccountDestination = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(resultDestination.Uuid);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Transfers,
                    descriptionOperation = "Transfers",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    fiduciaryAccountOriginId = idAccountOrigin,
                    cryptoAccountDestinationId = idAccountDestination,
                    Amount = fiduciaryOrigin.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionTransfers(int idUser, DepositCrypto cryptoOrigin , TransfersFiduciary  fiduciaryDestination)
        {
            try
            {

                TransactionCrypto resultOrigin =
                        await _unitOfWork.TransactionCryptoRepository.GetByUuid(cryptoOrigin.Uuid);

                if (resultOrigin == null)
                {
                    CryptoAccount accountFindingOrigin = await _unitOfWork.CryptoAccountRepository.GetByUuid(cryptoOrigin.Uuid);

                    resultOrigin = new TransactionCrypto
                    {
                        Uuid = accountFindingOrigin.Uuid
                    };
                    await _unitOfWork.TransactionCryptoRepository.Insert(resultOrigin);

                }


                TransactionFiduciary resultDestination =
                        await _unitOfWork.TransactionFiduciaryRepository.GetAccount(fiduciaryDestination.Cbu, fiduciaryDestination.Alias, fiduciaryDestination.AccountNumber);

                if (resultDestination == null)
                {
                    FiduciaryAccount accountFindingDestination
                        = await _unitOfWork.FiduciaryAccountRepository.GetAccount(fiduciaryDestination.Cbu, fiduciaryDestination.Alias, fiduciaryDestination.AccountNumber);

                    resultDestination = new TransactionFiduciary
                    {
                        Cbu = accountFindingDestination.Cbu,
                        Alias = accountFindingDestination.Alias,
                        AccountNumber = accountFindingDestination.AccountNumber
                    };

                    await _unitOfWork.TransactionFiduciaryRepository.Insert(resultDestination);
                }

                int idAccountOrigin = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(resultOrigin.Uuid);
                int idAccountDestination = await _unitOfWork.TransactionFiduciaryRepository.GetIdAccount(resultDestination.Cbu);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Transfers,
                    descriptionOperation = "Transfers",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    fiduciaryAccountDestinationId = idAccountDestination,
                    cryptoAccountOriginId = idAccountOrigin,
                    Amount = cryptoOrigin.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveTransactionTransfers(int idUser, DepositCrypto cryptoOrigin, TransfersCrypto cryptoDestination)
        {
            try
            {

                TransactionCrypto resultOrigin =
                        await _unitOfWork.TransactionCryptoRepository.GetByUuid(cryptoOrigin.Uuid);

                if (resultOrigin == null)
                {
                    CryptoAccount accountFindingOrigin = await _unitOfWork.CryptoAccountRepository.GetByUuid(cryptoOrigin.Uuid);

                    resultOrigin = new TransactionCrypto
                    {
                        Uuid = accountFindingOrigin.Uuid
                    };
                    await _unitOfWork.TransactionCryptoRepository.Insert(resultOrigin);

                }


                TransactionCrypto resultDestination =
                        await _unitOfWork.TransactionCryptoRepository.GetByUuid(cryptoDestination.Uuid);

                if (resultDestination == null)
                {
                    CryptoAccount accountFindingDestination = await _unitOfWork.CryptoAccountRepository.GetByUuid(cryptoDestination.Uuid);

                    resultDestination = new TransactionCrypto
                    {
                        Uuid = accountFindingDestination.Uuid
                    };
                    await _unitOfWork.TransactionCryptoRepository.Insert(resultDestination);

                }


                int idAccountOrigin = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(resultOrigin.Uuid);
                int idAccountDestination = await _unitOfWork.TransactionCryptoRepository.GetIdAccount(resultDestination.Uuid);

                Transaction newTransaction = new Transaction
                {
                    TypeOfOperation = TypeOfOperation.Transfers,
                    descriptionOperation = "Transfers",
                    UserId = idUser,
                    IsDeleted = false,
                    DeletedTimeUtc = null,
                    cryptoAccountDestinationId = idAccountDestination,
                    cryptoAccountOriginId = idAccountOrigin,
                    Amount = cryptoOrigin.Amount
                };
                await _unitOfWork.TransactionRepository.Insert(newTransaction);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
