namespace Szakdoga.Common.Dto
{
    /// <summary>
    /// Dto for handling the 1 student.
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// The Id of the student.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the student.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Courses that the student finished.
        /// </summary>
        public Dictionary<string, int?>? FinishedCourses { get; set; }

        /// <summary>
        /// Courses that the sttudent has.
        /// </summary>
        public List<string>? Syllabi { get; set; }
    }
}
