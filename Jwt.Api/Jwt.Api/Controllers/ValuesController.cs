using Jwt.Api.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Jwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Token token =Security.TokenHandler.CreateToken(_configuration); 
            //TokenHandler.CreateTokenHandler(_configuration);
            return Ok();
        }
    }
}
