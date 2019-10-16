namespace cwiczenia.API.Models
{
    public class SetGradeTo
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}