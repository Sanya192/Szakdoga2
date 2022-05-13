namespace Szakdoga.API.QueryDtos
{
    /// <summary>
    /// A DTO for transfering EqualentSubjectData.
    /// </summary>
    public class EqualsDto
    {
        /// <summary>
        /// The source Syllabus.
        /// </summary>
        public string SourceSyllabusId { get; set; }

        /// <summary>
        /// The target Syllabus.
        /// </summary>
        public string TargetSyllabusId { get; set; }

        /// <summary>
        /// The name of the source Syllabus.
        /// </summary>
        public string SourceSyllabusName { get; set; }

        /// <summary>
        /// The name of the target Syllabus.
        /// </summary>
        public string TargetSyllabusName { get; set; }

        /// <summary>
        /// List of Equal subjects.
        /// </summary>
        public List<SubjectEqualPairDto> EqualPairDtos { get; set; }
    }
}
