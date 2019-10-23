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
            CreateMap<Enrollments, EnrollmentForAddDto>().ReverseMap();
            CreateMap<StudentForUpdateDto, Student>().ReverseMap();
            CreateMap<ClassForCreationDto, Class>().ReverseMap();
            CreateMap<ClassForUpdateDto, Class>().ReverseMap();
        }
    }
}