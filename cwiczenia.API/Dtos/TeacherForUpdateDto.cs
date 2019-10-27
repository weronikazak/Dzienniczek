using System;

namespace cwiczenia.API.Dtos
{
    public class TeacherForUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
    }
}