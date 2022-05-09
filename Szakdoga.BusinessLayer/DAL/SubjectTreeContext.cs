using Microsoft.EntityFrameworkCore;
using Szakdoga.BusinessLayer.Model;

namespace Szakdoga.BusinessLayer.DAL
{
    public class SubjectTreeContext : DbContext
    {

        public DbSet<MainSyllabus> MainSyllabus { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<FinishedSubject> FinishedSubject { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\major\OneDrive\Dokumentumok\szakdogaLocal.mdf;Integrated Security=True;Connect Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainSyllabus>().ToTable("MainSyllabus");
            modelBuilder.Entity<Specialization>().ToTable("Specialization");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<FinishedSubject>().ToTable("FinishedSubjects");

        }
    }
}
