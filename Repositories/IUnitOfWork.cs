namespace Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        void Commit();
        Task CommitAsync();
    }
}
