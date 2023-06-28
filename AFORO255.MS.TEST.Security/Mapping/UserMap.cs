using AFORO255.MS.TEST.Security.DTOs;
using AFORO255.MS.TEST.Security.Models;
using AutoMapper;

namespace AFORO255.MS.TEST.Security.Mapping
{
    public class UserMap : Profile
    {
        public UserMap() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
