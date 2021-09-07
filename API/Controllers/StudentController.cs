using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/student")]
    //[ApiController]
    public class StudentController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] string rollNumber, [FromQuery] string nickName)
        {
            return Ok(StudentStatic.GetAllStudent());
        }

        // GET api/<StudentController>/5
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromForm]Student dept)
        {
            return Ok(StudentStatic.InsertStudent(dept));
        }

        // PUT api/<StudentController>/5
        [HttpPut("{email}")]
        public IActionResult Put(string email, Student dept)
        {
            return Ok(StudentStatic.UpdateStudent(email, dept));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent(email));
        }
    }
    public static class StudentStatic
    {
        private static List<Student> AllStudent { get; set; } = new List<Student>();
        public static Student InsertStudent(Student dept)
        {
            AllStudent.Add(dept);
            return dept;
        }

        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Student GetAStudent(string email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == email);
        }

        public static Student UpdateStudent(string email, Student dept)
        {
            foreach (var dpt in AllStudent)
            {
                if (email == dpt.Email)
                {
                    dpt.Name = dept.Name;
                }
            }
            return dept;
        }

        public static Student DeleteStudent(string email)
        {
            var Student = AllStudent.FirstOrDefault(x => x.Email == email);
            AllStudent = AllStudent.Where(x => x.Email != Student.Email).ToList();

            return Student;
        }
    }
}
