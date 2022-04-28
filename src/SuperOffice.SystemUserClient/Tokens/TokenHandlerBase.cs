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
    /// Base class for all token handlers.
    /// </summary>
    public abstract class TokenHandlerBase : ITokenHandler
    {
        private ConfigurationManager _configurationManager;

        /// <summary>
        /// Contructor for TokenHandlerBase class.
        /// </summary>
        /// <param name="client">HttpClient for issuing HTTP requests.</param>
        /// <param name="subdomain">SuperOffice CRM online subdomain.</param>
        protected TokenHandlerBase(HttpClient client, string subdomain)
        {
            _configurationManager = new ConfigurationManager(client ?? new HttpClient(), subdomain);
        }

        /// <summary>
        /// Configuration manager responsible for getting OIDC configuration from metadata Uri.
        /// </summary>
        protected ConfigurationManager ConfigurationManager => _configurationManager;

        /// <summary>
        /// A Microsoft.IdentityModel.Tokens.SecurityTokenHandler designed for creating and
        /// validating Json Web Tokens.
        /// </summary>
        protected virtual JsonWebTokenHandler SecurityTokenHandler => new JsonWebTokenHandler();

        /// <summary>
        /// Gets or sets the parameters used to validate identity tokens.
        /// </summary>
        /// <remarks>Contains the types and definitions required for validating a token.</remarks>
        protected virtual TokenValidationParameters ValidationParameters => new TokenValidationParameters();

        /// <summary>
        /// Validates an identity token.
        /// </summary>
        /// <param name="token">The identity token.</param>
        /// <returns>Task of type <see cref="TokenValidationResult"/> with results of validation.</returns>
        public abstract Task<TokenValidationResult> ValidateAsync(string token);
    }
}
