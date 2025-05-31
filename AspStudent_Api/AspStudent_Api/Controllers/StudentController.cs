using AspStudent_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspStudent_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public List<Student> GetStudent()
        {
            List<Student> std = [
                new Student() {
                    StudentId = 101,
                    StudentName = "Haseeb",
                    StudentClass = "11",
                    StudentSection = "B"
                },
                new Student() {
                    StudentId = 102,
                    StudentName = "Hanan",
                    StudentClass = "9",
                    StudentSection = "A"
                },
                new Student() {
                    StudentId = 103,
                    StudentName = "Shabbir",
                    StudentClass = "9",
                    StudentSection = "A"
                },
                new Student() {
                    StudentId = 104,
                    StudentName = "Raheem",
                    StudentClass = "12",
                    StudentSection = "E"
                },
                new Student() {
                    StudentId = 105,
                    StudentName = "Asim",
                    StudentClass = "10",
                    StudentSection = "C"
                }
                ];

            return std;
        }

        [HttpPost]
        public Student AddStudent([FromForm] Student std)
        {
            return std;
        }
    }
}
