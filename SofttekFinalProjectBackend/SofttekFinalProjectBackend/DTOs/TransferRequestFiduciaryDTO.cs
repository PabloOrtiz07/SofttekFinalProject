namespace SofttekFinalProjectBackend.DTOs
{
    public class TransferRequestFiduciaryDTO
    {
        public DepositCryptoDTO TransfersCryptoOrigin { get; set; }
        public DepositFiduciaryDTO TransfersFiduciaryOrigin { get; set; }
        public TransfersCryptoDTO TransfersCryptoDestination { get; set; }
        public TransfersFiduciaryDTO TransfersFiduciaryDestination { get; set; }
    }
}
