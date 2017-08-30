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

        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
