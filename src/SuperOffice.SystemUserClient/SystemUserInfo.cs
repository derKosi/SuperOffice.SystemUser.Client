// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace SuperOffice.SystemUser
{
    /// <summary>
    /// Used in conjunction with obtaining and refreshing System User Ticket.
    /// </summary>
    public class SystemUserInfo
    {
        private string _subDomain = string.Empty;

        /// <summary>
        /// The application secret, used in CRM online only. Equivalent to OAuth client_secret.
        /// </summary>
        [JsonPropertyName("ApplicationToken")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ClientSecret { get; set; }

        /// <summary>
        /// The customer id, used in CRM online only. Example Cust12345.
        /// </summary>
        [JsonPropertyName("ContextIdentifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ContextIdentifier { get; set; }

        /// <summary>
        /// The application private key (RSA XML format), used to sign system user token requests. Starts with &lt;RSAKeyValue&gt;.
        /// </summary>
        [JsonIgnore]
        public string PrivateKey { get; set; }

        /// <summary>
        /// The target SuperOffice CRM online subdomain ('sod', 'qaonline' or 'online').
        /// </summary>
        [JsonIgnore]
        public string SubDomain
        {
            get => _subDomain;
            set
            {
                if (!value.IsValidSubDomain())
                    throw new Client.Exceptions.InvalidSubDomainException("Invalid SuperOffice CRM online subdomain specified. Use 'sod' or 'qaonline' or 'online'.");
                _subDomain = value;
            }
        }

        /// <summary>
        /// Application system user token. Obtained as a claim in an authorization response.
        /// </summary>
        [JsonIgnore]
        public string SystemUserToken { get; set; }

        /// <summary>
        /// Return token type. Always JWT.
        /// </summary>
        [JsonPropertyName("ReturnTokenType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ReturnTokenType => "JWT";

        /// <summary>
        /// SignedSystemToken is the signed system user token string.
        /// </summary>
        [JsonPropertyName("SignedSystemToken")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SignedSystemToken => Sign();

        /// <summary>
        /// Cryptographically sign system user token.
        /// </summary>
        /// <returns>Signed system user token</returns>
        private string Sign()
        {
            string result = string.Empty;
            string utcDateTime = DateTime.UtcNow.ToString("yyyyMMddHHmm");
            string tokenAndDate = string.Concat(SystemUserToken, ".", utcDateTime);
            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rSACryptoServiceProvider.FromXmlString(PrivateKey);
                byte[] signedTokenAndDate = rSACryptoServiceProvider.SignData(Encoding.UTF8.GetBytes(tokenAndDate), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                result = string.Concat(tokenAndDate, ".", Convert.ToBase64String(signedTokenAndDate));
            }

            return result;
        }
    }
}
