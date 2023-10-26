using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Infrastructure;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsServices _services;

        public AccountsController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _services = new AccountsServices(unitOfWork, configuration, mapper);
        }

        /// <summary>
        /// Retrieves all accounts associated with a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="parameter">An optional parameter to specify the type of account (e.g. , Fiduciary, Crypto).</param>
        /// <param name="pageSize">An optional parameter to specify the page size for paginated results.</param>
        /// <param name="pageToShow">An optional parameter to specify the page number for paginated results.</param>
        /// <returns>A response containing the list of user accounts.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAccounts([FromRoute] int id, int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {
            return await _services.GetAllAccounts(id, parameter, pageSize, pageToShow, HttpContext.Request);
        }

        /// <summary>
        /// Retrieves a specific account by name.
        /// </summary>
        /// <param name="name">The name or identifier of the account.</param>
        /// <param name="parameter">An optional parameter to specify the type of account (e.g., Fiduciary, Crypto).</param>
        /// <returns>A response containing the details of the account.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAccountFiduciary(string name, int parameter = 0)
        {
            return await _services.GetAccount(name, parameter);
        }
    }
}
