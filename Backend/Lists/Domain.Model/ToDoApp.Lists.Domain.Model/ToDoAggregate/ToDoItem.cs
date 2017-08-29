using System;

namespace ToDoApp.Lists.Domain.Model.ToDoAggregate
{
    /// <summary>
    /// Specifies a single item in the ToDoList
    /// </summary>
    public class ToDoItem
    {
        private string _id = Guid.NewGuid().ToString();
        private string _ownerEmail;
        private string _description;

        /// <summary>
        /// Parameterless constructor, required by ORMs
        /// </summary>
        public ToDoItem()
        {
            
        }

        /// <summary>
        /// Initialize the ToDoItem with given parameters
        /// </summary>
        /// <param name="ownerEmail"></param>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <param name="priority"></param>
        public ToDoItem(string ownerEmail, string description, DateTime? dueDate, Priority priority)
        {
            _ownerEmail = ownerEmail;
            _description = description;
            this.DueDate = dueDate;
            this.Priority = priority;
        }

        /// <summary>
        /// Update this instance
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <param name="priority"></param>
        /// <param name="isCompleted"></param>
        public void Update(string description, DateTime? dueDate, Priority priority, 
            bool isCompleted)
        {
            _description = description;
            this.DueDate = dueDate;
            this.Priority = priority;
            IsCompleted = isCompleted;
        }

        /// <summary>
        /// Mark this ToDoItem as completed
        /// </summary>
        public void MarkAsCompleted()
        {
            this.IsCompleted = true;
        }

        /// <summary>
        /// Id of the ToDoList item
        /// </summary>
        public string Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        /// <summary>
        /// The email of the owner of this ToDoItem
        /// </summary>
        public string OwnerEmail { get { return _ownerEmail; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _ownerEmail = value;
                }
                else
                {
                    throw new NullReferenceException("Owner Email cannot be null or empty");
                }
            }
        }

        /// <summary>
        /// The content of the ToDoItem
        /// </summary>
        public string Description
        {
            get { return _description; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _description = value;
                }
                else
                {
                    throw new NullReferenceException("Description of the ToDo cannot be null");
                }
            }
        }

        /// <summary>
        /// Deadline for the ToDoItem
        /// </summary>
        public DateTime? DueDate
        {
            get;
            private set;
        }

        /// <summary>
        /// Priority of this ToDoItem
        /// </summary>
        public Priority Priority
        {
            get;
            private set;
        }

        /// <summary>
        /// Is this ToDoItem completed?
        /// </summary>
        public bool IsCompleted { get; private set; }
    }
}
