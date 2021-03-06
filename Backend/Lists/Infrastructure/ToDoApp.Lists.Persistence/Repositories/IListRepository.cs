﻿using System.Collections.Generic;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;

namespace ToDoApp.Lists.Persistence.Repositories
{
    /// <summary>
    /// Interface for the Lists repository
    /// </summary>
    public interface IListRepository : IRepository
    {
        /// <summary>
        /// Save a ToDoItem entry
        /// </summary>
        void Save(ToDoItem toDoItem);

        /// <summary>
        /// Update a ToDoItem entry
        /// </summary>
        void Update(ToDoItem toDoItem);

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
        /// <param name="sort"></param>
        /// <returns></returns>
        IList<ToDoItem> GetAllToDoItems(string email, string[] sort = null);
    }
}
