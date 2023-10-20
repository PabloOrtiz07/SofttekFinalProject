using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.Entities
{
    [Table("fiduciaryAccount")]

    public class FiduciaryAccount : Account
    {

        [Required]
        [Column("fiduciaryAccount_cbu", TypeName = "VARCHAR(100)")]
        public string Cbu { get; set; }

        [Required]
        [Column("fiduciaryAccount_alias", TypeName = "VARCHAR(100)")]
        public string Alias { get; set; }

        [Required]
        [Column("fiduciaryAccount_accountNumber")]
        public string AccountNumber { get; set; }
    }
}
