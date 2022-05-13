using Microsoft.AspNetCore.Mvc;
using System.Net;
using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.API.Controllers
{
    /// <summary>
    /// Class for handling students.
    /// Currently this table only has one record which id is <see cref="Constants.DefaultUserId"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
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

        /// <summary>
        /// Get's all subjects that a student finished. 
        /// </summary>
        [HttpGet("GetFinishedSubjects/")]
        public Dictionary<string, int?> GetFinishedSubjects()
        {
            return this.Get().FinishedCourses.ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Get's all subjects that a student finished within a specified syllabus.
        /// </summary>
        /// <param name="syllabusID">The id of the target syllabus.</param>
        [HttpGet("GetFinishedSubjects/{syllabusID}")]
        public Dictionary<string, int?> GetFinishedSubjects(string? syllabusID)
        {
            var classesRelatedToSyllabi = Context.Subjects.Where(x => x.SyllabusId == syllabusID).Select(x => x.Id).ToList();
            return this.Get().FinishedCourses.Where(x => classesRelatedToSyllabi.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Get's if the current user Finished the subject.
        /// </summary>
        /// <param name="subjectID">The target subject.</param>
        [HttpGet("GetFinishForUser/{subjectID}")]
        public bool GetFinishForUser(string subjectID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            return student.StudentFinisheds.Any(x => x.SubjectId == subjectID);
        }

        /// <summary>
        /// Set's the subject. finished
        /// </summary>
        /// <param name="subjectID"></param>
        [HttpGet("SetFinishForUser/{subjectID}")]
        public void SetFinishForUser(string subjectID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            if (student.StudentFinisheds.Any(x=>x.SubjectId==subjectID))
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            }
            else
            {
                student.StudentFinisheds.Add(new StudentFinished { StudentId = student.Id, SubjectId = subjectID });
                Context.Students.Update(student);
                Context.SaveChanges();
            }
        }

        [HttpGet("DeSetFinishForUser/{subjectID}")]
        public void DeSetFinishForUser(string subjectID)
        {
            var student = Context.Students.Find(Constants.DefaultUserId);
            if (!student.StudentFinisheds.Any(x => x.SubjectId == subjectID))
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            }
            else
            {
                student.StudentFinisheds.Remove(Context.StudentFinisheds.First(x => x.StudentId == student.Id && x.SubjectId == subjectID));
                Context.Students.Update(student);
                Context.SaveChanges();
            }
        }


    }
}
