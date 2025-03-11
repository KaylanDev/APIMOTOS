
using Motos.Data;
using Motos.Model;

namespace Motos.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMotosRepo _motosRepo;

        public AppDbContext context;

        public UnitOfWork( AppDbContext context)
        {
            
            this.context = context;
        }

        public IMotosRepo MotosRepo
        {
            get
            {
               return _motosRepo = _motosRepo ?? new MotosRepo(context);
            }
        }

       

        public async Task Commit()
        {
             await context.SaveChangesAsync();
        }
    }
}
