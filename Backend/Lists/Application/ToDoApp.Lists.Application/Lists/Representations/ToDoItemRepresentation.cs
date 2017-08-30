using System;

namespace ToDoApp.Lists.Application.Lists.Representations
{
    /// <summary>
    /// Representation for the ToDoItem
    /// </summary>
    public class ToDoItemRepresentation
    {
        public ToDoItemRepresentation(string id, string ownerEmail, string description, 
            DateTime? dueDate, string priority, bool isCompleted)
        {
            Id = id;
            OwnerEmail = ownerEmail;
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
