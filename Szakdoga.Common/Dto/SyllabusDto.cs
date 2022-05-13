using System.ComponentModel.DataAnnotations;

namespace Szakdoga.Common.Dto
{
    /// <summary>
    /// A dto for transfaring syllabus data.
    /// </summary>
    public class SyllabusDto
    {
        /// <summary>
        /// The id of syllabus. Can't be null.
        /// </summary>
        [Required]
        public string Id { get; set; } = null!;
        /// <summary>
        /// The Name of Syllabus.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The length in Semesters.
        /// </summary>
        public string? Length { get; set; }

        /// <summary>
        /// Kötelezően választható kredit.
        /// </summary>
        public string? MustChoseCredit { get; set; }

        /// <summary>
        /// Választható kredit.
        /// </summary>
        public string? ChosableCredit { get; set; }

        /// <summary>
        /// The semester which specializations starts.
        /// </summary>
        public string? StartingSpecSemester { get; set; }

        /// <summary>
        /// The Sylabbus of this Syllabus.
        /// </summary>
        public string? Parent { get; set;}

        /// <summary>
        /// List of it's Subjects.
        /// </summary>
        public List<SubjectDto>? Subjects { get; set; }
    }
}
