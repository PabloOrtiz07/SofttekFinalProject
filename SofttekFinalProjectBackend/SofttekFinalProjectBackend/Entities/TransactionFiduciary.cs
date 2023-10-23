using AutoMapper;
using SofttekFinalProjectBackend.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.Entities
{
    public class TransactionFiduciary : TransfersFiduciary
    {
        [Key]
        public int Id { get; set; }
    }
}
