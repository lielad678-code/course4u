using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel;

namespace WebServices.Controllers
{
    public class TeacherServiceController : ApiController
    {
        // NEW: POST api/user/login
        // Specifies that this action method responds to HTTP POST requests
        // Used for operations that send data to the server (e.g., login, create)
        [HttpPost]

        // Defines the route (URL endpoint) for this action
        // This method will be accessible at: POST /api/user/TeacherLogin
        // "api/user" is the base route, "TeacherLogin" is the specific action name
        [Route("api/user/TeacherLogin")]
        public IHttpActionResult Post([FromBody] User request)
        {
            // Validate request body
            // The request must not be null and must contain username and password
            if (request == null)
                return BadRequest("Request body is required.");

            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email and password must be provided.");


            // Create instance of data access layer
            TeacherDB teacherDB = new TeacherDB();

            // Attempt to authenticate user with provided credentials
            // This should internally compare hashed passwords (not plain text)
            Teacher teacher = teacherDB.Login(request.Email, request.Password);

            // For now, just return success and echo the username (never echo the password).
            // Validate the Response (Authentication Result)
            if (teacher == null)
            {
                // Use Unauthorized for failed logins to keep the reason specific but secure
                return Content(HttpStatusCode.Unauthorized, "Invalid username or password.");
            }

            // Return Success
            // Ensure the Teacher object doesn't include the password hash when serialized!
            return Ok(teacher);
        }


        // NEW: POST api/user/InsertNewTeacher
        // Specifies that this action method responds to HTTP POST requests
        // Used for operations that send data to the server (e.g., login, create)
        [HttpPost]

        // Defines the route (URL endpoint) for this action
        // This method will be accessible at: POST /api/user/TeacherLogin
        // "api/user" is the base route, "TeacherLogin" is the specific action name
        [Route("api/user/InsertNewTeacher")]
        public IHttpActionResult Post([FromBody] Teacher request)
        {
            // Validate request body
            // The request must not be null and must contain username and password
            if (request == null)
                return BadRequest("Request body is required.");

            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email and password must be provided.");


            // Create instance of data access layer
            TeacherDB teacherDB = new TeacherDB();

            // Add New Teacher
            teacherDB.Insert(request);

            // For now, just return success and echo the username (never echo the password).
            return Ok();

        }

        [HttpPost]
        [Route("api/user/SelectAllStudents")]
        public IHttpActionResult Post()
        {
            // Create instance of data access layer
            StudentDB studentDB = new StudentDB();
            StudentList students = studentDB.SelectAll();
            // For now, just return success and echo the username (never echo the password).
            return Ok(students);

        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}