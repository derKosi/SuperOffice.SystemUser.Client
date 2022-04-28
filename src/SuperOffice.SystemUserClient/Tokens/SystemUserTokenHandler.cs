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
    /// Used to validate System User tokens in SuperOffice CRM online environment.
    /// </summary>
    public class SystemUserTokenHandler : TokenHandlerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">HttpClient for issuing HTTP requests.</param>
        /// <param name="environment">SuperOffice CRM online environment.</param>
        public SystemUserTokenHandler(HttpClient client, string subdomain) :
            base(client, subdomain)
        {
        }


        /// <inheritdoc/>
        public override async Task<TokenValidationResult> ValidateAsync(string token)
        {
            // extract the ValidAudience claim value (database serial number). 
            var securityToken = SecurityTokenHandler.ReadJsonWebToken(token);
            
            string serialNumber;
            
            if (!securityToken.TryGetPayloadValue<string>(Constants.ClaimNames.Serial, out serialNumber))
            {
                throw new SecurityTokenException("Unable to read ValidAudience from System User token.");
            }

            var configuration = await ConfigurationManager.GetConfigurationAsync().ConfigureAwait(false);
            var validationParameters = ValidationParameters.Clone();
            validationParameters.ValidAudience = string.Concat("spn:", serialNumber);
            validationParameters.ValidIssuer = Constants.SystemUser.ClaimsIssuer;
            validationParameters.IssuerSigningKeys = configuration.JsonWebKeySet.Keys;

            var result = SecurityTokenHandler.ValidateToken(token, validationParameters);
            if (result.Exception != null || !result.IsValid)
            {
                throw new SecurityTokenValidationException(Constants.Error.FailedSystemUserTokenValidation, result.Exception);
            }
            return result;
        }
    }
}
