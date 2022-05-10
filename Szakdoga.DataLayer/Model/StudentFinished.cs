using System;
using System.Collections.Generic;

namespace Szakdoga.DataLayer.Datacontext
{
    public partial class StudentFinished
    {
        public int StudentId { get; set; }
        public string SubjectId { get; set; } = null!;
        public int? Grade { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
