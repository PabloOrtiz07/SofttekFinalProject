using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofttekFinalProjectBackend.Entities
{
    [Table("transactions")]

    public class Transaction
    {
        [Key]
        [Column("transaction_id")]
        public int Id { get; set; }
        [Required]
        [Column("transaction_typeofoperation")]
        public TypeOfOperation TypeOfOperation { get; set; }
        public string descriptionOperation { get; set; }
        public int? fiduciaryAccountOriginId { get; set; }
        public TransactionFiduciary? fiduciaryAccountOrigin { get; set; }
        public int? cryptoAccountOriginId { get; set; }
        public TransactionCrypto? cryptoAccountOrigin { get; set; }
        public int? fiduciaryAccountDestinationId { get; set; }
        public TransactionFiduciary? fiduciaryAccountDestination { get; set; }
        public int? cryptoAccountDestinationId { get; set; }
        public TransactionCrypto? cryptoAccountDestination { get; set; }

        public double Amount { get; set; }

        [Column("transaction_createdTimeUtc")]
        public DateTime? CreatedTimeUtc { get; set; }

        [Required]
        [Column("transaction_user")]
        [ForeignKey("UserId")]
        public int? UserId { get; set; }

        [Required]
        [Column("transaction_isDeleted")]
        public bool IsDeleted { get; set; }


        [Column("transaction_deletedTimeUtc")]
        public DateTime? DeletedTimeUtc { get; set; }

    }

    public enum TypeOfOperation
    {
        Sale,
        Buy,
        WithDraw,
        Deposit,
        Transfers
    }
}
