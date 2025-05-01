namespace Motos.API.Repository
{
    public interface IUnitOfWork
    {
        IMotosRepo MotosRepo { get; }
        IMarcaRepo MarcaRepo { get; }
        Task Commit();
    }
}
