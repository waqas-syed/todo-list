using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ToDoApp.Common.WebHost
{
    /// <summary>
    /// Configuring the Web Api
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register Configuration
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Specifying the formatter
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
