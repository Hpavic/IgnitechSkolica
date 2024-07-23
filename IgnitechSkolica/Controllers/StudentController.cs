using IgnitechSkolica.Data;
using IgnitechSkolica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IgnitechSkolica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Student
        [HttpGet]
        public async Task<ActionResult> GetAllStudents()
        {
            var students = await _context.Students
                .Select(x => new StudentDisplay
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    StudentCode = x.StudentCode
                })
                .ToListAsync();

            if (!students.Any())
            {
                return Ok("No students found!");
            }

            return Ok(students);
        }

        //GET: api/Student/Subjects/ST00001
        [HttpGet("Subjects/{studentCode}")]
        public async Task<ActionResult> GetSubjectsByStudentCode(string studentCode)
        {
            // Get student with provided studentCode
            var query = await _context.Students
                .Include(x => x.Subjects)
                .FirstOrDefaultAsync(x => x.StudentCode == studentCode);

            if (query == null)
            {
                return NotFound("Student with that code not found!");
            }

            var subjects = query.Subjects.Select(x => new SubjectDisplay
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            if (!subjects.Any())
            {
                return Ok("No subjects found for the selected student!");
            }

            return Ok(subjects);
        }
    }
}
