using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;
using System.Text.Json;

namespace auth
{
    public static class Config
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One way street",
                    locality = "Porto",
                    postal_code = 4440,
                    country = "Portugal"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "543765",
                        Username = "dev",
                        Password = "dev",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "dev"),
                            new Claim(JwtClaimTypes.GivenName, "dev"),
                            new Claim(JwtClaimTypes.FamilyName, "dev"),
                            new Claim(JwtClaimTypes.Email, "dev@example.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Role, "admin"),
                            new Claim(JwtClaimTypes.WebSite, "http://dev.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address),
                                IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "123654",
                        Username = "henrique",
                        Password = "henrique",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Henrique Saraiva"),
                            new Claim(JwtClaimTypes.GivenName, "Henrique"),
                            new Claim(JwtClaimTypes.FamilyName, "Saraiva"),
                            new Claim(JwtClaimTypes.Email, "henrique60983@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Role, "user"),
                            new Claim(JwtClaimTypes.WebSite, "http://henriquesaraiva.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address),
                                IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("personalinfoapi.read"),
                new ApiScope("personalinfoapi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("personalinfoapi")
                {
                    Scopes = new List<string> {"personalinfoapi.read", "personalinfoapi.write"},
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "personalinfoportal",
                    ClientName = "Peronal Info Portal",
                    ClientUri = "https://personal-info-dev.com",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireClientSecret = false,

                    RedirectUris = { "https://personal-info-dev.com/signin" },

                    PostLogoutRedirectUris = { "https://personal-info-dev.com/signout" },

                    AllowedCorsOrigins = { "https://personal-info-dev.com" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "personalinfoapi.read"
                    },

                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
