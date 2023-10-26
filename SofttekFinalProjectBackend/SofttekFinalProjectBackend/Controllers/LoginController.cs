using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class AuthorizeController : ControllerBase
    {
        private readonly UsersServices _services;

        public AuthorizeController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _services = new UsersServices(unitOfWork, configuration);
        }

        /// <summary>
        /// Authenticates a user by attempting to log in.
        /// </summary>
        /// <param name="authenticateDTO">Data transfer object containing user authentication details.</param>
        /// <returns>A response indicating the authentication result, including an access token if successful.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDTO authenticateDTO)
        {
            return await _services.UserLogin(authenticateDTO);
        }
    }
}
