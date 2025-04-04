using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Motos.Data;
using Motos.Model;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Motos.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(Expression<Func<T, bool>> predicate)
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
            _context.Update(entry);
            return entry;
        }
    }
}
