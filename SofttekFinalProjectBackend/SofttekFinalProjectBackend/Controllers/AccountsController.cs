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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAccounts([FromRoute] int id,int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {

           return await _services.GetAllAccounts(id,parameter,pageSize, pageToShow, HttpContext.Request);

        }
    }
}
