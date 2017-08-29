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

        public string OwnerEmail { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Priority { get; set; }
    }
}
