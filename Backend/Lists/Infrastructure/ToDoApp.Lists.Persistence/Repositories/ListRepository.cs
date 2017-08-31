using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;
using ToDoApp.Lists.Persistence.DatabasePipeline;

namespace ToDoApp.Lists.Persistence.Repositories
{
    /// <summary>
    /// Repository for performing operations on Lists
    /// </summary>
    public class ListRepository : IListRepository, IDisposable
    {
        private ListsContext _listsContext;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ListRepository(ListsContext listsContext)
        {
            _listsContext = listsContext;
        }

        /// <summary>
        /// Saves the given
        /// </summary>
        /// <param name="toDoItem"></param>
        public void Save(ToDoItem toDoItem)
        {
            try
            {
                _listsContext.ToDoItems.Add(toDoItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(ToDoItem toDoItem)
        {
            _listsContext.ToDoItems.Attach(toDoItem);
            _listsContext.Entry(toDoItem).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the instance
        /// </summary>
        /// <param name="toDoItem"></param>
        public void Delete(ToDoItem toDoItem)
        {
            _listsContext.ToDoItems.Remove(toDoItem);
        }

        /// <summary>
        /// Get a ToDoItem by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDoItem GetDoItemById(string id)
        {
            return _listsContext.ToDoItems.Find(id);
        }

        /// <summary>
        /// Gets all the ToDoItems using the email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IList<ToDoItem> GetAllToDoItems(string email, string[] sort = null)
        {
            IQueryable<ToDoItem> queryable = _listsContext.ToDoItems;

            // Add the sorting
            if (sort != null && sort.Length > 0)
                queryable = queryable.ApplySorting(sort);
            else
                queryable = queryable.OrderBy(c => c.Id);

            return queryable.Where(x => x.OwnerEmail == email).ToList();
        }
        
        /// <summary>
        /// Disposes the resources
        /// </summary>
        public void Dispose()
        {
            _listsContext?.Dispose();
        }

        /// <summary>
        /// Commit the changes to the database
        /// </summary>
        public void Commit()
        {
            _listsContext.SaveChanges();
        }
    }

    public static class QuerySortingExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IEnumerable<string> sort) where T : class
        {
            if (sort != null)
            {
                List<string> sortFields = new List<string>();

                foreach (string sortField in sort)
                {
                    string direction = null;
                    string fieldName = null;

                    if (sortField.StartsWith("+"))
                    {
                        sortFields.Add(string.Format("{0} ASC", sortField.TrimStart('+')));
                    }
                    else if (sortField.StartsWith("-"))
                    {
                        sortFields.Add(string.Format("{0} DESC", sortField.TrimStart('-')));
                    }
                    else
                    {
                        sortFields.Add(sortField);
                    }
                }

                return query.OrderBy(string.Join(",", sortFields));
            }

            return query;
        }
    }
}
