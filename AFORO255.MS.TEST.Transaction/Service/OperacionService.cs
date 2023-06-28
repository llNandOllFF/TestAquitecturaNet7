using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Models;
using AFORO255.MS.TEST.Transaction.Persistencia;
using AutoMapper;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public class OperacionService : IOperacionService
    {
        private readonly IMongoBookDBContext _context;
        protected IMongoCollection<Operacion> _dbCollection;
        private readonly IMapper _mapper;
        public OperacionService(IMongoBookDBContext context, IMapper mapper)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Operacion>(typeof(Operacion).Name);
            _mapper = mapper;
        }
        public async Task<OperacionDto> Add(OperacionRequest oOperacionRecord)
        {
            Operacion oOperacion = _mapper.Map<Operacion>(oOperacionRecord);
            await _dbCollection.InsertOneAsync(oOperacion);
            return _mapper.Map<OperacionDto>(oOperacion);
        }
        public async Task<IEnumerable<OperacionDto>> GetById(long idInvoice)
        {
            var result = await _dbCollection.Find(x => x.IdInvoice == idInvoice)
                                            .ToListAsync();
            return _mapper.Map<IEnumerable<OperacionDto>>(result.OrderBy(x => x.IdTransaccion));
        }
    }
}
