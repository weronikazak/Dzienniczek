using System.Threading.Tasks;
using cwiczenia.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ICwiczeniaRepository _repo;

        public TeachersController(ICwiczeniaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers() {
            var teachers = await _repo.GetTeachers();

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id) {
            var teacher = await _repo.GetTeacher(id);

            return Ok(teacher);
        }
    }
}