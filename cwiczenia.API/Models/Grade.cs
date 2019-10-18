using System.Collections.Generic;

namespace cwiczenia.API.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
    }
}