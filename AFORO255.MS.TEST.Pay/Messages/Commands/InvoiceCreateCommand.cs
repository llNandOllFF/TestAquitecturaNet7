using Aforo255.Cross.Event.Src.Commands;

namespace AFORO255.MS.TEST.Pay.Messages.Commands
{
    public class InvoiceCreateCommand : Command
    {
        public long IdInvoice { get; set; }
        public decimal Amount { get; set; }
    }
}
