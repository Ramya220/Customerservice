using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;


[assembly: OwinStartup(typeof(Customerservice.Startup))]

namespace Customerservice
{
    public class Startup
    {
         
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);  
  
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //The Path For generating the Toekn  
                TokenEndpointPath = new PathString("/token"),

                //Setting the Token Expired Time (24 hours)  
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //AuthorizationServerProvider class will validate the user credentials  
                Provider = new AuthorizationServerProvider()
            };

        //Token Generations  
        app.UseOAuthAuthorizationServer(options);  
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());  
  
            HttpConfiguration config = new HttpConfiguration();
        WebApiConfig.Register(config);  
        
}
}