using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.BusinessLayer.Utils
{
    public static class Constants
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubjectType
        {
            Mandatory,
            TypeA,
            TypeB,
            Optional
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubjectLanguage
        {
            Hungarian,
            Other
        }
        public static SubjectLanguage DefaultLanguage = SubjectLanguage.Hungarian;
        public static int DefaultUserId = 1;
    }
}
