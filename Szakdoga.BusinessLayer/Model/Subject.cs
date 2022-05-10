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
            SubjectLanguage = DefaultLanguage;
            PreRequisite=new List<SubjectPreRequisites>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string SubjectName { get; set; }
        public int Kredit { get; set; }

        public virtual ICollection<SubjectPreRequisites> PreRequisite { get; set; }

        public SubjectType SubjectType { get; set; }
        public SubjectLanguage SubjectLanguage { get; set; }
    }

    public class SubjectEquals
    {
        public int ID { get; set; }
        public virtual Subject? SubjectOne { get; set; }
        public virtual Subject? SubjectTwo { get; set; }
    }

    public class SubjectPreRequisites
    {
        public int ID { get; set; }
        public virtual Subject? theSubject { get; set; }
        public virtual Subject? PreRequisite { get; set; }
    }

}
