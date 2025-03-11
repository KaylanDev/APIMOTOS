namespace Motos.Repository
{
    public interface IUnitOfWork
    {
        IMotosRepo MotosRepo { get; }
        Task Commit();
    }
}
