using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Motos.API.Model;
using Motos.Application.Interfaces;
using Motos.Domain.Entities;


namespace Motos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotosMController : ControllerBase
    {
        private readonly IMotosMService _motosService;
        
        public MotosMController(IMotosMService motosMService)

        {
           
            _motosService = motosMService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var motos = await _motosService.GetMotos();

           
            return Ok(motos);
        }

        [HttpGet("{id:int}",Name = "Moto")]
       public async Task<ActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id is invalid!");
            }

            var moto = await _motosService.GetById(m => m.Id == id);
            if (moto is null) return BadRequest("Object is null!");
            

            return Ok(moto);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(JsonPatchDocument<MotosM> jsonPatch,int id)
        {
            var moto = await _motosService.Pacth(jsonPatch, id);
            if (moto is null || !ModelState.IsValid) return BadRequest();
          var motoDto = await _motosService.GetByIdSemDTO(m => m.Id == moto.Id);
            if (motoDto is null) return BadRequest("Object is null!");
            await  _motosService.Update(motoDto);
         
            return Ok(moto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MotosM moto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _motosService.Create(moto);
          
            return Ok(moto);
        }
   

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(MotosM moto, int id)
        {
            if (id != moto.Id) return BadRequest("insira o id correto");
           await _motosService.Update(moto);


            return Ok(moto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MotosM>> Delete(int id) {
          var moto = await _motosService.GetById(m => m.Id == id);
            if (id <= 0) return BadRequest("Id invalido");
           await _motosService.Delete(id);

            return Ok(moto);
        
        }
        
    }
}
