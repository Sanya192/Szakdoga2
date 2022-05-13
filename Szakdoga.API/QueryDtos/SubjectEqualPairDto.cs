using Szakdoga.Common.Dto;

namespace Szakdoga.API.QueryDtos
{
    /// <summary>
    /// Dto for 2 subject that are equal.
    /// </summary>
    public class SubjectEqualPairDto
    {
        /// <summary>
        /// The TargetSubject
        /// </summary>
        public SubjectDto TargetSubject { get; set; }

        /// <summary>
        /// The required Subject.
        /// </summary>
        public SubjectDto RequiredSubject { get; set; }
    }
}
