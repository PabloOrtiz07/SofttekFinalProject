using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UsersServices _services;

        public AuthorizeController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _services = new UsersServices( unitOfWork ,configuration);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDTO authenticateDTO)
        {
            return await _services.UserLogin(authenticateDTO);
        }
    }

}
