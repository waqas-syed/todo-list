using System.Runtime.Serialization;

namespace ToDoApp.Identity.Application.Account.Representations
{
    /// <summary>
    /// Object to represent a user to the ourside world
    /// </summary>
    public class UserRepresentation
    {
        public UserRepresentation(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        /// <summary>
        /// Name of the user
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>
        [DataMember]
        public string Email { get; set; }
    }
}
