using System;
using System.Collections.Generic;
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

            if (teacherForRegisterDto.ClassId != null) {
                var clas = await _repo.GetClass((int)teacher.ClassId);
                if (clas == null) {
                    throw new Exception("Nie ma takiej klasy");
                }
            }

            var subject = await _repo.GetSubject(teacherForRegisterDto.SubjectId);

            if (subject == null) 
                throw new Exception("Taki przedmiot nie istnieje");

            var ts = new TeacherSubjects();
            ts.Teacher = teacher;
            ts.Subject = subject;

            _repo.Add(ts);
            
            // var teacherSubjects = new List<Subjects>();

            // teacherSubjects.Add(subject);

            // teacher.Subjects = teacherSubjects;

            // subject.TeacherId = teacher.Id;
            // subject.Teacher = teacher;
            //teacher.Subjects.Add(subject);


            _repo.Add(teacher);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Cos poszlo nie tak podczas dodawania");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id) {
            var teacher = await _repo.GetTeacher(id);

            return Ok(teacher);
        }

        [HttpGet("getSubjects")]
        public async Task<IActionResult> GetTeacherSubjects() {
            var teacher = await _repo.GetTeacherSubjects();

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