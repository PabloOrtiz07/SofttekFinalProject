using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.Entities
{
    [Table("cryptoAccount")]

    public class CryptoAccount : Account
    {
        [Required]
        [Column("cryptoAccount_uuid", TypeName = "VARCHAR(100)")]
        public string Uuid { get; set; }

        [Required]
        [Column("cryptoAccount_description", TypeName = "VARCHAR(100)")]
        public string Description { get; set; }
    }
}
