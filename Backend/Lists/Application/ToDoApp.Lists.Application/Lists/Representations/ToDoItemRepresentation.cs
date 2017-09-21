using System;

namespace ToDoApp.Lists.Application.Lists.Representations
{
    /// <summary>
    /// Representation for the ToDoItem
    /// </summary>
    public class ToDoItemRepresentation
    {
        /// <summary>
        /// Initialize the ToDoItem's representation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerEmail"></param>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <param name="priority"></param>
        /// <param name="isCompleted"></param>
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
        /// Is the item completed
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
