using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SofttekFinalProjectBackend.Entities
{
    [Table("sales")]

    public class Sale
    {
        [Key]
        [Column("sale_id")]
        public int Id { get; set; }

        [Required]
        [Column("sale_amount")]
        public double Amount { get; set; }

        [Required]
        [Column("sale_description", TypeName = "VARCHAR(100)")]
        public string NameOfCrypto { get; set; }

        [Required]
        [Column("sale_cbuaccountpesos", TypeName = "VARCHAR(100)")]
        public string CbuAccountPesos {get; set; }

        [Required]
        [Column("sale_isDeleted")]
        public bool IsDeleted { get; set; }


        [Column("sale_deletedTimeUtc")]
        public DateTime? DeletedTimeUtc { get; set; }
    }
}
