using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using ToDoApp.Identity.Persistence.DatabasePipeline;

namespace ToDoApp.Identity.Persistence.Repositories
{
    /// <summary>
    /// Handles database operations related to Identity & access
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private UserManager<CustomIdentityUser> _userManager;

        /// <summary>
        /// Initialize with a UserManager instance
        /// </summary>
        /// <param name="userManager"></param>
        public AccountRepository(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
            var provider = new DpapiDataProtectionProvider("ToDoApp");
            
            userManager.UserTokenProvider = new DataProtectorTokenProvider<CustomIdentityUser>(
                provider.Create("EmailConfirmation"));
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IdentityResult RegisterUser(string fullName, string email, string password)
        {
            // Assign email to the uername property, as we will use email in place of username
            CustomIdentityUser user = new CustomIdentityUser
            {
                FullName = fullName,
                UserName = email,
                Email = email
            };
            IdentityResult result;
            result = _userManager.Create(user, password);

            return result;
        }

        /// <summary>
        /// Confirm the given email as verified
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ConfirmEmail(string userId, string token)
        {
            var identityResult = _userManager.ConfirmEmail(userId, token);
            if (identityResult.Succeeded)
            {
                return true;
            }
            throw new ArgumentException($"Could not confirm user email. UserId: {userId}");
        }

        /// <summary>
        /// Get a user by the email with which they registered
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public CustomIdentityUser GetUserByEmail(string email)
        {
            return _userManager.FindByEmail(email);
        }

        /// <summary>
        /// Gets a user by the email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CustomIdentityUser GetUserByPassword(string email, string password)
        {
            return _userManager.Find(email, password);
        }

        /// <summary>
        /// Get the token which this user must submit to activate their account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetEmailActivationToken(string userId)
        {
            return _userManager.GenerateEmailConfirmationToken(userId);
        }
    }
}
