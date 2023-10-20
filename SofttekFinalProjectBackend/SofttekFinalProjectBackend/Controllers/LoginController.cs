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
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorizeController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="authenticateDTO"></param>
   /// <returns></returns>
   /// 

   [HttpPost]
    public async Task<IActionResult> Login(AuthenticateDTO authenticateDTO)
    {
        try
            {
                var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(authenticateDTO);
                if (userCredentials is null)
                {
                    return null;
                }

                var token = _tokenJwtHelper.GenerateToken(userCredentials);

                var user = new UserLoginDTO()
                {
                    Email = userCredentials.Email,
                    Token = token
                };
                return Ok(user);

            }
            catch (Exception ex)
            {
                return null;

            }


        }
    }
}
