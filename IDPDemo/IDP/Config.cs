using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IDP
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "9a8e2420-92a0-47f9-8b7a-8b4daa6882fc",
                    Username="user1",
                    Password="password1",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name","user1"),
                        new Claim("family_name","family1"),
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client {
                    ClientId = "angular_spa",
                    ClientName = "Angular 4 Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string> { "openid", "profile" },
                    RedirectUris = new List<string> { "http://localhost:4200/auth-callback" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/" },
                    AllowedCorsOrigins = new List<string> { "http://localhost:4200" },
                    AllowAccessTokensViaBrowser = true
                },
                new Client {
                    ClientId = "asp.netcore_webapp",
                    ClientName = "ASP.NET Core WebApplication",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile
                    },
                    RedirectUris = new List<string> { "http://localhost:55616/signin-oidc" },

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AlwaysIncludeUserClaimsInIdToken = true
                },
                new Client {
                    ClientId = "windows-client",
                    ClientName = "Windows Client",
                    AllowedGrantTypes = {
                        GrantType.AuthorizationCode
                    },
                    AllowedScopes = new List<string> { "openid", "profile"},
                    RedirectUris = new List<string> { "urn:ietf:wg:oauth:2.0:oob" },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                }
               
            };
        }
    }
}
