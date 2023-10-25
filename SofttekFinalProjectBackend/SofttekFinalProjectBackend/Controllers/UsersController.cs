using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Services;
using System.Reflection.Metadata;

namespace SofttekFinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

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

        [HttpPut("withdrawmoney/{id}")]
        public async Task<IActionResult> WithdrawMoney([FromRoute] int id, WithDrawMoneyDTO withDrawMoneyDTO, int parameter = 0)
        {
            return await _services.WithDrawMoney(id, parameter, withDrawMoneyDTO);
        }

        [HttpPut("transfers/{id}")]
        public async Task<IActionResult> Transfers([FromRoute] int id, TransferRequestDTO transferRequestFiduciaryDTO, int parameter=0)
        {
            return  await _services.Transfers(id, parameter, transferRequestFiduciaryDTO);
        }

        [HttpPut("deposit/{id}")]
        public async Task<IActionResult> Deposit([FromRoute] int id, DepositRequestDTO depositRequest, int parameter = 0)
        {
            return await _services.Deposit(id, parameter, depositRequest);
        }

        [HttpPost("sale/{id}")]
        public async Task<IActionResult> Sale([FromRoute] int id, SaleRequestDTO saleRequest)
        {
            return await _services.Sale(id, saleRequest);
        }

        [HttpPut("buy/{id}")]
        public async Task<IActionResult> Buy([FromRoute] int id, int saleNumber)
        {
            return await _services.Buy(id, saleNumber);
        }

    }
}
