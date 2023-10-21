using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersServices _services;

        public UsersController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _services = new UsersServices(unitOfWork, configuration);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await _services.GetUserById(id);


        }

        /*[HttpPost]
        public async Task<IActionResult> Buy([FromRoute] int id)
        {
            return null;
        }

        [HttpPut]
        public async Task<IActionResult> Transfers([FromRoute] int id)
        {
            return null;
        }*/

        [HttpPost("transfersFiduciary/{id}")]
        public async Task<IActionResult> TransfersFiduciaryAccount([FromRoute] int id, int parameter, TransferRequestFiduciaryDTO transferRequestFiduciaryDTO)
        {
            return  await _services.Transfers(id, parameter, transferRequestFiduciaryDTO);
        }

        /*[HttpPost("depositFiduciary/{id}")]
        public async Task<IActionResult> DepositFiduciaryAccount([FromRoute] int id, FiduciaryDepositDTO fiduciaryDepositOrigin)
        {
            return await _services.DepositFiduciaryAccount(id, fiduciaryDepositOrigin);
        }*/

        [HttpPost("depositCrypto/{id}")]
        public async Task<IActionResult> DepositCryptoAccount([FromRoute] int id, CryptoDepositDTO cryptoDepositDTO)
        {
            return await _services.DepositCryptoAccount(id, cryptoDepositDTO);
        }*/

    }
}
