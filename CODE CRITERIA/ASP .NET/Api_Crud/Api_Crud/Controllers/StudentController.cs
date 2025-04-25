using Api_Crud.Models;
using Api_Crud.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var std = await _context.students.ToListAsync();
            return Ok(std);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudents([FromForm] Student std)
        {
            await _context.students.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Student>> UpdateStudents([FromForm] Student std, int id)
        {
            if(id != std.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(std).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete]
        public async Task<string> DeleteStudents(int id)
        {
            Student std = await _context.students.FindAsync(id) ?? new();
            _context.students.Remove(std);
            await _context.SaveChangesAsync();
            return "Student Removed Successfully";
        }
    }
}
