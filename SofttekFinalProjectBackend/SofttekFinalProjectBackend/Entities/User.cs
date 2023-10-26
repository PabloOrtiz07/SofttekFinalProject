using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace SofttekFinalProjectBackend.Entities
{
    [Table("users")]

    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        [Required]
        [Column("user_password", TypeName = "VARCHAR(100)")]

        public string Password { get; set; }

        [Required]
        [Column("user_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column("user_isDeleted")]
        public bool IsDeleted { get; set; }


        [Column("user_deletedTimeUtc")]
        public DateTime? DeletedTimeUtc { get; set; }

        [Column("user_crytoAccount")]
        public ICollection<CryptoAccount> CryptoAccounts { get; set; }
 
        [Column("user_fiduciaryAccount")]
        public ICollection<FiduciaryAccount> FiduciaryAccounts { get; set; }

        [Column("user_sales")]
        public ICollection<Sale> Sales { get; set; }

        [Column("user_transactions")]
        public ICollection<Transaction> Transactions { get; set; }

        [Required]
        [Column("role_id")]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
