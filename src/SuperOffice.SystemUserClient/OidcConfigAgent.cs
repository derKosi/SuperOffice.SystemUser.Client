// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperOffice.SystemUser
{
    internal class OidcConfigAgent
    {
        private HttpClient _client;
        private static MemoryCache _cache;
        private string _uri;

        static OidcConfigAgent()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public OidcConfigAgent(string uri, HttpClient client)
        {
            this._uri = uri;
            this._client = client;
        }

        internal async Task<OpenIdConfiguration> GetConfigurationAsync(string metadataAddress)
        {
            OpenIdConfiguration configuration;
            if (_cache.TryGetValue(metadataAddress, out configuration))
            {
                return configuration;
            }

            string json = await _client.GetStringAsync(metadataAddress).ConfigureAwait(false);
            configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenIdConfiguration>(json);
            _cache.Set(metadataAddress, configuration, new DateTimeOffset(DateTime.Now.AddSeconds(15)));
            return configuration;

        }

        internal async Task<JsonWebKeySet> GetJsonWebKeySetAsync(string jwksUri)
        {
            JsonWebKeySet keySet;

            if (_cache.TryGetValue(jwksUri, out keySet))
            {
                return keySet;
            }

            var response = await _client.GetStringAsync(jwksUri).ConfigureAwait(false);
            keySet = JsonWebKeySet.Create(response);
            
            _cache.Set(jwksUri, keySet, new DateTimeOffset(DateTime.Now.AddSeconds(15)));

            return keySet;
        }
    }
}