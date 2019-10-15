using System;

namespace cwiczenia.API.Dtos
{
    public class StudentForRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public string Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
    }
}