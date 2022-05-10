using Microsoft.EntityFrameworkCore;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.DataLayer.DAL
{
    public interface ISzakdogaContext
    {
        DbSet<StudentFinished> StudentFinisheds { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<SubjectType> SubjectTypes { get; set; }
        DbSet<Syllabus> Syllabi { get; set; }
        public int SaveChanges();
    }
}