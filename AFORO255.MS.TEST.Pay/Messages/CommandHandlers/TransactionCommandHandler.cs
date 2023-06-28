using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using AutoMapper;
using MediatR;

namespace AFORO255.MS.TEST.Pay.Messages.CommandHandlers
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCreateCommand, bool>
    {
        private readonly IEventBus _eventBus;
        private readonly IMapper _mapper;
        public TransactionCommandHandler(IEventBus eventBus, IMapper mapper)
        {
            _eventBus = eventBus;
            _mapper = mapper;
        }
        public Task<bool> Handle(TransactionCreateCommand command, CancellationToken cancellationToken)
        {
            _eventBus.Publish(_mapper.Map<TransactionCreatedEvent>(command));
            return Task.FromResult(true);
        }
    }
}
