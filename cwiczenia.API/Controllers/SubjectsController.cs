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
    public class SubjectsController : ControllerBase
    {
        private readonly ICwiczeniaRepository _repo;
        private readonly IMapper _mapper;

        public SubjectsController(ICwiczeniaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects() {
            var subjects = await _repo.GetSubjects();

            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id) {
            var subject = await _repo.GetSubject(id);

            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(Subjects subjectName) {
            var subject = _mapper.Map<Subjects>(subjectName);

            _repo.Add(subject);

            if (await _repo.SaveAll()) {
                return Ok(subject);
            }

            throw new Exception("Coś się nie udało podczas dodawania nowego przedmiotu.");
        }
    }
}