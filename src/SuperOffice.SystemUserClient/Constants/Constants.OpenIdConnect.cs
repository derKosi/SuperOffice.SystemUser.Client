// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SuperOffice.SystemUser
{
    public static partial class Constants
    {

        /// <summary>
        /// A static inner class representing constants related to OAuth authentication.
        /// </summary>
        public static class OpenIdConnect
        {

            /// <summary>
            /// The metadata endpoint URL with a parameterized placeholder for the tenant name.
            /// </summary>
            public const string MetadataEndpoint = "https://{0}.superoffice.com/login/.well-known/openid-configuration";
        }

    }
}
