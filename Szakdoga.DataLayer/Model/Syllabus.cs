namespace Szakdoga.DataLayer.Model
{
    public partial class Syllabus
    {
        public Syllabus()
        {
            InverseParentNavigation = new HashSet<Syllabus>();
            Subjects = new HashSet<Subject>();
            Students = new HashSet<Student>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Length { get; set; }
        public string? MustChoseCredit { get; set; }
        public string? ChosableCredit { get; set; }
        public string? StartingSpecSemester { get; set; }
        public string? Parent { get; set; }

        public virtual Syllabus? ParentNavigation { get; set; }
        public virtual ICollection<Syllabus> InverseParentNavigation { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
