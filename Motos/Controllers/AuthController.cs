using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Motos.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      private readonly  IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


    }
}
