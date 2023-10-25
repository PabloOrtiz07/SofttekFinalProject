using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class WithDrawFiduciaryDTO
    {
        public string Cbu { get; set; }
        public string Alias { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public int TypeOfWithDraw { get; set; }
        public string MameOfCrypto { get; set; }

        public int UserId { get; set; }
    }

}
