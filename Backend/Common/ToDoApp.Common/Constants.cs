using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common
{
    /// <summary>
    /// Contains constant variables that are used across multiple Bounded Contexts
    /// </summary>
    public class Constants
    {
        public static readonly string FrontendUrl = ConfigurationManager.AppSettings.Get("FrontendUrl");
        public static readonly string DatabaseConnectionString = "MySql";
    }
}
