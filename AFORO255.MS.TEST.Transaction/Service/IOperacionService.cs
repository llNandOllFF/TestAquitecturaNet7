using AFORO255.MS.TEST.Transaction.DTOs;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public interface IOperacionService
    {
        Task<OperacionDto> Add(OperacionRequest oOperacion);
        Task<IEnumerable<OperacionDto>> GetById(long idInvoice);
    }
}
