using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ToDoApp.Identity.Application.Account;

namespace ToDoApp.Identity.Application.Ninject.Modules
{
    /// <summary>
    /// Declares dependencies to inject for the Identity.Application layer
    /// </summary>
    public class IdentityApplicationNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load the Dependencies to inject
        /// </summary>
        public override void Load()
        {
            Bind<IAccountApplicationService>().To<AccountApplicationService>().InTransientScope();
        }
    }
}
