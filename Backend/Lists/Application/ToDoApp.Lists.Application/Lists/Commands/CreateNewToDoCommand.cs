using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Lists.Application.Lists.Commands
{
    /// <summary>
    /// Acts as a data transfer object when creating a new ToDoItem
    /// </summary>
    public class CreateNewToDoCommand
    {
        public CreateNewToDoCommand(string ownerEmail, string description, DateTime? dueDate, string priority)
        {
            OwnerEmail = ownerEmail;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        /// <summary>
        /// Owner Email
        /// </summary>
        public string OwnerEmail { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Due Date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        public string Priority { get; set; }
    }
}
