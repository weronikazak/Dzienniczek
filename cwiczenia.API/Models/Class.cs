using System.Collections.Generic;

namespace cwiczenia.API.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int Year { get; set; }
        //public int TeacherId { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}