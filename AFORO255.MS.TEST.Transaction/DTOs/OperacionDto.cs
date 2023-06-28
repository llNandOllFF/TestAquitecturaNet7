namespace AFORO255.MS.TEST.Transaction.DTOs
{
    public class OperacionDto
    { 
        public string IdTransaccion { get; set; }
        public long? IdInvoice { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }

}
}
