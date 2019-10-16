using System.Collections.Generic;
using cwiczenia.API.Models;

namespace cwiczenia.API.Dtos
{
    public class ClassForUpdateDto
    {
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}