using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transaction.Service;
using AutoMapper;

namespace AFORO255.MS.TEST.Transaction.Messages.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly IOperacionService _operacionService;
        private readonly IMapper _mapper;
        public TransactionEventHandler(IOperacionService operacionService, IMapper mapper)
        {
            _mapper = mapper;
            _operacionService = operacionService;
        }

        public Task Handle (TransactionCreatedEvent @event) 
        {
            _operacionService.Add(_mapper.Map<OperacionRequest>(@event));
            return Task.CompletedTask;
        }
    }
}
