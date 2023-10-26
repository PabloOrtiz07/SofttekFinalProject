using AutoMapper;
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

        [HttpGet("GetTransaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {

            return await _services.GetAllUsersTransaction(id);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {

            return await _services.GetAllUsersTransaction(parameter, pageSize, pageToShow, HttpContext.Request);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUserTransaction(int id, int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {

            return await _services.GetAllUserTransaction(id, parameter, pageSize, pageToShow, HttpContext.Request);

        }
    }
}
