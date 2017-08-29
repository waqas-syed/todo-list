using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToDoApp.Identity.Persistence.Repositories
{
    /// <summary>
    /// Account repository's interface
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Registers a user and returns a tuple with the following two items:
        /// IdentityResult : EmailConfirmationToken
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IdentityResult RegisterUser(string email, string password);

        /// <summary>
        /// Confirm Email
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ConfirmEmail(string userId, string token);
        
        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IdentityUser GetUserByEmail(string email);

        /// <summary>
        /// Get the token which this user must submit to activate their account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetEmailActivationToken(string userId);
    }
}
