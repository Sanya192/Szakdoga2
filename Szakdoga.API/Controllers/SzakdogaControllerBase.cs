using Microsoft.AspNetCore.Mvc;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;

namespace Szakdoga.API.Controllers
{
    /// <summary>
    /// Base class for Subject And Syllabus Controller. Defines Crud and assign dependencies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class SzakdogaControllerBase<TModel, TDto, TKey> : ControllerBase
    {
        /// <summary>
        /// Maps the dependecies.
        /// </summary>
        /// <param name="context"><see cref="Context"/></param>
        /// <param name="mapper"><see cref="Mapper"/></param>
        protected SzakdogaControllerBase(ISzakdogaContext context, IMapper<TModel, TDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        /// <summary>
        /// Db context for queries.
        /// </summary>
        protected ISzakdogaContext Context { get; set; }

        /// <summary>
        /// Mapper used for type conversion.
        /// </summary>
        protected IMapper<TModel, TDto> Mapper { get; set; }

        /// <summary>
        /// Gets all <typeparamref name="TDto"/> objects.
        /// </summary>
        /// <returns>An <typeparamref name="TDto"/> collection.</returns>
        [HttpGet]
        public abstract IEnumerable<TDto> Get();

        /// <summary>
        /// Gets <typeparamref name="TDto"/> object by id>
        /// </summary>
        /// <param name="id"> The id.</param>
        /// <returns>The <typeparamref name="TDto"/> object</returns>
        [HttpGet("{id}")]
        public abstract TDto Get(TKey id);

        /// <summary>
        /// Adds a new object to the Database.
        /// </summary>
        /// <param name="value">THe value to be added.</param>
        [HttpPut()]
        public abstract void Put([FromBody] TDto value);

        /// <summary>
        /// Deletes a record of the database.
        /// </summary>
        /// <param name="id">The key of the object to be deleted.</param>
        [HttpDelete("{id}")]
        public abstract void Delete(TKey id);
    }
}
