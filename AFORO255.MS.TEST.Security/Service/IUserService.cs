using AFORO255.MS.TEST.Security.DTOs;

namespace AFORO255.MS.TEST.Security.Service
{
    public interface IUserService
    {
        IEnumerable<UserDto> Listar();
        bool ValidateUser(string username, string pass);
    }
}
