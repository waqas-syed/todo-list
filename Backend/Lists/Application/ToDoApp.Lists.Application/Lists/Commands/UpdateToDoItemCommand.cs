using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Lists.Application.Lists.Commands
{
    /// <summary>
    /// Acts as a DTO for handling the modify request for a ToDoItem
    /// </summary>
    public class UpdateToDoItemCommand
    {
        public UpdateToDoItemCommand(string id, string description, DateTime? dueDate, string priority,
            bool isCompleted)
        {
            Id = id;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            IsCompleted = isCompleted;
        }

        public string Id { get; set; }

        public string OwnerEmail { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Priority { get; set; }

        public bool IsCompleted { get; set; }
    }
}
