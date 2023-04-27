// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SuperOffice.SystemUser
{
    public static partial class Constants
    {

        /// <summary>
        /// A static inner class representing constants related to OAuth authentication.
        /// </summary>
        public static class OAuth
        {
            /// <summary>
            /// The access token key.
            /// </summary>
            public const string AccessToken = "access_token";

            /// <summary>
            /// The OAuth authority URL with a parameterized placeholder for the tenant name.
            /// </summary>
            public const string Authority = "https://{0}.superoffice.com/login";

            /// <summary>
            /// The claims issuer URL with a parameterized placeholder for the tenant name.
            /// </summary>
            public const string ClaimsIssuer = "https://{0}.superoffice.com";

            /// <summary>
            /// The client ID key.
            /// </summary>
            public const string ClientId = "client_id";

            /// <summary>
            /// The client secret key.
            /// </summary>
            public const string ClientSecret = "client_secret";

            /// <summary>
            /// The grant type key.
            /// </summary>
            public const string GrantType = "grant_type";

            /// <summary>
            /// The ID token key.
            /// </summary>
            public const string IdToken = "id_token";

            /// <summary>
            /// The metadata endpoint URL with a parameterized placeholder for the tenant name.
            /// </summary>
            public const string MetadataEndpoint = "https://{0}.superoffice.com/login/.well-known/openid-configuration";

            /// <summary>
            /// The redirect URI key.
            /// </summary>
            public const string RedirectUri = "redirect_uri";

            /// <summary>
            /// The refresh token key.
            /// </summary>
            public const string RefreshToken = "refresh_token";

            /// <summary>
            /// The response mode key.
            /// </summary>
            public const string ResponseMode = "response_mode";

            /// <summary>
            /// The response type key.
            /// </summary>
            public const string ResponseType = "response_type";

            /// <summary>
            /// The scope key.
            /// </summary>
            public const string Scope = "scope";

            /// <summary>
            /// The state key.
            /// </summary>
            public const string State = "state";
        }

    }
}
