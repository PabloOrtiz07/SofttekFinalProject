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
    public class WithDrawsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public WithDrawsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult WithDraws()
        {
            return View();
        }

        public async Task<IActionResult> WithDrawsAddPartial(WithDrawFiduciaryDTO withDrawFiduciary)
        {
            var withDrawFiduciarysViewModel = new WithDrawFiduciaryViewModel();

            if (withDrawFiduciary != null)
            {
                withDrawFiduciarysViewModel = withDrawFiduciary;
            }

            return PartialView("~/Views/WithDraws/Partial/WithDrawsFiduciaryAddPartial.cshtml", withDrawFiduciarysViewModel);
        }

        public IActionResult SendWithDraw(WithDrawFiduciaryDTO withDrawFiduciaryDTO)
        {

            WithdrawMoneyFiduciaryModel model = new WithdrawMoneyFiduciaryModel
            {
                cbu = withDrawFiduciaryDTO.Cbu,
                alias = withDrawFiduciaryDTO.Alias,
                accountNumber = withDrawFiduciaryDTO.AccountNumber,
                amount = withDrawFiduciaryDTO.Amount,
                typeOfWithDraw = withDrawFiduciaryDTO.TypeOfWithDraw
            };
            WithdrawMoneyCryptoModel modelDos = new WithdrawMoneyCryptoModel
            {
                uuid = "string",
                amount = 0,
                nameOfCrypto = "string",
            };
            WithDrawMoneyModel withDrawMoneyModel = new WithDrawMoneyModel();

            withDrawMoneyModel.WithdrawMoneyFiduciary = model;
            withDrawMoneyModel.WithdrawMoneyCrypto = modelDos;





            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = withDrawFiduciaryDTO.UserId;
            var apiUrl = $"Users/withdrawmoney/1?parameter=0";
            var users = baseApi.PutToApi(apiUrl, withDrawMoneyModel, token);
            return RedirectToAction("WithDraws", "WithDraws", new { area = "" });
        }
    }
}
