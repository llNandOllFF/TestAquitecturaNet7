using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Security.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController :ControllerBase
    {
        private readonly IUserService _userService;
        public UsuariosController(IUserService userService) => _userService = userService?? throw new ArgumentNullException(nameof(userService));
        
        [HttpGet]
        public IActionResult Get() => Ok(_userService.Listar());
    }
}
