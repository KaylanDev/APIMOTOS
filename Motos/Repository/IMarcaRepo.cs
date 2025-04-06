using Motos.Model;
using System.Linq.Expressions;

namespace Motos.Repository
{
    public interface IMarcaRepo : IRepository<Marca>
    {
        public IEnumerable<Marca> MotosMarca();
      
    }
}
