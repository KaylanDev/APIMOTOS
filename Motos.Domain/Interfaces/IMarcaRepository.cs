using Motos.Domain.Entities;
using System.Linq.Expressions;

namespace Motos.Domain.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        public Task<IEnumerable<Marca>> GetMotosByMarca();
        public Task<Marca> GetMotosByMarcaOne(Expression<Func<Marca ,bool>>predicate);
    }
}
