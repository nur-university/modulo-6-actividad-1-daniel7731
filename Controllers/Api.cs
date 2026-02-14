using ApiGateWay.Model;
using ApiGateWay.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Ocelot.RequestId;
using System.Reflection;

namespace ApiGateWay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class api : ControllerBase
    {
        private readonly TokenService _tokenService;
        public api(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User request)
        {
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = _tokenService.GenerateToken(request.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
