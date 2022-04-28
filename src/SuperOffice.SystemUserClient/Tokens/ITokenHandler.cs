using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace SuperOffice.SystemUser.Tokens
{
    interface ITokenHandler
    {
        Task<TokenValidationResult> ValidateAsync(string idToken);
    }
}
