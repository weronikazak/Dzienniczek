using System;
using System.Collections.Generic;
using cwiczenia.API.Models;

namespace cwiczenia.API.Dtos
{
    public class TeacherForRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
    }
}