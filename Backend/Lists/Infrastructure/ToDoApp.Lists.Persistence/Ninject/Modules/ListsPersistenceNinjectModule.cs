using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject.Web.Common;
using ToDoApp.Lists.Persistence.DatabasePipeline;
using ToDoApp.Lists.Persistence.Repositories;

namespace ToDoApp.Lists.Persistence.Ninject.Modules
{
    /// <summary>
    /// Lists.Application Ninject module
    /// </summary>
    public class ListsPersistenceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ListsContext>().ToSelf().InRequestScope();
            Bind<IListRepository>().To<ListRepository>().InTransientScope();
        }
    }
}
