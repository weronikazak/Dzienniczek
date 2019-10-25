using cwiczenia.API.Models;

namespace cwiczenia.API.Dtos
{
    public class EnrollmentForAddDto
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }
        public int Grade { get; set; }
    }
}