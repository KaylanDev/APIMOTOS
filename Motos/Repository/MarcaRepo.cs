using Microsoft.EntityFrameworkCore;
using Motos.Data;
using Motos.Model;
using System.Linq.Expressions;

namespace Motos.Repository
{
    public class MarcaRepo : Repository<Marca>, IMarcaRepo
    {
        public MarcaRepo(AppDbContext context) : base(context)
        {
        }



        public IEnumerable<Marca> MotosMarca()
        {
            var motos = _context.Marca.Include(c => c.Motos ).ToList();
            return motos;
        }

    }
}
