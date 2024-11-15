using Domains.Models;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CourseContext _context;

        public IStudentRepository StudentRepository { get; set; }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ClearAllTrackedEntities();
                throw;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                ClearAllTrackedEntities();
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public void ClearAllTrackedEntities()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
