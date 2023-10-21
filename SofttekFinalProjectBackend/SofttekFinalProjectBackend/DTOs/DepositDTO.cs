using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DTOs
{
    public abstract class DepositDTO
    {
        public double Mount { get; set; }
        public TypeOfAccount TypeOfDeposit { get; set; }

    }
}
