using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class DepositFiduciaryDTO
    {
        public double Amount { get; set; }
        public int TypeOfDeposit { get; set; }
        public string Cbu { get; set; }
        public string Alias { get; set; }
        public string AccountNumber { get; set; }
        public int UserId { get; set; }
        public string NameOfCrypto { get; set; }



    }
}
