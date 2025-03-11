using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Motos.Data;
using Motos.Model;
using Motos.Repository;
using System.Threading.Tasks;

namespace Motos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotosMController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly AppDbContext _conxtex;
        public MotosMController(IUnitOfWork uof,AppDbContext context)

        {
            _conxtex = context;
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotosM>>> Get()
        {
            var motos = await _uof.MotosRepo.Get();
            return Ok(motos);
        }

        [HttpGet("{id:int}",Name = "Moto")]
       public async Task<ActionResult<MotosM>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id is invalid!");
            }

            var moto = await _uof.MotosRepo.GetById(m => m.Id == id);
            if (moto is null) return BadRequest("Object is null!");

            return Ok(moto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MotosM moto)
        {
            if (!ModelState.IsValid) return BadRequest();
            _uof.MotosRepo.Create(moto);
          await  _uof.Commit();
            return Ok(moto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(MotosM moto, int id)
        {
            if (id != moto.Id) return BadRequest("insira o id correto");
            _uof.MotosRepo.Update(moto);
            await _uof.Commit();

            return Ok(moto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MotosM>> Delete(int id) {
            var moto = await _uof.MotosRepo.GetById(m => m.Id == id);
            
            if (moto is null) return BadRequest("objeto nulo");
            _uof.MotosRepo.Delete(moto);
           await _uof.Commit();
            return Ok(moto);
        
        }
        
    }
}
