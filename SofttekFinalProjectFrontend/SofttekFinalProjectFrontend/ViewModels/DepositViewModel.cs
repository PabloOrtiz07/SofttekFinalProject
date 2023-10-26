using Data.DTOs;
using SofttekFinalProjectFrontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class DepositViewModel
    {
        public int UserId { get; set; }

        public DepositFiduciaryDTO DepositFiduciary { get; set; }
        public DepositCryptoDTO DepositCrypto { get; set; }

        public static implicit operator DepositViewModel(DepositDTO deposit)
        {
            var depositViewModel = new DepositViewModel
            {
                DepositFiduciary = new DepositFiduciaryDTO
                {
                    cbu = "default",
                    alias = "default",
                    accountNumber = "default",
                    amount = 0,
                    typeOfDeposit = 0,
                    nameOfCrypto = "default"
                },
                DepositCrypto = new DepositCryptoDTO
                {
                    uuid = "default",
                    nameOfCrypto = "default",
                    amount = 0,
                    typeOfDeposit = 0
                }
            };

            return depositViewModel;
        }
    }

}
