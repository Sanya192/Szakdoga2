using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.Common.Mappers
{
    /// <summary>
    /// Maps between <typeparamref name="TModel"/> and<typeparamref name="TDto"/>.
    /// </summary>
    /// <typeparam name="TModel">The modelType.</typeparam>
    /// <typeparam name="TDto">The Dto</typeparam>
    public interface IMapper <TModel,TDto>
    {
        /// <summary>
        /// Maps from Model to Dto.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <returns>The output dto.</returns>
        public TDto? MapToDto(TModel? model);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TModel? MapToModel(TDto? model);


        public TModel? MapToModel(TDto? dto, TModel? reference);

    }
}
