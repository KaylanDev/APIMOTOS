using System.Linq.Expressions;

namespace Motos.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
    Task<T> Create(T entry);
    Task<T> Delete(T entry);
    Task<T> Update(T entry);
}
