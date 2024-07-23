using IgnitechSkolica.Data;
using IgnitechSkolica.Models;
using IgnitechSkolica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IgnitechSkolica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly GradeService _gradeService;

        public GradeController(GradeService gradeService)
        {
            _gradeService = gradeService;
        }

        #region Helper Methods

        /* (AI)
        I would like to include extra column here in GradeDisplay
        public class GradeDisplay { public int Id { get; set; } public int Value { get; set; } public DateTime CreatedOn { get; set; }} which is actual crade of the given Grade.
        Meaning, we are currently storing Value in db, value represent how many % did student get on that Paper.
        It is in range from 1 - 100. So now I would like to specify the range from 0 - 49 will be GradeText nedovoljan and GradeNumber 1, 
        from 50 - 63 GradeText will be dovoljan and GradeNumber will be 2, from 64 - 76 GradeText will be Dobar and GradeNumber 3, 
        from 77 - 89 GradeText Vrlo Dobar and GradeNumber 4, from 90 - 100 GradeText Izvrstan, GradeNumber 5. 
        So we need to add these 2 values to GradeDisplay and also we can define these GradeText as Enum... 
        and of course we have to have algorithm which will be getting given values for GradeText and GradeNumber based on value for that Grade

        (ME) changed from enum to text (string)
        */

        private static string GetGradeText(int value)
        {
            return value switch
            {
                >= 0 and <= 49 => "Nedovoljan",
                >= 50 and <= 63 => "Dovoljan",
                >= 64 and <= 76 => "Dobar",
                >= 77 and <= 89 => "Vrlo Dobar",
                >= 90 and <= 100 => "Izvrstan",
                _ => throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 100")
            };
        }

        private static int GetGradeNumber(int value)
        {
            return value switch
            {
                >= 0 and <= 49 => 1,
                >= 50 and <= 63 => 2,
                >= 64 and <= 76 => 3,
                >= 77 and <= 89 => 4,
                >= 90 and <= 100 => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 100")
            };
        }

        #endregion

        //GET: api/Grade/Student/ST00001/Subject/1/Grades
        [HttpGet("Student/{studentCode}/Subject/{subjectId}/Grades")]
        public async Task<ActionResult> GetGradesByStudentAndSubject(string studentCode, int subjectId)
        {
            var grades = await _gradeService.GetGradesByStudentAndSubjectAsync(studentCode, subjectId);

            if (!grades.Any())
            {
                return Ok("No grades found for the given student and subject.");
            }

            var gradeDisplays = grades.Select(g => new GradeDisplay
            {
                Id = g.Id,
                Value = g.Value,
                CreatedOn = g.CreatedOn,
                GradeText = GetGradeText(g.Value),
                GradeNumber = GetGradeNumber(g.Value)
            }).ToList();

            return Ok(gradeDisplays);
        }

        //GET: api/Grade/Student/ST00008/Subject/12/AverageGrade
        [HttpGet("Student/{studentCode}/Subject/{subjectId}/AverageGrade")]
        public async Task<ActionResult> GetAverageGradeByStudentAndSubject(string studentCode, int subjectId)
        {
            var grades = await _gradeService.GetGradesByStudentAndSubjectAsync(studentCode, subjectId);

            if (!grades.Any())
            {
                return Ok("No grades found for the given student and subject.");
            }

            var averageValue = grades.Average(x => x.Value);
            var roundedAverageValue = (int)Math.Round(averageValue, MidpointRounding.AwayFromZero);

            var averageGrade = new
            {
                AverageValue = roundedAverageValue,
                GradeText = GetGradeText(roundedAverageValue),
                GradeNumber = GetGradeNumber(roundedAverageValue)
            };

            return Ok(averageGrade);
        }
    }
}
