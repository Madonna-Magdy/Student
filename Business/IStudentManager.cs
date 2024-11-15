using Business.ViewModels;

namespace Business
{
    public interface IStudentManager
    {
        Task AddAsync(StudentAddVm model);
        Task UpdateAsync(StudentVm model);
        Task DeleteAsync(int id);
        Task<StudentVm> GetByIdAsync(int id);
        Task<List<StudentVm>> GetAllAsync();
    }
}
