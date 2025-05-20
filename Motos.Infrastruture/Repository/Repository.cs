using Microsoft.EntityFrameworkCore;
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
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {

            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
          await  Task.Delay(5000);
            var entry =   await _context.Set<T>().FirstOrDefaultAsync(predicate);
            return entry;
        }

        public async Task<T> Create(T entry)
        {
            _context.Set<T>().Add(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public async Task<T> Delete(T entry)
        {
            _context.Set<T>().Remove(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public async Task<T> Update(T entry)
        {
           _context.Update(entry);
            await _context.SaveChangesAsync();
            return entry; 
        }
    }
}
