using Microsoft.AspNet.Identity;

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
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="isExternalUser"></param>
        /// <returns></returns>
        IdentityResult RegisterUser(string name, string email, string password, bool isExternalUser = false);
    }
}
