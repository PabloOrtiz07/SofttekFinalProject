using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface ISaleRepository : IRepository<Sale>
    {
        public Task<bool> SaveSaleDTO(SaleRequestDTO saleDTO);
        public Task<List<Sale>> GetAllAvailable();
        public Task<bool> DeleteSaleById(int id);

    }
}
