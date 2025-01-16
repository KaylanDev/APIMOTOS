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
            return _db.MotosM.ToList();
        }

        [HttpGet("{id:int}",Name = "motos")]
       public ActionResult<MotosM> GetOne(int id)
        {
            return _db.MotosM.FirstOrDefault(moto => moto.Id == id);
        }

        [HttpPost]
        public ActionResult Post(MotosM m)
        {
            if (m is null) return BadRequest("vc n preencheu");

            _db.MotosM.Add(m);
            _db.SaveChanges();

            return new CreatedAtRouteResult("motos", new { Id = m.Id},m);
            
        }
        
    }
}
