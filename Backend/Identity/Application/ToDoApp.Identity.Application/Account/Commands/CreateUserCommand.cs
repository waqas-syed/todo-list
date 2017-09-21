using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Identity.Application.Account.Commands
{
    /// <summary>
    /// DTO command to create a new user
    /// </summary>
    public class CreateUserCommand
    {
        public CreateUserCommand(string fullName, string email, string password, string confirmPassword)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        /// <summary>
        /// Full Name
        /// </summary>
        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation of password
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
