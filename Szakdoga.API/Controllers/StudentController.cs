using Microsoft.AspNetCore.Mvc;
using System.Net;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController
    {
        public StudentController(ISzakdogaContext context, IMapper<Student, StudentDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected ISzakdogaContext Context { get; set; }
        protected IMapper<Student, StudentDto> Mapper { get; set; }

        [HttpGet]
        public StudentDto Get()
        {
            return Mapper.MapToDto(Context.Students.First())!;
        }

        [HttpGet("GetFinishedSubjects/")]
        public Dictionary<string, int?> GetFinishedSubjects()
        {
            return this.Get().FinishedCourses.ToDictionary(x => x.Key, x => x.Value);
        }

        [HttpGet("GetFinishedSubjects/{syllabusID}")]
        public Dictionary<string, int?> GetFinishedSubjects(string? syllabusID)
        {
            var classesRelatedToSyllabi = Context.Subjects.Where(x => x.SyllabusId == syllabusID).Select(x => x.Id).ToList();
            return this.Get().FinishedCourses.Where(x => classesRelatedToSyllabi.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
        }

        [HttpPut]
        public void AddFinishedSubjects([FromBody] Dictionary<string, int?> finishedSubjects)
        {
            foreach (var item in finishedSubjects)
            {

                Context.StudentFinisheds.Add(new StudentFinished { StudentId = 1, Grade = item.Value, SubjectId = item.Key });
            }
            Context.SaveChanges();
        }
    }
}
