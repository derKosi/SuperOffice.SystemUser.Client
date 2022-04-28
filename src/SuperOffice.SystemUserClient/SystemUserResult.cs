// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace SuperOffice.SystemUser
{
    /// <summary>
    /// Represents the result of a system user request.
    /// </summary>
    public class SystemUserResult
    {
        [JsonProperty(PropertyName = "ErrorMessage", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "IsSuccessful", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)] 
        public bool IsSuccessful { get; set; }

        [JsonProperty(PropertyName = "Token", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Token { get; set; }
    }
}
