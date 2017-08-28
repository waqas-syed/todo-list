using System;

namespace ToDoApp.Lists.Domain.Model.ToDoAggregate
{
    /// <summary>
    /// Specifies a single item in the ToDoList
    /// </summary>
    public class ToDoItem
    {
        private string _id;
        private string _ownerEmail;
        private string _description;
        private DateTime? _dueDate;
        private Priority _priority;

        /// <summary>
        /// Initialize the ToDoItem with given parameters
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <param name="priority"></param>
        public ToDoItem(string description, DateTime dueDate, Priority priority)
        {
            _description = description;
            _dueDate = dueDate;
            _priority = priority;
        }

        /// <summary>
        /// Id of the ToDoList item
        /// </summary>
        public string Id
        {
            get { return _id; }
        }

        /// <summary>
        /// The email of the owner of this ToDoItem
        /// </summary>
        public string OwnerEmail { get { return _ownerEmail; } private set { _ownerEmail = value; } }

        /// <summary>
        /// The content of the ToDoItem
        /// </summary>
        public string Description { get { return _description; }
            private set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Deadline for the ToDoItem
        /// </summary>
        public DateTime? DueDate { get { return _dueDate; } private set { _dueDate = value; } }

        /// <summary>
        /// Priority of this ToDoItem
        /// </summary>
        public Priority Priority { get { return _priority; } private set { _priority = value; } }
    }
}
