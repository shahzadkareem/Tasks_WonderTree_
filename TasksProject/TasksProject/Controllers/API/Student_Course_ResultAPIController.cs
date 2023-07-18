using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class Student_Course_ResultAPIController : ApiController
    {

        private static List<Student_Course_Result> results = new List<Student_Course_Result>();

        // GET api/Student_Course_ResultAPI
        public IEnumerable<Student_Course_Result> Get()
        {
            return results;
        }

        // GET api/Student_Course_ResultAPI/{id}
        

        // POST api/Student_Course_ResultAPI
        public IHttpActionResult Post([FromBody] Student_Course_Result result)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Add the result to the database or perform other actions
            // ...

            results.Add(result);

            return CreatedAtRoute("DefaultApi", new { id = result.ID }, result);
        }

        // PUT api/Student_Course_ResultAPI/{id}
        public IHttpActionResult Post(int id, [FromBody] Student_Course_Result result)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingResult = results.FirstOrDefault(r => r.ID == id);
            if (existingResult == null)
                return NotFound();

            // Update the result in the database or perform other actions
            // ...

            existingResult.Stu_ID = result.Stu_ID;
            existingResult.Cours_ID = result.Cours_ID;
            existingResult.date = result.date;

            return Ok(existingResult);
        }
    }
}
