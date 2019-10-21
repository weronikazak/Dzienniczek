using cwiczenia.API.Models;

namespace cwiczenia.API.Dtos
{
    public class StudentForUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { 
            get {
                return Name + " " + Surname;
            }
        }
        public string Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}