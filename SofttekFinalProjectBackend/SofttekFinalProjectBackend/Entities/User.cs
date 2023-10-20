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

        [JsonIgnore]

        [Column("user_crytoAccount")]
        public ICollection<CryptoAccount> CryptoAccounts { get; set; }
        [JsonIgnore]
 
        [Column("user_fiduciaryAccount")]
        public ICollection<FiduciaryAccount> FiduciaryAccounts { get; set; }


    }
}
