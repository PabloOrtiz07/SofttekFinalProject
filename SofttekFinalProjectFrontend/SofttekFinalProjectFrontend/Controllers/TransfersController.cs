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
    [Authorize]

    public class TransfersController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public TransfersController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Transfers()
        {
            return View();
        }
        public async Task<IActionResult> TransfersCryptoToCryptoPartial(TransfersDTO transfersDTO)
        {
            var transfersViewModel = new TransfersViewModel();

            if (transfersDTO != null)
            {
                transfersViewModel = transfersDTO;
            }

            return PartialView("~/Views/Transfers/Partial/TransfersCryptoToCryptoPartial.cshtml", transfersViewModel);
        }
        public async Task<IActionResult> TransfersCryptoToFiduciaryPartial(TransfersDTO transfersDTO)
        {
            var transfersViewModel = new TransfersViewModel();

            if (transfersDTO != null)
            {
                transfersViewModel = transfersDTO;
            }

            return PartialView("~/Views/Transfers/Partial/TransfersCryptoToFiduciaryPartial.cshtml", transfersViewModel);
        }
        public async Task<IActionResult> TransfersFiduciaryToCryptoPartial(TransfersDTO transfersDTO)
        {
            var transfersViewModel = new TransfersViewModel();

            if (transfersDTO != null)
            {
                transfersViewModel = transfersDTO;
            }

            return PartialView("~/Views/Transfers/Partial/TransfersFiduciaryToCryptoPartial.cshtml", transfersViewModel);
        }
        public async Task<IActionResult> TransfersFiduciaryToFiduciaryPartial(TransfersDTO transfersDTO)
        {
            var transfersViewModel = new TransfersViewModel();

            if (transfersDTO != null)
            {
                transfersViewModel = transfersDTO;
            }

            return PartialView("~/Views/Transfers/Partial/TransfersFiduciaryToFiduciaryPartial.cshtml", transfersViewModel);
        }
        
        public IActionResult SendTransfersFiduciaryToFiduciary(TransfersDTO transfersDTO)
        {
            TransfersModel transfersModel = new TransfersModel();
            transfersModel.TransfersFiduciaryDestination = transfersDTO.TransfersFiduciaryDestination;
            transfersModel.TransfersFiduciaryOrigin = transfersDTO.TransfersFiduciaryOrigin;
            transfersModel.TransfersCryptoOrigin = transfersDTO.TransfersCryptoOrigin;
            transfersModel.TransfersCryptoDestination = transfersDTO.TransfersCryptoDestination;    

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = transfersDTO.UserId;
            var apiUrl = $"Users/transfers/{1}?parameter=0";
            var users = baseApi.PutToApi(apiUrl, transfersModel, token);
            return RedirectToAction("Transfers", "Transfers", new { area = "" });
        }
        public IActionResult SendTransfersFiduciaryToCrypto(TransfersDTO transfersDTO)
        {
            TransfersModel transfersModel = new TransfersModel();
            transfersModel.TransfersFiduciaryDestination = transfersDTO.TransfersFiduciaryDestination;
            transfersModel.TransfersFiduciaryOrigin = transfersDTO.TransfersFiduciaryOrigin;
            transfersModel.TransfersCryptoOrigin = transfersDTO.TransfersCryptoOrigin;
            transfersModel.TransfersCryptoDestination = transfersDTO.TransfersCryptoDestination;

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = transfersDTO.UserId;
            var apiUrl = $"Users/transfers/{1}?parameter=1";
            var users = baseApi.PutToApi(apiUrl, transfersModel, token);
            return RedirectToAction("Transfers", "Transfers", new { area = "" });
        }
        public IActionResult SendTransfersCryptoToFiduciary(TransfersDTO transfersDTO)
        {
            TransfersModel transfersModel = new TransfersModel();
            transfersModel.TransfersFiduciaryDestination = transfersDTO.TransfersFiduciaryDestination;
            transfersModel.TransfersFiduciaryOrigin = transfersDTO.TransfersFiduciaryOrigin;
            transfersModel.TransfersCryptoOrigin = transfersDTO.TransfersCryptoOrigin;
            transfersModel.TransfersCryptoDestination = transfersDTO.TransfersCryptoDestination;

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = transfersDTO.UserId;
            var apiUrl = $"Users/transfers/{1}?parameter=2";
            var users = baseApi.PutToApi(apiUrl, transfersModel, token);
            return RedirectToAction("Transfers", "Transfers", new { area = "" });
        }
        public IActionResult SendTransfersCryptoToCrypto(TransfersDTO transfersDTO)
        {
            TransfersModel transfersModel = new TransfersModel();
            transfersModel.TransfersFiduciaryDestination = transfersDTO.TransfersFiduciaryDestination;
            transfersModel.TransfersFiduciaryOrigin = transfersDTO.TransfersFiduciaryOrigin;
            transfersModel.TransfersCryptoOrigin = transfersDTO.TransfersCryptoOrigin;
            transfersModel.TransfersCryptoDestination = transfersDTO.TransfersCryptoDestination;

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var id = transfersDTO.UserId;
            var apiUrl = $"Users/transfers/{1}?parameter=3";
            var users = baseApi.PutToApi(apiUrl, transfersModel, token);
            return RedirectToAction("Transfers", "Transfers", new { area = "" });
        }
    }
}
