using Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private CourseContext _context;

        #region Constructors

        protected RepositoryBase(CourseContext context)
        {
            _entities = context.Set<TEntity>();
            context.Database.SetCommandTimeout(180);
            _context = context;
        }

        #endregion

        #region Properties

        private readonly DbSet<TEntity> _entities;

        #endregion

        #region Methods

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return _entities.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
                Delete(entity);
        }

        #endregion

    }
}
