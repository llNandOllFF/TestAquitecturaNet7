using AFORO255.MS.TEST.Security.DTOs;
using AFORO255.MS.TEST.Security.Models;
using AFORO255.MS.TEST.Security.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Security.Service
{
    public class UserService :IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public IEnumerable<UserDto> Listar() => _mapper.Map<IEnumerable<UserDto>>( _context.Users.AsNoTracking()
                                                                                                 .OrderBy(x => x.IdUser)
                                                                                                 .ToList());

        public bool ValidateUser(string username, string pass )
        {
            return (_context.Users.Where(x => x.UserName == username)
                                 .Where(x => x.Password == pass)
                                 .ToList()).Any();
        }
    }
}
