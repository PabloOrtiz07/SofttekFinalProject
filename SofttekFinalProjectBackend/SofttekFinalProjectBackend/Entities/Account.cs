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
        public int Amount
        {
            get; set;
        }

        [Required]
        [Column("account_sortofaccount")]
        public SortOfAccount Status { get; set; }

        [Required]
        [Column("account_user")]
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }

    }

    public enum SortOfAccount
    {
        Pesos,
        Dollar,
        Crypto
    }
}
