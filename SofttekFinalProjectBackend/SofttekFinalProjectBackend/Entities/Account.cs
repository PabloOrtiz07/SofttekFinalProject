using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.Entities
{
    public abstract class Account
    {
        [Key]
        [Column("account_id")]
        public int Id { get; set; }

        [Required]
        [Column("account_amount")]
        public double Amount
        {
            get; set;
        }

        [Required]
        [Column("account_typeOfaccount")]
        public TypeOfAccount TypeOfAccount { get; set; }

        [Required]
        [Column("account_user")]
        [ForeignKey("UserId")]
        public int? UserId { get; set; }

    }

    public enum TypeOfAccount
    {
        Pesos,
        Dollar,
        Crypto
    }
}
