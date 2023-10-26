using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectFrontend.ViewModels;

namespace SofttekFinalProjectFrontend.Controllers { 

    public class TransactionsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public TransactionsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Transactions()
        {
            return View();
        }

    }
}
