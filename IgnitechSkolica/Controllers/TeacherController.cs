using IgnitechSkolica.Data;
using IgnitechSkolica.Models;
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

        //GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult> GetAllTeachers()
        {
            var teachers = await _context.Teachers
                .Select(t => new TeacherDisplay
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    TeacherCode = t.TeacherCode
                })
                .ToListAsync();

            if (!teachers.Any())
            {
                return Ok("No teachers found!");
            }

            return Ok(teachers);
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

        //GET: api/Teacher/Subjects/TE00001
        [HttpGet("Subjects/{teacherCode}")]
        public async Task<ActionResult> GetSubjectsByTeacherCode(string teacherCode)
        {
            // Get teacher with provided teacherCode
            var query = await _context.Teachers
                .Include(x => x.Subjects)
                .FirstOrDefaultAsync(x => x.TeacherCode == teacherCode);

            if (query == null)
            {
                return NotFound("Teacher with that code not found!");
            }

            // Serialize only needed data
            var subjects = query.Subjects.Select(x => new SubjectDisplay
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            if (!subjects.Any())
            {
                return Ok("No subjects found for the selected teacher!");
            }

            return Ok(subjects);
        }
    }
}
