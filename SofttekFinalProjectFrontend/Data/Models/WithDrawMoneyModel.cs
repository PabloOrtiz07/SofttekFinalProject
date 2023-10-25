using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class WithDrawMoneyModel
    {
        public WithdrawMoneyCryptoModel? WithdrawMoneyCrypto { get; set; }
        public WithdrawMoneyFiduciaryModel? WithdrawMoneyFiduciary{ get; set; }

    }
}
