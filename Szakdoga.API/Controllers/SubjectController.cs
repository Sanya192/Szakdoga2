using Microsoft.AspNetCore.Mvc;
using System.Net;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;
using Szakdoga.DataLayer.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Szakdoga.API.Controllers
{
    public class SubjectController : SzakdogaControllerBase<Subject, SubjectDto, string>
    {

        public SubjectController(ISzakdogaContext context, IMapper<Subject, SubjectDto> mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<SubjectDto?> Get()
        {
            var result = Context.Subjects.ToList().Select(x => Mapper.MapToDto(x)).ToList();
            return result;
        }


        public override SubjectDto? Get(string id)
        {
            var result = Context.Subjects.FirstOrDefault(x => x.Id == id);
            if (result == null)
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return Mapper.MapToDto(result);
        }


        public override void Post([FromBody] SubjectDto value)
        {
            if (Context.Subjects.Find(value.Id) == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var modelToAdd = Mapper.MapToModel(value)!;
                if (value.Parents != null && value.Parents.Count > 0)
                {
                    modelToAdd.Parents = value.Parents.Select(x => Context.Subjects.Find(x)).ToList();
                }
                Context.Subjects.Update(modelToAdd);
                Context.SaveChanges();
            }
        }

        public override void Put([FromBody] SubjectDto value)
        {
            if (!PutSubjectToContext(value, Context))
            {
                this.Response.StatusCode = 400;
            }
        }

        public override void Delete(string id)
        {
            Subject? toDelete = Context.Subjects.Find(id);
            if (toDelete == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                Context.Subjects.Remove(toDelete);
            }
        }

        public static bool PutSubjectToContext(SubjectDto value, ISzakdogaContext Context)
        {
            var mapper = new SubjectMapper();
            if (Context.Subjects.Find(value.Id) != null || value == null)
            {
                return false;
            }
            else
            {
                var modelToAdd = mapper.MapToModel(value)!;
                if (value.Parents != null && value.Parents.Count > 0)
                {
                    modelToAdd.Parents = value.Parents.Select(x => Context.Subjects.Find(x)).ToList();
                }
                Context.Subjects.Add(modelToAdd);
                Context.SaveChanges();
                return true;
            }
        }
    }
}
