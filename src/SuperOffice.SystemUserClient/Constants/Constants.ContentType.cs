// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SuperOffice.SystemUser
{
    /// <summary>
    /// Constants used in the SuperOffice System User Client
    /// </summary>
    public static partial class Constants
    {
        /// <summary>
        /// ContentType values used in HTTP request headers
        /// </summary>
        public static class ContentType
        {
            /// <summary>
            /// JSON content type
            /// </summary>
            public const string Json = "application/json";

            /// <summary>
            /// Octet stream content type
            /// </summary>
            public const string OctetStream = "application/octet-stream";

            /// <summary>
            /// XML content type
            /// </summary>
            public const string Xml = "text/xml";
        }
    }
}
