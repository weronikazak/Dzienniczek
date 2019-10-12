using System.Collections.Generic;

namespace cwiczenia.API.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        // public ICollection<Student> Students { get; set; }
    }
}