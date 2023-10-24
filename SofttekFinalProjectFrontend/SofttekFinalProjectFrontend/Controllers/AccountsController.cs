using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectFrontend.ViewModels;

namespace SofttekFinalProjectFrontend.Controllers { 

    public class AccountsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AccountsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Accounts()
        {
            return View();
        }

        public async Task<IActionResult> FiduciaryAccountsAddPartial([FromBody] FiduciaryAccountDTO fiduciaryAccountDTO)
        {
            var accountsViewModel = new FiduciaryAccountViewModel();

            if (fiduciaryAccountDTO != null)
            {
                accountsViewModel = fiduciaryAccountDTO;
            }

            return PartialView("~/Views/Accounts/Partial/FiduciaryAddPartial.cshtml", accountsViewModel);
        }

        public IActionResult RegisterAccount(UserDTO user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var accounts = baseApi.PostToApi("Accounts", user, token);
            return RedirectToAction("Accounts", "Accounts", new { area = "" });
        }

        public IActionResult EditAccount(UserDTO user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = user.Id;
            var apiUrl = $"Accounts/{id}?parameter=0";
            var accounts = baseApi.PutToApi(apiUrl, user, token);
            return RedirectToAction("Accounts", "Accounts", new { area = "" });
        }

    }
}
