﻿using System.Collections.Generic;
using ToDoApp.Lists.Application.Lists.Commands;
using ToDoApp.Lists.Application.Lists.Representations;

namespace ToDoApp.Lists.Application.Lists
{
    /// <summary>
    /// List Application Service
    /// </summary>
    public interface IListApplicationService
    {
        /// <summary>
        /// Add new to do item
        /// </summary>
        /// <param name="createCommand"></param>
        void AddNewToDoItem(CreateNewToDoCommand createCommand);

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="updateCommand"></param>
        void UpdateToDoItem(UpdateToDoItemCommand updateCommand);

        /// <summary>
        /// Delete the ToDoitem with the given ID
        /// </summary>
        /// <param name="toDoItemId"></param>
        void DeleteToDoItem(string toDoItemId);

        /// <summary>
        /// Get all ToDos for the given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<ToDoItemRepresentation> GetToDoItemsByEmail(string email, string[] sort = null);

        /// <summary>
        /// Get a ToDoItem by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ToDoItemRepresentation GetToDoItemById(string id);
    }
}
