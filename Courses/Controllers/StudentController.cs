using Business;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _studentManager.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _studentManager.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentAddVm model)
        {
            await _studentManager.AddAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentVm model)
        {
            await _studentManager.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentManager.DeleteAsync(id);
            return Ok();
        }
    }
}
