using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.Common.Mappers
{
    public interface IMapper <TModel,TDto>
    {
        public TDto? MapToDto(TModel? model);
        public TModel? MapToModel(TDto? model);
    }
}
