using Motos.API.Model;
using System.Linq.Expressions;

namespace Motos.API.Repository
{
    public interface IMarcaRepo : IRepository<Marca>
    {
        public IEnumerable<Marca> MotosMarca();
      
    }
}
