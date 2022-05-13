using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Szakdoga.BusinessLayer.Utils
{
    /// <summary>
    /// A class for storing constant values.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The languages of the subjects.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubjectLanguage
        {
            /// <summary>
            /// Hungarian.
            /// </summary>
            Hungarian,
            /// <summary>
            /// NotSpecified Languages.
            /// </summary>
            Other
        }
        /// <summary>
        /// The default Language for subjects.
        /// </summary>
        public static readonly SubjectLanguage DefaultLanguage = SubjectLanguage.Hungarian;

        /// <summary>
        /// The default user id.
        /// It's used because this program does not handles multiple Users.
        /// </summary>
        public static readonly int DefaultUserId = 1;
    }
}
