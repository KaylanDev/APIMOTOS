using Motos.Data;
using Motos.Model;

namespace Motos.Repository
{
    public class MotosRepo : Repository<MotosM>,IMotosRepo
    {
        public MotosRepo(AppDbContext context) : base(context)
        {
        }

      
    }
}
