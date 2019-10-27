using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia.API.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int Year { 
            get 
            {
                return Year;
            }
            set 
            {
                Year = new DateTime().Year;
            }
        }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}