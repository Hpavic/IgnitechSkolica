namespace IgnitechSkolica.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TeacherCode { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
