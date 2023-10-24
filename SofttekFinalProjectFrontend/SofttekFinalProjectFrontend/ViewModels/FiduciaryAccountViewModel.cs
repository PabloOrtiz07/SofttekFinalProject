using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Data.DTOs;

namespace SofttekFinalProjectFrontend.ViewModels
{
    public class FiduciaryAccountViewModel 
    {


        public string Cbu { get; set; }

        public string Alias { get; set; }

        public string AccountNumber { get; set; }

        public static implicit operator FiduciaryAccountViewModel(FiduciaryAccountDTO fiduciaryAccount)
        {
            var fiduciaryViewModel = new FiduciaryAccountViewModel();
            fiduciaryViewModel.Cbu = fiduciaryAccount.Cbu;
            fiduciaryViewModel.Alias = fiduciaryAccount.Alias;
            fiduciaryViewModel.AccountNumber = fiduciaryAccount.AccountNumber;
            return fiduciaryViewModel;
        }
    }
}
