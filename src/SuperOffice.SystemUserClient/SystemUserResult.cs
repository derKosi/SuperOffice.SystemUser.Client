using System.Text.Json.Serialization;

namespace SuperOffice.SystemUser
{
    /// <summary>
    /// Represents the result of a system user request.
    /// </summary>
    public class SystemUserResult
    {
        /// <summary>
        /// Error Message if any.
        /// </summary>
        [JsonPropertyName("ErrorMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// IsSuccessful is true when the token is successfully returned.
        /// </summary>
        [JsonPropertyName("IsSuccessful")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Token is the system user token as JWT.
        /// </summary>
        [JsonPropertyName("Token")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Token { get; set; }
    }
}
