using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using AutoMapper;

namespace AFORO255.MS.TEST.Pay.Mapping
{
    public class TransactionMap : Profile
    {
        public TransactionMap() 
        {
            CreateMap<PagoDto, TransactionCreateCommand>()
                .ForMember(dst=> dst.Date , opt => opt.MapFrom(src=> src.Date.ToString()))
                .ReverseMap();
            CreateMap<TransactionCreateCommand, TransactionCreatedEvent>().ReverseMap();
        }
    }
}
