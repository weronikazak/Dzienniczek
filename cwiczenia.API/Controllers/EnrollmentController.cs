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

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollments(int id) {
            // id = studentId
            var enrollments = await _repo.GetEnrollments(id);
            return Ok(enrollments);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(EnrollmentForAddDto enrollmentForAddDto) {
            var enrollment = _mapper.Map<Enrollments>(enrollmentForAddDto);
            //enrollment.StudentId = enrollment.Student.Id;
            //enrollment.SubjectId = enrollment.Subject.Id;

            _repo.Add(enrollment);

            if (await _repo.SaveAll())
                return Ok(enrollment);

            throw new Exception("Cos poszlo nie tak podszas dodawania oceny");
        }
    }
}