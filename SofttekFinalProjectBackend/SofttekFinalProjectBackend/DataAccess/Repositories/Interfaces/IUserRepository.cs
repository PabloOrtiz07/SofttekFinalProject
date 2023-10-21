using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        public Task<User> GetUserById(int id);

        public Task<UserDTO> GetUserDTOById(int id);
        public Task<User?> AuthenticateCredentials(AuthenticateDTO dto);


    }
}
