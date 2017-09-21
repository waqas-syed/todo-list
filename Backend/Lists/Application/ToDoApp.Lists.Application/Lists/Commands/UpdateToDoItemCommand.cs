using System;

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

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

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

        /// <summary>
        /// Is the to do item completed
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
