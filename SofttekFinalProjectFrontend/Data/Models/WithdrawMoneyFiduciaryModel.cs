using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class WithdrawMoneyFiduciaryModel
    {
        public string cbu { get; set; }
        public string alias { get; set; }
        public string accountNumber { get; set; }
        public double amount { get; set; }
        public int typeOfWithDraw { get; set; }
    }
}

