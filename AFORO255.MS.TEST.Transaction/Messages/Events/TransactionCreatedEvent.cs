using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Transaction.Messages.Events
{
    public class TransactionCreatedEvent : Event
    {
        public long IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}
