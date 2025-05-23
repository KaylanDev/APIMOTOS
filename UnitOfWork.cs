using Motos.API.Data;
using Motos.API.Repository.Interfaces; // Certifique-se de que este namespace existe para IMotosRepo e IMarcaRepo
using Motos.API.Repository.Implementations; // Certifique-se de que este namespace existe para MotosRepo e MarcaRepo

namespace Motos.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMotosRepo _motosRepo;
        private IMarcaRepo _marcaRepo;
        public AppDbContext context;

        public UnitOfWork(AppDbContext context)
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

        public IMarcaRepo MarcaRepo
        {
            get
            {
                return _marcaRepo = _marcaRepo ?? new MarcaRepo(context);
            }
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}
