using AutoMapper;
using cwiczenia.API.Dtos;
using cwiczenia.API.Models;

namespace cwiczenia.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentForRegisterDto>().ReverseMap();
        }
    }
}