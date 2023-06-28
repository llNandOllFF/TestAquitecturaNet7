using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using AutoMapper;

namespace AFORO255.MS.TEST.Pay.Mapping
{
    public class InvoiceMap : Profile
    {
        public InvoiceMap() 
        {
            CreateMap<PagoDto, InvoiceCreateCommand>().ReverseMap();
            CreateMap<InvoiceCreateCommand, InvoiceCreatedEvent>().ReverseMap();
        }
    }
}
