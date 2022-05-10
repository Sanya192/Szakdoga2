using Microsoft.AspNetCore.Mvc;
using System.Net;
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
            return Context.Syllabi.Select(x => Mapper.MapToDto(x)).ToList();
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
                Context.Syllabi.Add(Mapper.MapToModel(value)!);
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
