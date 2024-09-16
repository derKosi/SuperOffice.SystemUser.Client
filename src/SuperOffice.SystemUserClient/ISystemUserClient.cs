// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperOffice.SystemUser
{
    /// <summary>
    /// Interface to obtain a System User Ticket or System User JWT.
    /// </summary>
    public interface ISystemUserClient
    {
        /// <summary>
        /// Populated when the System User Ticket is validated, this property represents the claims identity.
        /// </summary>
        ClaimsIdentity ClaimsIdentity { get; }

        /// <summary>
        /// Determines whether default HttpClient uses handler with default credentials and proxy settings. Default is false.
        /// </summary>
        bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// Sends a request to the system user web service.
        /// </summary>
        /// <returns>The <see cref="SuperOffice.SystemUser.SystemUserResult"/> which, if successful, contains System User JWT.</returns>
        Task<SystemUserResult> GetSystemUserJwtAsync();

        /// <summary>
        /// Sends a request to the system user web service and validates the results.
        /// </summary>
        /// <returns>A system user ticket.</returns>
        Task<string> GetSystemUserTicketAsync();


        /// <summary>
        /// Validates the response returned by the system user web service.
        /// </summary>
        /// <param name="systemUserResult">The response.</param>
        /// <returns>Returned a TokenValidationResult instance.</returns>
        /// <exception cref="Exception">An exception is thrown if there was any problems during validation.</exception>
        Task<TokenValidationResult> ValidateSystemUserResultAsync(SystemUserResult systemUserResult);
    }
}