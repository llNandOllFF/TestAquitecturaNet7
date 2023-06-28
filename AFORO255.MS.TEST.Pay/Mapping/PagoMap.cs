using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Models;
using AutoMapper;

namespace AFORO255.MS.TEST.Pay.Mapping
{
    public class PagoMap : Profile
    {
        public PagoMap() 
        {
            CreateMap<Pago, PagoDto>().ReverseMap();
        }
    }
}
