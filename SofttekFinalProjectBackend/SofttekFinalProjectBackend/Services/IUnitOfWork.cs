using SofttekFinalProjectBackend.DataAccess.Repositories;

namespace SofttekFinalProjectBackend.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public Task<int> Complete();

    }
}
