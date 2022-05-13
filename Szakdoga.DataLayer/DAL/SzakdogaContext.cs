using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.DataLayer.DAL
{
    public partial class SzakdogaContext : DbContext, ISzakdogaContext
    {
        public SzakdogaContext()
        {
        }

        public SzakdogaContext(DbContextOptions<SzakdogaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentFinished> StudentFinisheds { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectType> SubjectTypes { get; set; } = null!;
        public virtual DbSet<Syllabus> Syllabi { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\doga\\Szakdoga.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasMany(d => d.Syllabi)
                    .WithMany(p => p.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentSyllabus",
                        l => l.HasOne<Syllabus>().WithMany().HasForeignKey("SyllabusId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("StudentSyllabus_Syllabus_ID_fk"),
                        r => r.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("StudentSyllabus_Student_ID_fk"),
                        j =>
                        {
                            j.HasKey("StudentId", "SyllabusId").HasName("StudentSyllabus_pk");

                            j.ToTable("StudentSyllabus");

                            j.IndexerProperty<int>("StudentId").HasColumnName("StudentID");

                            j.IndexerProperty<string>("SyllabusId").HasMaxLength(300).IsUnicode(false).HasColumnName("SyllabusID");
                        });
            });

            modelBuilder.Entity<StudentFinished>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.SubjectId })
                    .HasName("StudentFinished_pk")
                    .IsClustered(false);

                entity.ToTable("StudentFinished");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("SubjectID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentFinisheds)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StudentFinished_Student_ID_fk");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentFinisheds)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StudentFinished_Subject_ID_fk");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Kredit)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("kredit");

                entity.Property(e => e.Language)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Hungarian')");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedSemester)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SyllabusId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("SyllabusID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Syllabus)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SyllabusId)
                    .HasConstraintName("Subject_Syllabus_ID_fk");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Subject_SubjectType_ID_fk");

                entity.HasMany(d => d.ChildSubjects)
                    .WithMany(p => p.Parents)
                    .UsingEntity<Dictionary<string, object>>(
                        "SubjectPreRequisite",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("ChildSubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectPreRequisite_Subject_ID_fk"),
                        r => r.HasOne<Subject>().WithMany().HasForeignKey("ParentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectPreRequisite_Subject_ID_fk_2"),
                        j =>
                        {
                            j.HasKey("ChildSubjectId", "ParentId").HasName("SubjectPreRequisite_pk");

                            j.ToTable("SubjectPreRequisite");

                            j.IndexerProperty<string>("ChildSubjectId").HasMaxLength(300).IsUnicode(false).HasColumnName("ChildSubjectID");

                            j.IndexerProperty<string>("ParentId").HasMaxLength(300).IsUnicode(false);
                        });

                entity.HasMany(d => d.NeededSubjects)
                    .WithMany(p => p.WantedSubjects)
                    .UsingEntity<Dictionary<string, object>>(
                        "SubjectEqual",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("NeededSubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectEquals_Subject_ID_fk_2"),
                        r => r.HasOne<Subject>().WithMany().HasForeignKey("WantedSubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectEquals_Subject_ID_fk"),
                        j =>
                        {
                            j.HasKey("WantedSubjectId", "NeededSubjectId").HasName("SubjectEquals_pk");

                            j.ToTable("SubjectEquals").HasComment("ekvivalencia tábla");

                            j.IndexerProperty<string>("WantedSubjectId").HasMaxLength(300).IsUnicode(false);

                            j.IndexerProperty<string>("NeededSubjectId").HasMaxLength(300).IsUnicode(false);
                        });

                entity.HasMany(d => d.Parents)
                    .WithMany(p => p.ChildSubjects)
                    .UsingEntity<Dictionary<string, object>>(
                        "SubjectPreRequisite",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("ParentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectPreRequisite_Subject_ID_fk_2"),
                        r => r.HasOne<Subject>().WithMany().HasForeignKey("ChildSubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectPreRequisite_Subject_ID_fk"),
                        j =>
                        {
                            j.HasKey("ChildSubjectId", "ParentId").HasName("SubjectPreRequisite_pk");

                            j.ToTable("SubjectPreRequisite");

                            j.IndexerProperty<string>("ChildSubjectId").HasMaxLength(300).IsUnicode(false).HasColumnName("ChildSubjectID");

                            j.IndexerProperty<string>("ParentId").HasMaxLength(300).IsUnicode(false);
                        });

                entity.HasMany(d => d.WantedSubjects)
                    .WithMany(p => p.NeededSubjects)
                    .UsingEntity<Dictionary<string, object>>(
                        "SubjectEqual",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("WantedSubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectEquals_Subject_ID_fk"),
                        r => r.HasOne<Subject>().WithMany().HasForeignKey("NeededSubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("SubjectEquals_Subject_ID_fk_2"),
                        j =>
                        {
                            j.HasKey("WantedSubjectId", "NeededSubjectId").HasName("SubjectEquals_pk");

                            j.ToTable("SubjectEquals").HasComment("ekvivalencia tábla");

                            j.IndexerProperty<string>("WantedSubjectId").HasMaxLength(300).IsUnicode(false);

                            j.IndexerProperty<string>("NeededSubjectId").HasMaxLength(300).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<SubjectType>(entity =>
            {
                entity.ToTable("SubjectType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Syllabus>(entity =>
            {
                entity.ToTable("Syllabus");

                entity.Property(e => e.Id)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ChosableCredit)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Length)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MustChoseCredit)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Parent)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("parent");

                entity.Property(e => e.StartingSpecSemester)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("Syllabus_Syllabus_ID_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
