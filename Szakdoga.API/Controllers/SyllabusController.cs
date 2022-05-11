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

        public override IEnumerable<SyllabusDto?> Get()
        {
            return Context.Syllabi.ToList().Select(x => Mapper.MapToDto(x));
        }

        [HttpGet("/Registered")]
        public Dictionary<string, string> GetRegisteredSyllabi()
        {
            return Context.Syllabi
                .Where(x => x.Students.Contains(Context.Students.FirstOrDefault(x => Constants.DefaultUserId == x.Id)))
                .ToDictionary(x => x.Id, x => x.Name);
        }

        public override SyllabusDto? Get(string id)
        {
            var result = Context.Syllabi.FirstOrDefault(x => x.Id == id);
            if (result == null)
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return Mapper.MapToDto(result);
        }


        public override void Post([FromBody] SyllabusDto value)
        {
            if (Context.Syllabi.Find(value.Id) == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                Context.Syllabi.Update(Mapper.MapToModel(value)!);
                Context.SaveChanges();
            }
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
                Context.Syllabi.Remove(toDelete);
            }
        }
    }
}
