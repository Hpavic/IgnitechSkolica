using IgnitechSkolica.Data;
using IgnitechSkolica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IgnitechSkolica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Teacher/Students/TE00001
        [HttpGet("Students/{teacherCode}")]
        public async Task<ActionResult> GetStudentsByTeacherCode(string teacherCode)
        {
            // Get teacher with provided teacherCode
            var query = await _context.Teachers
                .Include(x => x.Students)
                .FirstOrDefaultAsync(x => x.TeacherCode == teacherCode);

            if (query == null)
            {
                return NotFound("Teacher with that code not found!");
            }

            // Serialize only needed data
            var students = query.Students.Select(x => new StudentDisplay
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentCode = x.StudentCode
            }).ToList();

            if (!students.Any())
            {
                return Ok("No students found for the selected teacher!");
            }

            return Ok(students);
        }
    }
}
