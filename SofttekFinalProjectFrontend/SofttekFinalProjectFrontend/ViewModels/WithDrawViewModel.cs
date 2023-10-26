using Data.DTOs;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class WithDrawViewModel
    {
        public WithDrawMoneyFiduciaryDTO? WithDrawMoneyFiduciary { get; set; }
        public WithDrawMoneyCryptoDTO? WithDrawMoneyCrypto { get; set; }
        public int UserId { get; set; }

        public static implicit operator WithDrawViewModel(WithDrawDTO withDrawMoney)
        {
            var viewModel = new WithDrawViewModel
            {
                WithDrawMoneyFiduciary = new WithDrawMoneyFiduciaryDTO
                {
                    cbu = "default",
                    alias = "default",
                    accountNumber = "default",
                    amount = 0,
                    typeOfWithDraw = 0,
                },
                WithDrawMoneyCrypto = new WithDrawMoneyCryptoDTO
                {
                    uuid = "default",
                    amount = 0,
                    nameOfCrypto = "default"
                },
            };

            return viewModel;
        }
    }

}
