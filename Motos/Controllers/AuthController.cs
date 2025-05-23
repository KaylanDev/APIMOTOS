using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Motos.Application.DTOs.Auth.Comands.Register;

namespace Motos.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;

        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistroRequest request)
        {
           

            try
            {
                var response = await _mediator.Send(request);

                if (response.Succeeded)
                {
                    return StatusCode(201, new { message = "Usuário registrado com sucesso!", userId = response.UserId });
                }
                else
                {
                    return BadRequest(new { errors = response.Errors });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no registro: {ex.Message}");
                return StatusCode(500, new { message = "Ocorreu um erro interno ao tentar registrar." });
            }
        }


    }
}
