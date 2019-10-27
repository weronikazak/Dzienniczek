using System;
using System.Threading.Tasks;
using AutoMapper;
using cwiczenia.API.Data;
using cwiczenia.API.Dtos;
using cwiczenia.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ICwiczeniaRepository _repo;
        private readonly IMapper _mapper;

        public TeachersController(ICwiczeniaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers() {
            var teachers = await _repo.GetTeachers();

            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherForRegisterDto teacherForRegisterDto) {
            var teacher = _mapper.Map<Teacher>(teacherForRegisterDto);

            if (await _repo.GetSubject(teacher.Id) == null)
                throw new Exception("Nie ma takiego przedmiotu.");

            if (teacherForRegisterDto.ClassId != null) {
                if (await _repo.GetClass((int)teacher.ClassId) == null) {
                throw new Exception("Nie ma takiej klasy");
                }
            }

            return Ok(teacher);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id) {
            var teacher = await _repo.GetTeacher(id);

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id) {
            var teacher = await _repo.GetTeacher(id);

            _repo.Delete(teacher);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Cos poszlo nie tak podczas usuwania");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherForUpdateDto teacherForUpdateDto) {
            var teacher = await _repo.GetTeacher(id);

            _mapper.Map(teacher, teacherForUpdateDto);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Cos poszlo nie tak ppodczas update'wania nauczyciela");
            
        }
    }
}