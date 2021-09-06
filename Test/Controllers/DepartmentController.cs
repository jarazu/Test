using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/department")]
    //[Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // GET: api/<DepartmentController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.GetAllDepartment());
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            return Ok(DepartmentStatic.GetADepartment(code));
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Post(Department dept)
        {
            return Ok(DepartmentStatic.InsertDepartment(dept));
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{code}")]
        public IActionResult Put(string code, Department dept)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code, dept));
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }
    }

    public static class DepartmentStatic {
        private static List<Department> AllDepartment { get; set; } = new List<Department>();
        public static Department InsertDepartment(Department dept) {
            AllDepartment.Add(dept);
            return dept;
        }

        public static List<Department> GetAllDepartment() {
            return AllDepartment;
        }

        public static Department GetADepartment(string code) {
            return AllDepartment.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department dept) {
            foreach (var dpt in AllDepartment) {
                if (code == dpt.Code) {
                    dpt.Name = dept.Name;
                }
            }
            return dept;
        }

        public static Department DeleteDepartment(string code) {
            var department = AllDepartment.FirstOrDefault(x => x.Code == code);
            AllDepartment = AllDepartment.Where(x => x.Code != department.Code).ToList();

            return department;
        }
    }
}
