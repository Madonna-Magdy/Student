namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> Query();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}
