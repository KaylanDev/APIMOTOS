using Motos.Model;

namespace Motos.Repository
{
    public interface IMarcaRepo : IRepository<Marca>
    {
        public IEnumerable<Marca> MotosMarca();
    }
}
