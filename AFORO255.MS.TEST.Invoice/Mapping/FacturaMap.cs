using AFORO255.MS.TEST.Invoice.DTOs;
using AFORO255.MS.TEST.Invoice.Models;
using AutoMapper;

namespace AFORO255.MS.TEST.Invoice.Mapping
{
    public class FacturaMap : Profile
    {
        public FacturaMap() 
        {
            CreateMap<Factura,FacturaDto>()
                .ForMember(dst=> dst.EstadoDesc, opt => opt.MapFrom(src=> src.Estado==1?"Pendiente de pago":src.Estado==0?"Pagado":"No definido"))
                .ReverseMap();
        }
    }
}
