using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToDoApp.Identity.Persistence.DatabasePipeline
{
    /// <summary>
    /// Customer UserStore, that will be used by the UserManager
    /// </summary>
    public class CustomUserStore : UserStore<CustomIdentityUser>
    {
        public CustomUserStore(AuthContext authContext) : base(authContext)
        {
            
        }
    }
}
