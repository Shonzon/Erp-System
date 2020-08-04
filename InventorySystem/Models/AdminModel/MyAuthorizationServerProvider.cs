using InventorySystem.DAL;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace InventorySystem.Models.AdminModel
{
    public class MyAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        HomeDAL homeDAL = new HomeDAL();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //string clientId = string.Empty;
            //string clientSecret = string.Empty;
            //// The TryGetBasicCredentials method checks the Authorization header and
            //// Return the ClientId and clientSecret
            //if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            //{
            //    context.SetError("invalid_client", "Client credentials could not be retrieved through the Authorization header.");
            //    context.Rejected();
            //    return;
            //}
            ////Check the existence of by calling the ValidateClient method
            //ResultResponse client = homeDAL.CheckLoginFrom(clientId, clientSecret);
            //if (client != null)
            //{
            //    // Client has been verified.
            //    context.OwinContext.Set<ResultResponse>("oauth:client", client);
            //    context.Validated(clientId);
            //}
            //else
            //{
            //    // Client could not be validated.
            //   // context.SetError("invalid_client", "Client credentials are invalid.");
            //    context.Validated("Not Found");
            //}
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
                ResultResponse user = homeDAL.CheckLoginFrom(context.UserName, context.Password);
            if (user.IsSuccess==false)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            else
            {
                    
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                    identity.AddClaim(new Claim(ClaimTypes.Email, user.Msg));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.PrimaryKey.ToString()));
                    context.Validated(identity);
            }
                
        }
    }
}