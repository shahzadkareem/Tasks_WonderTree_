using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksProject.Models
{
    public class Course
    {
        [Key]
        public int Cours_ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "CourseName is invalid")]
        public String CourseName { get; set; }
    }
}