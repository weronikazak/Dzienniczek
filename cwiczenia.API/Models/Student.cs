using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia.API.Models
{
    public enum Grade {
        A, B, C, D, E
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        //public ICollection<SetGradeTo> SetGrade { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

    }
}