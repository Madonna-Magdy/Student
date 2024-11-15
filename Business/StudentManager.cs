using Business.ExceptionHandling;
using Business.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Business
{
    public class StudentManager : IStudentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task AddAsync(StudentAddVm model)
        {
            ValidateStudent(model);

            await _unitOfWork.StudentRepository.AddAsync(new Domains.Models.Student
            {
                Address = model.Address,
                MobileNumber = model.MobileNumber,
                Name = model.Name
            });

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var isStudentExist = await _unitOfWork.StudentRepository.Query().AnyAsync(x => x.Id == id);
            if (!isStudentExist) 
            {
                throw new PortalValidationException("Student does not exist");
            }

            await _unitOfWork.StudentRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<StudentVm>> GetAllAsync()
        {
            var students = await _unitOfWork.StudentRepository.Query()
                .Select(x => new StudentVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    MobileNumber = x.MobileNumber,
                    Address = x.Address
                }).ToListAsync();

            return students;
        }

        public async Task<StudentVm> GetByIdAsync(int id)
        {
            var student = await _unitOfWork.StudentRepository.Query().Where(x => x.Id == id)
                .Select(x => new StudentVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    MobileNumber = x.MobileNumber,
                    Address = x.Address
                }).FirstOrDefaultAsync();

            if (student == null)
            {
                throw new PortalValidationException("Student does not exist");
            }

            return student;
        }

        public async Task UpdateAsync(StudentVm model)
        {
            ValidateStudent(model);

            var student = await _unitOfWork.StudentRepository.Query().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (student == null)
            {
                throw new PortalValidationException("Student does not exist");
            }

            student.Name = model.Name;
            student.MobileNumber = model.MobileNumber;
            student.Address = model.Address;

            await _unitOfWork.CommitAsync();
        }

        private void ValidateStudent(StudentAddVm model)
        {
            if (model == null)
            {
                throw new PortalValidationException("No Data Found");
            }

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new PortalValidationException("Empty Name");
            }

            if (string.IsNullOrWhiteSpace(model.MobileNumber))
            {
                throw new PortalValidationException("Empty Mobile Number");
            }

            if (model.MobileNumber.Length != 11 || !model.MobileNumber.StartsWith("01"))
            {
                throw new PortalValidationException("Invalid Mobile Number");
            }

            if (string.IsNullOrWhiteSpace(model.Address))
            {
                throw new PortalValidationException("Empty Address");
            }
        }
    }
}
