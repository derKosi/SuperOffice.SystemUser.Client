// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SuperOffice.SystemUser
{
    public static partial class Constants
    {
        /// <summary>
        /// Constants used in the SuperOffice System User Client
        /// </summary>
        public static class ClaimNames
        {
            /// <summary>
            /// User principal name.
            /// </summary>
            public const string Upn = "http://schemes.superoffice.net/identity/upn";

            /// <summary>
            /// SuperId user principal name.
            /// </summary>
            public const string SuperIdUpn = "http://schemes.superoffice.net/identity/superid-upn";

            /// <summary>
            /// Tenant identifier.
            /// </summary>
            public const string TenantId = "http://schemes.superoffice.net/identity/tenantId";

            /// <summary>
            /// User's first name.
            /// </summary>
            public const string Firstname = "http://schemes.superoffice.net/identity/firstname";

            /// <summary>
            /// User's last name.
            /// </summary>
            public const string Lastname = "http://schemes.superoffice.net/identity/lastname";

            /// <summary>
            /// User's email address.
            /// </summary>
            public const string Email = "http://schemes.superoffice.net/identity/email";

            /// <summary>
            /// Identity provider.
            /// </summary>
            public const string IdentityProvider = "http://schemes.superoffice.net/identity/identityprovider";

            /// <summary>
            /// Secondary identity provider.
            /// </summary>
            public const string SecondaryIdentityProvider = "http://schemes.superoffice.net/identity/secondaryidentityprovider";

            /// <summary>
            /// Ticket associated with user's identity.
            /// </summary>
            public const string Ticket = "http://schemes.superoffice.net/identity/ticket";

            /// <summary>
            /// Context identifier associated with user's identity.
            /// </summary>
            public const string ContextIdentifier = "http://schemes.superoffice.net/identity/ctx";

            /// <summary>
            /// Associate identifier.
            /// </summary>
            public const string AssociateId = "http://schemes.superoffice.net/identity/associateid";

            /// <summary>
            /// User's initials.
            /// </summary>
            public const string Initials = "http://schemes.superoffice.net/identity/initials";

            /// <summary>
            /// User's primary email address.
            /// </summary>
            public const string SoPrimaryEmailAddress = "http://schemes.superoffice.net/identity/so_primary_email_address";

            /// <summary>
            /// Person identifier.
            /// </summary>
            public const string PersonId = "http://schemes.superoffice.net/identity/personid";

            /// <summary>
            /// NetServer URL.
            /// </summary>
            public const string NetserverUrl = "http://schemes.superoffice.net/identity/netserver_url";

            /// <summary>
            /// Web API URL.
            /// </summary>
            public const string WebApiUrl = "http://schemes.superoffice.net/identity/webapi_url";

            /// <summary>
            /// System token.
            /// </summary>
            public const string SystemToken = "http://schemes.superoffice.net/identity/system_token";

            /// <summary>
            /// Flag indicating whether the user has administrator privileges in the SuperOffice system.
            /// </summary>
            public const string IsAdministrator = "http://schemes.superoffice.net/identity/is_administrator";

            /// <summary>
            /// Company name.
            /// </summary>
            public const string CompanyName = "http://schemes.superoffice.net/identity/company_name";

            /// <summary>
            /// Company identifier.
            /// </summary>
            public const string CompanyId = "http://schemes.superoffice.net/identity/company_id";

            /// <summary>
            /// Database serial number.
            /// </summary>
            public const string Serial = "http://schemes.superoffice.net/identity/serial";
        }
    }
}
