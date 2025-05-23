using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Motos.API;
using Motos.Application.Interfaces;
using Motos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Motos.Application.DTO;
using Motos.Application.Service;
using Microsoft.Extensions.Caching.Memory;

namespace Motos.API.Controllers
{
    [Route("motos")]
    [ApiController]
    public class MotosMController : ControllerBase
    {
        private readonly IMotosMService _motosService;
        private readonly ICacheService _cacheService;
        private const string cacheKey = "Moto";

        private string _cacheKey(int id) => $"{cacheKey}_{id}";

        public MotosMController(IMotosMService motosMService,ICacheService cacheService)

        {
            _cacheService = cacheService;
            _motosService = motosMService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {


               var motos = await _cacheService.GetOrCreate(cacheKey, async () => await _motosService.GetMotos());

            if (motos is null)
            {
                return NotFound("Nao foi possivel encontrar!");
            }
            return Ok(motos);

        }

    

        [HttpGet("{id:int}",Name = "Moto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id is invalid!");
            }

            var moto = await _cacheService.GetOrCreate(_cacheKey(id), async () => await _motosService.GetById(id));

            if (moto is null) return BadRequest("Object is null!");
            

            return Ok(moto);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Patch(JsonPatchDocument<MotosM> jsonPatch,int id)
        {
            var moto = await _motosService.Pacth(jsonPatch, id);
            if (moto is null || !ModelState.IsValid) return BadRequest();
          var motoDto = await _motosService.GetById(id);
            if (motoDto is null) return BadRequest("Object is null!");
            await  _motosService.Update(motoDto);
         
            return Ok(moto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(MotosDTO motoDto)
        {
            if (!ModelState.IsValid) return BadRequest();
           var motoca = await _motosService.Create(motoDto);
            _cacheService.Remove(cacheKey);
           await _cacheService.GetOrCreate(_cacheKey(motoDto.Id), async () => await _motosService.GetById(motoDto.Id));


            return Ok(motoca);
        }
   

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(MotosDTO moto, int id)
        {
            if (id != moto.Id) return BadRequest("insira o id correto");
           await _motosService.Update(moto);


            return Ok(moto);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<MotosM>> Delete(int id) {
          var moto = await _motosService.GetById(id);
            if (id <= 0) return BadRequest("Id invalido");
           await _motosService.Delete(id);
            _cacheService.Remove(_cacheKey(id));
            _cacheService.Remove(cacheKey);

            return Ok(moto);
        
        }
        
    }
}
