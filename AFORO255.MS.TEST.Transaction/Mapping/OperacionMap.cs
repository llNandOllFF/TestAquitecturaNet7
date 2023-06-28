using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Models;
using AutoMapper;

namespace AFORO255.MS.TEST.Transaction.Mapping
{
    public class OperacionMap : Profile
    {
        public OperacionMap()
        {
            CreateMap<Operacion, OperacionDto>()
                .ForMember(dst => dst.IdTransaccion , opt=> opt.MapFrom(src=> src.IdTransaccion.ToString()))
                .ReverseMap();                
            CreateMap<Operacion, OperacionRequest>()                
                .ReverseMap()
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => DateTime.Parse(src.DateString)));
                
        }
    }
}
