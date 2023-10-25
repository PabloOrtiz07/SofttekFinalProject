using Data.DTOs;
using SofttekFinalProjectFrontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class DepositFiduciaryViewModel
    {
        public double Amount { get; set; }
        public int TypeOfDeposit { get; set; }
        public string Cbu { get; set; }
        public string Alias { get; set; }
        public string AccountNumber { get; set; }
        public int UserId { get; set; }
        public string NameOfCrypto { get; set; }


        public static implicit operator DepositFiduciaryViewModel(DepositFiduciaryDTO depositFiduciary)
        {
            var depositFiduciaryViewModel = new DepositFiduciaryViewModel
            {
                Cbu = "Default",
                Alias = "Default",
                AccountNumber = "Default",
                Amount = depositFiduciary.Amount,
                TypeOfDeposit = depositFiduciary.TypeOfDeposit,
                NameOfCrypto = "Default"
            };

            return depositFiduciaryViewModel;
        }
    }
}
