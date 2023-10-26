using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class DepositDTO
    {
        public int UserId { get; set; }
        public DepositFiduciaryDTO DepositFiduciary { get; set; }
        public DepositCryptoDTO DepositCrypto { get; set; }
    }
}
