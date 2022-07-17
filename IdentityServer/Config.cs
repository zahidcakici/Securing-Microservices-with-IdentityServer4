using IdentityServer4;
using IdentityServer4.Models;
// generic
using System.Collections.Generic;

namespace IdentityServer;
/// <summary>
/// Author : zahid.cakici@gmail.com
/// Date : 17.07.2022
/// Version : 1.0.0
/// </summary>
public class Config
{
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client()
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "secretApi" },
            },
            new Client()
            {
                ClientId = "postman",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = { "https://localhost:4200" },
                AllowedScopes = 
                {
                    "secretApi",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile 
                },
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,
                RequireConsent = false
            },
            new Client()
            {
                ClientId = "angular",

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,

                RedirectUris = { "http://localhost:4200" },
                PostLogoutRedirectUris = { "http://localhost:4200" },
                AllowedCorsOrigins = { "http://localhost:4200" },

                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    "secretApi",
                },

                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
            },
        };
    
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(){Name = "secretApi"},
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            // new ApiResource("SecretApi")
        };
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
}
