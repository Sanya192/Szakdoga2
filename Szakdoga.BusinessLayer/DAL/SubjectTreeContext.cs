using Microsoft.EntityFrameworkCore;
using Szakdoga.BusinessLayer.Model;

namespace Szakdoga.BusinessLayer.DAL
{
    public class SubjectTreeContext : DbContext
    {

        public DbSet<MainSyllabus> MainSyllabus { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<SubjectEquals> SubjectEquals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\doga\Szakdoga.mdf;Integrated Security=True;Connect Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
                .HasOne<Subject>(x => x.PreRequisite1)
                .WithOne();

            modelBuilder.Entity<Subject>()
                .HasOne<Subject>(x => x.PreRequisite2)
                .WithOne();

            /*modelBuilder.Entity<SubjectEquals>()
                .HasKey(x => new { x.SubjectOne, x.SubjectTwo });
            */


            /*modelBuilder.Entity<SubjectEquals>()
                .HasOne<Subject>(x => x.SubjectOne)
                .WithMany();

            modelBuilder.Entity<SubjectEquals>()
                .HasOne<Subject>(x => x.SubjectTwo)
                .WithMany();*/
        }
    }

}
