using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Motos.API.Model;

using Motos.Application.Interfaces;
using Motos.Domain.Entities;
using System.Threading.Tasks;

namespace Motos.API.Controllers
{
    [Route("marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService uof)
        {
            _marcaService = uof;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var marcas = await _marcaService.GetMarcas();

            return Ok(marcas);
        }

        [HttpGet("GetMotos")]
        public async Task<ActionResult> GetMarcaMotos()
        {
            var marcas = await _marcaService.GetMotosPorMarca();

            return Ok(marcas);
        }
        
        [HttpGet("GetMotosById")]
        public async Task<ActionResult> GetOneMarcaMotos(int id)
        {
            var marca = await _marcaService.GetMotoPorMarcaOne(id);


            return Ok(marca);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var marca = await _marcaService.GetById(id);

            return Ok(marca);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(Marca marca) {

            if (!ModelState.IsValid) return BadRequest();


          await _marcaService.Create(marca);
           
            return Ok(marca)
                ;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Marca marca)
        {
            if (!ModelState.IsValid) return BadRequest();
            var marcaUp = await _marcaService.Update(marca);
            return Ok(marcaUp);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Id is invalid!");
            var marcaDel = await _marcaService.Delete(id);
            return Ok(marcaDel);
        }
    }
}
