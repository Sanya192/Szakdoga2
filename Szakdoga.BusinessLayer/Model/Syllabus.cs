using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.BusinessLayer.Model
{
    public abstract class Syllabus
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public virtual List<Subject> Subjects { get; set; }

    }
}
