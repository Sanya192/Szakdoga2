using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.BusinessLayer.Model
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public virtual MainSyllabus MainSyllabus { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual List<Subject> ExtraSubjects { get; set; }
    }
    public class FinishedSubject
    {
        public int ID { get; set; }
        public virtual Subject SubjectId { get; set; }
        public virtual Student StudentId {get;set;}
        public int Grade { get; set; }
    }
}
