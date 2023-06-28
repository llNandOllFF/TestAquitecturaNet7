using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Invoice.Messages.Events
{
    public class InvoiceCreatedEvent : Event
    {
        public long IdInvoice { get; set; }
        public decimal Amount { get; set; }
    }
}
