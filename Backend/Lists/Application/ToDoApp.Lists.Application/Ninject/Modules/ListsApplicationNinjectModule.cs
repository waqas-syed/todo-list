using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ToDoApp.Lists.Application.Lists;

namespace ToDoApp.Lists.Application.Ninject.Modules
{
    /// <summary>
    /// Ninject module for Lists.Application
    /// </summary>
    public class ListsApplicationNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load the dependencies to inject
        /// </summary>
        public override void Load()
        {
            Bind<IListApplicationService>().To<ListApplicationService>().InTransientScope();
        }
    }
}
