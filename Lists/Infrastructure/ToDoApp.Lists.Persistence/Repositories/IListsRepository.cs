using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;

namespace ToDoApp.Lists.Persistence.Repositories
{
    /// <summary>
    /// Interface for the Lists repository
    /// </summary>
    public interface IListsRepository
    {
        /// <summary>
        /// Save or update a ToDoItem entry
        /// </summary>
        void SaveorUpdate(ToDoItem toDoItem);

        /// <summary>
        /// Delete the Id of the ToDoItem with the given ID
        /// </summary>
        /// <param name="toDoItemId"></param>
        void Delete(string toDoItemId);

        /// <summary>
        /// Get all of the ToDoItems associated with the given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<ToDoItem> GetAllToDoItems(string email);
    }
}
