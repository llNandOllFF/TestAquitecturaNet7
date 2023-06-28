namespace AFORO255.MS.TEST.Pay.DTOs
{
    public class PagoDto
    {
        public long IdOperation { get; set; }
        public long IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
