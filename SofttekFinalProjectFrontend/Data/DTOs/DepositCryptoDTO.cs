using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class DepositCryptoDTO
    {
        public string uuid { get; set; }
        public string nameOfCrypto { get; set; }
        public double amount { get; set; }
        public int typeOfDeposit { get; set; }
    }
}
