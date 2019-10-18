using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia.API.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { 
            get {
                return Name + " " + Surname;
            }
        }
        public DateTime? DateOfBirth { get; set; }
        public string Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Enrollments> Enrollments { get; set; }


    }
}