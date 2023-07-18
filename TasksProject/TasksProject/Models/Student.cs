using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksProject.Models
{
    public class Student
    {
        [Key]
        public int Stu_ID { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [RegularExpression(@"^[A-Za-z]+ [A-Za-z]+$", ErrorMessage = "StudentName is invalid")]
        public String StudentName { get; set; }
    }
}