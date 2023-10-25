using Data.Base;
using Data.DTOs;
using SofttekFinalProjectFrontend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using static Data.Base.BaseApi;

namespace SofttekFinalProjectFrontend.Controllers
{
    public class DepositsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public DepositsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Deposits()
        {
            return View();
        }

        public async Task<IActionResult> DepositsAddPartial(DepositFiduciaryDTO depositFiduciaryDTO)
        {
            var depositFiduciaryViewModel = new DepositFiduciaryViewModel();

            if (depositFiduciaryDTO != null)
            {
                depositFiduciaryViewModel = depositFiduciaryDTO;
            }

            return PartialView("~/Views/Deposits/Partial/DepositsFiduciaryAddPartial.cshtml", depositFiduciaryViewModel);
        }

        public IActionResult SendDeposit(DepositFiduciaryDTO depositFiduciaryDTO)
        {

            DepositFiduciaryModel modelFiduciary = new DepositFiduciaryModel
            {
                cbu = depositFiduciaryDTO.Cbu,
                alias = depositFiduciaryDTO.Alias,
                accountNumber = depositFiduciaryDTO.AccountNumber,
                amount = depositFiduciaryDTO.Amount,
                typeOfDeposit = depositFiduciaryDTO.TypeOfDeposit,
                nameOfCrypto = depositFiduciaryDTO.NameOfCrypto
            };

            DepositCryptoModel modelCrypto = new DepositCryptoModel
            {
                uuid = "default",
                nameOfCrypto = "default",
                amount = 0,
                typeOfDeposit = 0
            };

            DepositModel depositModel = new DepositModel();

            depositModel.DepositFiduciary = modelFiduciary;
            depositModel.DepositCrypto = modelCrypto;




            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = depositFiduciaryDTO.UserId;
            var apiUrl = $"Users/deposit/{id}?parameter=0";
            var users = baseApi.PutToApi(apiUrl, depositModel, token);
            return RedirectToAction("Deposits", "Deposits", new { area = "" });
        }

    }
}
