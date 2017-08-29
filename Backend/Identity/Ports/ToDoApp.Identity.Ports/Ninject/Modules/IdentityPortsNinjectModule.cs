using Ninject.Modules;
using ToDoApp.Identity.Ports.Resources;

namespace ToDoApp.Identity.Ports.Ninject.Modules
{
    /// <summary>
    /// Declares dependencies for the Identity & Access ports layer
    /// </summary>
    public class IdentityPortsNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load the dependencies
        /// </summary>
        public override void Load()
        {
            Bind<AccountController>().ToSelf().InTransientScope();
        }
    }
}
