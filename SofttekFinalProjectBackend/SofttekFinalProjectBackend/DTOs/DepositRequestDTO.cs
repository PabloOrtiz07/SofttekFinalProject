using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DTOs
{
    public class DepositRequestDTO
    {
        public DepositCrypto? DepositCrypto { get; set; }
        public DepositFiduciary? DepositFiduciary { get; set; }

    }
}
