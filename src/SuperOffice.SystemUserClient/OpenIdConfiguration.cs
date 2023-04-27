// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperOffice.SystemUser
{
    /// <summary>
    /// Class for deserializing the OpenID Connect configuration.
    /// </summary>
    public class OpenIdConfiguration
    {
        /// <summary>
        /// AuthorizationEndpoint is the OAuth authorize endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "authorization_endpoint", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        /// ClaimsSupported is the list of the Claim Names of the Claims that the OpenID Provider MAY be able to supply values for.
        /// </summary>
        [JsonProperty(PropertyName = "claims_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ClaimsSupported { get; set; }
        
        /// <summary>
        /// EndSessionEndpoint is the OpenID Provider's logout endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "end_session_endpoint", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string EndsessionEndpoint { get; set; }
        
        /// <summary>
        /// GrantTypesSupported is the OAuth 2.0 Grant Type values that this OP supports.
        /// </summary>
        [JsonProperty(PropertyName = "grant_types_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] GrantTypesSupported { get; set; }

        /// <summary>
        /// IdTokenSiningAlgValuesSupported is the JWS signing algorithms (alg values) supported for the ID Token to encode the Claims in a JWT.
        /// </summary>
        [JsonProperty(PropertyName = "id_token_signing_alg_values_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] IdTokenSigningAlgValuesSupported { get; set; }

        /// <summary>
        /// Issuer is the URL using the https scheme with no query or fragment component that the OP asserts as its Issuer Identifier.
        /// </summary>
        [JsonProperty(PropertyName = "issuer", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Issuer { get; set; }

        /// <summary>
        /// JwksUri is the URL of the OP's JSON Web Key Set [JWK] document.
        /// </summary>
        [JsonProperty(PropertyName = "jwks_uri", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string JwksUri { get; set; }
        
        /// <summary>
        /// JsonWebKeySet is the JSON Web Key Set [JWK] document containing the signing key(s) the RP uses to validate signatures from the OP.
        /// </summary>
        public JsonWebKeySet JsonWebKeySet { get; internal set; }

        /// <summary>
        /// ResponseModesSupported is the OAuth 2.0 response_mode values that this OP supports.
        /// </summary>
        [JsonProperty(PropertyName = "response_modes_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ResponseModesSupported { get; set; }

        /// <summary>
        /// ResponseTypesSupported is the OAuth 2.0 response_type values that this OP supports.
        /// </summary>
        [JsonProperty(PropertyName = "response_types_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ResponseTypesSupported { get; set; }

        /// <summary>
        /// ScopesSupport is the OAuth 2.0 scope values that this OP supports.
        /// </summary>
        [JsonProperty(PropertyName = "scopes_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] ScopesSupported { get; set; }

        /// <summary>
        /// SubjectTypesSupported is the Subject Identifier types that this OP supports.
        /// </summary>
        [JsonProperty(PropertyName = "subject_types_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] SubjectTypesSupported { get; set; }
        
        /// <summary>
        /// TokenEndpoint is the OAuth token endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "token_endpoint", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// TokenEndpointAuthMethodsSupported is the OAuth 2.0 Token Endpoint Authentication methods supported by this Token Endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "token_endpoint_auth_methods_supported", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] TokenEndpointAuthMethodsSupported { get; set; }
    }
}
