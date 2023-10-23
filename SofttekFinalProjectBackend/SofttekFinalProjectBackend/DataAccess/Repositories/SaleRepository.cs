using AutoMapper;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using System.Data;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly IMapper _mapper;

        public SaleRepository(ContextDB contextDB, AutoMapper.IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }
        public virtual async Task<bool> SaveSaleDTO(SaleRequestDTO saleRequest)
        {
            try
            {
                Sale sale = _mapper.Map<Sale>(saleRequest);
                _contextDB.Set<Sale>().Add(sale);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<List<Sale>> GetAllAvailable()
        {
            try
            {
                var sales = await base.GetAll();

                sales = sales.Where(role => role.IsDeleted == false).ToList();
                return sales;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteSaleById(int id)
        {

            try
            {
                Sale saleFinding = await GetById(id);
                if (saleFinding == null)
                {
                    return false;
                }
                saleFinding.IsDeleted = true;
                saleFinding.DeletedTimeUtc = DateTime.UtcNow;
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
