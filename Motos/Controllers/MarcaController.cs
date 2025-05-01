using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Motos.API.Model;

using Motos.Application.Interfaces;
using Motos.Domain.Entities;
using System.Threading.Tasks;

namespace Motos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _uof;

        public MarcaController(IMarcaService uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
           var marcas = await _uof.GetMarcas();

            return Ok(marcas);
        }

       /*[HttpGet("MOTOS DA MARCA")]
        public Task<ActionResult> getMarcas()
        {
            var motos = _motosService.
            return Ok(motos);
        }
        */
        [HttpPost]
        public async Task<ActionResult> Post(Marca marca) {

            if (!ModelState.IsValid) return BadRequest();


          await _uof.Create(marca);
           
            return Ok(marca)
                ;
        }


    }
}
