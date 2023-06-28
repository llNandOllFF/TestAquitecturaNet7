using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace AFORO255.MS.TEST.Pay.Service
{
    public class PagoService : IPagoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PagoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PagoDto> Listar() => _mapper.Map<IEnumerable<PagoDto>>(_context.Pago.AsNoTracking()
                                                                                               .OrderBy(x => x.IdInvoice)
                                                                                               .ToList());
        public PagoDto Agregar(long idInvoice,decimal amount)
        {
            Pago oPago = new Pago { IdInvoice = idInvoice, Amount = amount, Date = DateTime.Now };
            
            _context.Pago.Add(oPago);

            _context.SaveChanges();

            return _mapper.Map<PagoDto>(oPago);
        }
    }
}
