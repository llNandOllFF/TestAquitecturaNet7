using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AutoMapper;

namespace AFORO255.MS.TEST.Transaction.Mapping
{
    public class TransactionMap : Profile
    {
        public TransactionMap() 
        {
            CreateMap<TransactionCreatedEvent, OperacionRequest>()
                .ForMember(dst => dst.DateString, opt => opt.MapFrom(src => src.Date))
                .ReverseMap();
        }
    }
}
