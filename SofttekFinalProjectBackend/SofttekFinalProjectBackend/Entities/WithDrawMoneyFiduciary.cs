namespace SofttekFinalProjectBackend.Entities
{
    public class WithDrawMoneyFiduciary
    {
        public string Cbu { get; set; }

        public string Alias { get; set; }

        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public TypeOfAccount TypeOfWithDraw { get; set; }


    }
}
