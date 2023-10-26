using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Infrastructure;

namespace SofttekFinalProjectBackend.Services
{
    public class AccountsServices
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountsServices(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;

        }
        public async Task<IActionResult> GetAccount(string name, int parameter)
        {
            try
            {

                if (parameter == 0)
                {
                    FiduciaryAccount account = await _unitOfWork.FiduciaryAccountRepository.GetAccount(name, "","");
                    return ResponseFactory.CreateSuccessResponse(200, account);

                }
                if (parameter == 1)
                 {
                    CryptoAccount account = await _unitOfWork.CryptoAccountRepository.GetByUuid(name);
                    return ResponseFactory.CreateSuccessResponse(200, account);
                }
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }

        public async Task<IActionResult> GetAllAccounts(int id, int parameter, int pageSize, int pageToShow, HttpRequest Request)
        {
            try
            {

                if(parameter == 0)
                {
                    List<FiduciaryAccount> accounts = await _unitOfWork.FiduciaryAccountRepository.GetAll();
                    accounts = accounts.Where(fiduciaryAccount => fiduciaryAccount.UserId == id).ToList();
                    if (Request.Query.ContainsKey("page"))
                        int.TryParse(Request.Query["page"], out pageToShow);
                    var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                    var paginateUsers = PaginateHelper.Paginate(accounts, pageToShow, url, pageSize);
                    return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
                }
                if (parameter == 1)
                {
                    List<CryptoAccount> accounts = await _unitOfWork.CryptoAccountRepository.GetAll();
                    accounts = accounts.Where(cryptoAccount => cryptoAccount.UserId == id).ToList();
                    if (Request.Query.ContainsKey("page"))
                        int.TryParse(Request.Query["page"], out pageToShow);
                    var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                    var paginateUsers = PaginateHelper.Paginate(accounts, pageToShow, url, pageSize);
                    return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
                }
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }
    }
}
