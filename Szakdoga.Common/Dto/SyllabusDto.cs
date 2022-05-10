using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.Common.Dto
{
    public class SyllabusDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Length { get; set; }
        public string? MustChoseCredit { get; set; }
        public string? ChosableCredit { get; set; }
        public string? StartingSpecSemester { get; set; }
        public string? Parent { get; set; }
    }
}
