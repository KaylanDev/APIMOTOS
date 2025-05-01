using Motos.Domain.Entities;
using Motos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.Services
{
    public class MarcaService : IMarcaRepository
    {
        public Task<Marca> Create(Marca entry)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Delete(Marca entry)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Marca>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Marca> GetByIdAsync(Expression<Func<Marca, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Update(Marca entry)
        {
            throw new NotImplementedException();
        }
    }
}
