using Data.DTOs;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class WithDrawDTO
    {
        public WithDrawMoneyFiduciaryDTO? WithDrawMoneyFiduciary { get; set; }
        public WithDrawMoneyCryptoDTO? WithDrawMoneyCrypto { get; set; }
        public int UserId { get; set; }
    }

}
