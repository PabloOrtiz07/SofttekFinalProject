using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class DepositCryptoModel
    {
        public double amount { get; set; }
        public int typeOfDeposit { get; set; }
        public string nameOfCrypto { get; set; }
        public string uuid { get; set; }

    }
}
