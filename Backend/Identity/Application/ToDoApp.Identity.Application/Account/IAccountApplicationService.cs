using ToDoApp.Identity.Application.Account.Commands;
using ToDoApp.Identity.Application.Account.Representations;

namespace ToDoApp.Identity.Application.Account
{
    /// <summary>
    /// Interface for Application Service
    /// </summary>
    public interface IAccountApplicationService
    {
        /// <summary>
        /// Register User Command
        /// </summary>
        /// <param name="createUserCommand"></param>
        string Register(CreateUserCommand createUserCommand);

        /// <summary>
        /// Get the user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        UserRepresentation GetUserByEmail(string email);
    }
}
