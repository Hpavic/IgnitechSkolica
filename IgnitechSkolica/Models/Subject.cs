namespace IgnitechSkolica.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}
