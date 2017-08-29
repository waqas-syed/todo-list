using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using ToDoApp.Common.WebHost.Providers;
using ToDoApp.Identity.Application.Ninject.Modules;
using ToDoApp.Identity.Persistence.Ninject.Modules;
using ToDoApp.Identity.Ports.Ninject.Modules;
using ToDoApp.Lists.Application.Ninject.Modules;
using ToDoApp.Lists.Persistence.Ninject.Modules;
using ToDoApp.Lists.Ports.Ninject.Module;

[assembly: OwinStartup(typeof(ToDoApp.Common.WebHost.Startup))]
namespace ToDoApp.Common.WebHost
{
    public class AppBuilderProvider : IDisposable
    {
        private IAppBuilder _app;
        public AppBuilderProvider(IAppBuilder app)
        {
            _app = app;
        }
        public IAppBuilder Get() { return _app; }
        public void Dispose() { }
    }

    /// <summary>
    /// This class is used to load up the app using OWIN pipeline
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures Identity, OAuth, Cors, Web Api and dependency resolution
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new AppBuilderProvider(app));

            HttpConfiguration configuration = new HttpConfiguration();

            var corsPolicy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true
            };

            corsPolicy.Origins.Add(Constants.FrontendUrl);

            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            });

            
            ConfigureOAuth(app);
            WebApiConfig.Register(configuration);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(configuration);
        }

        private StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load<ListsPersistenceNinjectModule>();
            kernel.Load<ListsApplicationNinjectModule>();
            kernel.Load<ListsPortsNinjectModule>();
            kernel.Load<IdentityPersistenceNinjectModule>();
            kernel.Load<IdentityApplicationNinjectModule>();
            kernel.Load<IdentityPortsNinjectModule>();

            return kernel;
        }

        /// <summary>
        /// Configure OAuth
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oauthOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/v1/account/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new SimpleAuthorizationProvider()
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}