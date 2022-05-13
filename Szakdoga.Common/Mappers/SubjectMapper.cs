using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Mappers
{
    /// <inheritdoc/>.
    public class SubjectMapper : IMapper<Subject, SubjectDto>
    {
        /// <inheritdoc/>.
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
                Language = (Constants.SubjectLanguage)Enum.Parse(typeof(Constants.SubjectLanguage), model.Language),
            };

            dto.Parents = model?.Parents?.ToList()?.Select(x => x)?.ToDictionary(x => x.Id, x => x.Name);
            return dto;
        }

        /// <inheritdoc/>.
        public Subject? MapToModel(SubjectDto? model)
        {
            return this.MapToModel(model, null);
        }

        /// <inheritdoc/>.
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

            return subject;
        }

        /// <inheritdoc/>.
        public Subject? MapToModel(Subject? dto, SubjectDto reference)
        {
            throw new NotImplementedException();
        }
    }
}
