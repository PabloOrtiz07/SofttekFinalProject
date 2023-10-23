using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Logic
{
    public class SaleManager
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;

        public SaleManager(AccountFinder accountFinder, GestorOfOperation gestorOfOperation)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
        }

        public async Task<bool> Sale(User user, SaleRequestDTO saleRequest)
        {
            try
            {
                bool result = false;

                FiduciaryAccount matchingAccountFiduciaryAccount = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, saleRequest.CbuAccountPesos);
                CryptoAccount matchingAccountCrypto = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, saleRequest.NameOfCrypto);

                if (matchingAccountCrypto == null || matchingAccountCrypto == null)
                {
                    return false;
                }

                result = await _gestorOfOperation.PublishSale(matchingAccountCrypto, saleRequest);

                return result;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
