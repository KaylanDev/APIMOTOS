using Microsoft.EntityFrameworkCore;
using Motos.Domain.Entities;
using Motos.Domain.Interfaces;
using Motos.Infrastruture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Infrastruture.Repository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Marca>> GetMotosByMarca()
        {
          
            var marca = await _context.Marca.Include(m => m.Motos).ToListAsync();
            return marca;
        }

        public async Task<Marca> GetMotosByMarcaOne(Expression<Func<Marca, bool>> predicate)
        {
            var marca = await _context.Marca.Include(m => m.Motos).FirstOrDefaultAsync(predicate);
            return marca;
        }
    }
}
