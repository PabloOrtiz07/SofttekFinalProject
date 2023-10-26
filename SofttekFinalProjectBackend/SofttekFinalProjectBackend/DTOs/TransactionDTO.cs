using SofttekFinalProjectBackend.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public TypeOfOperation TypeOfOperation { get; set; }
        public string descriptionOperation { get; set; }
        public double amount { get; set; }
        public TransfersFiduciary? fiduciaryAccountOrigin { get; set; }
        public TransfersCrypto? cryptoAccountOrigin { get; set; }
        public TransfersFiduciary? fiduciaryAccountDestination { get; set; }
        public TransfersCrypto? cryptoAccountDestination { get; set; }
        public DateTime CreatedTimeUtc { get; set; }


    }
}
