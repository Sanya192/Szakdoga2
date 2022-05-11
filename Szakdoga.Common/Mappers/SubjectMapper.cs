using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Mappers
{
    public class SubjectMapper : IMapper<Subject, SubjectDto>
    {
        public SubjectDto? MapToDto(Subject? model)
        {
            if (model == null)
                return null;
            SubjectDto dto = new()
            {
                Id = model.Id,
                Name = model.Name,
                Kredit = model.Kredit,
                RecommendedSemester = model.RecommendedSemester,
                SyllabusId = model.SyllabusId,
                SubjectType = model.Type != null ? (Constants.SubjectType)Enum.Parse(typeof(Constants.SubjectType), model?.Type?.Name) : null,
                Language = (Constants.SubjectLanguage)Enum.Parse(typeof(Constants.SubjectLanguage), model.Language),
            };

            dto.Parents = model?.Parents?.Select(x => x).ToDictionary(x => x.Id, x => x.Name);
            return dto;
        }

        public Subject? MapToModel(SubjectDto? dto)
        {
            if (dto == null)
                return null;
            Subject subject = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Kredit = dto.Kredit.ToString(),
                RecommendedSemester = dto.RecommendedSemester.ToString(),
                SyllabusId = dto.SyllabusId,
                Language = dto.Language.ToString(),
                // Parents = dto.Parents != null ? dto.Parents?.Select(x => new Subject() { Id = x })?.ToList() : null,
            };
            return subject;
        }
    }
}
