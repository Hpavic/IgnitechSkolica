using Microsoft.EntityFrameworkCore;
using IgnitechSkolica.Models;

namespace IgnitechSkolica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "Ivan", LastName = "Horvat", TeacherCode = "TE00001" },
                new Teacher { Id = 2, FirstName = "Veldin", LastName = "Karic", TeacherCode = "TE00002" },
                new Teacher { Id = 3, FirstName = "Danijel", LastName = "Poldrugac", TeacherCode = "TE00003" },
                new Teacher { Id = 4, FirstName = "Jasmin", LastName = "Agic", TeacherCode = "TE00004" },
                new Teacher { Id = 5, FirstName = "Eduardo", LastName = "Da Silva", TeacherCode = "TE00005" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Tadej", LastName = "Pogacar", TeacherId = 1, StudentCode = "ST00001" },
                new Student { Id = 2, FirstName = "Ante", LastName = "Budimir", TeacherId = 2, StudentCode = "ST00002" },
                new Student { Id = 3, FirstName = "Ivan", LastName = "Ljubicic", TeacherId = 3, StudentCode = "ST00003" },
                new Student { Id = 4, FirstName = "Mario", LastName = "Ancic", TeacherId = 4, StudentCode = "ST00004" },
                new Student { Id = 5, FirstName = "Novak", LastName = "Djokovic", TeacherId = 5, StudentCode = "ST00005" },
                new Student { Id = 6, FirstName = "Ivica", LastName = "Zubac", TeacherId = 5, StudentCode = "ST00006" },
                new Student { Id = 7, FirstName = "Andrej", LastName = "Kramaric", TeacherId = 3, StudentCode = "ST00007" },
                new Student { Id = 8, FirstName = "Donna", LastName = "Vekic", TeacherId = 3, StudentCode = "ST00008" },
                new Student { Id = 9, FirstName = "Petra", LastName = "Martic", TeacherId = 2, StudentCode = "ST00009" },
                new Student { Id = 10, FirstName = "Zulejka", LastName = "Stefanini Tucan", TeacherId = 3, StudentCode = "ST000010" },
                new Student { Id = 11, FirstName = "Maca", LastName = "Maradona", TeacherId = 4, StudentCode = "ST000011" }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Matematika 1", StudentId = 1, TeacherId = 1 },
                new Subject { Id = 2, Name = "Matematika 3", StudentId = 2, TeacherId = 1 },
                new Subject { Id = 3, Name = "Organizacija", StudentId = 1, TeacherId = 2 },
                new Subject { Id = 4, Name = "Engleski 1", StudentId = 1, TeacherId = 3 },
                new Subject { Id = 5, Name = "Engleski 3", StudentId = 3, TeacherId = 3 },
                new Subject { Id = 6, Name = "Baze podataka 1", StudentId = 3, TeacherId = 4 },
                new Subject { Id = 7, Name = "Programiranje 1", StudentId = 4, TeacherId = 4 },
                new Subject { Id = 8, Name = "Poslovno odlucivanje", StudentId = 5, TeacherId = 5 },
                new Subject { Id = 9, Name = "Komunikacija 1", StudentId = 6, TeacherId = 5 },
                new Subject { Id = 10, Name = "Komunikacija 3", StudentId = 5, TeacherId = 5 },
                new Subject { Id = 11, Name = "Osnove ekonomije 1", StudentId = 7, TeacherId = 2 },
                new Subject { Id = 12, Name = "Osnove ekonomije 3", StudentId = 8, TeacherId = 2 },
                new Subject { Id = 13, Name = "Poslovna ekonomija 1", StudentId = 8, TeacherId = 2 },
                new Subject { Id = 14, Name = "Poslovna ekonomija 3", StudentId = 9, TeacherId = 2 },
                new Subject { Id = 15, Name = "Financijska matematika 1", StudentId = 10, TeacherId = 1 },
                new Subject { Id = 16, Name = "Financijska matematika 3", StudentId = 11, TeacherId = 1 }
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, Value = 95, SubjectId = 1, CreatedOn = DateTime.Now },
                new Grade { Id = 2, Value = 88, SubjectId = 2, CreatedOn = DateTime.Now },
                new Grade { Id = 3, Value = 70, SubjectId = 3, CreatedOn = DateTime.Now },
                new Grade { Id = 4, Value = 51, SubjectId = 3, CreatedOn = DateTime.Now },
                new Grade { Id = 5, Value = 55, SubjectId = 4, CreatedOn = DateTime.Now },
                new Grade { Id = 6, Value = 44, SubjectId = 5, CreatedOn = DateTime.Now },
                new Grade { Id = 7, Value = 33, SubjectId = 6, CreatedOn = DateTime.Now },
                new Grade { Id = 8, Value = 85, SubjectId = 6, CreatedOn = DateTime.Now },
                new Grade { Id = 9, Value = 90, SubjectId = 7, CreatedOn = DateTime.Now },
                new Grade { Id = 10, Value = 91, SubjectId = 7, CreatedOn = DateTime.Now },
                new Grade { Id = 11, Value = 99, SubjectId = 7, CreatedOn = DateTime.Now },
                new Grade { Id = 12, Value = 74, SubjectId = 8, CreatedOn = DateTime.Now },
                new Grade { Id = 13, Value = 66, SubjectId = 9, CreatedOn = DateTime.Now },
                new Grade { Id = 14, Value = 65, SubjectId = 9, CreatedOn = DateTime.Now },
                new Grade { Id = 15, Value = 67, SubjectId = 10, CreatedOn = DateTime.Now },
                new Grade { Id = 16, Value = 56, SubjectId = 10, CreatedOn = DateTime.Now },
                new Grade { Id = 17, Value = 50, SubjectId = 11, CreatedOn = DateTime.Now },
                new Grade { Id = 18, Value = 51, SubjectId = 11, CreatedOn = DateTime.Now },
                new Grade { Id = 19, Value = 52, SubjectId = 11, CreatedOn = DateTime.Now },
                new Grade { Id = 20, Value = 73, SubjectId = 11, CreatedOn = DateTime.Now },
                new Grade { Id = 21, Value = 81, SubjectId = 12, CreatedOn = DateTime.Now },
                new Grade { Id = 22, Value = 82, SubjectId = 12, CreatedOn = DateTime.Now },
                new Grade { Id = 23, Value = 83, SubjectId = 13, CreatedOn = DateTime.Now },
                new Grade { Id = 24, Value = 89, SubjectId = 13, CreatedOn = DateTime.Now },
                new Grade { Id = 25, Value = 91, SubjectId = 14, CreatedOn = DateTime.Now },
                new Grade { Id = 26, Value = 77, SubjectId = 15, CreatedOn = DateTime.Now },
                new Grade { Id = 27, Value = 75, SubjectId = 16, CreatedOn = DateTime.Now },
                new Grade { Id = 28, Value = 59, SubjectId = 16, CreatedOn = DateTime.Now },
                new Grade { Id = 29, Value = 71, SubjectId = 16, CreatedOn = DateTime.Now }
            );
        }
    }
}
