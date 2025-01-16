using Microsoft.AspNetCore.Mvc;
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
        
    }
}
