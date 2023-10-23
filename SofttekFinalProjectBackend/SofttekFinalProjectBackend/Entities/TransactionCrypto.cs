using AutoMapper;
using SofttekFinalProjectBackend.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.Entities
{
    public class TransactionCrypto : TransfersCrypto
    {
        [Key]
        public int Id { get; set; }
    }
}
