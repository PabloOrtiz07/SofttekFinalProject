using Microsoft.EntityFrameworkCore.Query;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Logic
{
    public class BuyManager
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;

        public BuyManager(AccountFinder accountFinder, GestorOfOperation gestorOfOperation)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
        }

        public async Task<bool> Buy(User user, IEnumerable<Sale> sales ,int saleNumber, IEnumerable<FiduciaryAccount> allAccounts)
        {
            try
            {
                bool result = false;
                
                Sale sale = await _accountFinder.FindingMatchingSaleAvailableAsync(sales, saleNumber);
                FiduciaryAccount fiduciaryAccountPesosOrigin = await _accountFinder.FindingAccountPesosAsync(user.FiduciaryAccounts);
                FiduciaryAccount fiduciaryAccountPesosDestination = await _accountFinder.FindingAccountPesosAsync(allAccounts,sale.CbuAccountPesos);
                CryptoAccount cryptoAccountOrigin = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, sale.NameOfCrypto);

                if (sale == null || fiduciaryAccountPesosOrigin == null || fiduciaryAccountPesosDestination == null || cryptoAccountOrigin == null)
                {
                    return  false;
                }

                if (fiduciaryAccountPesosOrigin.Cbu == fiduciaryAccountPesosDestination.Cbu)
                {
                    return false;
                }

                result = await _gestorOfOperation.Buy(sale, fiduciaryAccountPesosOrigin, fiduciaryAccountPesosDestination,cryptoAccountOrigin);
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
