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
            return await _context.MotosM
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
