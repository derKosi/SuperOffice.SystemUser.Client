// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.Serialization;

namespace SuperOffice.SystemUser
{
    public static partial class Constants
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        public static class Error
        {
            /// <summary>
            /// A const string property representing an argument null exception message with a parameterized placeholder.
            /// </summary>
            public const string ArgNullException = "'{0}' cannot be null or empty";

            /// <summary>
            /// A const string property representing a configuration null exception message.
            /// </summary>
            public const string ConfigCannotBeNull = "Configuration cannot be null";

            /// <summary>
            /// A const string property representing an HTTP client null exception message with a condition.
            /// </summary>
            public const string HttpClientCannotBeNull = "HttpClient cannot be null if config.BaseURL is NULL.";

            /// <summary>
            /// A const string property representing a returned content length too large exception message with a parameterized placeholder.
            /// </summary>
            public const string ContentTooLarge = "Returned Content Length too large: ";

            /// <summary>
            /// A const string property representing an access token validation failed exception message.
            /// </summary>
            public const string FailedAccessTokenValidation = "Access token validation failed.";

            /// <summary>
            /// A const string property representing a system user token validation failed exception message.
            /// </summary>
            public const string FailedSystemUserTokenValidation = "System User token validation failed.";
        }
    }
}
