using Newtonsoft.Json;

namespace Test.SystemUserClient
{
    public class Settings
    {
        [JsonProperty(PropertyName = "ClientSecret", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientSecret { get; set; }

        [JsonProperty(PropertyName = "ContextIdentifier", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContextIdentifier { get; set; }

        [JsonProperty(PropertyName = "SubDomain", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SubDomain { get; set; }

        [JsonProperty(PropertyName = "SystemUserToken", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SystemUserToken { get; set; }

        [JsonProperty(PropertyName = "PrivateKey", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PrivateKey { get; set; }
    }
}
