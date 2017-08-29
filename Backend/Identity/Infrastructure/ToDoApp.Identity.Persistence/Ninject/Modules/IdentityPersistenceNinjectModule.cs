using Ninject.Modules;
using Ninject.Web.Common;
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
            Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();
        }
    }
}
