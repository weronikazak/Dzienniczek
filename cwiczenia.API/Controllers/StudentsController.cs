using System.Threading.Tasks;
using cwiczenia.API.Data;
using cwiczenia.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using cwiczenia.API.Models;
using System;

namespace cwiczenia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICwiczeniaRepository _repo;
        private readonly IMapper _mapper;

        public StudentsController(ICwiczeniaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentForRegisterDto studentForRegister) {
            var student = _mapper.Map<Student>(studentForRegister);

            var classe = _repo.GetClass((int)student.ClassId);

            if (classe == null) {
                throw new Exception("Taka klasa nie istnieje");
            }

            _repo.Add(student);

            if (await _repo.SaveAll()) {
                return Ok(student);
            }

            throw new Exception("Coś się nie udało podczas dodawania nowego studenta.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id) {
            var student = await _repo.GetStudent(id);

            _repo.Delete(student);

            if (await _repo.SaveAll())
                return NoContent();
            
            throw new Exception("Cos poszlo nie tak podczas kasowania ucznia");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(StudentForUpdateDto studentForUpdateDto, int id) {
            var student = await _repo.GetStudent(id);

            _mapper.Map(student, studentForUpdateDto);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Cos poszło nie tak podczas aktualizowania informacji o uczniu.");
        }

    }
}