using Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class SalesViewModel
    {
        public int UserID { get; set; }
        public string NameOfCrypto { get; set; }
        public string CbuAccountPesos { get; set; }
        public double Amount { get; set; }


        public static implicit operator SalesViewModel(SaleDTO sale)
        {
            var saleViewModel = new SalesViewModel
            {
                NameOfCrypto = "default",
                CbuAccountPesos = "default",
                Amount = 0,
            };

            return saleViewModel;
        }
    }
}
