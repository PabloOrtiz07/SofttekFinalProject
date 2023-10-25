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

    }
}
