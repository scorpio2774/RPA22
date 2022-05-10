using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace Prodajalna
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //dodaj json formatter
            var json = config.Formatters.JsonFormatter;

            //da bo delala krožna referenca
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            //odstrani xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
