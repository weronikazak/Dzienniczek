using System.ComponentModel.DataAnnotations;

namespace cwiczenia.API.Models
{
    public class Enrollments
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }
        public int Grade { get; set; }
    }
}