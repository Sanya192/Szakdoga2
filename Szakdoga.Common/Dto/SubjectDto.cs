using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using Szakdoga.BusinessLayer.Utils;
using System.Text.Json.Serialization;

namespace Szakdoga.Common.Dto
{
    public class SubjectDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Kredit { get; set; }
        public string? RecommendedSemester { get; set; }
        public string? SyllabusId { get; set; }
        public bool? Finished { get; set; }
        public Dictionary<string, string>? Parents { get; set; }
        public Constants.SubjectLanguage Language { get; set; }
        public Constants.SubjectType? SubjectType { get; set; }

    }
}
