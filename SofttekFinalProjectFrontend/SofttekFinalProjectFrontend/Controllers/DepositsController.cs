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
        public async Task<IActionResult> DepositsFiduciaryPartial(DepositDTO depositDTO)
        {
            var depositViewModel = new DepositViewModel();

            if (depositDTO != null)
            {
                depositViewModel = depositDTO;
            }

            return PartialView("~/Views/Deposits/Partial/DepositsFiduciaryPartial.cshtml", depositViewModel);
        }

        public async Task<IActionResult> DepositsCryptoPartial(DepositDTO depositDTO)
        {
            var depositViewModel = new DepositViewModel();

            if (depositDTO != null)
            {
                depositViewModel = depositDTO;
            }

            return PartialView("~/Views/Deposits/Partial/DepositsCryptoPartial.cshtml", depositViewModel);
        }
        public IActionResult SendDepositFiduciary(DepositDTO depositDTO)
        {

            DepositFiduciaryModel modelFiduciary = new DepositFiduciaryModel
            {
                cbu = depositDTO.DepositFiduciary.cbu,
                alias = depositDTO.DepositFiduciary.alias,
                accountNumber = depositDTO.DepositFiduciary.accountNumber,
                amount = depositDTO.DepositFiduciary.amount,
                typeOfDeposit = depositDTO.DepositFiduciary.typeOfDeposit,
                nameOfCrypto = depositDTO.DepositFiduciary.nameOfCrypto
            };

            DepositModel depositModel = new DepositModel();

            depositModel.DepositFiduciary = modelFiduciary;




            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = depositDTO.UserId;
            var apiUrl = $"Users/deposit/{id}?parameter=0";
            var users = baseApi.PutToApi(apiUrl, depositModel, token);
            return RedirectToAction("Deposits", "Deposits", new { area = "" });
        }

        public IActionResult SendDepositCrypto(DepositDTO depositDTO)
        {

            DepositCryptoModel modelCrypto = new DepositCryptoModel
            {
                uuid = depositDTO.DepositCrypto.uuid,
                nameOfCrypto = depositDTO.DepositCrypto.nameOfCrypto,
                amount = depositDTO.DepositCrypto.amount,
                typeOfDeposit = depositDTO.DepositCrypto.typeOfDeposit
            };

            DepositModel depositModel = new DepositModel();

            depositModel.DepositCrypto = modelCrypto;




            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = depositDTO.UserId;
            var apiUrl = $"Users/deposit/{id}?parameter=0";
            var users = baseApi.PutToApi(apiUrl, depositModel, token);
            return RedirectToAction("Deposits", "Deposits", new { area = "" });
        }

    }
}
