using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Logic
{
    public class WithDrawManager
    {
        private readonly AccountFinder _accountFinder;
        private readonly GestorOfOperation _gestorOfOperation;

        public WithDrawManager(AccountFinder accountFinder, GestorOfOperation gestorOfOperation)
        {
            _accountFinder = accountFinder;
            _gestorOfOperation = gestorOfOperation;
        }
        public async Task<bool> WithDraw(User user, WithDrawMoneyCrypto withDrawMoneyCrypto)
        {
            try
            {
                bool result = false;

                FiduciaryAccount matchingFiduciaryAccount = await _accountFinder.FindingAccountPesosAsync(user.FiduciaryAccounts);
                CryptoAccount matchingCryptoAccount = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, withDrawMoneyCrypto.NameOfCrypto);

                if (matchingFiduciaryAccount == null &&  matchingCryptoAccount == null)
                {
                    return result = false;
                }

                result = await _gestorOfOperation.WithDrawCryptoAccount(matchingFiduciaryAccount, matchingCryptoAccount, withDrawMoneyCrypto);

                return result;

            }
            catch (Exception ex)
            {
                bool result = false;
                return result;

            }
        }

        public async Task<bool> WithDraw(User user, WithDrawMoneyFiduciary withDrawMoneyFiduciary)
        {
            try
            {
                bool result = false;

                FiduciaryAccount matchingAccount = await _accountFinder.FindMatchingFiduciaryAccountAsync(user.FiduciaryAccounts, withDrawMoneyFiduciary);

                if (matchingAccount == null)
                {
                    return result = false;
                }

                result = await _gestorOfOperation.WithDrawFiduciaryAccount(matchingAccount, withDrawMoneyFiduciary);

                return result;

            }
            catch (Exception ex)
            {
                bool result = false;
                return result;

            }
        }

        public async Task<bool> WithDraw(User user, DepositCrypto cryptoAccount)
        {
            try
            {
                bool result = false;

                CryptoAccount matchingAccount = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoAccount);

                if (matchingAccount == null)
                {
                    return result;
                }

                await _gestorOfOperation.DepositCryptoAccount(matchingAccount, cryptoAccount);

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
