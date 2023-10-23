using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DTOs
{
    public abstract class DepositDTO
    {
        public double Amount { get; set; }
        public TypeOfAccount TypeOfDeposit { get; set; }
        public string? NameOfCrypto { get; set; }

    }
}
