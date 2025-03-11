using Motos.Model;
using System.Linq.Expressions;

namespace Motos.Repository
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(Expression <Func<T,bool>> predicate);
        T Create(T entry);
        T Update(T entry);
        T Delete(T entry);
    }
}
