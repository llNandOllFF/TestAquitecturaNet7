using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Pay.Messages.Events
{
    public class TransactionCreatedEvent : InvoiceCreatedEvent
    {
        public string Date { get; set; }
    }
}
