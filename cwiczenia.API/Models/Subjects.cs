using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia.API.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }

    }
}