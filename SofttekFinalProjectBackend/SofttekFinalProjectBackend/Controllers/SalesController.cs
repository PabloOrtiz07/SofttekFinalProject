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

        [HttpGet]        
        public async Task<IActionResult> GetAll(int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {

           return await _services.GetAllSales(parameter,pageSize, pageToShow, HttpContext.Request);

        }
    }
}
