using AFORO255.MS.TEST.Invoice.DTOs;

namespace AFORO255.MS.TEST.Invoice.Service
{
    public interface IFacturaService
    {
        FacturaDto BuscarPorInvoice(long IdInvoice);
        IEnumerable<FacturaDto> Listar();
        FacturaDto Actualizar(FacturaDto oFacturaDto);
    }
}
