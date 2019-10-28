using System;
using System.Collections.Generic;

namespace cwiczenia.API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { 
            get {
                return Name + " " + Surname;
            } 
        }
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
    }
}