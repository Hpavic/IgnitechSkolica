using IgnitechSkolica.Data;
using IgnitechSkolica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IgnitechSkolica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Subject
        [HttpGet]
        public async Task<ActionResult> GetAllSubjects()
        {
            var subjects = await _context.Subjects
                .Select(x => new SubjectDisplay
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            if (!subjects.Any())
            {
                return Ok("No subjects found!");
            }

            return Ok(subjects);
        }

        // GET: api/Student/ST00001/Subject/1/Teacher
        [HttpGet("Student/{studentCode}/Subject/{subjectId}/Teacher")]
        public async Task<ActionResult> GetTeacherByStudentAndSubject(string studentCode, int subjectId)
        {
            var subject = await _context.Subjects
                .Include(x => x.Teacher)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Student != null && x.Teacher != null && 
                    x.Student.StudentCode == studentCode && 
                    x.Id == subjectId);

            if (subject == null)
            {
                return NotFound("No such subject found for the given student.");
            }

            var teacher = subject.Teacher;

            if (teacher == null)
            {
                return NotFound("No teacher found for the given subject.");
            }

            var teacherDisplay = new TeacherDisplay
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                TeacherCode = teacher.TeacherCode
            };

            return Ok(teacherDisplay);
        }
    }
}
