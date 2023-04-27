# SuperOffice SystemUser Client

This library supports the System User flow. The client makes it very easy to call the online PartnerSystemUserService endpoint, validate the JWT and return the claims it contains.

The JWT contains a lot of information, however, it's usually just the Ticket credential that is interesting. Therefore, **SuperOffice.SystemUser.Client** simplifies calling the service, validating the response, and then returning the ticket in a single method call.

> [!WARNING]
> Do **not** ask for a System User Ticket every single time you SuperOffice web services - they are good for 6 hours. When you get a ticket, a new credentials record in the database each and every time. Therefore, **take advantage of the 6 hour window** and only ask for a new Ticket when absolutely necessary!

## How to use System User flow

Use the SystemUserClient class, located in the `SuperOffice.SystemUser` namespace.

The constructor accepts a `SuperOffice.SystemUser.SystemUserInfo` instance, and contains all of the information required to submit a request to the _partnersystemuserservice.svc_ endpoint.

### SystemUserInfo Properties

|Property            |Description                                        |
|--------------------|---------------------------------------------------|
|SubDomain           |The online environment (SOD, QAOnline, Production).   |
|ContextIdentifier   |The tenant, or customer, identity.                 |
|ClientSecret        |The application secret, a.k.a. client_secret.      |
|PrivateKey          |The applications RSAXML private certificate value. |
|SystemUserToken     |The SystemUser token, issued during app approval.  |

Given the required information, the `SystemUserClient` is able to generate and send a request to the service, then receive and validate the response.

```C#
var sysUserClient = new SystemUserClient(systemUserInfo);
var sysUserJwt = await sysUserClient.GetSystemUserJwtAsync();
var sysUserTkt = await sysUserClient.GetSystemUserTicketAsync();
```

**GetSystemUserJwtAsync**, only returns the JWT, wrapped in a `SystemUserResult`. It does not validate or extract any claims.

**GetSystemUserTicketAsync**, obtains the JWT, validates the token, and returns the system user ticket.

## Explicit JWT validation

When using `GetSystemUserJwtAsync`, there are two ways you can perform validation.

1. Use the ValidateSystemUserResultMethod, and get back a `TokenValidationResult`. This method is responsible for populating SystemUserClient.ClaimsIdentity property. This method is also used by the `GetSystemUserTicketAsync` method.

```C#
var tokenValidationResult = await sysUserClient.ValidateSystemUserResultAsync(systemUserResult);
```

1. Manually perform validation and extract claims, the `SystemUserClient` uses the `JwtTokenHandler`, located in the `SuperOffice.SystemUser.Tokens` namespace.

```C#
var handler = new SystemUserTokenHandler(
    new System.Net.Http.HttpClient(), // HttpClient instance.
    "sod"                             // target online environment (SOD, Stage or Production)
    );

var tokenValidationResult = await handler.ValidateAsync(sysUserJwt.Token);
```

The method `SystemUserTokenHandler.ValidateAsync` returns a TokenValidationResult, a Microsoft datatype located in the [Microsoft.IdentityModel.Tokens](https://docs.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.tokens.tokenvalidationresult) namespace, in the `Microsoft.IdentityModel.Tokens` assembly.
