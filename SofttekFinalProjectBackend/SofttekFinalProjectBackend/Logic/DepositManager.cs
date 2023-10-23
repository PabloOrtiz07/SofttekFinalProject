using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Infrastructure;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Logic
{
    public class DepositManager
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;

        public DepositManager(AccountFinder accountFinder, GestorOfOperation gestorOfOperation)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
        }

        public async Task<bool> Deposit(User user, DepositFiduciary fiduciaryAccount)
        {
            try
            {
                bool result = false;

                FiduciaryAccount matchingAccount = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, fiduciaryAccount);

                if (matchingAccount == null)
                {
                    return result = false;
                }

                result = await _gestorOfOperation.DepositFiduciaryAccount(matchingAccount, fiduciaryAccount);

                return result;

            }
            catch (Exception ex)
            {
                bool result = false;
                return result;

            }
        }

        public async Task<bool> Deposit(User user, DepositCrypto cryptoAccount)
        {
            try
            {
                bool result = false;

                CryptoAccount matchingAccount = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoAccount);

                if (matchingAccount == null)
                {
                    return result;
                }

                result = await _gestorOfOperation.DepositCryptoAccount(matchingAccount, cryptoAccount);

                return result;

            }
            catch (Exception ex)
            {
                bool result = false;
                return result;

            }
        }

    }
}
