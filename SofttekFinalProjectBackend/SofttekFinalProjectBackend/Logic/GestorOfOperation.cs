using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Infrastructure;
using SofttekFinalProjectBackend.Services;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<bool> WithDrawCryptoAccount(FiduciaryAccount matchingFiduciaryAccount, CryptoAccount matchingCryptoAccount, WithDrawMoneyCrypto withDrawMoneyCrypto)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingFiduciaryAccount, withDrawMoneyCrypto);

                if (matchingCryptoAccount.Amount - withDrawMoneyCrypto.Amount >= 0)
                {
                    matchingCryptoAccount.Amount -= withDrawMoneyCrypto.Amount;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> WithDrawFiduciaryAccount(FiduciaryAccount matchingAccount, WithDrawMoneyFiduciary withDrawMoneyFiduciary)
        {
            try
            {
                double convertedAmount = withDrawMoneyFiduciary.Amount;

                if (matchingAccount.Amount - convertedAmount >= 0)
                {
                    matchingAccount.Amount -= convertedAmount;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DepositFiduciaryAccount(FiduciaryAccount matchingAccount, DepositCrypto cryptoDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingAccount, cryptoDeposit);

                matchingAccount.Amount += convertedAmount;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DepositFiduciaryAccount(FiduciaryAccount matchingAccount, DepositFiduciary fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingAccount, fiduciaryDeposit);

                matchingAccount.Amount += convertedAmount;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DepositCryptoAccount(CryptoAccount matchingAccount, DepositFiduciary fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(matchingAccount, fiduciaryDeposit);

                matchingAccount.Amount += convertedAmount;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DepositCryptoAccount(CryptoAccount matchingAccount, DepositCrypto cryptoDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(matchingAccount, cryptoDeposit);

                matchingAccount.Amount += convertedAmount;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersBetweenAccounts(FiduciaryAccount matchingAccount, DepositFiduciary fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountFiduciary(matchingAccount, fiduciaryDeposit);

                if (matchingAccount.Amount - convertedAmount >= 0)
                {
                    matchingAccount.Amount -= convertedAmount;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersBetweenAccounts(CryptoAccount matchingAccount, DepositCrypto cryptoDeposit)
        {
            try
            {
                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(matchingAccount, cryptoDeposit);

                if (matchingAccount.Amount - convertedAmount >= 0)
                {
                    matchingAccount.Amount -= convertedAmount;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> PublishSale(CryptoAccount matchingAccount, SaleRequestDTO saleRequest)
        {
            try
            {
                bool result = false;
                if (matchingAccount.Amount - saleRequest.Amount >= 0)
                {
                    matchingAccount.Amount -= saleRequest.Amount;
                    result = await _unitOfWork.SaleRepository.SaveSaleDTO(saleRequest);
                    if (result == false)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Buy(Sale sale, FiduciaryAccount fiduciaryAccountOrigin, FiduciaryAccount fiduciaryAccountDestination, CryptoAccount cryptoAccountOrigin)
        {
            try
            {
                bool result = false;

                double convertedAmount = await _calculateManager.CalculateConvertedAmountCrypto(sale);

                if(fiduciaryAccountOrigin.Amount - convertedAmount >= 0)
                {
                    fiduciaryAccountOrigin.Amount -= convertedAmount;
                    fiduciaryAccountDestination.Amount += convertedAmount;
                    cryptoAccountOrigin.Amount += sale.Amount;
                    result = await _unitOfWork.SaleRepository.DeleteSaleById(sale.Id);
                    if (result == false)
                    {
                        return false;
                    }
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
