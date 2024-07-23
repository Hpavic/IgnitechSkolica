namespace IgnitechSkolica.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class GradeDisplay
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? GradeText { get; set; }
        public int GradeNumber { get; set; }
    }
}
