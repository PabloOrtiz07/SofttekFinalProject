using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Infrastructure;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Logic
{
    public class GestorOfOperation
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConversionManager _conversionManager;
        private readonly CalculateManager _calculateManager;

        public GestorOfOperation (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _conversionManager = new ConversionManager();
            _calculateManager = new CalculateManager(_conversionManager);
        }

        public async Task<bool> DepositFiduciaryAccount(FiduciaryAccount matchingAccount, DepositCryptoDTO cryptoDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingAccount, cryptoDeposit);

                matchingAccount.Mount += convertedAmount;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DepositFiduciaryAccount(FiduciaryAccount matchingAccount, DepositFiduciaryDTO fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingAccount, fiduciaryDeposit);

                matchingAccount.Mount += convertedAmount;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DepositCryptoAccount(CryptoAccount matchingAccount, DepositFiduciaryDTO fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(matchingAccount, fiduciaryDeposit);

                matchingAccount.Mount += convertedAmount;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DepositCryptoAccount(CryptoAccount matchingAccount, DepositCryptoDTO cryptoDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(matchingAccount, cryptoDeposit);

                matchingAccount.Mount += convertedAmount;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersBetweenAccounts(FiduciaryAccount matchingAccount, DepositFiduciaryDTO fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingAccount, fiduciaryDeposit);

                if (matchingAccount.Mount >= 0)
                {
                    matchingAccount.Mount += convertedAmount;
                    await _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersBetweenAccounts(CryptoAccount matchingAccount, DepositCryptoDTO cryptoDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(matchingAccount, cryptoDeposit);

                if (matchingAccount.Mount >= 0)
                {
                    matchingAccount.Mount += convertedAmount;
                    await _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Buy()
        {
            try
            {
          

                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
