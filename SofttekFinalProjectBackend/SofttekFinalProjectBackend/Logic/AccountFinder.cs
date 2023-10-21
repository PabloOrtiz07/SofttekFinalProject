using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using System.Security.Principal;

namespace SofttekFinalProjectBackend.Logic
{
    public class AccountFinder
    {
        public async Task<FiduciaryAccount> FindMatchingFiduciaryAccount(IEnumerable<FiduciaryAccount> accounts, DepositFiduciaryDTO fiduciaryTransfersOrigin)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account =>
                (account.AccountNumber == fiduciaryTransfersOrigin.AccountNumber ||
                account.Cbu == fiduciaryTransfersOrigin.Cbu ||
                account.Alias == fiduciaryTransfersOrigin.Alias) &&
                account.TypeOfAccount == fiduciaryTransfersOrigin.TypeOfDeposit));
        }

        public async Task<FiduciaryAccount> FindMatchingFiduciaryAccount(IEnumerable<FiduciaryAccount> accounts, TransfersFiduciaryDTO fiduciaryTransfersOrigin)
        {
            FiduciaryAccount matchingAccount = await Task.Run(() =>
                accounts.SingleOrDefault(account =>
                    (account.AccountNumber == fiduciaryTransfersOrigin.AccountNumber ||
                    account.Cbu == fiduciaryTransfersOrigin.Cbu ||
                    account.Alias == fiduciaryTransfersOrigin.Alias)));

            return matchingAccount;
        }


        public async Task<CryptoAccount> FindMatchingCryptoAccountAsync(IEnumerable<CryptoAccount> accounts, TransfersCryptoDTO cryptoTransfers)
        {
            return await Task.Run(() => accounts.FirstOrDefault(account => account.Uuid == cryptoTransfers.Uuid));
        }

        public async Task<CryptoAccount> FindMatchingCryptoAccountAsync(IEnumerable<CryptoAccount> accounts, DepositCryptoDTO depositCrypto)
        {
            return await Task.Run(() => accounts.SingleOrDefault(account => account.Uuid == depositCrypto.Uuid));
        }


    }
}
