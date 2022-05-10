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
    public abstract class SzakdogaControllerBase<TModel, TDto, TKey> : ControllerBase
    {
        protected SzakdogaControllerBase(ISzakdogaContext context, IMapper<TModel, TDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected ISzakdogaContext Context { get; set; }
        protected IMapper<TModel, TDto> Mapper { get; set; }

        [HttpGet]
        public abstract IEnumerable<TDto?> Get();

        [HttpGet("{id}")]
        public abstract TDto? Get(TKey id);

        [HttpPost]
        public abstract void Post([FromBody] TDto value);

        [HttpPut()]
        public abstract void Put([FromBody] TDto value);

        [HttpDelete("{id}")]
        public abstract void Delete(TKey id);
    }
}
