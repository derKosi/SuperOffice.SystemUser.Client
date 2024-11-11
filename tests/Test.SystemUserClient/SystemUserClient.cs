using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SuperOffice.SystemUser;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Test.SystemUserClient
{
    [TestClass]
    public class SystemUserClientTests
    {
         private Settings _settings;

        /*
         * The TestInitialize method is called before each test method in the test class.
         * It fetches the settings from the configuration file, settings.test.json, and the certificate from pricateKey.xml
         */

        [TestInitialize]
        public void Initialize()
        {
            _settings = LoadConfiguration();
            _settings.PrivateKey = PrivateCertificate;
        }

        private static Settings LoadConfiguration()
        {
            var configText = File.ReadAllText("settings.test.json");
            var settings = JsonConvert.DeserializeObject<Settings>(configText);
            return settings;
        }

        private static string PrivateCertificate
        {
            get
            {
                // Load the private key from the specified file path
                if (File.Exists("privateKey.xml"))
                {
                    return File.ReadAllText("privateKey.xml");
                }
                else
                {
                    throw new FileNotFoundException("Private key file not found.");
                }
            }
        }

        [TestMethod]
        public async Task Test_Get_SystemUser_Ticket_Async()
        {
            var client = new SuperOffice.SystemUser.SystemUserClient(GetSystemUserInfo(), new System.Net.Http.HttpClient());

            var ticket = await client.GetSystemUserTicketAsync();
            Debug.WriteLine("Output: " + ticket);

            StringAssert.StartsWith(ticket, "7T:");
        }

        [TestMethod]
        public void Test_Get_SystemUser_Ticket_Sync()
        {
            var client = new SuperOffice.SystemUser.SystemUserClient(GetSystemUserInfo(), new System.Net.Http.HttpClient());

            var ticket = client.GetSystemUserTicketAsync().GetAwaiter().GetResult();
            Debug.WriteLine("Output: " + ticket);

            StringAssert.StartsWith(ticket, "7T:");
        }

        [TestMethod]
        public async Task Test_Validate_SystemUser_JWT_Async()
        {
            var client = new SuperOffice.SystemUser.SystemUserClient(GetSystemUserInfo(), new System.Net.Http.HttpClient());
            var tokenResult = await client.GetSystemUserJwtAsync();
            var tokenValidationResult = await client.ValidateSystemUserResultAsync(tokenResult);
            Assert.IsTrue(tokenValidationResult.IsValid);
        }


        [TestMethod]
        [ExpectedException(typeof(SuperOffice.SystemUser.Client.Exceptions.InvalidSubDomainException))]
        public async Task When_SubDomain_Explicitly_Set_Throw_InvalidSubDomainException()
        {
            var sysUser = GetSystemUserInfo();
            sysUser.SubDomain = "production";
            var client = new SuperOffice.SystemUser.SystemUserClient(GetSystemUserInfo(), new System.Net.Http.HttpClient());
            var ticket = await client.GetSystemUserTicketAsync();

        }

        [TestMethod]
        [ExpectedException(typeof(SuperOffice.SystemUser.Client.Exceptions.InvalidSubDomainException))]
        public async Task When_Validating_Token_With_Invalid_SubDomain_Throw_InvalidSubDomainException()
        {
            var client = new SuperOffice.SystemUser.SystemUserClient(GetSystemUserInfo(), new System.Net.Http.HttpClient());
            var token = await client.GetSystemUserJwtAsync();

            var handler = new SuperOffice.SystemUser.Tokens.SystemUserTokenHandler(
                new System.Net.Http.HttpClient(), // HttpClient instance.
                "staging"                       // target online subdomain (sod, qaonline or online)
            );

            var tokenValidationResult = await handler.ValidateAsync(token.Token);
        }

        private SuperOffice.SystemUser.SystemUserInfo GetSystemUserInfo()
        {
            var sysUser = new SuperOffice.SystemUser.SystemUserInfo();
            sysUser.ClientSecret = _settings.ClientSecret;
            sysUser.ContextIdentifier = _settings.ContextIdentifier;
            sysUser.SubDomain = _settings.SubDomain;
            sysUser.SystemUserToken = _settings.SystemUserToken;
            sysUser.PrivateKey = _settings.PrivateKey;

            return sysUser;
        }
    }
}
