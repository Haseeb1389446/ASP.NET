using Api_Crud.Models;
using Api_Crud.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return _context.students.ToList();
        }

        [HttpPost]
        public Student AddStudents([FromForm] Student std)
        {
            _context.students.Add(std);
            _context.SaveChanges();
            return std;
        }


    }
}
