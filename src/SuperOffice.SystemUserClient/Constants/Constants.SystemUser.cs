// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SuperOffice.SystemUser
{
    public static partial class Constants
    {
        /// <summary>
        /// SystemUser constants.
        /// </summary>
        public static class SystemUser
        {
            /// <summary>
            /// ClaimsIssuer used in the SystemUserClient
            /// </summary>
            public const string ClaimsIssuer = "SuperOffice AS";

            /// <summary>
            /// SystemUserEndpoint is the URL used to authenticate a SystemUser
            /// </summary> 
            public const string SystemUserEndpoint = "https://{0}.superoffice.com/Login/api/PartnerSystemUser/Authenticate";
        }
    }
}
