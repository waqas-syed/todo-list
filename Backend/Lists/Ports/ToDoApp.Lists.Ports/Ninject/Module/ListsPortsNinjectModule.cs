using Ninject.Modules;
using Ninject.Web.Common;
using ToDoApp.Lists.Ports.Resources;

namespace ToDoApp.Lists.Ports.Ninject.Module
{
    /// <summary>
    /// Ninject Module for the Lists.Ports Project
    /// </summary>
    public class ListsPortsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ListsController>().ToSelf().InTransientScope();
        }
    }
}
