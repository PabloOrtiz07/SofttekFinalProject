using Data.DTOs;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class TransfersViewModel
    {
        public int UserId { get; set; }
        public TransfersCryptoOriginDTO? TransfersCryptoOrigin { get; set; }
        public TransfersFiduciaryOriginDTO? TransfersFiduciaryOrigin { get; set; }
        public TransfersFiduciaryDestinationDTO? TransfersFiduciaryDestination { get; set; }
        public TransfersCryptoDestinationDTO? TransfersCryptoDestination { get; set; }

        public static implicit operator TransfersViewModel(TransfersDTO transfersDTO)
        {
            var transfersViewModel = new TransfersViewModel
            {
                UserId = transfersDTO.UserId,
                TransfersCryptoOrigin = new TransfersCryptoOriginDTO
                {
                    Uuid = "default",
                    Amount = 0,
                    TypeOfDeposit = 2,
                    NameOfCrypto = "default",
                },
                TransfersFiduciaryOrigin = new TransfersFiduciaryOriginDTO
                {
                    Amount = 0,
                    TypeOfDeposit = 0,
                    NameOfCrypto = "default",
                    Cbu = "default",
                    Alias = "default",
                    AccountNumber = "default"
                },
                TransfersCryptoDestination = new TransfersCryptoDestinationDTO
                {
                    Uuid = "default",
                },
                TransfersFiduciaryDestination = new TransfersFiduciaryDestinationDTO
                {
                    Cbu = "default",
                    Alias = "default",
                    AccountNumber = "default"
                }
            };

            return transfersViewModel;
        }
    }

}
