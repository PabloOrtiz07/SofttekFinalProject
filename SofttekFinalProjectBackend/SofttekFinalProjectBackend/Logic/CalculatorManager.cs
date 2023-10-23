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
        public async Task<double> CalculateConvertedAmountFiduciary(FiduciaryAccount matchingAccount, WithDrawMoneyCrypto withDrawMoneyCrypto)
        {
            try
            {
                double convertedAmount = 0;

                double dollar = await _conversionManager.ConvertCryptoToDollar(withDrawMoneyCrypto.NameOfCrypto.ToLower(), withDrawMoneyCrypto.Amount);
                convertedAmount = await _conversionManager.ConvertDollarToPesos(dollar);



                return convertedAmount;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }

        public async Task<double> CalculateConvertedAmountFiduciary(FiduciaryAccount matchingAccount, DepositCrypto cryptoDeposit)
        {
            try
            {
                double convertedAmount = 0;

                switch (matchingAccount.TypeOfAccount)
                {
                    case TypeOfAccount.Pesos when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto:
                        double dollar = await _conversionManager.ConvertCryptoToDollar(cryptoDeposit.NameOfCrypto.ToLower(), cryptoDeposit.Amount);
                        convertedAmount = await _conversionManager.ConvertDollarToPesos(dollar);
                        break;

                    case TypeOfAccount.Dollar when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto:
                        convertedAmount = await _conversionManager.ConvertCryptoToDollar(cryptoDeposit.NameOfCrypto.ToLower(), cryptoDeposit.Amount);
                        break;
                }

                return convertedAmount;
            }
            catch (Exception ex)
            {
               
                throw; 
            }
        }

        public async Task<double> CalculateConvertedAmountFiduciary(FiduciaryAccount matchingAccount, DepositFiduciary fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = 0;

                switch (matchingAccount.TypeOfAccount)
                {
                    case TypeOfAccount.Pesos when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                        convertedAmount = await _conversionManager.ConvertDollarToPesos(fiduciaryDeposit.Amount);
                        break;

                    case TypeOfAccount.Dollar when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                        convertedAmount = await _conversionManager.ConvertPesosToDollar(fiduciaryDeposit.Amount);
                        break;

                    case TypeOfAccount.Pesos when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                        convertedAmount = fiduciaryDeposit.Amount;
                        break;

                    case TypeOfAccount.Dollar when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                        convertedAmount = fiduciaryDeposit.Amount;
                        break;

                    case TypeOfAccount.Pesos when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Crypto:
                        double dollar = await _conversionManager.ConvertCryptoToDollar(fiduciaryDeposit.NameOfCrypto.ToLower(), fiduciaryDeposit.Amount);
                        convertedAmount = await _conversionManager.ConvertDollarToPesos(dollar);
                        break;

                    case TypeOfAccount.Dollar when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Crypto:
                        convertedAmount = await _conversionManager.ConvertCryptoToDollar(fiduciaryDeposit.NameOfCrypto.ToLower(), fiduciaryDeposit.Amount);
                        break;
                }

                return convertedAmount;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }

        public async Task<double> CalculateConvertedAmountCrypto(Sale saleRequest)
        {
            try
            {
                double convertedAmount = 0;

                double dollar = await _conversionManager.ConvertCryptoToDollar(saleRequest.NameOfCrypto.ToLower(), saleRequest.Amount);
                convertedAmount = await _conversionManager.ConvertDollarToPesos(dollar);
                return convertedAmount;
            }
            catch (Exception ex)
            {
               
                throw; 
            }
        }

        public async Task<double> CalculateConvertedAmountCrypto(CryptoAccount matchingAccount, DepositFiduciary fiduciaryDeposit)
        {
            try
            {
                double convertedAmount = 0;

                double dollar = 0;

                switch (matchingAccount.TypeOfAccount)
                {
                    case TypeOfAccount.Crypto when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                        convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), fiduciaryDeposit.Amount);
                        break;

                    case TypeOfAccount.Crypto when fiduciaryDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                        dollar = await _conversionManager.ConvertPesosToDollar(fiduciaryDeposit.Amount);
                        convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), dollar);
                        break;
                }

                return convertedAmount;
            }
            catch (Exception ex)
            {
               
                throw; 
            }
        }

        public async Task<double> CalculateConvertedAmountCrypto(CryptoAccount matchingAccount, DepositCrypto cryptoDeposit)
        {
            try
            {
                double convertedAmount = 0;

                double dollar = 0;

                switch (matchingAccount.TypeOfAccount)
                {
                    case TypeOfAccount.Crypto when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto && string.Equals(matchingAccount.NameOfCrypto.ToLower(), cryptoDeposit.NameOfCrypto.ToLower(), StringComparison.OrdinalIgnoreCase):
                        convertedAmount = cryptoDeposit.Amount;
                        break;

                    case TypeOfAccount.Crypto when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Crypto && !string.Equals(matchingAccount.NameOfCrypto.ToLower(), cryptoDeposit.NameOfCrypto.ToLower(), StringComparison.OrdinalIgnoreCase):
                        dollar = await _conversionManager.ConvertCryptoToDollar(cryptoDeposit.NameOfCrypto.ToLower(), cryptoDeposit.Amount);
                        convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), dollar);
                        break;
                    case TypeOfAccount.Crypto when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Dollar:
                        convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), cryptoDeposit.Amount);
                        break;

                    case TypeOfAccount.Crypto when cryptoDeposit.TypeOfDeposit == TypeOfAccount.Pesos:
                        dollar = await _conversionManager.ConvertPesosToDollar(cryptoDeposit.Amount);
                        convertedAmount = await _conversionManager.ConvertDollarToCrypto(matchingAccount.NameOfCrypto.ToLower(), dollar);
                        break;
                }

                return convertedAmount;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }

    }
}
