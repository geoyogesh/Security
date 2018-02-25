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
            return new List<Client>();
        }
    }
}
