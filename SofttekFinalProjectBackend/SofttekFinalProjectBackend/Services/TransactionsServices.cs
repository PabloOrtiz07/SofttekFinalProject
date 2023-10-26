using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Infrastructure;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace SofttekFinalProjectBackend.Services
{
    public class TransactionsServices
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TransactionsServices(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;

        }
        public async Task<IActionResult> GetAllUsersTransaction(int id)
        {
            try
            {
                Transaction transaction = await _unitOfWork.TransactionRepository.GetById(id);
                return ResponseFactory.CreateSuccessResponse(200, transaction);

                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }


        public async Task<IActionResult> GetAllUsersTransaction(int parameter, int pageSize, int pageToShow, HttpRequest Request)
        {
            try
            {

                List<Transaction> transactions = await _unitOfWork.TransactionRepository.GetAllTransaction();



                if (parameter == 0)
                {
                    transactions = transactions.Where(transaction => transaction.IsDeleted == false).ToList();
                }

                List<TransactionDTO> transactionsDTO = _mapper.Map<List<TransactionDTO>>(transactions);

                if (Request.Query.ContainsKey("page"))
                    int.TryParse(Request.Query["page"], out pageToShow);
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateUsers = PaginateHelper.Paginate(transactionsDTO, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(200, paginateUsers);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }
        public async Task<IActionResult> GetAllUserTransaction(int id, int parameter, int pageSize, int pageToShow, HttpRequest Request)
        {
            try
            {

                List<Transaction> transactions = await _unitOfWork.TransactionRepository.GetAllUserTransaction(id);



                if (parameter == 0)
                {
                    transactions = transactions.Where(transaction => transaction.IsDeleted == false).ToList();
                }

                List<TransactionDTO> transactionsDTO = _mapper.Map<List<TransactionDTO>>(transactions);

                if (Request.Query.ContainsKey("page"))
                    int.TryParse(Request.Query["page"], out pageToShow);
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateUsers = PaginateHelper.Paginate(transactionsDTO, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(200, paginateUsers);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
        }
    }
}