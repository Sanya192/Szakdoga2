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

            dto.Parents = model?.Parents?.ToList().Select(x => x).ToDictionary(x => x.Id, x => x.Name);
            return dto;
        }


        public Subject? MapToModel(SubjectDto? model)
        {
            return this.MapToModel(model, null);
        }

        public Subject? MapToModel(SubjectDto? dto, Subject? reference)
        {
            if (dto == null)
                return null;
            Subject subject = reference ?? new();
            subject.Id = dto.Id;
            subject.Name = dto.Name;
            subject.Kredit = dto.Kredit?.ToString();
            subject.RecommendedSemester = dto.RecommendedSemester?.ToString();
            subject.SyllabusId = dto.SyllabusId;
            subject.Language = dto.Language.ToString();
            // Parents = dto.Parents != null ? dto.Parents?.Select(x => new Subject() { Id = x })?.ToList() : null,

            return subject;
        }

        public Subject? MapToModel(Subject? dto, SubjectDto reference)
        {
            throw new NotImplementedException();
        }
    }
}
