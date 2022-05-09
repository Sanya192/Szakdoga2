using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Szakdoga.BusinessLayer.Utils.Constants;

namespace Szakdoga.BusinessLayer.Model
{
    public class Subject
    {
        public Subject()
        {
            PreRequisite = new List<Subject>();
            SubjectLanguage = DefaultLanguage;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string SubjectName { get; set; }
        public int Kredit { get; set; }
        public virtual List<Subject>? PreRequisite { get; set; }
        public SubjectType SubjectType { get; set; }
        public SubjectLanguage SubjectLanguage { get; set; }

    }
}
