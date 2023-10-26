using SofttekFinalProjectBackend.DTOs;

namespace SofttekFinalProjectBackend.Entities
{
    public class DepositFiduciary : DepositDTO
    {

        public string Cbu { get; set; }

        public string Alias { get; set; }

        public string AccountNumber { get; set; }

    }
}
