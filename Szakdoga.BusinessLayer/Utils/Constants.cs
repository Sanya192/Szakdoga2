using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.BusinessLayer.Utils
{
    public static class Constants
    {
        public enum SubjectType
        {
            Required,
            Specialization,
            MandatoryOptional,
            Optional
        }
        public enum SubjectLanguage
        {
            Hungarian,
            Other
        }
        public static SubjectLanguage DefaultLanguage = SubjectLanguage.Hungarian;
        public static bool DefaultUpdateEnabled = true;
    }
}
