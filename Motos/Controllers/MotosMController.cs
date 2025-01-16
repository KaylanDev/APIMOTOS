using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Motos.Data;
using Motos.Model;

namespace Motos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotosMController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MotosMController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MotosM>> Get()
        {

            try
            {
            return _db.MotosM.ToList();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }
        }

        [HttpGet("{id:int}",Name = "motos")]
       public ActionResult<MotosM> GetOne(int id)
        {
            try
            {
            return _db.MotosM.FirstOrDefault(moto => moto.Id == id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }
        }

        [HttpPost]
        public ActionResult Post(MotosM m)
        {
            try
            {
                if (m is null) return BadRequest("vc n preencheu");

                _db.MotosM.Add(m);
                _db.SaveChanges();

                return new CreatedAtRouteResult("motos", new { Id = m.Id }, m);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }
            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(MotosM m, int id)
        {
            if (id != m.Id) return BadRequest("insira o id correto");
            _db.Entry(m).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(m);

        }

        [HttpDelete("{id:int}")]
        public ActionResult<MotosM> Delete(int id) {
            var moto = _db.MotosM.FirstOrDefault(m => m.Id == id);
            
            if (moto is null) return BadRequest("objeto nulo");

          
            _db.MotosM.Remove(moto);
            _db.SaveChanges();
            return Ok(moto);
        
        }
        
    }
}
