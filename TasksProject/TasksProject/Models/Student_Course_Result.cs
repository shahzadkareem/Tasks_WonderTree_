using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksProject.Models
{
    public class Student_Course_Result
    {
        [Key]
        public int ID { get; set; }
        public int Stu_ID { get; set; }
        public Student Student { get; set; }
        public int Cours_ID { get; set; }
        public Course Course { get; set; }
        public DateTime date { get; set; }
    }
}