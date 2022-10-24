using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Test.SystemUserClient
{
    [TestClass]
    public class SystemUserClientTests
    {
        /*
            To run tests, populate the following private members with your application details.
         */

        private readonly string _clientSecret = "YOUR_APP_CLIENT_SECRET";
        private readonly string _contextIdentifier = "Cust12345";
        private readonly string _subDomain = "sod";
        private readonly string _systemUserToken = "YOUR_APP_SYSTEM_USER_TOKEN";
        private readonly string _privateKey = @"<RSAKeyValue>
  <Modulus>YOUR_APP_RSA_XML_MODULUS</Modulus>
  <Exponent>YOUR_APP_RSA_XML_EXPONENT</Exponent>
  <P>YOUR_APP_RSA_XML_P</P>
  <Q>YOUR_APP_RSA_XML_Q</Q>
  <DP>YOUR_APP_RSA_XML_DP</DP>
  <DQ>YOUR_APP_RSA_XML_DQ</DQ>
  <InverseQ>YOUR_APP_RSA_XML_INVERSEQ</InverseQ>
  <D>YOUR_APP_RSA_XML_D</D>
</RSAKeyValue>";

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
            sysUser.ClientSecret = _clientSecret;
            sysUser.ContextIdentifier = _contextIdentifier;
            sysUser.SubDomain = _subDomain;
            sysUser.SystemUserToken = _systemUserToken;
            sysUser.PrivateKey = _privateKey;

            return sysUser;
        }
    }
}
