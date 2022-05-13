using Szakdoga.Common.Dto;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Mappers
{
    /// <inheritdoc/>.
    public class SyllabusMapper : IMapper<Syllabus, SyllabusDto>
    {
        /// <inheritdoc/>.
        public SyllabusDto? MapToDto(Syllabus? model)
        {
            if (model == null)
                return null;
            SyllabusDto dto = new()
            {
                Id = model.Id,
                Name = model.Name,
                Length = model.Length,
                MustChoseCredit = model.MustChoseCredit,
                ChosableCredit = model.ChosableCredit,
                StartingSpecSemester = model.StartingSpecSemester,
                Parent = model.Parent
            };
            var subjects = model.Subjects?.ToList();
            if (subjects != null && subjects.Count > 0)
            {
                SubjectMapper subjectMapper = new();
                dto.Subjects = new List<SubjectDto>();
                foreach (var subject in subjects)
                {
                    var sub = subjectMapper.MapToDto(subject);
                    if (sub != null)
                        dto.Subjects.Add(sub);
                }
            }
            return dto;
        }

        /// <inheritdoc/>.
        public Syllabus? MapToModel(SyllabusDto? dto)
        {
            return MapToModel(dto, null);
        }

        /// <inheritdoc/>.
        public Syllabus? MapToModel(SyllabusDto? dto, Syllabus? reference)
        {
            if (dto == null)
                return null;
            Syllabus model = reference ?? new();

            model.Id = dto.Id;
            model.Name = dto.Name;
            model.Length = dto.Length;
            model.MustChoseCredit = dto.MustChoseCredit;
            model.ChosableCredit = dto.ChosableCredit;
            model.StartingSpecSemester = dto.StartingSpecSemester;
            model.Parent = dto.Parent;
            return model;
        }
    }
}
