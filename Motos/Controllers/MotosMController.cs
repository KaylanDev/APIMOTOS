using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Motos.API.Model;
using Motos.API.Model.Dtos;
using Motos.API.Repository;

namespace Motos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotosMController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        
        public MotosMController(IUnitOfWork uof)

        {
           
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotosDto>>> Get()
        {
            var motos = await _uof.MotosRepo.GetAsync();

            var motosDto = MotosDto.MotosMToDtoList(motos);
            return Ok(motosDto);
        }

        [HttpGet("{id:int}",Name = "Moto")]
       public async Task<ActionResult<MotosDto>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id is invalid!");
            }

            var moto = await _uof.MotosRepo.GetByIdAsync(m => m.Id == id);
            if (moto is null) return BadRequest("Object is null!");
            var motodto =  MotosDto.MotosMToDto(moto);

            return Ok(motodto);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<MotosM>> Patch(JsonPatchDocument<MotosM> jsonPatch,int id)
        {
            var moto = await _uof.MotosRepo.GetByIdAsync(m => m.Id == id);
            if (moto is null) return BadRequest("objeto is null!");
            jsonPatch.ApplyTo(moto);
            if (!ModelState.IsValid) return BadRequest();

            _uof.MotosRepo.Update(moto);
            await _uof.Commit();
            return moto;
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
            var moto = await _uof.MotosRepo.GetByIdAsync(m => m.Id == id);
            
            if (moto is null) return BadRequest("objeto nulo");
            _uof.MotosRepo.Delete(moto);
           await _uof.Commit();
            return Ok(moto);
        
        }
        
    }
}
