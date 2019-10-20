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

            _repo.Add(student);

            if (await _repo.SaveAll()) {
                return Ok(student);
            }

            throw new Exception("Coś się nie udało podczas dodawania nowego studenta.");
        }

        [HttpGet("{studentId}/enrollments")]
        public async Task<IActionResult> GetEnrollments(int studentId) {
            var enrollment = await _repo.GetEnrollments(studentId);

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(EnrollmentForAddDto enrollmentForAddDto) {
            var enrollment = _mapper.Map<Enrollments>(enrollmentForAddDto);

            _repo.Add(enrollment);

            if (await _repo.SaveAll())
                return Ok(enrollment);

            throw new Exception("Cos poszlo nie tak podszas dodawania oceny");
        }
    }
}