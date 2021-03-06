﻿using System;
using System.Collections.Generic;
using ToDoApp.Lists.Application.Lists.Commands;
using ToDoApp.Lists.Application.Lists.Representations;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;
using ToDoApp.Lists.Persistence.Repositories;

namespace ToDoApp.Lists.Application.Lists
{
    /// <summary>
    /// Application Service for Lists
    /// </summary>
    public class ListApplicationService : IListApplicationService
    {
        private IListRepository _listsRepository;

        public ListApplicationService(IListRepository listsRepository)
        {
            _listsRepository = listsRepository;
        }

        /// <summary>
        /// Add the ToDoItem
        /// </summary>
        /// <param name="createCommand"></param>
        public void AddNewToDoItem(CreateNewToDoCommand createCommand)
        {
            Priority priority = (Priority) Enum.Parse(typeof(Priority), createCommand.Priority);
            // First map the Command objet to an actual domain model instance
            var toDoItem = new ToDoItem(createCommand.OwnerEmail, createCommand.Description, createCommand.DueDate,
                priority);

            // Save this instance to the database
            _listsRepository.Save(toDoItem);
            _listsRepository.Commit();
        }

        /// <summary>
        /// Update the ToDoItem
        /// </summary>
        /// <param name="updateCommand"></param>
        public void UpdateToDoItem(UpdateToDoItemCommand updateCommand)
        {
            // Convert the stirng to Priority enum
            Priority priority = (Priority)Enum.Parse(typeof(Priority), updateCommand.Priority);

            // Get the correspinding instance from the database
            var toDoItem = _listsRepository.GetDoItemById(updateCommand.Id);

            if (toDoItem == null)
            {
                throw new NullReferenceException("Could not find the ToDoItem by the given Id");
            }
            
            // Now update the values of the domain object
            toDoItem.Update(updateCommand.Description, updateCommand.DueDate, priority, updateCommand.IsCompleted);

            // Update the instance in the database
            _listsRepository.Update(toDoItem);
            // Commit the changes
            _listsRepository.Commit();
        }

        /// <summary>
        /// Delete the ToDoItem
        /// </summary>
        /// <param name="toDoItemId"></param>
        public void DeleteToDoItem(string toDoItemId)
        {
            // Get the ToDoItem by it's ID
            var toDoItem = _listsRepository.GetDoItemById(toDoItemId);

            // If we didn't find any instance, then throw an exception
            if (toDoItem == null)
            {
                throw new NullReferenceException("Could not find the ToDoItem by the given Id");
            }

            // Now delete the instance in consideration
            _listsRepository.Delete(toDoItem);
            // Now commit the transaction to the database
            _listsRepository.Commit();
        }

        /// <summary>
        /// Get all the ToDoItems by email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IList<ToDoItemRepresentation> GetToDoItemsByEmail(string email, string[] sort = null)
        {
            // Get all the ToDoItem domain objects
            var allToDoItems = _listsRepository.GetAllToDoItems(email, sort);

            // Initialize a new list that we will send to the client after doing the conversion from the Domain 
            // Objects to the representations
            IList<ToDoItemRepresentation> toDoItemRepresentations = new List<ToDoItemRepresentation>();
            // Now convert them to the corresponding representation that we can use to send to the outside world,
            // giving us the choice as to what to expose
            foreach (var toDoItem in allToDoItems)
            {
                var toDoRepresentation = ConvertToDoItemToRepresentation(toDoItem);
                toDoItemRepresentations.Add(toDoRepresentation);
            }
            return toDoItemRepresentations;
        }

        /// <summary>
        /// Get a ToDoItem by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDoItemRepresentation GetToDoItemById(string id)
        {
            var toDoItem = _listsRepository.GetDoItemById(id);
            if (toDoItem == null)
            {
                throw new NullReferenceException("No ToDoItem found with the id: " + id);
            }
            return ConvertToDoItemToRepresentation(toDoItem);
        }

        /// <summary>
        /// Converts a given ToDoItem to it's representation that can be sent to the outside world
        /// </summary>
        /// <returns></returns>
        private ToDoItemRepresentation ConvertToDoItemToRepresentation(ToDoItem toDoItem)
        {
            return new ToDoItemRepresentation(toDoItem.Id, toDoItem.OwnerEmail,
                toDoItem.Description, toDoItem.DueDate, toDoItem.Priority.ToString(), toDoItem.IsCompleted);
        }
    }
}
