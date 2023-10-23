using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DTOs
{
    public class TransferRequestDTO
    {
        public DepositCrypto? TransfersCryptoOrigin { get; set; }
        public DepositFiduciary? TransfersFiduciaryOrigin { get; set; }
        public TransfersCrypto? TransfersCryptoDestination { get; set; }
        public TransfersFiduciary? TransfersFiduciaryDestination { get; set; }
    }
}
