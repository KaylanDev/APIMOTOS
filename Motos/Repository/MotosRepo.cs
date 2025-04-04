using Motos.Data;
using Motos.Model;
using Microsoft.EntityFrameworkCore;

namespace Motos.Repository
{
    public class MotosRepo : Repository<MotosM>, IMotosRepo
    {
        public MotosRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<MotosM>> Get()
        {
            return await _context.MotosM
                .Include(m => m.Marca)
                .ToListAsync();
        }

        public override async Task<MotosM> GetById(System.Linq.Expressions.Expression<Func<MotosM, bool>> predicate)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _context.MotosM
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(predicate);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public override MotosM Create(MotosM entry)
        {
            var Marca = _context.Marca.FirstOrDefault(m => m.NomeMarca == entry.MarcaMoto);

            if (Marca == null)
            {
                throw new ArgumentNullException("Marca inexistente");
            }

            entry.MarcaId = Marca.MarcaId;
            return base.Create(entry);
        }
    }
}
