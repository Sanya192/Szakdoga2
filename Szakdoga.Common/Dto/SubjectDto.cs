using System.ComponentModel.DataAnnotations;
using Szakdoga.BusinessLayer.Utils;

namespace Szakdoga.Common.Dto
{
    /// <summary>
    /// A dto object used for transfering subject data.
    /// </summary>
    public class SubjectDto
    {
        /// <summary>
        /// The Id of the subject. Can't be null.
        /// </summary>
        [Required]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The name of the subject.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The kredit numbeer of the subject.
        /// </summary>
        public string? Kredit { get; set; }

        /// <summary>
        /// The Recommended Semester for taking the Subject.
        /// </summary>
        public string? RecommendedSemester { get; set; }

        /// <summary>
        /// The Id of which syllabus belongs to.
        /// If null it's an optional class.
        /// </summary>
        public string? SyllabusId { get; set; }
        
        /// <summary>
        /// True if finished class.
        /// </summary>
        public bool? Finished { get; set; }

        /// <summary>
        /// The pre requirements of the class.
        /// </summary>
        public Dictionary<string, string?>? Parents { get; set; }

        /// <summary>
        /// The language of the class. Default is <see cref="Constants.DefaultLanguage"/>
        /// </summary>
        public Constants.SubjectLanguage Language { get; set; }

    }
}
