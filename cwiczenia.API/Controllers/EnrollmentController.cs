using System;
using System.Threading.Tasks;
using AutoMapper;
using cwiczenia.API.Data;
using cwiczenia.API.Dtos;
using cwiczenia.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly ICwiczeniaRepository _repo;
        private readonly IMapper _mapper;

        public EnrollmentController(ICwiczeniaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetEnrollments(int studentId) {
            // id = studentId
            var enrollments = await _repo.GetEnrollments(studentId);
            //var enrollments = await _repo.GetEnrollment();

            return Ok(enrollments);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(EnrollmentForAddDto enrollmentForAddDto) {
            var enrollment = _mapper.Map<Enrollments>(enrollmentForAddDto);

            var student = await _repo.GetStudent(enrollment.StudentId);
            var subject = await _repo.GetSubject(enrollment.SubjectId);

            if (student == null)
                throw new Exception("Uzytkownik nie istnieje");

            if (subject == null)
                throw new Exception("Przedmiot nie istnieje");

            enrollment.Student = student;
            enrollment.Subject = subject;

            _repo.Add<Enrollments>(enrollment);

            if (await _repo.SaveAll())
                return Ok(enrollment);

            throw new Exception("Cos poszlo nie tak podszas dodawania oceny");
        }
    }
}