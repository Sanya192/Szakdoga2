using Microsoft.AspNetCore.Mvc;
using System.Net;
using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.API.Controllers
{
    public class SyllabusController : SzakdogaControllerBase<Syllabus, SyllabusDto, string>
    {
        public SyllabusController(ISzakdogaContext context, IMapper<Syllabus, SyllabusDto> mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<SyllabusDto> Get()
        {
            return Context.Syllabi.ToList().Select(x => Mapper.MapToDto(x));
        }

        public override SyllabusDto Get(string id)
        {
            var result = Context.Syllabi.FirstOrDefault(x => x.Id == id);
            if (result == null)
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return UpdateFinishes(Mapper.MapToDto(result));
        }

        [HttpGet("AllSpecName/{MainId}")]
        public Dictionary<string, string> GetRegisteredSpecSyllabiName(string MainId)
        {
            return GetSyllabiNamesBasedOn(x =>x.Parent ==MainId);
        }
        [HttpGet("AllMainName")]
        public Dictionary<string, string> GetAllMainSyllabiName()
        {
            return GetSyllabiNamesBasedOn(x => x.Parent == null);
        }

        [HttpGet("AllSpecName")]
        public Dictionary<string, string> GetAllSpecSyllabiName()
        {
            return GetSyllabiNamesBasedOn(x =>x.Parent != null);
        }

        public override void Put([FromBody] SyllabusDto value)
        {
            if (Context.Syllabi.Find(value.Id) != null || value == null)
            {
                this.Response.StatusCode = 400;
            }
            else
            {
                var syllabusModel = Mapper.MapToModel(value)!;
                syllabusModel.Subjects = new List<Subject>();
                foreach (var item in value.Subjects)
                {
                    SubjectController.PutSubjectToContext(item, Context);
                    syllabusModel.Subjects.Add(Context.Subjects.Find(item.Id)!);
                }

                Context.Syllabi.Add(syllabusModel);
                Context.SaveChanges();
            }
        }

        public override void Delete(string id)
        {
            var toDelete = Context.Syllabi.Find(id);
            if (toDelete == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                foreach (var item in toDelete.Subjects)
                {
                    Context.StudentFinisheds.RemoveRange(item.StudentFinisheds);
                    Context.Subjects.Remove(item);

                }
                Context.Syllabi.Remove(toDelete);
            }
        }

        private Dictionary<string, string> GetSyllabiNamesBasedOn(Func<Syllabus, bool> condition)
        {
            return Context.Syllabi.ToList()
               .Where(x => condition(x))
               .ToDictionary(x => x.Id, x => x.Name);
        }

        private SyllabusDto UpdateFinishes(SyllabusDto dtoList)
        {
            for (int i = 0; i < dtoList.Subjects.Count; i++)
                dtoList.Subjects[i].Finished = Context.StudentFinisheds.Count(x => x.StudentId == Constants.DefaultUserId && x.SubjectId == dtoList.Subjects[i].Id) > 0;
            return dtoList;
        }

    }
}
