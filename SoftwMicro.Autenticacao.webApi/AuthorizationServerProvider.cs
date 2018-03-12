using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace SCAFwebApi
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {  
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {   //Responsaval por verificar token para não fazer varias persistência servidor.
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            try
            {
                var user = context.UserName;
                var password = context.Password;

                if (user != "Manoel" )
                {
                    context.SetError("invalid_grant", "O nome de usuário ou senha está incorreto");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user));

                var roles = new List<string>();
                roles.Add("user");

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch
            {
                context.SetError("invalid_grant", "Erro na autênticação.");

            }
           

        }
    }
}