using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentWebAPI.DataBase;
using StudentWebAPI.Model;

namespace StudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        List<Student> studets = new List<Student>();
        private MyContext _myContext;
        public StudentController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet]
        [Route("api/Students")]
        public ObjectResult GetJsonResult()
        {
            var studet = _myContext.Students;

            return StatusCode(200, studet);
        }

        [HttpGet]
        [Route("api/Students/{id}")]
        public ObjectResult GetJsonResult(int id)
        {
            var studet = _myContext.Students.FirstOrDefault(s => s.Id == id);

            if (studet != null)
            {
                return StatusCode(200, studet);
            }
            return StatusCode(404, studet);           
        }

        [HttpPost]
        [Route("api/AddStudentList")]
        public ObjectResult AddStudentList(Student model)
        {
            try
            {
                _myContext.Add(model);

                _myContext.SaveChanges();

                return StatusCode(200, model);
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }               
    }
}