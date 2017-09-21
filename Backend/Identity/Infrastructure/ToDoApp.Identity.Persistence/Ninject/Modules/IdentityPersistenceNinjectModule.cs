using Microsoft.AspNet.Identity;
using Ninject.Modules;
using Ninject.Web.Common;
using ToDoApp.Identity.Persistence.DatabasePipeline;
using ToDoApp.Identity.Persistence.Repositories;

namespace ToDoApp.Identity.Persistence.Ninject.Modules
{
    /// <summary>
    /// Declares dependencies for the Identity.Persistence layer
    /// </summary>
    public class IdentityPersistenceNinjectModule : NinjectModule
    {
        /// <summary>
        /// Loads the dependencies
        /// </summary>
        public override void Load()
        {
            Bind<AuthContext>().ToSelf().InRequestScope();
            Bind(typeof(IUserStore<CustomIdentityUser>)).To<CustomUserStore>().InRequestScope();
            Bind(typeof(UserManager<CustomIdentityUser>)).ToSelf().InRequestScope();
            Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();
        }
    }
}
