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
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string SubjectName { get; set; }
        public int Kredit { get; set; }

        public virtual Subject? PreRequisite1 { get; set; }
        public virtual Subject? PreRequisite2 { get; set; }

        public SubjectType SubjectType { get; set; }
        public SubjectLanguage SubjectLanguage { get; set; }

        public bool AddPreRequisite(Subject subject)
        {
            if (PreRequisite1 == null)
            {
                PreRequisite1 = subject;
                return true;
            }
            if (PreRequisite2 == null)
            {
                PreRequisite2 = subject;
                return true;
            }
            return false;
        }
    }
    public class SubjectEquals
    {
        public int ID { get; set; }
        public virtual Subject? SubjectOne { get; set; }
        public virtual Subject? SubjectTwo { get; set; }
    }



}
