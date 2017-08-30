using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using ToDoApp.Identity.Application.Account.Commands;
using ToDoApp.Identity.Application.Account.Representations;
using ToDoApp.Identity.Persistence.DatabasePipeline;
using ToDoApp.Identity.Persistence.Repositories;

namespace ToDoApp.Identity.Application.Account
{
    /// <summary>
    /// Account Application Service
    /// </summary>
    public class AccountApplicationService : IAccountApplicationService
    {
        private IAccountRepository _accountRepository;

        public AccountApplicationService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="createUserCommand"></param>
        public string Register(CreateUserCommand createUserCommand)
        {
            if (!createUserCommand.Password.Equals(createUserCommand.ConfirmPassword))
            {
                throw new InvalidOperationException("Password and Confirm password are not equal");
            }
            // Register the User
            IdentityResult registrationResult = _accountRepository.RegisterUser(
                createUserCommand.FullName, 
                createUserCommand.Email,
                createUserCommand.Password);
            if (registrationResult == null)
            {
                throw new NullReferenceException("Whoa! Unexpected error happened while registering the user. Didnt expect that");
            }
            if (!registrationResult.Succeeded)
            {
                throw new InvalidOperationException(registrationResult.Errors.First());
            }
            // Get the User instance to have her Id
            var retreivedUser = _accountRepository.GetUserByEmail(createUserCommand.Email);
            // Generate the token for this user using email and user Id
            //var emailVerificationToken = _emailTokenGenerationService.GenerateEmailToken(retreivedUser.Email, retreivedUser.Id);
            var emailVerificationToken = _accountRepository.GetEmailActivationToken(retreivedUser.Id);
            if (string.IsNullOrWhiteSpace(emailVerificationToken))
            {
                throw new NullReferenceException("Could not generate token for user: " + retreivedUser.Id);
            }
            _accountRepository.ConfirmEmail(retreivedUser.Id, emailVerificationToken);
            
            return retreivedUser.Id;
        }

        /// <summary>
        /// Get a uer by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserRepresentation GetUserByEmail(string email)
        {
            CustomIdentityUser customIdentityUser = _accountRepository.GetUserByEmail(email);
            if (customIdentityUser != null)
            {
                return new UserRepresentation(customIdentityUser.FullName, customIdentityUser.Email);
            }
            throw new NullReferenceException("Could not find the user for the given email");
        }
    }
}
