using SofttekFinalProjectBackend.Entities;
using System.Security.Principal;

namespace SofttekFinalProjectBackend.Logic
{
    public class AccountFinder
    {
        public async Task<FiduciaryAccount> FindingAccountPesosAsync(IEnumerable<FiduciaryAccount> fiduciaryAccounts, string cbu)
        {
            return await Task.Run(() => fiduciaryAccounts.FirstOrDefault(fiduciaryAccount
                => fiduciaryAccount.Cbu == cbu));
        }
        public async Task<FiduciaryAccount> FindingAccountPesosAsync(IEnumerable<FiduciaryAccount> fiduciaryAccounts)
        {
            return await Task.Run(() => fiduciaryAccounts.FirstOrDefault(fiduciaryAccount
                => fiduciaryAccount.TypeOfAccount == TypeOfAccount.Pesos));
        }

        public async Task<Sale> FindingMatchingSaleAvailableAsync(IEnumerable<Sale> sales, int saleNumber)
        {
            return await Task.Run(() => sales.SingleOrDefault(sale => sale.Id == saleNumber));
        }

        public async Task<FiduciaryAccount> FindMatchingFiduciaryAccountAsync(IEnumerable<FiduciaryAccount> accounts, WithDrawMoneyFiduciary withDrawMoneyFiduciary)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account =>
                (string.Equals(account.AccountNumber, withDrawMoneyFiduciary.AccountNumber, StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(account.Cbu, withDrawMoneyFiduciary.Cbu, StringComparison.OrdinalIgnoreCase) ||
                 (string.Equals(account.Alias, withDrawMoneyFiduciary.Alias, StringComparison.OrdinalIgnoreCase) &&
                  account.TypeOfAccount == withDrawMoneyFiduciary.TypeOfWithDraw)
            )));
        }


        public async Task<FiduciaryAccount> FindMatchingFiduciaryAccountAsync(IEnumerable<FiduciaryAccount> accounts, string cbu)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account =>
                string.Equals(account.Cbu, cbu, StringComparison.OrdinalIgnoreCase) &&
                account.TypeOfAccount == TypeOfAccount.Pesos));
        }

        public async Task<FiduciaryAccount> FindMatchingFiduciaryAccountAsync(IEnumerable<FiduciaryAccount> accounts, DepositFiduciary fiduciaryTransfersOrigin)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account =>
                (string.Equals(account.AccountNumber, fiduciaryTransfersOrigin.AccountNumber, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(account.Cbu, fiduciaryTransfersOrigin.Cbu, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(account.Alias, fiduciaryTransfersOrigin.Alias, StringComparison.OrdinalIgnoreCase))));
        }

        public async Task<FiduciaryAccount> FindMatchingFiduciaryAccountAsync(IEnumerable<FiduciaryAccount> accounts, TransfersFiduciary fiduciaryTransfersOrigin)
        {
            FiduciaryAccount matchingAccount = await Task.Run(() =>
                accounts.SingleOrDefault(account =>
                    (string.Equals(account.AccountNumber, fiduciaryTransfersOrigin.AccountNumber, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(account.Cbu, fiduciaryTransfersOrigin.Cbu, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(account.Alias, fiduciaryTransfersOrigin.Alias, StringComparison.OrdinalIgnoreCase))));

            return matchingAccount;
        }

        public async Task<CryptoAccount> FindMatchingCryptoAccountAsync(IEnumerable<CryptoAccount> accounts, TransfersCrypto cryptoTransfers)
        {
            return await Task.Run(() => accounts.FirstOrDefault(account =>
                string.Equals(account.Uuid, cryptoTransfers.Uuid, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<CryptoAccount> FindMatchingCryptoAccountAsync(IEnumerable<CryptoAccount> accounts, DepositCrypto depositCrypto)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account =>
                string.Equals(account.Uuid, depositCrypto.Uuid, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<CryptoAccount> FindMatchingCryptoAccountAsync(IEnumerable<CryptoAccount> accounts, string nameOfCrypto)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account =>
                string.Equals(account.NameOfCrypto, nameOfCrypto, StringComparison.OrdinalIgnoreCase)));
        }


    }
}