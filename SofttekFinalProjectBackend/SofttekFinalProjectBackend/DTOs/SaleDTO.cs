using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SofttekFinalProjectBackend.DTOs
{
    public class SaleDTO
    {

            public int SaleNumber { get; set; }
            public double Amount { get; set; }
            public string NameOfCrypto { get; set; }


    }
}
