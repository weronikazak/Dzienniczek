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
    public class ClassController : ControllerBase
    {
        private IMapper _mapper;
        private ICwiczeniaRepository _repo;

        public ClassController(IMapper mapper, ICwiczeniaRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses() {
            var classes = await _repo.GetClasses();

            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(ClassForCreationDto classForCreationDto) {
            var clas = _mapper.Map<Class>(classForCreationDto);

            _repo.Add(clas);

            if (await _repo.SaveAll()) {
                return Ok(clas);
            }

            throw new Exception("Cos sie schrzanilo podczs dodawania klasy");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, ClassForUpdateDto classForUpdateDto){
            var clas = await _repo.GetClass(id);

            _mapper.Map(classForUpdateDto, clas);

            if (await _repo.SaveAll()) {
                return NoContent();
            }

            throw new Exception("Coś poszlo nie tak podczas aktualizowania");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id) {
            var clas = await _repo.GetClass(id);

            _repo.Delete(clas);

            if (await _repo.SaveAll()) {
                return NoContent();
            }

            throw new Exception("Coś poszło nie tak podczas usuwania klasy");
        }

    }
}