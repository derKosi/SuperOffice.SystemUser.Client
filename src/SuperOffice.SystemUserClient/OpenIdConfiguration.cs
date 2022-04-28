// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperOffice.SystemUser
{
    public class OpenIdConfiguration
    {
        [JsonProperty(PropertyName = "authorization_endpoint", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AuthorizationEndpoint { get; set; }

        [JsonProperty(PropertyName = "claims_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ClaimsSupported { get; set; }
        
        [JsonProperty(PropertyName = "end_session_endpoint", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string EndsessionEndpoint { get; set; }
        
        [JsonProperty(PropertyName = "grant_types_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] GrantTypesSupported { get; set; }

        [JsonProperty(PropertyName = "id_token_signing_alg_values_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] IdTokenSigningAlgValuesSupported { get; set; }

        [JsonProperty(PropertyName = "issuer", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Issuer { get; set; }

        [JsonProperty(PropertyName = "jwks_uri", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string JwksUri { get; set; }
        
        public JsonWebKeySet JsonWebKeySet { get; internal set; }

        [JsonProperty(PropertyName = "response_modes_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ResponseModesSupported { get; set; }

        [JsonProperty(PropertyName = "response_types_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ResponseTypesSupported { get; set; }

        [JsonProperty(PropertyName = "scopes_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ScopesSupported { get; set; }

        [JsonProperty(PropertyName = "subject_types_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] SubjectTypesSupported { get; set; }
        
        [JsonProperty(PropertyName = "token_endpoint", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TokenEndpoint { get; set; }

        [JsonProperty(PropertyName = "token_endpoint_auth_methods_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] TokenEndpointAuthMethodsSupported { get; set; }
    }
}
