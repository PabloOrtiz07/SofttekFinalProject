using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Infrastructure;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Logic
{
    public class ConversionManager
    {
        private readonly GestorOfApis _gestorOfApis;
        public ConversionManager()
        {
            _gestorOfApis = new GestorOfApis();
        }
        public async Task<double> ConvertPesosToDollar(double pesos)
        {
            try
            {
                var dollar = pesos / await _gestorOfApis.GetDollarValueAsync();

                return dollar;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<double> ConvertDollarToPesos(double dollar)
        {
            try
            {
                var pesos = dollar * await _gestorOfApis.GetDollarValueAsync();

                return pesos;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<double> ConvertCryptoToDollar(string nameOfCrypto ,double crypto)
        {
            try
            {
                var dollar = crypto * await _gestorOfApis.GetCryptoToDollarValueAsync(nameOfCrypto);

                return dollar;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<double> ConvertDollarToCrypto(string nameOfCrypto, double dollar)
        {
            try
            {
                var crypto = dollar / await _gestorOfApis.GetCryptoToDollarValueAsync(nameOfCrypto);

                return crypto;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
