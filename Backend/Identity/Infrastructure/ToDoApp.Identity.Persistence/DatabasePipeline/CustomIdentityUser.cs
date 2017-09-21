using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToDoApp.Identity.Persistence.DatabasePipeline
{
    /// <summary>
    /// Custom Implementation for the Identity's user
    /// </summary>
    public class CustomIdentityUser : IdentityUser
    {
        /// <summary>
        /// Full Name
        /// </summary>
        public string FullName { get; set; }
    }
}
