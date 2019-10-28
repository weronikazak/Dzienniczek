namespace cwiczenia.API.Models
{
    public class TeacherSubjects
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}