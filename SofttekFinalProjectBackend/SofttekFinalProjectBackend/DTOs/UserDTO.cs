using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.DTOs
{
    public class UserDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTimeUtc { get; set; }
        public List<CryptoAccount> CryptoAccounts { get; set; }
        public List<FiduciaryAccount> FiduciaryAccounts { get; set; }
    }
}
