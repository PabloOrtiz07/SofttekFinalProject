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
    public class UsersController : ControllerBase
    {
        private readonly UsersServices _services;

        public UsersController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _services = new UsersServices(unitOfWork, configuration);
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user's information if found or a 404 Not Found response if the user does not exist.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await _services.GetUserById(id);
        }

        /// <summary>
        /// Allows a user to initiate a withdrawal of funds from their account.
        /// </summary>
        /// <param name="id">The unique identifier of the user initiating the withdrawal.</param>
        /// <param name="withDrawMoneyDTO">Data transfer object containing withdrawal details.</param>
        /// <param name="parameter">A parameter to specify the withdrawal type (e.g., Fiduciary, Crypto).</param>
        /// <returns>A response indicating the result of the withdrawal operation.</returns>
        [HttpPut("withdrawmoney/{id}")]
        public async Task<IActionResult> WithdrawMoney([FromRoute] int id, WithDrawMoneyDTO withDrawMoneyDTO, int parameter = 0)
        {
            return await _services.WithDrawMoney(id, parameter, withDrawMoneyDTO);
        }

        /// <summary>
        /// Allows a user to initiate a transfer of funds to another account.
        /// </summary>
        /// <param name="id">The unique identifier of the user initiating the transfer.</param>
        /// <param name="transferRequestFiduciaryDTO">Data transfer object containing transfer details.</param>
        /// <param name="parameter">A parameter to specify the transfer type (e.g., Fiduciary, Crypto).</param>
        /// <returns>A response indicating the result of the transfer operation.</returns>
        [HttpPut("transfers/{id}")]
        public async Task<IActionResult> Transfers([FromRoute] int id, TransferRequestDTO transferRequestFiduciaryDTO, int parameter = 0)
        {
            return await _services.Transfers(id, parameter, transferRequestFiduciaryDTO);
        }

        /// <summary>
        /// Allows a user to make a deposit into their account.
        /// </summary>
        /// <param name="id">The unique identifier of the user making the deposit.</param>
        /// <param name="depositRequest">Data transfer object containing deposit details.</param>
        /// <param name="parameter">A parameter to specify the deposit type (e.g., Fiduciary, Crypto).</param>
        /// <returns>A response indicating the result of the deposit operation.</returns>
        [HttpPut("deposit/{id}")]
        public async Task<IActionResult> Deposit([FromRoute] int id, DepositRequestDTO depositRequest, int parameter = 0)
        {
            return await _services.Deposit(id, parameter, depositRequest);
        }

        /// <summary>
        /// Allows a user to initiate a sale transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the user initiating the sale.</param>
        /// <param name="saleRequest">Data transfer object containing sale details.</param>
        /// <returns>A response indicating the result of the sale operation.</returns>
        [HttpPost("sale/{id}")]
        public async Task<IActionResult> Sale([FromRoute] int id, SaleRequestDTO saleRequest)
        {
            return await _services.Sale(id, saleRequest);
        }

        /// <summary>
        /// Allows a user to initiate a purchase of a sale.
        /// </summary>
        /// <param name="id">The unique identifier of the user initiating the purchase.</param>
        /// <param name="saleNumber">The sale number associated with the purchase.</param>
        /// <returns>A response indicating the result of the purchase operation.</returns>
        [HttpPut("buy/{id}")]
        public async Task<IActionResult> Buy([FromRoute] int id, int saleNumber)
        {
            return await _services.Buy(id, saleNumber);
        }
    }
}
