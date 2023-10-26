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
    public class SalesController : ControllerBase
    {
        private readonly SalesServices _services;

        public SalesController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _services = new SalesServices(unitOfWork, configuration, mapper);
        }

        /// <summary>
        /// Retrieves all sales with optional pagination and filtering.
        /// </summary>
        /// <param name="parameter">An optional parameter for filtering sales.</param>
        /// <param name="pageSize">An optional page size for pagination (default: 10).</param>
        /// <param name="pageToShow">An optional page number for pagination (default: 1).</param>
        /// <returns>A list of sales based on the provided filters and pagination parameters.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {
            return await _services.GetAllSales(parameter, pageSize, pageToShow, HttpContext.Request);
        }

        /// <summary>
        /// Retrieves a specific sale by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sale.</param>
        /// <returns>The sale information if found, or a 404 Not Found response if the sale does not exist.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale([FromRoute] int id)
        {
            return await _services.GetSale(id);
        }
    }
}
