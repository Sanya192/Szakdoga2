using System;
using System.Collections.Generic;

namespace Szakdoga.DataLayer.Model
{
    public partial class SubjectType
    {
        public SubjectType()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
