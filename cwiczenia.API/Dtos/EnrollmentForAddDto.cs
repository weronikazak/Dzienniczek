using cwiczenia.API.Models;

namespace cwiczenia.API.Dtos
{
    public class EnrollmentForAddDto
    {
        public Student Student { get; set; }
        public Subjects Subject { get; set; }
        public Grade Grade { get; set; }
    }
}