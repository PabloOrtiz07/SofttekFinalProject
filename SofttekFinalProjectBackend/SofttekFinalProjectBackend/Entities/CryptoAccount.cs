using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SofttekFinalProjectBackend.Entities
{
    [Table("cryptoAccounts")]
    [Index(nameof(Uuid), IsUnique = true)]

    public class CryptoAccount : Account
    {
        [Required]
        [Column("cryptoAccount_uuid", TypeName = "VARCHAR(100)")]
        public string Uuid { get; set; }

        [Required]
        [Column("cryptoAccount_description", TypeName = "VARCHAR(100)")]
        public string NameOfCrypto { get; set; }
    }
}
