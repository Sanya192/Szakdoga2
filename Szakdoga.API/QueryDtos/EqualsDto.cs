using Szakdoga.Common.Dto;

namespace Szakdoga.API.QueryDtos
{
    public class EqualsDto
    {
        public string sourceSyllabusId;
        public string targetSyllabusId;
        public SubjectDto targetSubject;
        public SubjectDto requiredSubject;
    }
}
