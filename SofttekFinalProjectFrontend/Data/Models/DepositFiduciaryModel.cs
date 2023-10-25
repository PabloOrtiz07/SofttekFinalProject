using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class DepositFiduciaryModel
    {
        public double amount { get; set; }
        public int typeOfDeposit { get; set; }
        public string cbu { get; set; }
        public string alias { get; set; }
        public string accountNumber { get; set; }
        public string nameOfCrypto { get; set; }

    }
}
