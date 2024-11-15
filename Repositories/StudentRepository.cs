using Domains.Models;

namespace Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private CourseContext _context;

        public StudentRepository(CourseContext context) : base(context)
        {
            _context = context;
        }

    }
}
