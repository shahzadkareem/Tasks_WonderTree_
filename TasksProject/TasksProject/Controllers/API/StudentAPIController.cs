using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class StudentAPIController : ApiController
    {
        private List<Student> students = new List<Student>();

        public StudentAPIController()
        {
            // Sample data
            students.Add(new Student { Stu_ID = 1, StudentName = "Shahzad"});
            students.Add(new Student { Stu_ID = 2, StudentName = "Bilal" });
            students.Add(new Student { Stu_ID = 3, StudentName = "Ali"});
        }

        public IEnumerable<Student> Get()
        {
            return students;
        }

       

        public IHttpActionResult Post([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Save the student to the database or perform other actions
            // ...

            return Ok(student);
        }
    }
}
