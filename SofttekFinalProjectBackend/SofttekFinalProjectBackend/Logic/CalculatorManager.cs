using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Logic
{
    public class CalculateManager
    {
        private readonly ConversionManager _conversionManager;

        public CalculateManager(ConversionManager conversionManager)
        {
            _conversionManager = conversionManager;
        }

        public async Task<double> CalculateConvertedAmountFiduciary(FiduciaryAccount matchingAccount, DepositCryptoDTO cryptoDeposit)
        {
            double convertedAmount = 0;

            switch (matchingAccount.TypeOfAccount)
            {
                case TypeOfAccount.Pesos when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto:
                    double dollar = await _conversionManager.ConvertCryptoToDollar(cryptoDeposit.NameOfCrypto.ToLower(), cryptoDeposit.Mount);
                    convertedAmount = await _conversionManager.ConvertDollarToPesos(dollar);
                    break;

                case TypeOfAccount.Dollar when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto:
                    convertedAmount = await _conversionManager.ConvertCryptoToDollar(cryptoDeposit.NameOfCrypto.ToLower(), cryptoDeposit.Mount);
                    break;
            }

            return convertedAmount;
        }

        public async Task<double> CalculateConvertedAmountFiduciary(FiduciaryAccount matchingAccount, DepositFiduciaryDTO fiduciaryDeposit)
        {
            double convertedAmount = 0;

            switch (matchingAccount.TypeOfAccount)
            {
                case TypeOfAccount.Pesos when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                    convertedAmount = await _conversionManager.ConvertDollarToPesos(fiduciaryDeposit.Mount);
                    break;

                case TypeOfAccount.Dollar when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                    convertedAmount = await _conversionManager.ConvertPesosToDollar(fiduciaryDeposit.Mount);
                    break;

                case TypeOfAccount.Pesos when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                    convertedAmount = fiduciaryDeposit.Mount;
                    break;

                case TypeOfAccount.Dollar when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                    convertedAmount = fiduciaryDeposit.Mount;
                    break;

            }

            return convertedAmount;
        }

        public async Task<double> CalculateConvertedAmountCrypto(CryptoAccount matchingAccount, DepositFiduciaryDTO fiduciaryDeposit)
        {
            double convertedAmount = 0;

            double dollar = 0;

            switch (matchingAccount.TypeOfAccount)
            {
                case TypeOfAccount.Crypto when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                    convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), fiduciaryDeposit.Mount);
                    break;

                case TypeOfAccount.Crypto when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                    dollar = await _conversionManager.ConvertPesosToDollar(fiduciaryDeposit.Mount);
                    convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), fiduciaryDeposit.Mount);
                    break;
            }

            return convertedAmount;
        }

        public async Task<double> CalculateConvertedAmountCrypto(CryptoAccount matchingAccount, DepositCryptoDTO cryptoDeposit)
        {
            double convertedAmount = 0;

            double dollar = 0;

            switch (matchingAccount.TypeOfAccount)
            {
                case TypeOfAccount.Crypto when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto && matchingAccount.NameOfCrypto != cryptoDeposit.NameOfCrypto:
                    dollar = await _conversionManager.ConvertCryptoToDollar(cryptoDeposit.NameOfCrypto.ToLower(), cryptoDeposit.Mount);
                    convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), dollar);
                    break;
            }

            return convertedAmount;
        }
    }
}
