using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Infrastructure;

namespace SofttekFinalProjectBackend.Logic
{
    public class TransfersManager
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;

        public TransfersManager(AccountFinder accountFinder, GestorOfOperation gestorOfOperation)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
        }

        public async Task<bool> TransfersOriginToDestination(User user, DepositFiduciary fiduciaryTransfersOrigin, TransfersFiduciary fiduciaryTransfersDestination)
        {
            try
            {
                FiduciaryAccount matchingAccountOrigin = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, fiduciaryTransfersOrigin);
                FiduciaryAccount matchingAccountDestination = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, fiduciaryTransfersDestination);

                if (matchingAccountOrigin == null || matchingAccountDestination == null)
                {
                    return false;
                }

                var result = await _gestorOfOperation.TransfersBetweenAccounts(matchingAccountOrigin, fiduciaryTransfersOrigin) &&
                             await _gestorOfOperation.DepositFiduciaryAccount(matchingAccountDestination, fiduciaryTransfersOrigin);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersOriginToDestination(User user, DepositFiduciary fiduciaryTransfersOrigin, TransfersCrypto cryptoTransfersDestination)
        {
            try
            {
                FiduciaryAccount matchingAccountOrigin = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, fiduciaryTransfersOrigin);
                CryptoAccount matchingAccountDestination = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoTransfersDestination);

                if (matchingAccountOrigin == null || matchingAccountDestination == null)
                {
                    return false;
                }

                var result = await _gestorOfOperation.TransfersBetweenAccounts(matchingAccountOrigin, fiduciaryTransfersOrigin) &&
                             await _gestorOfOperation.DepositCryptoAccount(matchingAccountDestination, fiduciaryTransfersOrigin);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersOriginToDestination(User user, DepositCrypto cryptoDepositOrigin, TransfersFiduciary fiduciaryTransfersDestination)
        {
            try
            {
                CryptoAccount matchingAccountOrigin = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoDepositOrigin);
                FiduciaryAccount matchingAccountDestination = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, fiduciaryTransfersDestination);

                if (matchingAccountOrigin == null || matchingAccountDestination == null)
                {
                    return false;
                }

                var result = await _gestorOfOperation.TransfersBetweenAccounts(matchingAccountOrigin, cryptoDepositOrigin) &&
                             await _gestorOfOperation.DepositFiduciaryAccount(matchingAccountDestination, cryptoDepositOrigin);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> TransfersOriginToDestination(User user, DepositCrypto cryptoDepositOrigin, TransfersCrypto cryptoTransfersDestination)
        {
            try
            {
                CryptoAccount matchingAccountOrigin = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoDepositOrigin);
                CryptoAccount matchingAccountDestination = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoTransfersDestination);

                if (matchingAccountOrigin == null || matchingAccountDestination == null || matchingAccountOrigin.Uuid == matchingAccountDestination.Uuid)
                {
                    return false;
                }

                var result = await _gestorOfOperation.TransfersBetweenAccounts(matchingAccountOrigin, cryptoDepositOrigin) &&
                             await _gestorOfOperation.DepositCryptoAccount(matchingAccountDestination, cryptoDepositOrigin);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
