using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Infrastructure;

namespace SofttekFinalProjectBackend.Logic
{
    public class Transfers
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;

        public Transfers(AccountFinder accountFinder, GestorOfOperation gestorOfOperation)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
        }

        public async Task<bool> TransfersOriginToDestination(User user, DepositFiduciaryDTO fiduciaryTransfersOrigin, TransfersFiduciaryDTO fiduciaryTransfersDestination)
        {
            try
            {
                FiduciaryAccount matchingAccountOrigin = await _accountFinder.FindMatchingFiduciaryAccount(user.FiduciaryAccounts, fiduciaryTransfersOrigin);
                FiduciaryAccount matchingAccountDestination = await _accountFinder.FindMatchingFiduciaryAccount(user.FiduciaryAccounts, fiduciaryTransfersDestination);

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

        public async Task<bool> TransfersOriginToDestination(User user, DepositFiduciaryDTO fiduciaryTransfersOrigin, TransfersCryptoDTO cryptoTransfersDestination)
        {
            try
            {
                FiduciaryAccount matchingAccountOrigin = await _accountFinder.FindMatchingFiduciaryAccount(user.FiduciaryAccounts, fiduciaryTransfersOrigin);
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

        public async Task<bool> TransfersOriginToDestination(User user, DepositCryptoDTO cryptoDepositOrigin, TransfersFiduciaryDTO fiduciaryTransfersDestination)
        {
            try
            {
                CryptoAccount matchingAccountOrigin = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoDepositOrigin);
                FiduciaryAccount matchingAccountDestination = await _accountFinder.FindMatchingFiduciaryAccount(user.FiduciaryAccounts, fiduciaryTransfersDestination);

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

        public async Task<bool> TransfersOriginToDestination(User user, DepositCryptoDTO cryptoDepositOrigin, TransfersCryptoDTO cryptoTransfersDestination)
        {
            try
            {
                CryptoAccount matchingAccountOrigin = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoDepositOrigin);
                CryptoAccount matchingAccountDestination = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoTransfersDestination);

                if (matchingAccountOrigin == null || matchingAccountDestination == null)
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
