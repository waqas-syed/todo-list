using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common;

namespace ToDoApp.Identity.Persistence.DatabasePipeline
{
    /// <summary>
    /// DbContext for the Identity & Access Bounded Context
    /// </summary>
    public class AuthContext : DbContext
    {
        public AuthContext() : base(Constants.DatabaseConnectionString)
        {
            
        }
    }
}
