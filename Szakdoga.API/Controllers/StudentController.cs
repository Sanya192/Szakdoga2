using Microsoft.AspNetCore.Mvc;
using System.Net;
using Szakdoga.BusinessLayer.Utils;
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

        [HttpGet("RegisterForUser/{syllabusID}")]
        public void RegisterForUser(string syllabusID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            student.Syllabi.Add(Context.Syllabi.Find(syllabusID));
            Context.Students.Update(student);
            Context.SaveChanges();
        }

        [HttpGet("DeRegisterForUser/{syllabusID}")]
        public void DeRegisterForUser(string syllabusID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            student.Syllabi.Remove(Context.Syllabi.Find(syllabusID));
            Context.Students.Update(student);
            Context.SaveChanges();
        }
        [HttpGet("GetFinishForUser/{subjectID}")]
        public bool GetFinishForUser(string subjectID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            return student.StudentFinisheds.Count(x=>x.SubjectId == subjectID)>0;
        }
        [HttpGet("SetFinishForUser/{subjectID}")]
        public void SetFinishForUser(string subjectID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            student.StudentFinisheds.Add(new StudentFinished { StudentId = student.Id, SubjectId = subjectID });
            Context.Students.Update(student);
            Context.SaveChanges();
        }
        [HttpGet("DeSetFinishForUser/{subjectID}")]
        public void DeSetFinishForUser(string subjectID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            student.StudentFinisheds.Remove(Context.StudentFinisheds.First(x=>x.StudentId == student.Id && x.SubjectId == subjectID));
            Context.Students.Update(student);
            Context.SaveChanges();
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
