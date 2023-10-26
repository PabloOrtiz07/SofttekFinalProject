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
        public async Task<IActionResult> WithDrawsFiduciaryPartial(WithDrawDTO withDrawFiduciary)
        {
            var withDrawFiduciarysViewModel = new WithDrawViewModel();

            if (withDrawFiduciary != null)
            {
                withDrawFiduciarysViewModel = withDrawFiduciary;
            }

            return PartialView("~/Views/WithDraws/Partial/WithDrawsFiduciaryPartial.cshtml", withDrawFiduciarysViewModel);
        }

        public async Task<IActionResult> WithDrawsCryptoPartial(WithDrawDTO withDrawFiduciary)
        {
            var withDrawFiduciarysViewModel = new WithDrawViewModel();

            if (withDrawFiduciary != null)
            {
                withDrawFiduciarysViewModel = withDrawFiduciary;
            }

            return PartialView("~/Views/WithDraws/Partial/WithDrawsCryptoPartial.cshtml", withDrawFiduciarysViewModel);
        }

        public IActionResult SendWithDrawFiduciary(WithDrawDTO withDrawDTO)
        {

            WithdrawMoneyFiduciaryModel modelFiduciary = new WithdrawMoneyFiduciaryModel
            {
                cbu = withDrawDTO.WithDrawMoneyFiduciary.cbu,
                alias = withDrawDTO.WithDrawMoneyFiduciary.alias,
                accountNumber = withDrawDTO.WithDrawMoneyFiduciary.accountNumber,
                amount = withDrawDTO.WithDrawMoneyFiduciary.amount,
                typeOfWithDraw = withDrawDTO.WithDrawMoneyFiduciary.typeOfWithDraw
            };

            WithDrawMoneyModel withDrawMoneyModel = new WithDrawMoneyModel();

            withDrawMoneyModel.WithdrawMoneyFiduciary = modelFiduciary;

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = withDrawDTO.UserId;
            var apiUrl = $"Users/withdrawmoney/{id}?parameter=0";
            var users = baseApi.PutToApi(apiUrl, withDrawMoneyModel, token);
            return RedirectToAction("WithDraws", "WithDraws", new { area = "" });
        }
        public IActionResult SendWithDrawCrypto(WithDrawDTO withDrawDTO)
        {

            WithdrawMoneyCryptoModel modelCrypto = new WithdrawMoneyCryptoModel
            {
                uuid = withDrawDTO.WithDrawMoneyCrypto.uuid,
                amount = withDrawDTO.WithDrawMoneyCrypto.amount,
                nameOfCrypto = withDrawDTO.WithDrawMoneyCrypto.nameOfCrypto,
            };
            WithDrawMoneyModel withDrawMoneyModel = new WithDrawMoneyModel();

            withDrawMoneyModel.WithdrawMoneyCrypto = modelCrypto;

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = withDrawDTO.UserId;
            var apiUrl = $"Users/withdrawmoney/{id}?parameter=1";
            var users = baseApi.PutToApi(apiUrl, withDrawMoneyModel, token);
            return RedirectToAction("WithDraws", "WithDraws", new { area = "" });
        }
    }
}
