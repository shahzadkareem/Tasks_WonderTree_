using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TasksProject.Models;
using System.Web.Http;

namespace TasksProject.Controllers
{
    public class CourseAPIController : ApiController
    {
        private List<Course> courses = new List<Course>();

        public CourseAPIController()
        {
            // Sample data
            courses.Add(new Course { Cours_ID = 1, CourseName = "Math" });
            courses.Add(new Course { Cours_ID = 2, CourseName = "Science" });
            courses.Add(new Course { Cours_ID = 3, CourseName = "English" });
        }
     
        public IEnumerable<Course> GetCourse()
        {
          
            return courses;
        }

       

        public IHttpActionResult Post([FromBody]Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Save the course to the database or perform other actions
            // ...

            return Ok(course);
        }
    }
}
