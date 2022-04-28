using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperOffice.SystemUser.Tokens
{
    /// <summary>
    /// Used to validate OAuth id_token in SuperOffice CRM online environment.
    /// </summary>
    public class JwtTokenHandler : TokenHandlerBase
    {
        /// <summary>
        /// SuperOffice Application ID, same as OAuth client_id.
        /// </summary>
        private readonly string _clientId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientId">SuperOffice Application ID, same as OAuth client_id. Required for Jwt validation.</param>
        /// <param name="client">HttpClient for issuing HTTP requests.</param>
        /// <param name="subdomain">SuperOffice CRM online subdomain.</param>
        public JwtTokenHandler(string clientId, HttpClient client, string subdomain) :
            base(client, subdomain)
        {
            _clientId = clientId;
        }


        /// <summary>
        /// Validates an OAuth ID token.
        /// </summary>
        /// <param name="idToken"></param>
        /// <returns>TokenValidationResult</returns>
        public override async Task<TokenValidationResult> ValidateAsync(string idToken)
        {
            var configuration = await ConfigurationManager.GetConfigurationAsync().ConfigureAwait(false);
            var validationParameters = ValidationParameters.Clone();
            validationParameters.ValidAudience = _clientId;
            validationParameters.ValidIssuer = ConfigurationManager.ClaimsIssuer;
            validationParameters.IssuerSigningKeys = configuration.JsonWebKeySet.Keys;

            return SecurityTokenHandler.ValidateToken(idToken, validationParameters);
        }
    }
}
