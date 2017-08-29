using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToDoApp.Identity.Persistence.Repositories
{
    /// <summary>
    /// Handles database operations related to Identity & access
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Initialize with a UserManager instance
        /// </summary>
        /// <param name="userManager"></param>
        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="isExternalUser"></param>
        /// <returns></returns>
        public IdentityResult RegisterUser(string name, string email, string password, bool isExternalUser = false)
        {
            // Assign email to the uername property, as we will use email in place of username
            IdentityUser user = new IdentityUser
            {
                UserName = email,
                Email = email
            };
            IdentityResult result;
            if (!isExternalUser)
            {
                result = _userManager.Create(user, password);
            }
            else
            {
                result = _userManager.Create(user);
            }

            return result;
        }
    }
}
