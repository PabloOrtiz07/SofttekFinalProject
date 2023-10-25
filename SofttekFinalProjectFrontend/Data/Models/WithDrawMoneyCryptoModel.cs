using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class WithdrawMoneyCryptoModel
    {
        public string uuid { get; set; }
        public decimal amount { get; set; }
        public string nameOfCrypto { get; set; }
    }

}
