using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace Customerservice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.Routes.MapHttpRoute(
               name: "withoutactionApi",
               routeTemplate: "api/{Controller}",
               //defaults: new { Controllers = "Customersales"  }
               defaults: new { id = RouteParameter.Optional }

           );
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
              name: "WithActionApi",
              routeTemplate: "api/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{Controller}/{itemcode}",
                //defaults: new { Controllers = "Customersales"}
                defaults: new { itemcode = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
              name: "NewApi",
              routeTemplate: "api/{Controller}/{id}",
              //defaults: new { Controllers = "Customersales"}
              defaults: new { id = RouteParameter.Optional }
          );
        }
    }
}
