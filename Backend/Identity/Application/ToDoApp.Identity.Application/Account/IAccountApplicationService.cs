using ToDoApp.Identity.Application.Account.Commands;

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
    }
}
