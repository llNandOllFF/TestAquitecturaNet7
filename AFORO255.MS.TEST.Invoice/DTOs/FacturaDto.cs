namespace AFORO255.MS.TEST.Invoice.DTOs
{
    public class FacturaDto
    {
        public long IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public int Estado { get; set; }
        public string EstadoDesc { get; set; }
    }
}
