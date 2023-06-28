using AFORO255.MS.TEST.Invoice.DTOs;
using AFORO255.MS.TEST.Invoice.Models;
using AFORO255.MS.TEST.Invoice.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Invoice.Service
{
    public class FacturaService : IFacturaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public FacturaService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }
        public IEnumerable<FacturaDto> Listar() => _mapper.Map<IEnumerable<FacturaDto>>(_context.Factura.AsNoTracking()
                                                                                                        .OrderBy(x => x.IdInvoice)
                                                                                                        .ToList());

        public FacturaDto BuscarPorInvoice(long IdInvoice) => _mapper.Map<FacturaDto>(_context.Factura.AsNoTracking().FirstOrDefault(x => x.IdInvoice == IdInvoice));
        public FacturaDto Actualizar(FacturaDto oFacturaDto)
        {
            Factura oFactura = _context.Factura.AsNoTracking()
                                               .FirstOrDefault(x => x.IdInvoice == oFacturaDto.IdInvoice);

            if(oFactura == null) return new FacturaDto();

            oFactura = _mapper.Map<Factura>(oFacturaDto);

            _context.Factura.Update(oFactura);

            _context.SaveChanges();

            return _mapper.Map<FacturaDto>(oFactura);
        }
    }
}
