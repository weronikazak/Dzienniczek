using System.Threading.Tasks;
using cwiczenia.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICwiczeniaRepository _repo;

        public StudentsController(ICwiczeniaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents() {
            var students = await _repo.GetStudents();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id) {
            var student = await _repo.GetStudent(id);

            return Ok(student);
        }
    }
}