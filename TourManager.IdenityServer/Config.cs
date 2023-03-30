using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using static System.Net.WebRequestMethods;

namespace TourManager.IdenityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
            new ApiScope("tour-manager-app", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "angular-client",
                RequireClientSecret = false,
                RequireConsent = false,
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                //AllowAccessTokensViaBrowser = true,
                //AccessTokenLifetime = 600,
                AllowedCorsOrigins = { "http://localhost:4200" },

                ClientSecrets = {
                    new Secret("secret".Sha256())
                },

                RedirectUris = { "http://localhost:4200/signin-callback" },
                //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "http://localhost:4200/signout-callback" },

                AllowOfflineAccess = true,
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "tour-manager-app"
                }
            },
            };
    }
}