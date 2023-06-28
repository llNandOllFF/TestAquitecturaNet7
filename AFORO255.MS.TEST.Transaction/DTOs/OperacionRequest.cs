namespace AFORO255.MS.TEST.Transaction.DTOs
{
    public class OperacionSearch
    {
        public long IdInvoice { get; set; }
    }
    public class OperacionRequest
    {
        public long IdInvoice {get;set;}
        public decimal Amount {get;set;}
        public string DateString {get;set;}
    }
}
