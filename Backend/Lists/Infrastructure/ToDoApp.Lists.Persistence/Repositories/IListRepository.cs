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
    public interface IListRepository : IRepository
    {
        /// <summary>
        /// Save or update a ToDoItem entry
        /// </summary>
        void SaveorUpdate(ToDoItem toDoItem);

        /// <summary>
        /// Delete the Id of the ToDoItem with the given ID
        /// </summary>
        /// <param name="toDoItem"></param>
        void Delete(ToDoItem toDoItem);

        /// <summary>
        /// Get the ToDoItem by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ToDoItem GetDoItemById(string id);

        /// <summary>
        /// Get all of the ToDoItems associated with the given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<ToDoItem> GetAllToDoItems(string email);
    }
}
