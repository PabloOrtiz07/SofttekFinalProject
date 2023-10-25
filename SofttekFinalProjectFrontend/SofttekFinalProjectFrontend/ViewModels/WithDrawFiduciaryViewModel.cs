using Data.DTOs;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class WithDrawFiduciaryViewModel
    {
        public string Cbu { get; set; }
        public string Alias { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public int TypeOfWithDraw { get; set; }
        public int UserId { get; set; }


        public static implicit operator WithDrawFiduciaryViewModel(WithDrawFiduciaryDTO withDrawFiduciary)
        {
            var withDrawFiduciaryViewModel = new WithDrawFiduciaryViewModel
            {
                Cbu = "Default",
                Alias = "Default",
                AccountNumber = "Default",
                Amount = 0,
                TypeOfWithDraw = 0
            };

            return withDrawFiduciaryViewModel;
        }
    }
}
