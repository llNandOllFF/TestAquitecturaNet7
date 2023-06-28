using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.DTOs;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AFORO255.MS.TEST.Security.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUserService _userService;
        private readonly string _exp;
        public AuthenticationController(IOptionsSnapshot<JwtOptions> jwtOptions, IUserService userService, IConfiguration configuration)
        {
            _jwtOptions = jwtOptions.Value;
            _userService = userService;
            _exp = configuration.GetSection("jwt:expiration").Value??"no definido.";
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] AuthenticationRequest oAuthentication) 
        {
            if (!_userService.ValidateUser(oAuthentication.username, oAuthentication.password)) return Unauthorized();
            string token = JwtToken.Create(_jwtOptions);
            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", token);
            return Ok(new AuthenticationResponse(token, _exp+" .min"));
        }
    }
}
