using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsServices _services;

        public TransactionsController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _services = new TransactionsServices(unitOfWork, configuration, mapper);
        }

        /// <summary>
        /// Retrieves all transactions for a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>A list of transactions associated with the user if found, or a 404 Not Found response if the user does not exist.</returns>
        [HttpGet("GetTransaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            return await _services.GetAllUsersTransaction(id);
        }

        /// <summary>
        /// Retrieves all user transactions with optional pagination and filtering.
        /// </summary>
        /// <param name="parameter">An optional parameter for filtering transactions.</param>
        /// <param name="pageSize">An optional page size for pagination (default: 10).</param>
        /// <param name="pageToShow">An optional page number for pagination (default: 1).</param>
        /// <returns>A list of user transactions based on the provided filters and pagination parameters.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {
            return await _services.GetAllUsersTransaction(parameter, pageSize, pageToShow, HttpContext.Request);
        }

        /// <summary>
        /// Retrieves all transactions for a specific user with optional pagination and filtering.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="parameter">An optional parameter for filtering transactions.</param>
        /// <param name="pageSize">An optional page size for pagination (default: 10).</param>
        /// <param name="pageToShow">An optional page number for pagination (default: 1).</param>
        /// <returns>A list of transactions associated with the user based on the provided filters and pagination parameters.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUserTransaction(int id, int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {
            return await _services.GetAllUserTransaction(id, parameter, pageSize, pageToShow, HttpContext.Request);
        }
    }
}
