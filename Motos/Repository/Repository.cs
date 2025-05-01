using Microsoft.EntityFrameworkCore;
using Motos.API.Data;
using System.Linq.Expressions;

namespace Motos.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual T Create(T entry)
        {
            _context.Set<T>().Add(entry);
            return entry;
        }

        public T Delete(T entry)
        {
            _context.Set<T>().Remove(entry);
            return entry;
        }

        public T Update(T entry)
        {
            _context.Set<T>().Update(entry);
            return entry;
        }
    }
}
