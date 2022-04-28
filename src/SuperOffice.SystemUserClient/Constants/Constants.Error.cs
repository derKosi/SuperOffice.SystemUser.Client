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
            public const string ArgNullException = "'{0}' cannot be null or empty";
            public const string ConfigCannotBeNull = "Configuration cannot be null";
            public const string HttpClientCannotBeNull = "HttpClient cannot be null if config.BaseURL is NULL.";
            public const string ContentTooLarge = "Returned Content Length too large: ";
            public const string FailedAccessTokenValidation = "Access token validation failed.";
            public const string FailedSystemUserTokenValidation = "System User token validation failed.";
        }
    }
}
