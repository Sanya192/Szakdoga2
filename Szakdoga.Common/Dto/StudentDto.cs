using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.Common.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Dictionary<string,int?> FinishedCourses { get; set; }

        public List<string> Syllabi { get; set; }
    }
}
