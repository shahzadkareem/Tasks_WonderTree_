using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using TasksProject.Models;

namespace TasksProject
{
    public class ApplicationUser : IdentityUser
    {
    }
  
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TaskString")
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student_Course_Result> student_Course_Results { get; set; }
        public DbSet<Log> Log { get; set; }


    }
}