using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Infrastructure;

namespace SofttekFinalProjectBackend.Services
{
    public class SalesServices
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SalesServices(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;

        }

        public async Task<IActionResult> GetAllSales(int parameter, int pageSize, int pageToShow, HttpRequest Request)
        {
            try
            {

                List<Sale> sales = await _unitOfWork.SaleRepository.GetAll();



                if(parameter == 0)
                {
                    sales = sales.Where(sale => sale.IsDeleted == false).ToList();
                }

                List<SaleDTO> salesDTO = _mapper.Map<List<SaleDTO>>(sales);

                if (Request.Query.ContainsKey("page")) 
                    int.TryParse(Request.Query["page"], out pageToShow);
                    var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                    var paginateUsers = PaginateHelper.Paginate(salesDTO, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(200, paginateUsers);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }
    }
}
