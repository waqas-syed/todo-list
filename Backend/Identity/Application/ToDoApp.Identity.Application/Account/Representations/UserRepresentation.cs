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

        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
