using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class SaleDTO
    {
        public int UserID { get; set; }
        public double Amount { get; set; }
        public string NameOfCrypto { get; set; }

        public string CbuAccountPesos { get; set; }
    }
}
