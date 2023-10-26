using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectFrontend.ViewModels;

namespace SofttekFinalProjectFrontend.Controllers {
    [Authorize]

    public class SalesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public SalesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Sales()
        {
            return View();
        }

        public async Task<IActionResult> SalesPartial(SaleDTO saleDTO)
        {
            var saleViewModel = new SalesViewModel();

            if (saleDTO != null)
            {
                saleViewModel = saleDTO;
            }

            return PartialView("~/Views/Sales/Partial/SalesPartial.cshtml", saleViewModel);
        }
        public IActionResult SendSale(SaleDTO saleDTO)
        {

            SaleModel saleModel = new SaleModel
            {
                Amount = saleDTO.Amount,
                NameOfCrypto = saleDTO.NameOfCrypto,
                CbuAccountPesos = saleDTO.CbuAccountPesos

            };

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = saleDTO.UserID;
            var apiUrl = $"Users/sale/{id}";
            var users = baseApi.PostToApi(apiUrl, saleModel, token);
            return RedirectToAction("Sales", "Sales", new { area = "" });
        }

    }
}
