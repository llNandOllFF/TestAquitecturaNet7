using AFORO255.MS.TEST.Pay.DTOs;

namespace AFORO255.MS.TEST.Pay.Service
{
    public interface IPagoService
    {
        IEnumerable<PagoDto> Listar();
        PagoDto Agregar(long idInvoice, decimal amount);
    }
}
