# Security


Identity and Access management (IAM) should belong to central location: an Identity Provider (IDP) 
IDP should allow clients to safely allow authentication and authorization using OpenID connect and OAuth2

OAuth 2.0(authorization) and OpenID Connect(authentication)
OAuth 2.0 is an open protocol to allow secure authorization in a simple and standard method for web, mobile and desktop application 

IdentityServer and Azure AD are security token service which impliments these standards. it exposes endpoints as defined by OAuth 2.0 specification.

OpenID Connect is simple identity layer on top of Auth2.0 protocol. So OpenID Connect extends OAuth 2.0.

With IDC clients can recieve the identity token (next to access token). Identity token can be used to sign into client application and can use the access token to access an API.

The UserInfo endpoint allows client application to get more information about the user.

IdentityServer and Azure AD are identity providers, Authorization Servers.

OpenID Connect(OIDC) is superior protocol. it extends and supersedes OAuth 2.0

Even if the client application only requires authorization to access an API, we should use OIDC instead of plain OAuth 2.0


Server Side Web Applications
Client Side Web Applications
WebAPI 
Desktop Applications
Mobile Applications
Hybrid Mobile Applications
