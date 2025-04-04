using Motos.Data;
using Motos.Model;

namespace Motos.Repository
{
    public class MarcaRepo : Repository<Marca>, IMarcaRepo
    {
        public MarcaRepo(AppDbContext context) : base(context)
        {
        }


    }
}
