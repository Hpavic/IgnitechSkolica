using IgnitechSkolica.Data;
using IgnitechSkolica.Models;
using Microsoft.EntityFrameworkCore;

namespace IgnitechSkolica.Services
{
    public class GradeService
    {
        private readonly AppDbContext _context;

        public GradeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Grade>> GetGradesByStudentAndSubjectAsync(string studentCode, int subjectId)
        {
            var grades = await _context.Grades
                .Include(x => x.Subject)
                .Where(x => x.Subject != null && x.Subject.Student != null && x.Subject.Student.StudentCode == studentCode && x.Subject.Id == subjectId)
                .ToListAsync();

            return grades;
        }
    }
}
