using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Messages.Events;
using AFORO255.MS.TEST.Invoice.Service;
using AutoMapper;

namespace AFORO255.MS.TEST.Invoice.Messages.EventHandlers
{
    public class InvoiceEventHandler : IEventHandler<InvoiceCreatedEvent>
    {
        private readonly IFacturaService _facturaService;
        public InvoiceEventHandler(IFacturaService facturaService) => _facturaService = facturaService;
        public Task Handle (InvoiceCreatedEvent @event)
        {
            var oFactura = _facturaService.BuscarPorInvoice(@event.IdInvoice);

            oFactura.Amount = oFactura.Amount - @event.Amount;

            if (oFactura.Amount <= 0) oFactura.Estado = 0;

            _facturaService.Actualizar(oFactura);

            return Task.CompletedTask;
        }
    }
}
