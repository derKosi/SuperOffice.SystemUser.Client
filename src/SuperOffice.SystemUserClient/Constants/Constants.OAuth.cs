// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SuperOffice.SystemUser
{
    public static partial class Constants
    {

        public static class OAuth
        {
            public const string AccessToken = "access_token";

            public const string Authority = "https://{0}.superoffice.com/login";

            public const string ClaimsIssuer = "https://{0}.superoffice.com";

            public const string ClientId = "client_id";

            public const string ClientSecret = "client_secret";

            public const string GrantType = "grant_type";

            public const string IdToken = "id_token";

            public const string MetadataEndpoint = "https://{0}.superoffice.com/login/.well-known/openid-configuration";

            public const string RedirectUri = "redirect_uri";

            public const string RefreshToken = "refresh_token";

            public const string ResponseMode = "response_mode";

            public const string ResponseType = "response_type";

            public const string Scope = "scope";

            public const string State = "state";
        }
    }
}
