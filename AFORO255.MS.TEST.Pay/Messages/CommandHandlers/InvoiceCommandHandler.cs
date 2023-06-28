using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using AutoMapper;
using MediatR;

namespace AFORO255.MS.TEST.Pay.Messages.CommandHandlers
{
    public class InvoiceCommandHandler : IRequestHandler<InvoiceCreateCommand,bool>
    {
        private readonly IEventBus _eventBus;
        private readonly IMapper _mapper;
        public InvoiceCommandHandler(IEventBus eventBus, IMapper mapper)
        {
            _eventBus = eventBus;
            _mapper = mapper;
        }

        public Task<bool> Handle(InvoiceCreateCommand command,CancellationToken cancellationToken) 
        {
            _eventBus.Publish(_mapper.Map<InvoiceCreatedEvent>(command));
            return Task.FromResult(true);
        }
    }
}
