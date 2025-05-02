


using Motos.Domain.Entities;
using System.Linq.Expressions;

namespace Motos.Application.Interfaces;

public interface IMarcaService
{
    public Task<IEnumerable<Marca>> GetMarcas();
    public Task<Marca> GetById(Expression<Func<Marca, bool>> predicate);

    public Task<Marca> Create(Marca marca);
    public Task<Marca> Update(Marca marca);
    public Task<Marca> Delete(int id);

}
