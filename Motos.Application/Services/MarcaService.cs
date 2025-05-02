using Motos.Application.Interfaces;
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
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        public Task<Marca> Create(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> GetById(Expression<Func<Marca, bool>> predicate)
        {
            var marca = _marcaRepository.GetByIdAsync(predicate);
            return marca;
        }

     

        public Task<IEnumerable<Marca>> GetMarcas()
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Update(Marca marca)
        {
            throw new NotImplementedException();
        }
    }
}
