using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Motos.Model;
using Motos.Repository;
using System.Threading.Tasks;

namespace Motos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public MarcaController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> Get()
        {
           var marcas = await _uof.MarcaRepo.Get();

            return Ok(marcas);
        }
        [HttpPost]
        public async Task<ActionResult<Marca>> Post(Marca marca) {

            if (!ModelState.IsValid) return BadRequest();


            _uof.MarcaRepo.Create(marca);
            await _uof.Commit();
            return Ok(marca)
                ;
        }


    }
}
