using Szakdoga.Common.Dto;

namespace Szakdoga.API.QueryDtos
{
    public class EqualsDto
    {
        public string sourceSyllabusId { get; set; }
        public string targetSyllabusId { get; set; }
        public List<SubjectEqualPairDto> EqualPairDtos { get; set; }
    }

    public class SubjectEqualPairDto
    {
        public SubjectDto targetSubject { get; set; }
        public SubjectDto requiredSubject { get; set; }
    }
}
