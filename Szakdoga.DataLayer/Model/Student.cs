using System;
using System.Collections.Generic;

namespace Szakdoga.DataLayer.Datacontext
{
    public partial class Student
    {
        public Student()
        {
            StudentFinisheds = new HashSet<StudentFinished>();
            Syllabi = new HashSet<Syllabus>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<StudentFinished> StudentFinisheds { get; set; }

        public virtual ICollection<Syllabus> Syllabi { get; set; }
    }
}
