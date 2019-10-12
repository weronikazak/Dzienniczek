using System.Threading.Tasks;
using cwiczenia.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia.API.Controllers
{
    public class StudentController : ControllerBase
    {
        private CwiczeniaRepository _repo;

        public StudentController(CwiczeniaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents() {
            var students = await _repo.GetStudents();
            return Ok(students);
        }
    }
}